namespace Archia.Data.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Data.Naming;
    using Archia.Entities;
    using Archia.Utils;

    using Microsoft.Extensions.Logging;

    using MySql.Data.MySqlClient;

    public sealed class AppRoleService : DbServiceBase, IAppRoleService
    {
        public AppRoleService(MySqlConnection dbConnection, ILogger<AppRoleService> logger) : base(dbConnection, logger) { }

        public async Task<AppRole?> FindRoleByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await QuerySingleOrDefaultAsync<AppRole?>
            (
                $@"
SELECT
    Id,
    Name,
    NormalizedName,
    ConcurrencyStamp

    FROM {DbTable.Role}

    WHERE Id = @id
;
                ",
                new { id },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task<AppRole?> FindRoleByNameAsync(string normalizedName, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(normalizedName, nameof(normalizedName));

            return await QuerySingleOrDefaultAsync<AppRole?>
            (
                $@"
SELECT
    Id,
    Name,
    NormalizedName,
    ConcurrencyStamp

    FROM {DbTable.Role}

    WHERE NormalizedName = @normalizedName
;
                ",
                new { normalizedName },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task CreateRoleAsync(AppRole role, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));

            await ExecuteAsync
            (
                $@"
INSERT INTO {DbTable.Role}(
    Id,
    Name,
    NormalizedName,
    ConcurrencyStamp
) SELECT
    @id,
    @name,
    @normalizedName,
    @concurrencyStamp
;
                ",
                new
                {
                    id = role.Id,
                    name = role.Name,
                    normalizedName = role.NormalizedName,
                    concurrencyStamp = role.ConcurrencyStamp
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task UpdateRoleAsync(AppRole role, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));

            await ExecuteAsync
            (
                $@"
UPDATE {DbTable.Role} SET
    Name = @name,
    NormalizedName = @normalizedName,
    ConcurrencyStamp = @concurrencyStamp

    WHERE Id = @id
;
                ",
                new
                {
                    id = role.Id,
                    name = role.Name,
                    normalizedName = role.NormalizedName,
                    concurrencyStamp = role.ConcurrencyStamp
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task DeleteRoleAsync(AppRole role, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));

            await ExecuteAsync
            (
                $@"
DELETE
    FROM {DbTable.Role}
    WHERE Id = @id
;
                ",
                new { id = role.Id },
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}