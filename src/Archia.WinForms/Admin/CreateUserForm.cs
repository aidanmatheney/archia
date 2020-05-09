namespace Archia.WinForms.Admin
{
    using System;

    using Archia.Entities;

    using Microsoft.Extensions.Logging;

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
            try
            {
                await Services.UserManager.CreateAsync(newUser, password).ConfigureAwait(false);
                await Services.UserManager.AddToRoleAsync(newUser, role).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error creating user");
                UiUtils.ErrorMessageBox("Error creating user");
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