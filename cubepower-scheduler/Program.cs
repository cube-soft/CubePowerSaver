using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CubePower {
    static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            if (System.Diagnostics.Process.GetProcessesByName(
                System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DummyForm());
            new DummyForm();
            Application.Run();
        }
    }
}
