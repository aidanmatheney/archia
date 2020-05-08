namespace Archia.WinForms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private readonly string _username;
        private readonly IServiceProvider _services;

        public MainForm(string username, IServiceProvider services)
        {
            _username = username;
            _services = services;

            InitializeComponent();

            UsernameLabel.Text = username;
            PopulateActionsPanel();
            SetStatus("Signed into Archia");
        }

        private void PopulateActionsPanel()
        {
            static Button CreateButton(string actionName, Func<Form> createForm)
            {
                var button = new Button
                {
                    Text = actionName,
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

            void AddAction(string actionName, Func<Form> createForm)
            {
                var button = CreateButton(actionName, createForm);
                ActionsPanel.Controls.Add(button);
            }

            AddAction("Patient Search", () => new Form()); // TODO
            AddAction("Edit Patient Information", () => new Form()); // TODO
            AddAction("Examine Patient", () => new ExaminePatientForm());
            AddAction("Edit Patient Records", () => new Form()); // TODO
            AddAction("Assign Room", () => new Form()); // TODO
        }

        private void SetStatus(string status) => StatusLabel.Text = status;
    }
}