namespace Archia.WebApi
{
    using System;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    using Archia.Data.Migrations;

    internal static class Program
    {
        private const string ConnectionStringEnvironmentVariableName = "ARCHIA_WEBAPI_CONNECTIONSTRING";

        private static void Main(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariableName);
            if (connectionString is null)
                throw new InvalidOperationException($"{ConnectionStringEnvironmentVariableName} environment variable is not set");
            var migrator = new Migrator(connectionString);
            if (migrator.IsUpgradeRequired())
                throw new InvalidOperationException("The database requires upgrades. Run Archia.Data.Migrations to execute the new change scripts.");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}