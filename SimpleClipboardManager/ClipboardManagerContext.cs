using SimpleClipboardManager.Properties;
using System;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    class ClipboardManagerContext : ApplicationContext
    {
        private NotifyIcon _trayIcon;

        private ClipboardManager _manager;

        public ClipboardManagerContext()
        {
            _manager = new ClipboardManager();

            // Initialize Tray Icon
            _trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit),
                new MenuItem("Print", Print)
            }),
                Visible = true
            };
        }

        void Print(object sender, EventArgs e)
        {
            _manager.PrintHistory();
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            _trayIcon.Visible = false;

            Application.Exit();
        }
    }
}
