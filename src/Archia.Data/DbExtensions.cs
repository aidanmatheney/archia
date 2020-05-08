namespace Archia.Data
{
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Utils;

    using MySql.Data.MySqlClient;

    public static class DbExtensions
    {
        public static async Task EnsureOpenAsync(this MySqlConnection dbConnection, CancellationToken cancellationToken = default)
        {
            ThrowIf.Null(dbConnection, nameof(dbConnection));

            if (dbConnection.State == ConnectionState.Closed)
                await dbConnection.OpenAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}