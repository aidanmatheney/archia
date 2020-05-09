namespace Archia.WinForms.UseCases
{
    using System;

    using Archia.Entities;

    public partial class ExaminePatientForm : ArchiaForm
    {
        public ExaminePatientForm(ArchiaServiceProvider services) : base(services)
        {
            services.UserContext.EnsureSignedIn();

            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!UiUtils.SubmitMessageBox())
                return;

            Services.PatientService.CreatePatientAsync(new Patient
            {
                FirstName = "A"
            });

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (UiUtils.CancelMessageBox())
                Close();
        }
    }
}