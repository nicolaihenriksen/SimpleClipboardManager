using SimpleClipboardManager.Dialogs;
using SimpleClipboardManager.Properties;
using System;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    internal class ClipboardManagerContext : ApplicationContext
    {
        private NotifyIcon _trayIcon;
        private ClipboardManager _manager;

        public ClipboardManagerContext()
        {
            _manager = new ClipboardManager();

            _trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Settings", ShowSettings),
                    new MenuItem("Exit", Exit),
                }),
                Visible = true
            };
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            var dialog = new SettingsDialog(null, _manager)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _manager.SaveSettings();
            }
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            _trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
