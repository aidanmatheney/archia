namespace Archia.Data.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Entities;

    public interface IAppRoleService
    {
        Task<AppRole?> FindRoleByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<AppRole?> FindRoleByNameAsync(string normalizedName, CancellationToken cancellationToken = default);
        Task CreateRoleAsync(AppRole role, CancellationToken cancellationToken = default);
        Task UpdateRoleAsync(AppRole role, CancellationToken cancellationToken = default);
        Task DeleteRoleAsync(AppRole role, CancellationToken cancellationToken = default);
    }
}