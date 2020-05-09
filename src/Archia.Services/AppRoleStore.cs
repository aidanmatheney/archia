namespace Archia.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;

    using Archia.Data.Services;
    using Archia.Entities;
    using Archia.Utils;
    using System;

    public sealed class AppRoleStore : IRoleStore<AppRole>
    {
        private readonly IAppRoleService _roleService;
        private readonly ILogger<AppRoleStore> _logger;

        public AppRoleStore(IAppRoleService roleService, ILogger<AppRoleStore> logger)
        {
            ThrowIf.Null(roleService, nameof(roleService));
            ThrowIf.Null(logger, nameof(logger));

            _roleService = roleService;
            _logger = logger;
        }

        public Task<string> GetRoleIdAsync(AppRole role, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string?> GetRoleNameAsync(AppRole role, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(AppRole role, string? name, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));
            role.Name = name;
            return Task.CompletedTask;
        }

        public Task<string?> GetNormalizedRoleNameAsync(AppRole role, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));
            return Task.FromResult(role.NormalizedName);
        }

        public Task SetNormalizedRoleNameAsync(AppRole role, string? normalizedName, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));
            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
        public async Task<AppRole?> FindByIdAsync(string id, CancellationToken cancellationToken = default)
#pragma warning restore CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
        {
            ThrowIf.Null(id, nameof(id));
            return await _roleService.FindRoleByIdAsync(new Guid(id), cancellationToken).ConfigureAwait(false);
        }

#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
        public async Task<AppRole?> FindByNameAsync(string normalizedName, CancellationToken cancellationToken = default)
#pragma warning restore CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
        {
            ThrowIf.Null(normalizedName, nameof(normalizedName));
            return await _roleService.FindRoleByNameAsync(normalizedName, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IdentityResult> CreateAsync(AppRole role, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));
            await _roleService.CreateRoleAsync(role, cancellationToken).ConfigureAwait(false);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(AppRole role, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));
            await _roleService.UpdateRoleAsync(role, cancellationToken).ConfigureAwait(false);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(AppRole role, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(role, nameof(role));
            await _roleService.DeleteRoleAsync(role, cancellationToken).ConfigureAwait(false);
            return IdentityResult.Success;
        }

        public void Dispose() { }
    }
}
