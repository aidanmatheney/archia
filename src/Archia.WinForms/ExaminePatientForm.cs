namespace Archia.WinForms
{
    using System;
    using System.Windows.Forms;

    public partial class ExaminePatientForm : Form
    {
        public ExaminePatientForm()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to submit?", "Confirm Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to cancel?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}