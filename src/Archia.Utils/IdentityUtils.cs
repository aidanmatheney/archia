namespace Archia.Utils
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Archia.Entities;

    using Microsoft.AspNetCore.Identity;

    public static class IdentityUtils
    {
        public static string GetErrorsDebugString(this IdentityResult identityResult)
        {
            ThrowIf.Null(identityResult, nameof(identityResult));

            return string.Join(Environment.NewLine, identityResult.Errors.Select(error => $"{error.Code}: {error.Description}"));
        }

        /// <summary>
        /// Marks the user as locked out in the store, and updates the security stamp so they are logged out.
        /// </summary>
        public static async Task LockOutAsync(this UserManager<AppUser> userManager, AppUser user, bool shouldBeLockedOut)
        {
            ThrowIf.Null(userManager, nameof(userManager));
            ThrowIf.Null(user, nameof(user));

            if (user.IsLockedOut == shouldBeLockedOut)
                return;

            var lockoutEndDate = shouldBeLockedOut ? DateTimeOffset.MaxValue : default(DateTimeOffset?);
            await userManager.SetLockoutEndDateAsync(user, lockoutEndDate).ConfigureAwait(false);
            await userManager.UpdateSecurityStampAsync(user).ConfigureAwait(false);
            await userManager.UpdateAsync(user).ConfigureAwait(false);
        }
    }
}