using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    class RoundCornerPanel : Panel
    {
        public Color BackgroundColor { get; set; } = Color.Black;

        public RoundCornerPanel()
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRoundedRectangle(new SolidBrush(BackgroundColor), 10, 10, this.Width - 20, this.Height - 20, 10);
        }
    }
}
