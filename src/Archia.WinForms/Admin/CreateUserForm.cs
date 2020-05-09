namespace Archia.WinForms.Admin
{
    using System;

    using Archia.Entities;

    public partial class CreateUserForm : ArchiaForm
    {
        public CreateUserForm(ArchiaServiceProvider services) : base(services)
        {
            services.UserContext.EnsureSignedIn();

            InitializeComponent();
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            if (!UiUtils.SubmitMessageBox())
                return;

            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;
            var role = (string)RoleComboBox.SelectedItem;

            var newUser = new AppUser(username);

            var createResult = await Services.UserManager.CreateAsync(newUser, password).ConfigureAwait(false);
            if (!createResult.Succeeded)
            {
                UiUtils.IdentityResultMessageBox(createResult, "Error creating user");
                return;
            }

            var addToRoleResult = await Services.UserManager.AddToRoleAsync(newUser, role).ConfigureAwait(false);
            if (!addToRoleResult.Succeeded)
            {
                UiUtils.IdentityResultMessageBox(createResult, "Error adding user to role");
                return;
            }

            UiUtils.SuccessMessageBox("Successfully created user");

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (UiUtils.CancelMessageBox())
                Close();
        }
    }
}