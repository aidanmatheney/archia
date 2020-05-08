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
        private readonly string _username;
        private readonly ArchiaServiceProvider _services;

        public DashboardForm(string username, ArchiaServiceProvider services)
        {
            ThrowIf.Null(username, nameof(username));
            ThrowIf.Null(services, nameof(services));

            _username = username;
            _services = services;

            InitializeComponent();

            UsernameLabel.Text = username;
            PopulateActionsPanel();
            SetStatus("Signed into Archia");
        }

        private void PopulateActionsPanel()
        {
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

            AddActions
            (
                ("Patient Search", () => new Form()), // TODO
                ("Edit Patient Information", () => new Form()), // TODO
                ("Examine Patient", () => new ExaminePatientForm(_username, _services)),
                ("Edit Patient Records", () => new Form()), // TODO
                ("Assign Room", () => new Form()) // TODO
            );
        }

        private void SetStatus(string status) => StatusLabel.Text = status;
    }
}