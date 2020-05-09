﻿namespace Archia.WinForms
{
    using System;
    using System.Windows.Forms;

    using Archia.Utils;

    public partial class SignInForm : Form
    {
        private readonly ArchiaServiceProvider _services;

        public SignInForm(ArchiaServiceProvider services)
        {
            ThrowIf.Null(services, nameof(services));

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
                _services.UserContext.SignIn(username);

                UsernameTextBox.ResetText();
                PasswordTextBox.ResetText();

                Hide();

                var dashboardForm = new DashboardForm(_services);
                dashboardForm.ShowDialog();

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
    }
}