using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimpleClipboardManager.Controls
{
    class RoundCornerPanel : Panel
    {
        public Color BackgroundColor { get; set; } = Color.Black;

        public int Radius { get; set; } = 15;

        public RoundCornerPanel()
        {
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRoundedRectangle(new SolidBrush(BackgroundColor), 0, 0, this.Width, this.Height, Radius);
        }
    }
}
