namespace Archia.WinForms
{
    using System;

    public sealed class ArchiaUserContext
    {
        private string? _username;

        /// <exception cref="InvalidOperationException" />
        public string Username
        {
            get
            {
                EnsureSignedIn();
                return _username!;
            }
        }
        public bool IsSignedIn => !(_username is null);

        public void SignIn(string username) => _username = username;
        public void SignOut() => _username = null;

        /// <exception cref="InvalidOperationException" />
        public void EnsureSignedIn()
        {
            if (!IsSignedIn)
                throw new InvalidOperationException("User is not signed in");
        }
    }
}