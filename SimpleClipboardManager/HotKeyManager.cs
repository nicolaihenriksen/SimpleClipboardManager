using System;
using System.Threading;
using System.Windows.Forms;
using static SimpleClipboardManager.SafeNativeMethods;

namespace SimpleClipboardManager
{
    internal static class HotKeyManager
    {
        public static event Action<HotKeyEventArgs> HotKeyPressed;
        public static event Action ModifiersReleased;

        private delegate void RegisterHotKeyDelegate(IntPtr hwnd, int id, uint modifiers, uint key);
        private delegate void UnRegisterHotKeyDelegate(IntPtr hwnd, int id);

        private static volatile MessageWindow _wnd;
        private static volatile IntPtr _hwnd;
        private static ManualResetEvent _windowReadyEvent = new ManualResetEvent(false);
        private static int _id = 0;
        private static bool _isHotkeyPressed;

        static HotKeyManager()
        {
            Thread messageLoop = new Thread(delegate ()
            {
                Application.Run(new MessageWindow());
            })
            {
                Name = "MessageLoopThread",
                IsBackground = true
            };
            messageLoop.Start();
        }

        public static int RegisterHotKey(Keys key, KeyModifiers modifiers)
        {
            _windowReadyEvent.WaitOne();
            int id = Interlocked.Increment(ref _id);
            _wnd.Invoke(new RegisterHotKeyDelegate(RegisterHotKeyInternal), _hwnd, id, (uint)modifiers, (uint)key);
            return id;
        }

        public static void UnregisterHotKey(int id)
        {
            _wnd.Invoke(new UnRegisterHotKeyDelegate(UnRegisterHotKeyInternal), _hwnd, id);
        }

        private static void RegisterHotKeyInternal(IntPtr hwnd, int id, uint modifiers, uint key)
        {
            SafeNativeMethods.RegisterHotKey(hwnd, id, modifiers, key);
        }

        private static void UnRegisterHotKeyInternal(IntPtr hwnd, int id)
        {
            SafeNativeMethods.UnregisterHotKey(_hwnd, id);
        }

        private static void OnHotKeyPressed(HotKeyEventArgs e)
        {
            if (e.Key == Keys.Insert || !_isHotkeyPressed)
            {
                _isHotkeyPressed = true;
                HotKeyPressed?.Invoke(e);
            }
        }

        private static void OnModifiersReleased()
        {
            _isHotkeyPressed = false;
            ModifiersReleased?.Invoke();
        }

        private class MessageWindow : Form
        {
            private HookHandlerDelegate _callback;
            private IntPtr _hookId;

            public MessageWindow()
            {
                _wnd = this;
                _hwnd = Handle;
                _windowReadyEvent.Set();
                _callback = new HookHandlerDelegate(HookCallback);
                _hookId = SetWindowsHookEx(WH_KEYBOARD_LL, _callback, IntPtr.Zero, 0);
            }

            protected override void Dispose(bool disposing)
            {
                UnhookWindowsHookEx(_hookId);
                base.Dispose(disposing);
            }

            private IntPtr HookCallback(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
            {
                IntPtr retVal = CallNextHookEx(_hookId, nCode, wParam, ref lParam);
                if (nCode >= 0)
                {
                    if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
                    {
                        if (lParam.vkCode >= 160 && lParam.vkCode <= 161)
                        {
                            // Shift key is released
                            if (ModifierKeys == Keys.Shift)
                            {
                                // Shift was the only modifier left! (if both SHIFTs were pressed, this will fire when one is released. Unlikely scenario so nothing is done to support it)
                                OnModifiersReleased();
                            }
                        }
                        if (lParam.vkCode >= 162 && lParam.vkCode <= 163)
                        {
                            // Control key is released
                            if (ModifierKeys == Keys.Control)
                            {
                                // Control was the only modifier left (if both CTRLs were pressed, this will fire when one is released. Unlikely scenario so nothing is done to support it)
                                OnModifiersReleased();
                            }
                        }
                    }
                }
                return retVal;
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_HOTKEY)
                {
                    HotKeyEventArgs e = new HotKeyEventArgs(m.LParam);
                    OnHotKeyPressed(e);
                }
                base.WndProc(ref m);
            }

            protected override void SetVisibleCore(bool value)
            {
                // Ensure the window never becomes visible
                base.SetVisibleCore(false);
            }
        }
    }

    internal class HotKeyEventArgs : EventArgs
    {
        public readonly Keys Key;
        public readonly KeyModifiers Modifiers;

        public HotKeyEventArgs(Keys key, KeyModifiers modifiers)
        {
            Key = key;
            Modifiers = modifiers;
        }

        public HotKeyEventArgs(IntPtr hotKeyParam)
        {
            uint param = (uint)hotKeyParam.ToInt64();
            Key = (Keys)((param & 0xffff0000) >> 16);
            Modifiers = (KeyModifiers)(param & 0x0000ffff);
        }
    }

    [Flags]
    internal enum KeyModifiers
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8,
        NoRepeat = 0x4000
    }
}