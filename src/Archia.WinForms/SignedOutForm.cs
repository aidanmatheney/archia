namespace Archia.WinForms
{
    using System;
    using System.Windows.Forms;

    public partial class SignedOutForm : Form
    {
        private readonly ArchiaServiceProvider _services;

        public SignedOutForm(ArchiaServiceProvider services)
        {
            _services = services;

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
                UsernameTextBox.ResetText();
                PasswordTextBox.ResetText();

                Hide();

                var mainForm = new MainForm(username, _services);
                mainForm.ShowDialog();

                Show();
            }
            else
            {
                MessageBox.Show("Your username and/or password is incorrect", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleCredentialsTextChanged(object sender, EventArgs e)
        {
            var hasUsername = UsernameTextBox.Text.Length > 0;
            var hasPassword = PasswordTextBox.Text.Length > 0;

            SignInButton.Enabled = hasUsername && hasPassword;
        }

        private void HandleCredentialsKeyDown(object sender, KeyEventArgs e)
        {
            var hasUsername = UsernameTextBox.Text.Length > 0;
            var hasPassword = PasswordTextBox.Text.Length > 0;

            if (hasUsername && hasPassword && e.KeyCode == Keys.Enter)
                SignIn();
        }
    }
}