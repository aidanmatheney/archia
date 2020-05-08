namespace Archia.WinForms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    using Archia.Utils;

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