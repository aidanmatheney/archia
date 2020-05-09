namespace Archia.WinForms
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using Archia.Data.Services;
    using Archia.Entities;
    using Archia.Services;
    using Archia.Utils;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    using MySql.Data.MySqlClient;

    public sealed class ArchiaAppContext : ApplicationContext
    {
        private const string ConnectionStringEnvironmentVariableName = "ARCHIA_WEBAPI_CONNECTIONSTRING";

        public ArchiaAppContext(string[] args)
        {
            ThrowIf.Null(args, nameof(args));

            _ = RunAsync(args);
        }

        private async Task RunAsync(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder.ConfigureServices(ConfigureServices);
            hostBuilder.ConfigureLogging(ConfigureLogging);

            var host = hostBuilder.Build();

            await host.RunAsync().ConfigureAwait(false);
            ExitThread();
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddHostedService<ArchiaAppService>();

            services.AddScoped(serviceProvider => new ArchiaServiceProvider(serviceProvider));

            services
                .AddIdentityCore<AppUser>(options =>
                {
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;

                    options.Password.RequiredLength = 8;
                    options.Password.RequiredUniqueChars = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;

                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.SignIn.RequireConfirmedAccount = false;

                    options.Stores.MaxLengthForKeys = 128;
                    options.Stores.ProtectPersonalData = false; // TODO: Investigate whether this should be enabled
                })
                .AddRoles<AppRole>()
                .AddUserStore<AppUserStore>()
                .AddRoleStore<AppRoleStore>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.AddLogging();

            var baseConnectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariableName);
            if (baseConnectionString is null)
                throw new InvalidOperationException($"{ConnectionStringEnvironmentVariableName} environment variable is not set");

            var connectionString = new MySqlConnectionStringBuilder(baseConnectionString)
            {
                AllowUserVariables = true,
                AllowLoadLocalInfile = true
            };

            services.AddScoped(serviceProvider => new MySqlConnection(connectionString.ToString()));
            services.AddScoped<IDbConnection>(serviceProvider => serviceProvider.GetRequiredService<MySqlConnection>());

            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppRoleService, AppRoleService>();

            services.AddScoped<IPatientService, PatientService>();

            services.AddScoped<ILogService, LogService>();

            services.AddSingleton<ArchiaUserContext>();
        }

        public static void ConfigureLogging(HostBuilderContext context, ILoggingBuilder loggingBuilder)
        {
            var services = loggingBuilder.Services;

            services.AddSingleton<ILoggerProvider>(serviceProvider =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var settings = configuration.GetSection("Logging:Database").Get<BatchLoggerSettings>();

                return new DbLoggerProvider(settings, serviceProvider);
            });
        }
    }
}