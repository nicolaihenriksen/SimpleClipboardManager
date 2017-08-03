using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleClipboardManager.Controls
{
    class PreviewPanel : Panel
    {
        private int _maxPreviewLines;
        public int MaxPreviewLines
        {
            get => _maxPreviewLines;
            set
            {
                if (value == _maxPreviewLines)
                    return;
                _maxPreviewLines = value;
                RecalculateHeight();
            }
        }

        public string PreviewText
        {
            get => _lbl.Text;
            set
            {
                if (value == _lbl.Text)
                    return;
                _lbl.Text = value;
                RecalculateHeight();
            }
        }

        private Label _lbl;

        public PreviewPanel()
        {
            _lbl = new Label
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
                AutoSize = true,
            };
            Controls.Add(_lbl);
            Paint += PreviewPanel_Paint;
        }

        private void RecalculateHeight()
        {
            Height = GetLineCount(PreviewText) * 18;
            Invalidate();
        }

        private int GetLineCount(string text)
        {
            if (MaxPreviewLines == 0 || string.IsNullOrWhiteSpace(text))
                return 0;

            int newLineLen = Environment.NewLine.Length;
            int numLines = text.Length - text.Replace(Environment.NewLine, string.Empty).Length;
            if (newLineLen != 0)
            {
                numLines /= newLineLen;
                numLines++;
            }
            return Math.Min(MaxPreviewLines, numLines);
        }

        private void PreviewPanel_Paint(object sender, PaintEventArgs e)
        {
            // Paint border
            using (var pen = new Pen(Color.Black, 1))
            {
                var rect = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
