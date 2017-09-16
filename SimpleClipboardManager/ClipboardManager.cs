using Microsoft.Win32;
using SimpleClipboardManager.Dialogs;
using SimpleClipboardManager.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    internal class ClipboardManager
    {
        //Startup registry key and value
        private const string StartupKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private const string StartupValue = "SimpleClipboardManager";

        private readonly object FileAccessLock = new object();
        private const string ClipboardDataFileName = "clipboard.data";
        private const string SettingsFileName = "settings.xml";
        public List<ClipboardItem> ClipboardItems { get; private set; } = new List<ClipboardItem>();
        public SettingsModel Settings { get; private set; }
        private PasteFromClipboardDialog _pasteFromClipboardDialog;
        private PasteQueue _pasteQueue = new PasteQueue();
        private ManualResetEventSlim _modifiersReleased = new ManualResetEventSlim();

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
            HotKeyManager.ModifiersReleased += () => _modifiersReleased.Set();
            LoadSettings();
            LoadClipboard();
        }

        private void HotKeyManager_HotKeyPressed(HotKeyEventArgs e)
        {
            try
            {
                if (e.Key == Keys.Insert)
                {
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
                        Paste(ClipboardItems[index].Text, true, () => _pasteFromClipboardDialog?.Hide());
                }
                else if (e.Key >= Keys.F1 && e.Key <= Keys.F12)
                {
                    // Paste the n'th item from favorites
                    var index = (int)e.Key - 112;    // 112 is the ASCII equivalent for the F1 key
                    var favorite = ClipboardItems.FirstOrDefault(ci => ci.Favorite == index);
                    if (favorite != null)
                        Paste(favorite.Text, true, () => _pasteFromClipboardDialog?.Hide());
                }
            }
            catch
            {
                // If an error occurs, we hope we can just continue on assuming it was a one time error :-/
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

        public void Paste(string text, bool waitForModifiersReleased = false, Action prePasteAction = null)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (prePasteAction != null)
                {
                    prePasteAction.Invoke();
                    // Allow the "hide" action to take effect before pasting. If not done, pasting from the paste dialog may fail from time to time 
                    Task.Delay(10).Wait();
                }
                var hWnd = GetFocusedControlHandle();
                if (hWnd != IntPtr.Zero)
                {
                    if (waitForModifiersReleased)
                        _modifiersReleased.Reset();
                    Task.Run(() =>
                    {
                        if (waitForModifiersReleased)
                            _modifiersReleased.Wait();
                        _pasteQueue.Add(new PasteInfo { WindowHandle = hWnd, Text = text });
                    });
                }
            }
            _pasteFromClipboardDialog?.Close();
        }

        private struct PasteInfo 
        {
            public IntPtr WindowHandle;
            public string Text;
        } 

        private class PasteQueue
        {
            private BlockingCollection<PasteInfo> _queue = new BlockingCollection<PasteInfo>();

            public PasteQueue()
            {
                Task.Run(() => HandleQueueItems());
            }

            private void HandleQueueItems()
            {
                while (!_queue.IsCompleted)
                {
                    var item = _queue.Take();

                    try
                    {
                        /*
                         * NOTE: The code below assumes it is able to post WM_CHAR messages for the whole string to paste
                         * before the users moves the focus away from the control. If focus is moved to another control while
                         * iterating the characters in the string, the remaining characters may be "pasted" into the newly
                         * focused control (if it accepts key input)
                         */

                        // "Paste" each character one by one
                        foreach (var c in item.Text)
                            SafeNativeMethods.PostMessage(item.WindowHandle, SafeNativeMethods.WM_CHAR, new IntPtr(c), IntPtr.Zero);
                    }
                    catch
                    {
                        // If anything goes wrong while "pasting", we ignore it and hope we continue on :-/
                    }
                }
            }

            public void Add(PasteInfo item)
            {
                _queue.Add(item);
            }
        }

        private IntPtr GetFocusedControlHandle()
        {
            IntPtr activeWindowHandle = SafeNativeMethods.GetForegroundWindow();
            IntPtr focusedControlHandle = IntPtr.Zero;
            IntPtr activeWindowThread = SafeNativeMethods.GetWindowThreadProcessId(activeWindowHandle, IntPtr.Zero);
            var sync = new AutoResetEvent(false);
            ClipboardNotification.MonitorForm.Invoke(new Action(() =>
            {
                IntPtr thisWindowThread = SafeNativeMethods.GetWindowThreadProcessId(ClipboardNotification.MonitorForm.Handle, IntPtr.Zero);
                SafeNativeMethods.AttachThreadInput(activeWindowThread, thisWindowThread, true);
                focusedControlHandle = SafeNativeMethods.GetFocus();
                SafeNativeMethods.AttachThreadInput(activeWindowThread, thisWindowThread, false);
                sync.Set();
            }));
            sync.WaitOne();
            return focusedControlHandle;
        }

        private void ClipboardNotification_ClipboardUpdated(string text)
        {
            // Ignore continued copies to avoid spamming the clipboard with the same items
            if (ClipboardItems.Count > 0 && ClipboardItems[0].Text == text)
                return;

            ClipboardItems.Insert(0, new ClipboardItem { Text = text });
            TruncateClipboardIfNeeded();
            SaveClipboard();
        }

        public void SaveClipboard()
        {
            if (Settings.StorageEnabled)
            {
                lock (FileAccessLock)
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
        }

        private void LoadClipboard()
        {
            lock (FileAccessLock)
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
        }

        public void SaveSettings()
        {
            TruncateClipboardIfNeeded();
            var serializer = new DataContractSerializer(typeof(SettingsModel));
            lock (FileAccessLock)
            {
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
        }

        private void TruncateClipboardIfNeeded()
        {
            var numItemsToRemove = ClipboardItems.Count - Settings.MaxStoredItems;
            if (numItemsToRemove <= 0)
                return;
            var copy = new List<ClipboardItem>(ClipboardItems.Where(ci => ci.Favorite.HasValue == false));
            copy.Reverse();
            for (int i=0; i<numItemsToRemove; i++)
            {
                var itemToRemove = copy[i];
                ClipboardItems.Remove(itemToRemove);
            }
        }

        private static void SetStartOnBoot()
        {
            try
            {
                // Set the application to run at startup
                RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
                key.SetValue(StartupValue, Application.ExecutablePath.ToString());
            }
            catch
            {
                // Ignore
            }
        }

        private static void RemoveStartOnBoot()
        {
            try
            {
                // Set the application to run at startup
                RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
                key.DeleteValue(StartupValue);
            }
            catch
            {
                // Ignore
            }
        }

        private void LoadSettings()
        {
            var serializer = new DataContractSerializer(typeof(SettingsModel));
            lock (FileAccessLock)
            {
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
}
