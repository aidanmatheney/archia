namespace Archia.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Data.Naming;
    using Archia.Entities;
    using Archia.Utils;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;

    public sealed class DbSeeder
    {
        private readonly List<(string Username, string DefaultPassword)> _defaultAdmins = new List<(string, string)>();

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ILogger _logger;

        public DbSeeder
        (
            DbSeederSettings settings,
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            ILogger<DbSeeder> logger
        )
        {
            ThrowIf.Null(settings, nameof(settings));
            ThrowIf.Null(userManager, nameof(userManager));
            ThrowIf.Null(roleManager, nameof(roleManager));
            ThrowIf.Null(logger, nameof(logger));

            if (!(settings.DefaultAdmins is null))
            {
                foreach (var defaultAdmin in settings.DefaultAdmins)
                {
                    if (string.IsNullOrWhiteSpace(defaultAdmin.Username))
                        throw new ArgumentException($"{nameof(settings)}.{nameof(DbSeederSettings.DefaultAdmins)} must not contain an empty {nameof(DbSeederSettings.DefaultCredentials.Username)} ", nameof(settings));

                    if (string.IsNullOrWhiteSpace(defaultAdmin.DefaultPassword))
                        throw new ArgumentException($"{nameof(settings)}.{nameof(DbSeederSettings.DefaultAdmins)} must not contain an empty {nameof(DbSeederSettings.DefaultCredentials.DefaultPassword)} ", nameof(settings));

                    _defaultAdmins.Add((defaultAdmin.Username, defaultAdmin.DefaultPassword));
                }
            }

            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            await EnsureRoles(cancellationToken).ConfigureAwait(false);
            await EnsureAdminUsers(cancellationToken).ConfigureAwait(false);
        }

        private async Task EnsureRoles(CancellationToken cancellationToken)
        {
            await EnsureRole(RoleName.Secretary, cancellationToken).ConfigureAwait(false);
            await EnsureRole(RoleName.Nurse, cancellationToken).ConfigureAwait(false);
            await EnsureRole(RoleName.Doctor, cancellationToken).ConfigureAwait(false);
            await EnsureRole(RoleName.Administrator, cancellationToken).ConfigureAwait(false);
        }

        private async Task EnsureRole(string roleName, CancellationToken cancellationToken)
        {
            Debug.Assert(!(roleName is null));

            var roleExists = await _roleManager.RoleExistsAsync(roleName).ConfigureAwait(false);
            if (roleExists)
            {
                _logger.LogDebug("Role {roleName} exist", roleName);
                return;
            }

            _logger.LogDebug("Creating role {roleName}", roleName);
            var createRoleResult = await _roleManager.CreateAsync(new AppRole(roleName)).ConfigureAwait(false);
            if (!createRoleResult.Succeeded)
            {
                _logger.LogCritical("Failed to create role {roleName}. Errors: {errors}", roleName, createRoleResult.GetErrorsDebugString());
                throw new Exception($"Failed to create role {roleName}. Errors: {createRoleResult.GetErrorsDebugString()}");
            }
        }

        private async Task EnsureAdminUsers(CancellationToken cancellationToken)
        {
            foreach (var (username, defaultPassword) in _defaultAdmins)
            {
                var adminUser = await EnsureUser(username, defaultPassword, cancellationToken).ConfigureAwait(false);
                await EnsureUserRole(adminUser, RoleName.Administrator, cancellationToken).ConfigureAwait(false);
                await EnsureLockedOut(adminUser, false, cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task<AppUser> EnsureUser(string username, string defaultPassword, CancellationToken cancellationToken)
        {
            Debug.Assert(!(username is null));
            Debug.Assert(!(defaultPassword is null));

            var user = await _userManager.FindByNameAsync(username).ConfigureAwait(false);
            if (!(user is null))
            {
                _logger.LogDebug("User {username} already exists", username);
                return user;
            }

            _logger.LogDebug("Creating user {username}", username);
            user = new AppUser(username);
            var createUserResult = await _userManager.CreateAsync(user, defaultPassword).ConfigureAwait(false);
            if (!createUserResult.Succeeded)
            {
                _logger.LogCritical("Failed to create user {username}. Errors: {errors}", username, createUserResult.GetErrorsDebugString());
                throw new Exception($"Failed to create user {username}. Errors: {createUserResult.GetErrorsDebugString()}");
            }

            return user;
        }

        private async Task EnsureUserRole(AppUser user, string roleName, CancellationToken cancellationToken)
        {
            Debug.Assert(!(user is null));
            Debug.Assert(!(roleName is null));

            var isInRole = await _userManager.IsInRoleAsync(user, roleName).ConfigureAwait(false);
            if (isInRole)
            {
                _logger.LogDebug("User {username} is already in {roleName} role", user.UserName, roleName);
                return;
            }

            _logger.LogDebug("Adding user {username} to {roleName} role", user.UserName, roleName);
            var addToRoleResult = await _userManager.AddToRoleAsync(user, roleName).ConfigureAwait(false);
            if (!addToRoleResult.Succeeded)
            {
                _logger.LogCritical("Failed to add user {username} to {roleName} role. Errors: {errors}", user.UserName, roleName, addToRoleResult.GetErrorsDebugString());
                throw new Exception($"Failed to add user {user.UserName} to {roleName} role. Errors: {addToRoleResult.GetErrorsDebugString()}");
            }
        }

        private async Task EnsureLockedOut(AppUser user, bool lockedOut, CancellationToken cancellationToken)
        {
            Debug.Assert(!(user is null));

            _logger.LogDebug($"Ensuring user {{username}} is {(lockedOut ? string.Empty : "not ")}locked out", user.UserName);
            await _userManager.LockOutAsync(user, lockedOut).ConfigureAwait(false);
        }
    }
}