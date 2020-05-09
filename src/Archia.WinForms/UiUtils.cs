namespace Archia.WinForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using Archia.Utils;
    using Microsoft.AspNetCore.Identity;

    public static class UiUtils
    {
        public static void UiThread(this Control control, Action action)
        {
            ThrowIf.Null(control, nameof(control));
            ThrowIf.Null(action, nameof(action));

            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public static T UiThread<T>(this Control control, Func<T> func)
        {
            ThrowIf.Null(control, nameof(control));
            ThrowIf.Null(func, nameof(func));

            if (control.InvokeRequired)
            {
                return (T)control.Invoke(func);
            }

            return func();
        }

        /// <summary>
        /// Displays a success message box with specified text and caption.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        public static void SuccessMessageBox(string text, string caption = "Success")
            => MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>
        /// Displays an error message box with specified text and caption.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        public static void ErrorMessageBox(string text, string caption = "Error")
            => MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

        /// <summary>
        /// Displays an exception message box with specified text and caption.
        /// </summary>
        /// <param name="ex">The exception to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        public static void ExceptionMessageBox(Exception ex, string caption = "Error")
            => ErrorMessageBox(ex.ToString(), caption);

        /// <summary>
        /// Displays a <see cref="IdentityResult"/> message box with specified text and caption.
        /// </summary>
        /// <param name="result">The <see cref="IdentityResult"/> whose errors to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        public static void IdentityResultMessageBox(IdentityResult result, string caption = "Error")
            => ErrorMessageBox(string.Join(Environment.NewLine, result.Errors.Select(error => error.Description)), caption);

        /// <summary>
        /// Displays a confirmation message box with specified text and caption.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        public static bool ConfirmMessageBox(string text, string caption = "Confirm")
            => MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        /// <summary>
        /// Displays a submit confirmation message box with specified text and caption.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        public static bool SubmitMessageBox(string text = "Are you sure you wish to submit?", string caption = "Submit?")
            => ConfirmMessageBox(text, caption);

        /// <summary>
        /// Displays a cancel confirmation message box with specified text and caption.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        public static bool CancelMessageBox(string text = "Are you sure you wish to cancel?", string caption = "Cancel?")
            => ConfirmMessageBox(text, caption);

        public static IReadOnlyDictionary<string, string> AssignAccessKeys(IReadOnlyCollection<string> labels, IReadOnlyDictionary<int, int>? skipsByLabelIdx = null)
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
                        throw new ArgumentException("Empty label", nameof(labels));

                    if (round >= label.Length)
                        continue;

                    isRoundEmpty = false;

                    var c = char.ToLower(label[round]);
                    if (c < 'a' || c > 'z')
                        continue;

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