namespace Archia.WebApi
{
    using System;
    using System.Data;
    using System.IO;
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    using MySql.Data.MySqlClient;

    using Archia.Data.Services;
    using Archia.Utils;

    internal sealed class Startup
    {
        private const string DevelopmentCorsPolicyName = "DevelopmentCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            ThrowIf.Null(configuration, nameof(configuration));

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(DevelopmentCorsPolicyName, policy => policy.WithOrigins("http://localhost:3000"));
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Archia Web API",
                    Version = "v1"
                });

                var docFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var docFilePath = Path.Combine(AppContext.BaseDirectory, docFileName);
                options.IncludeXmlComments(docFilePath);
            });

            var connectionString = Environment.GetEnvironmentVariable("ARCHIA_WEBAPI_CONNECTIONSTRING");
            if (connectionString is null)
                throw new InvalidOperationException("ARCHIA_WEBAPI_CONNECTIONSTRING environment variable is not set");
            services.AddScoped<IDbConnection>(serviceProvider => new MySqlConnection(connectionString));

            services.AddScoped<IPatientService, PatientService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(DevelopmentCorsPolicyName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api-docs/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api-docs/v1/swagger.json", "Archia Web API V1");
                options.RoutePrefix = "api-docs";
            });
        }
    }
}