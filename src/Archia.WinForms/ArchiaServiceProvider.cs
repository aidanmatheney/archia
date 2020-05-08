namespace Archia.WinForms
{
    using System;

    using Archia.Data.Services;
    using Archia.Utils;

    using Microsoft.Extensions.DependencyInjection;

    using MySql.Data.MySqlClient;

    public sealed class ArchiaServiceProvider : IServiceProvider
    {
        private readonly IServiceProvider _services;

        public ArchiaServiceProvider(IServiceProvider services)
        {
            ThrowIf.Null(services, nameof(services));

            _services = services;
        }

        public MySqlConnection DbConnection => Get<MySqlConnection>();
        public IPatientService PatientService => Get<IPatientService>();

        public object GetService(Type serviceType) => _services.GetService(serviceType);
        public ArchiaServiceScope CreateScope() => new ArchiaServiceScope(_services.CreateScope());

        private T Get<T>() => _services.GetRequiredService<T>();
    }
}