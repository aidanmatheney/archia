namespace Archia.WinForms
{
    partial class ExaminePatientForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.HealthAssessmentLabel = new System.Windows.Forms.Label();
            this.PatientNameLabel = new System.Windows.Forms.Label();
            this.PatientNameTextBox = new System.Windows.Forms.TextBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.SymptomsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.HealthAssessmentTextBox = new System.Windows.Forms.TextBox();
            this.SymptomsTextBox = new System.Windows.Forms.TextBox();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.SymptomsTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.HealthAssessmentTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.HealthAssessmentLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.PatientNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PatientNameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DateLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SymptomsLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.DatePicker, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 200);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // HealthAssessmentLabel
            // 
            this.HealthAssessmentLabel.AutoSize = true;
            this.HealthAssessmentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HealthAssessmentLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HealthAssessmentLabel.Location = new System.Drawing.Point(3, 99);
            this.HealthAssessmentLabel.Name = "HealthAssessmentLabel";
            this.HealthAssessmentLabel.Size = new System.Drawing.Size(136, 101);
            this.HealthAssessmentLabel.TabIndex = 0;
            this.HealthAssessmentLabel.Text = "Health Assessment:";
            this.HealthAssessmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PatientNameLabel
            // 
            this.PatientNameLabel.AutoSize = true;
            this.PatientNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatientNameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PatientNameLabel.Location = new System.Drawing.Point(3, 0);
            this.PatientNameLabel.Name = "PatientNameLabel";
            this.PatientNameLabel.Size = new System.Drawing.Size(136, 33);
            this.PatientNameLabel.TabIndex = 0;
            this.PatientNameLabel.Text = "Patient name:";
            this.PatientNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PatientNameTextBox
            // 
            this.PatientNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatientNameTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PatientNameTextBox.Location = new System.Drawing.Point(145, 3);
            this.PatientNameTextBox.Name = "PatientNameTextBox";
            this.PatientNameTextBox.Size = new System.Drawing.Size(646, 27);
            this.PatientNameTextBox.TabIndex = 1;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DateLabel.Location = new System.Drawing.Point(3, 33);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(136, 33);
            this.DateLabel.TabIndex = 0;
            this.DateLabel.Text = "Date:";
            this.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SymptomsLabel
            // 
            this.SymptomsLabel.AutoSize = true;
            this.SymptomsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SymptomsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SymptomsLabel.Location = new System.Drawing.Point(3, 66);
            this.SymptomsLabel.Name = "SymptomsLabel";
            this.SymptomsLabel.Size = new System.Drawing.Size(136, 33);
            this.SymptomsLabel.TabIndex = 0;
            this.SymptomsLabel.Text = "Symptoms:";
            this.SymptomsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 276);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.SubmitButton, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.CancelButton, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 223);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(794, 50);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubmitButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SubmitButton.Location = new System.Drawing.Point(635, 3);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 44);
            this.SubmitButton.TabIndex = 1;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelButton.Location = new System.Drawing.Point(716, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 44);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // HealthAssessmentTextBox
            // 
            this.HealthAssessmentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HealthAssessmentTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HealthAssessmentTextBox.Location = new System.Drawing.Point(145, 102);
            this.HealthAssessmentTextBox.Multiline = true;
            this.HealthAssessmentTextBox.Name = "HealthAssessmentTextBox";
            this.HealthAssessmentTextBox.Size = new System.Drawing.Size(646, 95);
            this.HealthAssessmentTextBox.TabIndex = 1;
            // 
            // SymptomsTextBox
            // 
            this.SymptomsTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SymptomsTextBox.Location = new System.Drawing.Point(145, 69);
            this.SymptomsTextBox.Name = "SymptomsTextBox";
            this.SymptomsTextBox.Size = new System.Drawing.Size(646, 27);
            this.SymptomsTextBox.TabIndex = 1;
            // 
            // DatePicker
            // 
            this.DatePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatePicker.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DatePicker.Location = new System.Drawing.Point(145, 36);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(646, 27);
            this.DatePicker.TabIndex = 2;
            // 
            // ExaminePatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 276);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "ExaminePatientForm";
            this.Text = "Examine Patient";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label PatientNameLabel;
        private System.Windows.Forms.TextBox PatientNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label HealthAssessmentLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label SymptomsLabel;
        private System.Windows.Forms.TextBox SymptomsTextBox;
        private System.Windows.Forms.TextBox HealthAssessmentTextBox;
        private System.Windows.Forms.DateTimePicker DatePicker;
    }
}