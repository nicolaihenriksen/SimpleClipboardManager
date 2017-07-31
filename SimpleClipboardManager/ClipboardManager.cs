using Microsoft.Win32;
using SimpleClipboardManager.Dialogs;
using SimpleClipboardManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    public class ClipboardManager
    {
        //Startup registry key and value
        private const string StartupKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private const string StartupValue = "SimpleClipboardManager";

        private const string ClipboardDataFileName = "clipboard.data";
        private const string SettingsFileName = "settings.xml";
        public List<ClipboardItem> ClipboardItems { get; private set; } = new List<ClipboardItem>();
        public SettingsModel Settings { get; private set; }
        private PasteFromClipboardDialog _pasteFromClipboardDialog;

        public ClipboardManager()
        {
            ClipboardNotification.ClipboardUpdated += ClipboardNotification_ClipboardUpdated;
            // Activation hotkeys
            HotKeyManager.RegisterHotKey(Keys.Insert, KeyModifiers.Control);
            HotKeyManager.RegisterHotKey(Keys.Insert, KeyModifiers.NoRepeat);
            // Paste n'th item from clipboard hotkeys
            HotKeyManager.RegisterHotKey(Keys.D1, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.D2, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.D3, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.D4, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.D5, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.D6, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.D7, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.D8, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.D9, KeyModifiers.Control | KeyModifiers.Shift);
            // Paste favorites hotkeys
            HotKeyManager.RegisterHotKey(Keys.F1, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F2, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F3, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F4, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F5, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F6, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F7, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F8, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F9, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F10, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F11, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.RegisterHotKey(Keys.F12, KeyModifiers.Control | KeyModifiers.Shift);
            HotKeyManager.HotKeyPressed += HotKeyManager_HotKeyPressed;
            LoadSettings();
            LoadClipboard();
        }

        private void HotKeyManager_HotKeyPressed(HotKeyEventArgs e)
        {
            if (e.Key == Keys.Insert) {
                HandleActivationHotKey(e.Modifiers);
                return;
            }
            if (e.Modifiers != (KeyModifiers.Control | KeyModifiers.Shift))
                return;

            if (e.Key >= Keys.D1 && e.Key <= Keys.D9)
            {
                // Paste the n'th item from the clipboard
                var index = (int)e.Key - 49;     // 49 is the ASCII equivalent for the digit 1
                if (ClipboardItems.Count > index)
                    Paste(ClipboardItems[index].Text, () => _pasteFromClipboardDialog?.Hide());
            }
            else if (e.Key >= Keys.F1 && e.Key <= Keys.F12)
            {
                // Paste the n'th item from favorites
                var index = (int)e.Key - 112;    // 112 is the ASCII equivalent for the F1 key
                var favorite = ClipboardItems.FirstOrDefault(ci => ci.Favorite == index);
                if (favorite != null)
                    Paste(favorite.Text, () => _pasteFromClipboardDialog?.Hide());
            }
        }

        private void HandleActivationHotKey(KeyModifiers modifiers)
        {
            if (Settings.HotKey == HotKey.Insert && modifiers != 0)
                return;
            if (Settings.HotKey == HotKey.ControlInsert && modifiers != KeyModifiers.Control)
                return;

            var activeAppTitle = GetActiveWindowTitle();
            if (string.IsNullOrWhiteSpace(activeAppTitle))
                return;

            if (_pasteFromClipboardDialog?.Visible == true)
            {
                _pasteFromClipboardDialog.BringInFocus();
                return;
            }
            _pasteFromClipboardDialog = new PasteFromClipboardDialog(this, activeAppTitle);
            _pasteFromClipboardDialog.FormClosed += (s, e1) => _pasteFromClipboardDialog = null;
            _pasteFromClipboardDialog.ShowDialog();
        }

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            var buf = new StringBuilder(nChars);
            var handle = SafeNativeMethods.GetForegroundWindow();
            if (SafeNativeMethods.GetWindowText(handle, buf, nChars) > 0)
            {
                return buf.ToString();
            }
            return null;
        }

        public void Paste(string text, Action prePasteAction = null)
        {
            if (!string.IsNullOrEmpty(text))
            {
                ClipboardNotification.SuppressNextEvent();
                var paster = new Paster { Text = text };
                Thread thread = new Thread(paster.DoPaste);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                prePasteAction?.Invoke();
                if (_pasteFromClipboardDialog != null)
                {
                    SendKeys.Send("^v");
                }
                else
                {
                    var hWnd = GetFocusedHandle();
                    if (hWnd != IntPtr.Zero)
                        SafeNativeMethods.PostMessage(hWnd, SafeNativeMethods.WM_PASTE, IntPtr.Zero, IntPtr.Zero);
                }
            }
            _pasteFromClipboardDialog?.Close();
        }

        private class Paster
        {
            public string Text { get; set; }

            public void DoPaste()
            {
                Clipboard.SetText(Text, TextDataFormat.Text);
            }
        }

        static IntPtr GetFocusedHandle()
        {
            var info = new SafeNativeMethods.GUITHREADINFO();
            info.cbSize = Marshal.SizeOf(info);
            if (!SafeNativeMethods.GetGUIThreadInfo(0, ref info))
                return IntPtr.Zero;
            return info.hwndFocus;
        }

        private void ClipboardNotification_ClipboardUpdated(string text)
        {
            ClipboardItems.Insert(0, new ClipboardItem { Text = text });
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
                        bf.Serialize(fs, ClipboardItems);
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
                        ClipboardItems = (List<ClipboardItem>)bf.Deserialize(fs);
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
                if (Settings.StorageEnabled)
                    SaveClipboard();
                else if (isoStore.FileExists(ClipboardDataFileName))
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
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
                key.SetValue(StartupValue, Application.ExecutablePath.ToString());
            }
            catch (Exception e)
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
                {
                    using (var fs = isoStore.OpenFile("log.txt", FileMode.Append))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(e.Message);
                            sw.WriteLine(e.StackTrace);
                        }
                    }
                }
            }
        }

        private static void RemoveStartOnBoot()
        {
            // Set the application to run at startup
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
                key.DeleteValue(StartupValue);
            }
            catch (Exception e)
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
                {
                    using (var fs = isoStore.OpenFile("log.txt", FileMode.Append))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(e.Message);
                            sw.WriteLine(e.StackTrace);
                        }
                    }
                }
            }
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
