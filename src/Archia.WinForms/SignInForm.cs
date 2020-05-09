namespace Archia.WinForms
{
    using System;

    public partial class SignInForm : ArchiaForm
    {
        public SignInForm(ArchiaServiceProvider services) : base(services)
        {
            InitializeComponent();

#if DEBUG
            UsernameTextBox.Text = "aidan";
            PasswordTextBox.Text = "password1";
#endif

            HandleCredentialsTextChanged(this, EventArgs.Empty);
        }

        private void SignInButton_Click(object sender, EventArgs e) => SignIn();

        private void SignIn()
        {
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;

            if (username.Equals("aidan", StringComparison.OrdinalIgnoreCase) && password.Equals("password1"))
            {
                Services.UserContext.SignIn(username);

                UsernameTextBox.ResetText();
                PasswordTextBox.ResetText();

                Hide();

                var dashboardForm = new DashboardForm(Services);
                dashboardForm.ShowDialog();

                Show();
            }
            else
            {
                UiUtils.ErrorMessageBox("Your username and/or password is incorrect", "Invalid Credentials");
            }
        }

        private void HandleCredentialsTextChanged(object sender, EventArgs e)
        {
            var hasUsername = UsernameTextBox.Text.Length > 0;
            var hasPassword = PasswordTextBox.Text.Length > 0;

            SignInButton.Enabled = hasUsername && hasPassword;
        }
    }
}