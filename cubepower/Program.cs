using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CubePower {
    static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            System.Diagnostics.Process[] ps =
                System.Diagnostics.Process.GetProcessesByName("cubepower-scheduler");
            foreach (System.Diagnostics.Process p in ps) p.Kill();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
