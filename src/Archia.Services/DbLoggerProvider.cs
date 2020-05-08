namespace Archia.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;

    using Archia.Data.Services;
    using Archia.Entities;
    using Archia.Utils;

    public sealed class DbLoggerProvider : BatchLoggerProviderBase
    {
        public DbLoggerProvider
        (
            BatchLoggerSettings settings,
            IServiceProvider serviceProvider
        ) : base
        (
            settings?.FlushInterval ?? throw new ArgumentNullException(nameof(settings)),
            settings?.LogLevel ?? throw new ArgumentNullException(nameof(settings)),
            serviceProvider
        ) { }

        protected override async Task ExecuteAsync(IEnumerable<LogEntry> entries, IServiceProvider scopedServiceProvider)
        {
            ThrowIf.Null(entries, nameof(entries));
            ThrowIf.Null(scopedServiceProvider, nameof(scopedServiceProvider));

            var logService = scopedServiceProvider.GetRequiredService<ILogService>();
            await logService.InsertEntriesAsync(entries).ConfigureAwait(false);
        }
    }
}
