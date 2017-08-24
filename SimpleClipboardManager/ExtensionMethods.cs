using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    internal static class ExtensionMethods
    {
        internal static Point LocationInForm(this Control control, Form form = null)
        {
            if (form == null)
            {
                form = control.FindForm();
                if (form == null)
                    throw new Exception("Form not found.");
            }

            Point cScreen = control.PointToScreen(control.Location);
            Point fScreen = form.Location;
            return new Point(cScreen.X - fScreen.X, cScreen.Y - fScreen.Y);
        }
    }
}
