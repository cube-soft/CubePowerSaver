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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DummyForm());
            new DummyForm();
            Application.Run();
        }

        private static void BackgroundWorker_DoWork(Object sender, DoWorkEventArgs e) {
            Scheduler sched = new Scheduler();
            sched.Execute();
        }
    }
}
