using System;
using System.Threading;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{06c5afba-d217-425e-973d-ffac347024aa}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ClipboardManagerContext());
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

    }
}
