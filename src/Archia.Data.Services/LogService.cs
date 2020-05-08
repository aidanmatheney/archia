namespace Archia.Data.Services
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using MySql.Data.MySqlClient;

    using Archia.Data.Naming;
    using Archia.Entities;
    using Archia.Utils;

    public sealed class LogService : DbServiceBase, ILogService
    {
        public LogService(MySqlConnection dbConnection, ILogger<LogService> logger) : base(dbConnection, logger) { }

        public async Task<IEnumerable<LogEntry>> GetAllEntriesAsync(CancellationToken cancellationToken = default)
        {
            return await QueryAsync<LogEntry>
            (
                $@"
SELECT
    Id,
    TimeWritten

    FROM {DbTable.LogEntry}
    ORDER BY TimeWritten DESC
;
                ",
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task<LogEntry?> FindEntryByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await QuerySingleOrDefaultAsync<LogEntry>
            (
                $@"
SELECT
    Id,
    TimeWritten

    FROM {DbTable.LogEntry}
    WHERE Id = @id
;
                ",
                new { id },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task InsertEntriesAsync(IEnumerable<LogEntry> entries, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(entries, nameof(entries));

            await using var entriesTable = await TempTableAsync(entries, table =>
            {
                table.Column("TimeWritten", "datetime NOT NULL", entry => entry.TimeWritten.DateTime);
                table.Column("ServerName", "varchar(64) NOT NULL", entry => entry.ServerName);
                table.Column("Category", "varchar(256) NOT NULL", entry => entry.Category);
                table.Column("Scope", "longtext NULL", entry => entry.Scope);
                table.Column("LogLevel", "varchar(11) NOT NULL", entry => entry.LogLevel);
                table.Column("EventId", "int NOT NULL", entry => entry.EventId);
                table.Column("EventName", "varchar(64) NULL", entry => entry.EventName);
                table.Column("Message", "longtext NOT NULL", entry => entry.Message);
                table.Column("Exception", "longtext NULL", entry => entry.Exception);
            }, cancellationToken).ConfigureAwait(false);

            await ExecuteAsync
            (
                $@"
INSERT INTO {DbTable.LogEntry}(
    TimeWritten,
    ServerName,
    Category,
    Scope,
    LogLevel,
    EventId,
    EventName,
    Message,
    Exception
) SELECT
    TimeWritten,
    ServerName,
    Category,
    Scope,
    LogLevel,
    EventId,
    EventName,
    Message,
    Exception

    FROM {entriesTable.Name}
;
                ",
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task DeleteEntryAsync(LogEntry entry, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(entry, nameof(entry));

            await ExecuteAsync
            (
                $@"
DELETE
    FROM {DbTable.LogEntry}
    WHERE Id = @id
;
                ",
                new { id = entry.Id },
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}
