namespace Archia.WinForms.UseCases
{
    using System;
    using System.Windows.Forms;

    using Archia.Entities;
    using Archia.Utils;

    public partial class ExaminePatientForm : Form
    {
        private readonly ArchiaServiceProvider _services;

        public ExaminePatientForm(ArchiaServiceProvider services)
        {
            ThrowIf.Null(services, nameof(services));

            services.UserContext.EnsureSignedIn();

            _services = services;

            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to submit?", "Confirm Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _services.PatientService.CreatePatientAsync(new Patient
            {
                FirstName = "A"
            });

            Close();
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