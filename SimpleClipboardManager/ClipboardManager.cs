using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    class ClipboardManager
    {

        private List<string> _history = new List<string>();

        private InterceptKeys _keyInterceptor;

        public ClipboardManager()
        {
            ClipboardNotification.ClipboardUpdated += ClipboardNotification_ClipboardUpdated;
            _keyInterceptor = new InterceptKeys();
            _keyInterceptor.KeysPressed += KeyInterceptor_KeysPressed;
        }

        private void KeyInterceptor_KeysPressed(object sender, Keys keys)
        {
            if ((keys & Keys.Insert) == Keys.Insert && Control.ModifierKeys == Keys.Control)
            {
                PrintHistory();
                var contextMenu = new ContextMenuForm(_history);
                ClipboardNotification.SuppressNextEvent();
                contextMenu.ShowDialog();
            }
        }

        private void ClipboardNotification_ClipboardUpdated(object sender, string text)
        {
            _history.Insert(0, text);
        }

        public void PrintHistory()
        {
            Debug.WriteLine("Clipboard history:");
            Debug.WriteLine(string.Join(Environment.NewLine, _history));
        }
    }
}
