namespace Archia.Data.Services
{
    using System.Collections.Generic;

    public sealed class DbSeederSettings
    {
        public sealed class DefaultCredentials
        {
            public string? Username { get; set; }
            public string? DefaultPassword { get; set; }
        }

        public IReadOnlyList<DefaultCredentials>? DefaultAdmins { get; set; }
    }
}