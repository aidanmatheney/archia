namespace Archia.WinForms
{
    using System;
    using System.Threading.Tasks;

    public partial class SignInForm : ArchiaForm
    {
        public SignInForm(ArchiaServiceProvider services) : base(services)
        {
            InitializeComponent();

#if DEBUG
            UsernameTextBox.Text = "aidan";
            PasswordTextBox.Text = "password123";
#endif

            HandleCredentialsTextChanged(this, EventArgs.Empty);
        }

        private void SignInButton_Click(object sender, EventArgs e) => _ = SignIn();

        private async Task SignIn()
        {
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;

            var user = await Services.UserManager.FindByNameAsync(username).ConfigureAwait(true);
            if (user is null)
            {
                UiUtils.ErrorMessageBox("Your username and/or password is incorrect", "Invalid Credentials");
                return;
            }

            var signInResult = await Services.SignInManager.CheckPasswordSignInAsync(user, password, false).ConfigureAwait(true);
            if (!signInResult.Succeeded)
            {
                UiUtils.ErrorMessageBox("Your username and/or password is incorrect", "Invalid Credentials");
                return;
            }

            Services.UserContext.SignIn(user);

            UsernameTextBox.ResetText();
            PasswordTextBox.ResetText();

            Hide();

            var dashboardForm = new DashboardForm(Services);
            dashboardForm.ShowDialog();

            Show();
        }

        private void HandleCredentialsTextChanged(object sender, EventArgs e)
        {
            var hasUsername = UsernameTextBox.Text.Length > 0;
            var hasPassword = PasswordTextBox.Text.Length > 0;

            SignInButton.Enabled = hasUsername && hasPassword;
        }
    }
}