using System;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    internal class ClipboardNotification
    {
        public static event Action<string> ClipboardUpdated;
        internal static ClipboardUpdatedForm MonitorForm { get; } = new ClipboardUpdatedForm();

        private static object _eventLock = new object();
        private static int _eventsToSuppress = 0;

        public static void SuppressNextEvent()
        {
            lock (_eventLock)
            {
                // When pasting text, 2 additional WM_CLIPBOARDUPDATE events fire. We want to ignore these
                _eventsToSuppress = 2;
            }
        }

        private static void OnClipboardUpdate(EventArgs e)
        {
            var text = Clipboard.GetText();
            if (!string.IsNullOrWhiteSpace(text))
                ClipboardUpdated?.Invoke(text);
        }

        internal class ClipboardUpdatedForm : Form
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
                    lock (_eventLock)
                    {
                        if (_eventsToSuppress == 0)
                            OnClipboardUpdate(null);
                        else
                            _eventsToSuppress--;
                    }
                }
                base.WndProc(ref m);
            }
        }
    }
}
