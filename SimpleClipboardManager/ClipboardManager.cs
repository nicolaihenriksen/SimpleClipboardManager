using Microsoft.Win32;
using SimpleClipboardManager.Dialogs;
using SimpleClipboardManager.Model;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    public class ClipboardManager
    {
        //Startup registry key and value
        private const string StartupKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private const string StartupValue = "ClipboardManager";

        private const string ClipboardDataFileName = "clipboard.data";
        private const string SettingsFileName = "settings.xml";
        private List<ClipboardItem> _clipboardItems = new List<ClipboardItem>();
        public SettingsModel Settings { get; private set; }
        private PasteFromClipboardDialog _pasteFromClipboardDialog;

        public ClipboardManager()
        {
            ClipboardNotification.ClipboardUpdated += ClipboardNotification_ClipboardUpdated;
            HotKeyManager.RegisterHotKey(Keys.Insert, KeyModifiers.Control);
            HotKeyManager.RegisterHotKey(Keys.Insert, KeyModifiers.NoRepeat);
            HotKeyManager.HotKeyPressed += HotKeyManager_HotKeyPressed;
            LoadSettings();
            LoadClipboard();
        }

        private void HotKeyManager_HotKeyPressed(HotKeyEventArgs e)
        {
            if (((e.Modifiers & KeyModifiers.Control) == KeyModifiers.Control && Settings.HotKey == HotKey.Insert)
                || ((e.Modifiers & KeyModifiers.NoRepeat) == KeyModifiers.NoRepeat && Settings.HotKey == HotKey.ControlInsert))
                return;

            if (_pasteFromClipboardDialog?.Visible == true)
            {
                _pasteFromClipboardDialog.BringInFocus();
                return;
            }
            _pasteFromClipboardDialog = new PasteFromClipboardDialog(this, _clipboardItems, Settings);
            _pasteFromClipboardDialog.FormClosed += (s, e1) => _pasteFromClipboardDialog = null;
            _pasteFromClipboardDialog.ShowDialog();
        }

        private void ClipboardNotification_ClipboardUpdated(string text)
        {
            _clipboardItems.Insert(0, new ClipboardItem { Text = text });
            SaveClipboard();
        }

        public void SaveClipboard()
        {
            if (Settings.StorageEnabled)
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
                {
                    using (var fs = isoStore.OpenFile(ClipboardDataFileName, FileMode.Create))
                    {
                        var bf = new BinaryFormatter();
                        bf.Serialize(fs, _clipboardItems);
                        fs.Flush();
                    }
                }
            }
        }

        private void LoadClipboard()
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (!isoStore.FileExists(ClipboardDataFileName))
                    return;
                using (var fs = isoStore.OpenFile(ClipboardDataFileName, FileMode.Open))
                {
                    if (Settings.StorageEnabled)
                    {
                        var bf = new BinaryFormatter();
                        _clipboardItems = (List<ClipboardItem>)bf.Deserialize(fs);
                    }
                    else
                    {
                        isoStore.DeleteFile(ClipboardDataFileName);
                    }
                }
            }
        }

        public void SaveSettings()
        {
            var serializer = new DataContractSerializer(typeof(SettingsModel));
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                using (var fs = isoStore.OpenFile(SettingsFileName, FileMode.Create))
                {
                    serializer.WriteObject(fs, Settings);
                }
                // Clean up if storage was disabled
                if (!Settings.StorageEnabled && isoStore.FileExists(ClipboardDataFileName))
                    isoStore.DeleteFile(ClipboardDataFileName);

                if (Settings.StartOnBoot)
                    SetStartOnBoot();
                else
                    RemoveStartOnBoot();
            }
        }

        

        private static void SetStartOnBoot()
        {
            // Set the application to run at startup
            RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
            key.SetValue(StartupValue, Application.ExecutablePath.ToString());
        }

        private static void RemoveStartOnBoot()
        {
            // Set the application to run at startup
            RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
            try
            {
                key.DeleteValue(StartupValue);
            }
            catch { }
        }

        private void LoadSettings()
        {
            var serializer = new DataContractSerializer(typeof(SettingsModel));
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (!isoStore.FileExists(SettingsFileName))
                {
                    Settings = new SettingsModel();
                    return;
                }
                using (var fs = isoStore.OpenFile(SettingsFileName, FileMode.Open))
                {
                    try
                    {
                        Settings = (SettingsModel)serializer.ReadObject(fs);
                    }
                    catch
                    {
                        // Invalid settings file, use defaults
                        Settings = new SettingsModel();
                    }
                }
            }
        }
    }
}
