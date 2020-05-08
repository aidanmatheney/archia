﻿namespace Archia.WinForms
{
    using System;

    using Microsoft.Extensions.DependencyInjection;

    public sealed class ArchiaServiceScope : IServiceScope
    {
        private readonly IServiceScope _scope;

        public ArchiaServiceScope(IServiceScope scope)
        {
            _scope = scope;
            ServiceProvider = new ArchiaServiceProvider(_scope.ServiceProvider);
        }

        public ArchiaServiceProvider ServiceProvider { get; }
        IServiceProvider IServiceScope.ServiceProvider => ServiceProvider;

        public void Dispose() => _scope.Dispose();
    }
}