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
            try {
                Application.Run(new MainForm());
            }
            catch (Exception err) {
                System.Reflection.Assembly exec = System.Reflection.Assembly.GetEntryAssembly();
                string dir = System.IO.Path.GetDirectoryName(exec.Location);
                string path = dir + @"\cubepower.log";
                using (System.IO.StreamWriter output = new System.IO.StreamWriter(path)) {
                    output.WriteLine(err.Message);

                    IPowerScheme scheme;
                    if (Environment.OSVersion.Version.Major > 5) scheme = new PowerSchemeVista();
                    else scheme = new PowerSchemeXP();
                    scheme.Dump(output);
                }
            }
        }
    }
}
