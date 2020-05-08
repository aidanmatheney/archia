namespace Archia.WinForms.Admin
{
    using System.Windows.Forms;

    using Archia.Utils;

    public partial class CreateUserForm : Form
    {
        private readonly string _username;
        private readonly ArchiaServiceProvider _services;

        public CreateUserForm(string username, ArchiaServiceProvider services)
        {
            ThrowIf.Null(username, nameof(username));
            ThrowIf.Null(services, nameof(services));

            _username = username;
            _services = services;

            InitializeComponent();
        }
    }
}