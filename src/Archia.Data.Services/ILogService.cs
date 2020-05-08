namespace Archia.Data.Services
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Entities;

    public interface ILogService
    {
        Task<IEnumerable<LogEntry>> GetAllEntriesAsync(CancellationToken cancellationToken = default);
        Task<LogEntry?> FindEntryByIdAsync(int id, CancellationToken cancellationToken = default);
        Task InsertEntriesAsync(IEnumerable<LogEntry> entries, CancellationToken cancellationToken = default);
        Task DeleteEntryAsync(LogEntry entry, CancellationToken cancellationToken = default);
    }
}
