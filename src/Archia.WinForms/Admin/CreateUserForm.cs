namespace Archia.WinForms.Admin
{
    using System.Windows.Forms;

    using Archia.Utils;

    public partial class CreateUserForm : Form
    {
        private readonly ArchiaServiceProvider _services;

        public CreateUserForm(ArchiaServiceProvider services)
        {
            ThrowIf.Null(services, nameof(services));

            services.UserContext.EnsureSignedIn();

            _services = services;

            InitializeComponent();
        }
    }
}