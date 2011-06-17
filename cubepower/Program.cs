using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CubePower {
    static class Program {
        internal class NativeMethods {
            public const int SW_NORMAL = 1;

            [DllImport("user32.dll")]
            public static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

            [DllImport("user32.dll")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);
        }

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Process self = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(self.ProcessName);
            int selfid = self.Id;
            foreach (Process proc in processes) {
                if (proc.Id != selfid) {
                    NativeMethods.ShowWindow(proc.MainWindowHandle, NativeMethods.SW_NORMAL);
                    NativeMethods.SetForegroundWindow(proc.MainWindowHandle);
                    return;
                }
            }

            Process[] scueduler = Process.GetProcessesByName("cubepower-scheduler");
            foreach (Process proc in scueduler) proc.Kill();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
