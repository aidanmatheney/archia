namespace Archia.WinForms
{
    using System;

    using Archia.Entities;

    public sealed class ArchiaUserContext
    {
        private AppUser? _user;

        /// <exception cref="InvalidOperationException" />
        public AppUser User
        {
            get
            {
                EnsureSignedIn();
                return _user!;
            }
        }

        public bool IsSignedIn => !(_user is null);

        public void SignIn(AppUser user) => _user = user;
        public void SignOut() => _user = null;

        /// <exception cref="InvalidOperationException" />
        public void EnsureSignedIn()
        {
            if (!IsSignedIn)
                throw new InvalidOperationException("User is not signed in");
        }
    }
}