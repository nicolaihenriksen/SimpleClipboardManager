using System;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    public sealed class ClipboardNotification
    {
        public static event EventHandler<string> ClipboardUpdated;

        private static ClipboardUpdatedForm _monitorForm = new ClipboardUpdatedForm();

        private static int eventsToSuppress = 0;

        public static void SuppressNextEvent()
        {
            eventsToSuppress = 2;
        }

        private static void OnClipboardUpdate(EventArgs e)
        {
            var text = Clipboard.GetText();
            if (!string.IsNullOrWhiteSpace(text))
                ClipboardUpdated?.Invoke(null, text);
        }

        private class ClipboardUpdatedForm : Form
        {
            public ClipboardUpdatedForm()
            {
                SafeNativeMethods.SetParent(Handle, SafeNativeMethods.HWND_MESSAGE);
                SafeNativeMethods.AddClipboardFormatListener(Handle);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == SafeNativeMethods.WM_CLIPBOARDUPDATE)
                {
                    if (eventsToSuppress == 0)
                        OnClipboardUpdate(null);
                    else
                        eventsToSuppress--;
                }
                base.WndProc(ref m);
            }
        }
    }
}
