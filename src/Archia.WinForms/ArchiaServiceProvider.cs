﻿namespace Archia.WinForms
{
    using System;

    using Archia.Data.Services;
    using Archia.Entities;
    using Archia.Utils;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    using MySql.Data.MySqlClient;

    public sealed class ArchiaServiceProvider : IServiceProvider
    {
        private readonly IServiceProvider _services;

        public ArchiaServiceProvider(IServiceProvider services)
        {
            ThrowIf.Null(services, nameof(services));

            _services = services;
        }

        public IHostApplicationLifetime AppLifetime => Get<IHostApplicationLifetime>();

        public MySqlConnection DbConnection => Get<MySqlConnection>();

        public IAppUserService UserService => Get<IAppUserService>();
        public IAppRoleService RoleService => Get<IAppRoleService>();

        public IPatientService PatientService => Get<IPatientService>();

        public ILogService LogService => Get<ILogService>();

        public UserManager<AppUser> UserManager => Get<UserManager<AppUser>>();
        public RoleManager<AppRole> RoleManager => Get<RoleManager<AppRole>>();
        public SignInManager<AppUser> SignInManager => Get<SignInManager<AppUser>>();

        public ILogger Logger<TCategoryName>() => Get<ILogger<TCategoryName>>();
        public ILogger Logger(object category)
        {
            ThrowIf.Null(category, nameof(category));

            var loggerType = typeof(ILogger<>).MakeGenericType(category.GetType());
            var logger = (ILogger)Get(loggerType);
            return logger;
        }

        public ArchiaUserContext UserContext => Get<ArchiaUserContext>();

        public DbSeeder DbSeeder => Get<DbSeeder>();

        public object GetService(Type serviceType) => _services.GetService(serviceType);
        public ArchiaServiceScope CreateScope() => new ArchiaServiceScope(_services.CreateScope());

        private T Get<T>() => _services.GetRequiredService<T>();
        private object Get(Type serviceType) => _services.GetRequiredService(serviceType);
    }
}