namespace Archia.WinForms
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using Archia.WinForms.Admin;
    using Archia.WinForms.UseCases;

    public partial class DashboardForm : ArchiaForm
    {
        public DashboardForm(ArchiaServiceProvider services) : base(services)
        {
            services.UserContext.EnsureSignedIn();

            InitializeComponent();

            UsernameLabel.Text = services.UserContext.User.UserName;
            PopulateActionsPanel();
            SetStatus("Signed into Archia");
        }

        private void PopulateActionsPanel()
        {
            AddActions
            (
                ("Patient Check-In", () => new PatientCheckInForm(Services)),
                ("Patient Search", () => new PatientSearchForm(Services)),
                ("Edit Patient Personal Information", () => new EditPatientPersonalInformationForm(Services)),
                ("Examine Patient", () => new ExaminePatientForm(Services)),
                ("Assign Room", () => new AssignRoomForm(Services)),
                ("Edit Patient Medical Records", () => new EditPatientMedicalRecordsForm(Services)),
                ("Order Medication", () => new OrderMedicationForm(Services)),
                ("Delete Patient", () => new DeletePatientForm(Services)),
                ("Schedule Appointment", () => new ScheduleAppointmentForm(Services)),

                ("Create User", () => new CreateUserForm(Services))
            );

            #region Implementation

            void AddActions(params (string ActionName, Func<Form> CreateForm)[] actions)
            {
                var ampersandLabelByActionName = UiUtils.AssignAccessKeys
                (
                    actions.Select(action => action.ActionName).ToList()
                );
                foreach (var (actionName, createForm) in actions)
                {
                    var ampersandLabel = ampersandLabelByActionName[actionName];
                    var button = CreateButton(ampersandLabel, createForm);
                    ActionsPanel.Controls.Add(button);
                }
            }

            static Button CreateButton(string label, Func<Form> createForm)
            {
                var button = new Button
                {
                    Text = label,
                    Size = new Size(150, 100),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };

                button.Click += (sender, e) =>
                {
                    var form = createForm();
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog();
                };

                return button;
            }

            #endregion
        }

        private void SetStatus(string status) => StatusLabel.Text = status;
    }
}