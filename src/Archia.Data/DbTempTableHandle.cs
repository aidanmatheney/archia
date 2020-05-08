namespace Archia.Data
{
    using System;
    using System.Threading.Tasks;

    using Archia.Utils;

    public sealed class DbTempTableHandle : AsyncActionDisposable
    {
        public DbTempTableHandle(string name, Func<Task> dropTable) : base(dropTable)
        {
            ThrowIf.Null(name, nameof(name));
            Name = name;
        }

        public string Name { get; }
    }
}