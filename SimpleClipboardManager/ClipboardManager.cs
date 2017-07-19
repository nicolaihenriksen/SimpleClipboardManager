using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    public class ClipboardManager
    {
        private const string ClipboardDataFileName = "clipboard.data";
        private List<ClipboardItem> _clipboardItems = new List<ClipboardItem>();

        private ContextMenuForm _contextMenuForm;

        public ClipboardManager()
        {
            ClipboardNotification.ClipboardUpdated += ClipboardNotification_ClipboardUpdated;
            //InterceptKeys.KeysPressed += KeyInterceptor_KeysPressed;
            HotKeyManager.RegisterHotKey(Keys.Insert, KeyModifiers.Control);
            HotKeyManager.HotKeyPressed += HotKeyManager_HotKeyPressed;
            LoadClipboard();
        }

        private void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            if (_contextMenuForm?.Visible == true)
            {
                //_contextMenuForm.Invoke(new Action(_contextMenuForm.BringInFocus));
                _contextMenuForm.BringInFocus();
            }
            else
            {
                _contextMenuForm = new ContextMenuForm(this, _clipboardItems);
                _contextMenuForm.FormClosed += (s, e1) => _contextMenuForm = null;
                try
                {
                    //_contextMenuForm.Invoke(new Action(() => _contextMenuForm.ShowDialog()));
                    _contextMenuForm.ShowDialog();
                }
                catch
                {

                }
            }
        }

        private void ClipboardNotification_ClipboardUpdated(object sender, string text)
        {
            _clipboardItems.Insert(0, new ClipboardItem { Text = text });
            SaveClipboard();
        }

        public void SaveClipboard()
        {
            using (var fs = new FileStream(ClipboardDataFileName, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, _clipboardItems);
                fs.Flush();
            }
        }

        public void LoadClipboard()
        {
            if (File.Exists(ClipboardDataFileName))
            {
                using (var fs = new FileStream(ClipboardDataFileName, FileMode.Open))
                {
                    var bf = new BinaryFormatter();
                    _clipboardItems = (List<ClipboardItem>)bf.Deserialize(fs);
                }
            }
        }
    }
}
