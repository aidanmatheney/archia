namespace Archia.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Entities;

    public interface IAppUserService
    {
        #region IUserStore

        Task<AppUser?> FindUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<AppUser?> FindUserByUserNameAsync(string normalizedUserName, CancellationToken cancellationToken = default);
        Task CreateUserAsync(AppUser user, CancellationToken cancellationToken = default);
        Task UpdateUserAsync(AppUser user, CancellationToken cancellationToken = default);
        Task DeleteUserAsync(AppUser user, CancellationToken cancellationToken = default);

        #endregion

        #region IUserEmailStore

        Task<AppUser?> FindUserByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default);

        #endregion

        #region IUserRoleStore

        Task AddUserToRoleAsync(AppUser user, string normalizedRoleName, CancellationToken cancellationToken = default);
        Task RemoveUserFromRoleAsync(AppUser user, string normalizedRoleName, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetUserRolesAsync(AppUser user, CancellationToken cancellationToken = default);
        Task<bool> GetUserIsInRoleAsync(AppUser user, string normalizedRoleName, CancellationToken cancellationToken = default);
        Task<IEnumerable<AppUser>> GetUsersInRoleAsync(string normalizedRoleName, CancellationToken cancellationToken = default);

        #endregion
    }
}
