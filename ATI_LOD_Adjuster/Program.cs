using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ATI_LOD_Adjuster
{
/*    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }*/

    static class Program
    {
/*        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_RESTORE = 9;
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);*/

        static Mutex mutex = new Mutex(true, "{6530f6b0-c02f-42fe-82d8-5d38ebb9d050}");

        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true)) {
                try {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                } finally {
                    mutex.ReleaseMutex();
                }
            } else {
                MessageBox.Show("The application is already running");
/*                Process currentProcess = Process.GetCurrentProcess();
                IntPtr hWnd = currentProcess.MainWindowHandle;
                if (IsIconic(hWnd)) {
                    ShowWindowAsync(hWnd, SW_RESTORE);
                }
                SetForegroundWindow(hWnd);*/
            }
        }
    }

}
