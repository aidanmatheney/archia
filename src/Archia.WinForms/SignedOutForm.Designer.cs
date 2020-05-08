namespace Archia.WinForms
{
    partial class SignedOutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.CredentialsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SignInLabel = new System.Windows.Forms.Label();
            this.SignInButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CredentialsPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameTextBox.Location = new System.Drawing.Point(93, 6);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(439, 29);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.TextChanged += new System.EventHandler(this.HandleCredentialsTextChanged);
            this.UsernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleCredentialsKeyDown);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordTextBox.Location = new System.Drawing.Point(93, 48);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(439, 29);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.HandleCredentialsTextChanged);
            this.PasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleCredentialsKeyDown);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameLabel.Location = new System.Drawing.Point(3, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(84, 42);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username:";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordLabel.Location = new System.Drawing.Point(3, 42);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(84, 42);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "Password:";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CredentialsPanel
            // 
            this.CredentialsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CredentialsPanel.ColumnCount = 2;
            this.CredentialsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CredentialsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CredentialsPanel.Controls.Add(this.UsernameLabel, 0, 0);
            this.CredentialsPanel.Controls.Add(this.PasswordTextBox, 1, 1);
            this.CredentialsPanel.Controls.Add(this.PasswordLabel, 0, 1);
            this.CredentialsPanel.Controls.Add(this.UsernameTextBox, 1, 0);
            this.CredentialsPanel.Location = new System.Drawing.Point(3, 62);
            this.CredentialsPanel.Name = "CredentialsPanel";
            this.CredentialsPanel.RowCount = 2;
            this.CredentialsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CredentialsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CredentialsPanel.Size = new System.Drawing.Size(535, 84);
            this.CredentialsPanel.TabIndex = 0;
            // 
            // MainPanel
            // 
            this.MainPanel.ColumnCount = 1;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanel.Controls.Add(this.CredentialsPanel, 0, 2);
            this.MainPanel.Controls.Add(this.SignInLabel, 0, 1);
            this.MainPanel.Controls.Add(this.SignInButton, 0, 4);
            this.MainPanel.Controls.Add(this.label1, 0, 0);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 5;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.Size = new System.Drawing.Size(541, 185);
            this.MainPanel.TabIndex = 1;
            // 
            // SignInLabel
            // 
            this.SignInLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SignInLabel.AutoSize = true;
            this.SignInLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SignInLabel.Location = new System.Drawing.Point(3, 21);
            this.SignInLabel.Name = "SignInLabel";
            this.SignInLabel.Padding = new System.Windows.Forms.Padding(4);
            this.SignInLabel.Size = new System.Drawing.Size(535, 38);
            this.SignInLabel.TabIndex = 1;
            this.SignInLabel.Text = "Sign In";
            this.SignInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SignInButton
            // 
            this.SignInButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SignInButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SignInButton.Location = new System.Drawing.Point(463, 150);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(75, 32);
            this.SignInButton.TabIndex = 2;
            this.SignInButton.Text = "Sign In";
            this.SignInButton.UseVisualStyleBackColor = true;
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(535, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Archia Electronic Medical Records System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SignedOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 185);
            this.Controls.Add(this.MainPanel);
            this.Name = "SignedOutForm";
            this.Text = "Archia";
            this.CredentialsPanel.ResumeLayout(false);
            this.CredentialsPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TableLayoutPanel CredentialsPanel;
        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.Label SignInLabel;
        private System.Windows.Forms.Button SignInButton;
        private System.Windows.Forms.Label label1;
    }
}