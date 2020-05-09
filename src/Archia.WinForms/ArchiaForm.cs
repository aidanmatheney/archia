namespace Archia.WinForms
{
    using System.Windows.Forms;

    using Archia.Utils;

    using Microsoft.Extensions.Logging;

    public abstract class ArchiaForm : Form
    {
        protected ArchiaForm(ArchiaServiceProvider services)
        {
            ThrowIf.Null(services, nameof(services));

            Services = services;
            Logger = services.Logger(this);
        }

        protected ArchiaServiceProvider Services { get; }
        protected ILogger Logger { get; }
    }
}