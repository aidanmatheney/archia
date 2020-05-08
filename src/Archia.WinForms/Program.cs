namespace Archia.WinForms
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    using Archia.Data.Migrations;

    using MySql.Data.MySqlClient;

    internal static class Program
    {
        private const string ConnectionStringEnvironmentVariableName = "ARCHIA_WEBAPI_CONNECTIONSTRING";

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Debug.Assert(!(args is null));

            CheckForMigrations();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ArchiaAppContext(args));
        }

        private static void CheckForMigrations()
        {
            var baseConnectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariableName);
            if (baseConnectionString is null)
                throw new InvalidOperationException($"{ConnectionStringEnvironmentVariableName} environment variable is not set");

            var connectionString = new MySqlConnectionStringBuilder(baseConnectionString)
            {
                AllowUserVariables = true
            };

            var migrator = new Migrator(connectionString.ToString());
            if (migrator.IsUpgradeRequired())
                throw new InvalidOperationException("The database requires upgrades. Run Archia.Data.Migrations to execute the new change scripts.");
        }
    }
}