namespace Archia.WinForms
{
    partial class DashboardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.GreetingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.HelloLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.DashboardLabel = new System.Windows.Forms.Label();
            this.ActionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ActionsLabel = new System.Windows.Forms.Label();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainPanel.SuspendLayout();
            this.GreetingPanel.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.ColumnCount = 1;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanel.Controls.Add(this.GreetingPanel, 0, 0);
            this.MainPanel.Controls.Add(this.ActionsPanel, 0, 3);
            this.MainPanel.Controls.Add(this.ActionsLabel, 0, 2);
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 4;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanel.Size = new System.Drawing.Size(739, 393);
            this.MainPanel.TabIndex = 0;
            // 
            // GreetingPanel
            // 
            this.GreetingPanel.ColumnCount = 3;
            this.GreetingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.GreetingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GreetingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GreetingPanel.Controls.Add(this.HelloLabel, 1, 0);
            this.GreetingPanel.Controls.Add(this.UsernameLabel, 2, 0);
            this.GreetingPanel.Controls.Add(this.DashboardLabel, 0, 0);
            this.GreetingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GreetingPanel.Location = new System.Drawing.Point(3, 3);
            this.GreetingPanel.Name = "GreetingPanel";
            this.GreetingPanel.RowCount = 1;
            this.GreetingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GreetingPanel.Size = new System.Drawing.Size(733, 40);
            this.GreetingPanel.TabIndex = 0;
            // 
            // HelloLabel
            // 
            this.HelloLabel.AutoSize = true;
            this.HelloLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelloLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HelloLabel.Location = new System.Drawing.Point(607, 0);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(43, 40);
            this.HelloLabel.TabIndex = 1;
            this.HelloLabel.Text = "Hello,";
            this.HelloLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UsernameLabel.Location = new System.Drawing.Point(656, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(74, 40);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "username";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DashboardLabel
            // 
            this.DashboardLabel.AutoSize = true;
            this.DashboardLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DashboardLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DashboardLabel.Location = new System.Drawing.Point(3, 0);
            this.DashboardLabel.Name = "DashboardLabel";
            this.DashboardLabel.Size = new System.Drawing.Size(598, 40);
            this.DashboardLabel.TabIndex = 0;
            this.DashboardLabel.Text = "Dashboard";
            this.DashboardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ActionsPanel
            // 
            this.ActionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionsPanel.Location = new System.Drawing.Point(3, 84);
            this.ActionsPanel.Name = "ActionsPanel";
            this.ActionsPanel.Size = new System.Drawing.Size(733, 306);
            this.ActionsPanel.TabIndex = 2;
            // 
            // ActionsLabel
            // 
            this.ActionsLabel.AutoSize = true;
            this.ActionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionsLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ActionsLabel.Location = new System.Drawing.Point(3, 56);
            this.ActionsLabel.Name = "ActionsLabel";
            this.ActionsLabel.Size = new System.Drawing.Size(733, 25);
            this.ActionsLabel.TabIndex = 1;
            this.ActionsLabel.Text = "&Actions:";
            this.ActionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 396);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(739, 22);
            this.StatusStrip.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(38, 17);
            this.StatusLabel.Text = "status";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 418);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MainPanel);
            this.Name = "DashboardForm";
            this.Text = "Archia";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.GreetingPanel.ResumeLayout(false);
            this.GreetingPanel.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.TableLayoutPanel GreetingPanel;
        private System.Windows.Forms.Label HelloLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.FlowLayoutPanel ActionsPanel;
        private System.Windows.Forms.Label ActionsLabel;
        private System.Windows.Forms.Label DashboardLabel;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
    }
}

