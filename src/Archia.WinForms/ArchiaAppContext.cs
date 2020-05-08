namespace Archia.WinForms
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using Archia.Data.Services;
    using Microsoft.Extensions.DependencyInjection;

    using MySql.Data.MySqlClient;

    public sealed class ArchiaAppContext : ApplicationContext
    {
        private const string ConnectionStringEnvironmentVariableName = "ARCHIA_WEBAPI_CONNECTIONSTRING";

        public ArchiaAppContext()
        {
            var services = CreateServiceProvider();

            var signInForm = new SignInForm(services);
            signInForm.FormClosed += HandleSignInFormClosed;

            signInForm.Show();
        }

        private void HandleSignInFormClosed(object sender, FormClosedEventArgs e)
        {
            ExitThread();
        }

        private static ArchiaServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            var baseConnectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariableName);
            if (baseConnectionString is null)
                throw new InvalidOperationException($"{ConnectionStringEnvironmentVariableName} environment variable is not set");

            var connectionString = new MySqlConnectionStringBuilder(baseConnectionString)
            {
                AllowUserVariables = true,
                AllowLoadLocalInfile = true
            };

            services.AddLogging();

            services.AddScoped(serviceProvider => new MySqlConnection(connectionString.ToString()));
            services.AddScoped<IDbConnection>(serviceProvider => serviceProvider.GetRequiredService<MySqlConnection>());

            services.AddScoped<IPatientService, PatientService>();

            return new ArchiaServiceProvider(services.BuildServiceProvider());
        }
    }
}