namespace Archia.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using MySql.Data.MySqlClient;

    using Archia.Data.Naming;
    using Archia.Entities;
    using Archia.Utils;

    public sealed class AppUserService : DbServiceBase, IAppUserService
    {
        public AppUserService(MySqlConnection dbConnection, ILogger<AppUserService> logger) : base(dbConnection, logger) { }

        #region IUserStore

        public async Task<AppUser?> FindUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await QuerySingleOrDefaultAsync<AppUser?>
            (
                $@"
SELECT
    Id,
    UserName,
    NormalizedUserName,
    Email,
    NormalizedEmail,
    EmailConfirmed,
    PasswordHash,
    SecurityStamp,
    ConcurrencyStamp,
    PhoneNumber,
    PhoneNumberConfirmed,
    TwoFactorEnabled,
    LockoutEnd,
    LockoutEnabled,
    AccessFailedCount,
    AuthenticatorKey

    FROM {DbTable.User}
    WHERE Id = @id
;
                ",
                new { id },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task<AppUser?> FindUserByUserNameAsync(string normalizedUserName, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(normalizedUserName, nameof(normalizedUserName));

            return await QuerySingleOrDefaultAsync<AppUser?>
            (
                $@"
SELECT
    Id,
    UserName,
    NormalizedUserName,
    Email,
    NormalizedEmail,
    EmailConfirmed,
    PasswordHash,
    SecurityStamp,
    ConcurrencyStamp,
    PhoneNumber,
    PhoneNumberConfirmed,
    TwoFactorEnabled,
    LockoutEnd,
    LockoutEnabled,
    AccessFailedCount,
    AuthenticatorKey

    FROM {DbTable.User}
    WHERE NormalizedUserName = @normalizedUserName
;
                ",
                new { normalizedUserName },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task CreateUserAsync(AppUser user, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(user, nameof(user));

            await ExecuteAsync
            (
                $@"
INSERT INTO {DbTable.User}(
    Id,
    UserName,
    NormalizedUserName,
    Email,
    NormalizedEmail,
    EmailConfirmed,
    PasswordHash,
    SecurityStamp,
    ConcurrencyStamp,
    PhoneNumber,
    PhoneNumberConfirmed,
    TwoFactorEnabled,
    LockoutEnd,
    LockoutEnabled,
    AccessFailedCount,
    AuthenticatorKey
) SELECT
    @id,
    @userName,
    @normalizedUserName,
    @email,
    @normalizedEmail,
    @emailConfirmed,
    @passwordHash,
    @securityStamp,
    @concurrencyStamp,
    @phoneNumber,
    @phoneNumberConfirmed,
    @twoFactorEnabled,
    @lockoutEnd,
    @lockoutEnabled,
    @accessFailedCount,
    @authenticatorKey
;
                ",
                new
                {
                    id = user.Id,
                    userName = user.UserName,
                    normalizedUserName = user.NormalizedUserName,
                    email = user.Email,
                    normalizedEmail = user.NormalizedEmail,
                    emailConfirmed = user.EmailConfirmed,
                    passwordHash = user.PasswordHash,
                    securityStamp = user.SecurityStamp,
                    concurrencyStamp = user.ConcurrencyStamp,
                    phoneNumber = user.PhoneNumber,
                    phoneNumberConfirmed = user.PhoneNumberConfirmed,
                    twoFactorEnabled = user.TwoFactorEnabled,
                    lockoutEnd = user.LockoutEnd,
                    lockoutEnabled = user.LockoutEnabled,
                    accessFailedCount = user.AccessFailedCount,
                    authenticatorKey = user.AuthenticatorKey
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task UpdateUserAsync(AppUser user, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(user, nameof(user));

            await ExecuteAsync
            (
                $@"
UPDATE {DbTable.User} SET
    UserName = @userName,
    NormalizedUserName = @normalizedUserName,
    Email = @email,
    NormalizedEmail = @normalizedEmail,
    EmailConfirmed = @emailConfirmed,
    PasswordHash = @passwordHash,
    SecurityStamp = @securityStamp,
    ConcurrencyStamp = @concurrencyStamp,
    PhoneNumber = @phoneNumber,
    PhoneNumberConfirmed = @phoneNumberConfirmed,
    TwoFactorEnabled = @twoFactorEnabled,
    LockoutEnd = @lockoutEnd,
    LockoutEnabled = @lockoutEnabled,
    AccessFailedCount = @accessFailedCount,
    AuthenticatorKey = @authenticatorKey

    WHERE Id = @id
;
                ",
                new
                {
                    id = user.Id,
                    userName = user.UserName,
                    normalizedUserName = user.NormalizedUserName,
                    email = user.Email,
                    normalizedEmail = user.NormalizedEmail,
                    emailConfirmed = user.EmailConfirmed,
                    passwordHash = user.PasswordHash,
                    securityStamp = user.SecurityStamp,
                    concurrencyStamp = user.ConcurrencyStamp,
                    phoneNumber = user.PhoneNumber,
                    phoneNumberConfirmed = user.PhoneNumberConfirmed,
                    twoFactorEnabled = user.TwoFactorEnabled,
                    lockoutEnd = user.LockoutEnd,
                    lockoutEnabled = user.LockoutEnabled,
                    accessFailedCount = user.AccessFailedCount,
                    authenticatorKey = user.AuthenticatorKey
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task DeleteUserAsync(AppUser user, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(user, nameof(user));

            await ExecuteAsync
            (
                $@"
DELETE
    FROM {DbTable.User}
    WHERE Id = @id
;
                ",
                new { id = user.Id },
                cancellationToken
            ).ConfigureAwait(false);
        }

        #endregion

        #region IUserEmailStore

        public async Task<AppUser?> FindUserByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(normalizedEmail, nameof(normalizedEmail));

            return await QuerySingleOrDefaultAsync<AppUser?>
            (
                $@"
SELECT
    Id,
    UserName,
    NormalizedUserName,
    Email,
    NormalizedEmail,
    EmailConfirmed,
    PasswordHash,
    SecurityStamp,
    ConcurrencyStamp,
    PhoneNumber,
    PhoneNumberConfirmed,
    TwoFactorEnabled,
    LockoutEnd,
    LockoutEnabled,
    AccessFailedCount,
    AuthenticatorKey

    FROM {DbTable.User}
    WHERE NormalizedEmail = @normalizedEmail
;
                ",
                new { normalizedEmail },
                cancellationToken
            ).ConfigureAwait(false);
        }

        #endregion

        #region IUserRoleStore

        public async Task AddUserToRoleAsync(AppUser user, string normalizedRoleName, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(user, nameof(user));
            ThrowIf.Null(normalizedRoleName, nameof(normalizedRoleName));

            await ExecuteAsync
            (
                $@"
INSERT INTO {DbTable.UserRole}(
    UserId,
    RoleId
) SELECT
    @userId,
    role.Id

    FROM {DbTable.Role} AS role
    WHERE role.NormalizedName = @normalizedRoleName

    ON DUPLICATE KEY UPDATE RoleId = RoleId
;
                ",
                new
                {
                    userId = user.Id,
                    normalizedRoleName
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task RemoveUserFromRoleAsync(AppUser user, string normalizedRoleName, CancellationToken cancellationToken)
        {
            ThrowIf.Null(user, nameof(user));
            ThrowIf.Null(normalizedRoleName, nameof(normalizedRoleName));

            await ExecuteAsync
            (
                $@"
DELETE
    FROM {DbTable.UserRole} AS userRole
    JOIN {DbTable.Role} AS role ON
        role.Id = userRole.RoleId

    WHERE
        userRole.UserId = @userId
        AND role.NormalizedName = @normalizedRoleName
;
                ",
                new
                {
                    userId = user.Id,
                    normalizedRoleName
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(AppUser user, CancellationToken cancellationToken)
        {
            ThrowIf.Null(user, nameof(user));

            return await QueryAsync<string>
            (
                $@"
SELECT
    userRole.UserId,
    role.Name

    FROM {DbTable.UserRole} AS userRole
    JOIN {DbTable.Role} AS role ON
        role.Id = userRole.RoleId

    WHERE UserId = @userId
;
                ",
                new { userId = user.Id },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task<bool> GetUserIsInRoleAsync(AppUser user, string normalizedRoleName, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(user, nameof(user));
            ThrowIf.Null(normalizedRoleName, nameof(normalizedRoleName));

            return await ExecuteScalarAsync<bool>
            (
                $@"
SELECT
    COUNT(*)

    FROM {DbTable.UserRole} AS userRole
    JOIN {DbTable.Role} AS role ON
        role.Id = userRole.RoleId

    WHERE
        userRole.UserId = @userId
        AND role.NormalizedName = @normalizedRoleName
;
                ",
                new
                {
                    userId = user.Id,
                    normalizedRoleName
                },
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task<IEnumerable<AppUser>> GetUsersInRoleAsync(string normalizedRoleName, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(normalizedRoleName, nameof(normalizedRoleName));

            return await QueryAsync<AppUser>
            (
                $@"
SELECT
    user.Id,
    user.UserName,
    user.NormalizedUserName,
    user.Email,
    user.NormalizedEmail,
    user.EmailConfirmed,
    user.PasswordHash,
    user.SecurityStamp,
    user.ConcurrencyStamp,
    user.PhoneNumber,
    user.PhoneNumberConfirmed,
    user.TwoFactorEnabled,
    user.LockoutEnd,
    user.LockoutEnabled,
    user.AccessFailedCount,
    user.AuthenticatorKey

    FROM {DbTable.User} AS user
    JOIN {DbTable.UserRole} AS userRole ON
        userRole.UserId = user.Id
    JOIN {DbTable.Role} AS role ON
        role.Id = userRole.RoleId

    WHERE role.NormalizedName = @normalizedRoleName
;
                ",
                new { normalizedRoleName },
                cancellationToken
            ).ConfigureAwait(false);
        }

        #endregion
    }
}
