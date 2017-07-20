using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    class RoundCornerPanel : Panel
    {
        public Color BackgroundColor { get; set; } = Color.Black;

        public int Radius { get; set; } = 15;

        public RoundCornerPanel()
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var padding = 1;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRoundedRectangle(new SolidBrush(BackgroundColor), padding, padding, this.Width - 2 * padding, this.Height - 2 * padding, Radius);
        }
    }
}
