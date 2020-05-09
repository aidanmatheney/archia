namespace Archia.WinForms
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using Archia.Utils;
    using Archia.WinForms.UseCases;

    public partial class DashboardForm : Form
    {
        private readonly ArchiaServiceProvider _services;

        public DashboardForm(ArchiaServiceProvider services)
        {
            ThrowIf.Null(services, nameof(services));

            services.UserContext.EnsureSignedIn();

            _services = services;

            InitializeComponent();

            UsernameLabel.Text = services.UserContext.Username;
            PopulateActionsPanel();
            SetStatus("Signed into Archia");
        }

        private void PopulateActionsPanel()
        {
            AddActions
            (
                ("Patient Check-In", () => new PatientCheckInForm(_services)),
                ("Patient Search", () => new PatientSearchForm(_services)),
                ("Edit Patient Personal Information", () => new EditPatientPersonalInformationForm(_services)),
                ("Examine Patient", () => new ExaminePatientForm(_services)),
                ("Assign Room", () => new AssignRoomForm(_services)),
                ("Edit Patient Medical Records", () => new EditPatientMedicalRecordsForm(_services)),
                ("Order Medication", () => new OrderMedicationForm(_services)),
                ("Delete Patient", () => new DeletePatientForm(_services)),
                ("Schedule Appointment", () => new ScheduleAppointmentForm(_services))
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