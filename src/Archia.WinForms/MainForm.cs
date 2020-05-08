namespace Archia.WinForms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using Archia.Utils;

    public partial class MainForm : Form
    {
        private readonly string _username;
        private readonly ArchiaServiceProvider _services;

        public MainForm(string username, ArchiaServiceProvider services)
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
                var ampersandLabelByActionName = AssignAccessKeys(actions.Select(action => action.ActionName).ToList());
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

        private static IReadOnlyDictionary<string, string> AssignAccessKeys(IReadOnlyCollection<string> labels, IReadOnlyDictionary<int, int>? skipsByLabelIdx = null)
        {
            var skipsByLabelIdxMut = skipsByLabelIdx is null ? null : new Dictionary<int, int>(skipsByLabelIdx);

            var ampersandIdxByLabelIdx = new int[labels.Count];
            var usedAmpersandChars = new HashSet<char>(labels.Count);
            var assignedLabelIdxs = new HashSet<int>(labels.Count);

            int round = 0;
            while (true)
            {
                var isRoundEmpty = true;

                foreach (var (label, labelIdx) in labels.Index())
                {
                    if (assignedLabelIdxs.Contains(labelIdx))
                        continue;

                    if (!(skipsByLabelIdxMut is null) && skipsByLabelIdxMut.TryGetValue(labelIdx, out var skips) && skips > 0)
                    {
                        skipsByLabelIdxMut[labelIdx] = skips - 1;
                        continue;
                    }

                    if (label.Length == 0)
                        throw new ArgumentException("empty label", nameof(labels));

                    if (round >= label.Length)
                        continue;

                    var c = char.ToLower(label[round]);
                    isRoundEmpty = false;

                    if (usedAmpersandChars.Contains(c))
                        continue;

                    ampersandIdxByLabelIdx[labelIdx] = round;
                    usedAmpersandChars.Add(c);
                    assignedLabelIdxs.Add(labelIdx);
                }

                if (isRoundEmpty)
                    break;

                round += 1;
            }

            var ampersandLabelByLabel = new Dictionary<string, string>(labels.Count);
            foreach (var (label, labelIdx) in labels.Index())
            {
                if (assignedLabelIdxs.Contains(labelIdx))
                {
                    var ampersandLabelBuilder = new StringBuilder(label, label.Length + 1);
                    var ampersandIdx = ampersandIdxByLabelIdx[labelIdx];
                    ampersandLabelBuilder.Insert(ampersandIdx, '&');

                    ampersandLabelByLabel.Add(label, ampersandLabelBuilder.ToString());
                }
                else
                {
                    ampersandLabelByLabel.Add(label, label);
                }
            }

            return ampersandLabelByLabel;
        }
    }
}