using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CubePower {
    public partial class DummyForm : Form {
        public DummyForm() {
            InitializeComponent();

            this._worker = new BackgroundWorker();
            this._worker.WorkerSupportsCancellation = true;
            this._worker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            this._worker.RunWorkerAsync();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this._worker != null) this._worker.CancelAsync();
            this._scheduler.Reset();
            this.MainNotifyIcon.Visible = false;
            Application.Exit();
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Reflection.Assembly exec = System.Reflection.Assembly.GetEntryAssembly();
            string dir = System.IO.Path.GetDirectoryName(exec.Location);
            string path = dir + @"\cubepower.exe";
            if (System.IO.File.Exists(path)) {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = path;
                proc.Start();
                if (this._worker != null) this._worker.CancelAsync();
                this._scheduler.Reset();
                this.MainNotifyIcon.Visible = false;
                Application.Exit();
            }
            else {
                MessageBox.Show("cubepower.exe が見つかりませんでした。実行したディレクトリに cubepower.exe が存在するかどうか確認して下さい。",
                    "CubePowerSaver 実行エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.SettingToolStripMenuItem_Click(sender, e);
        }

        private void BackgroundWorker_DoWork(Object sender, DoWorkEventArgs e) {
            this._scheduler.Execute();
        }

        private BackgroundWorker _worker;
        private Scheduler _scheduler = new Scheduler();

        private void VersionToolStripMenuItem_Click(object sender, EventArgs e) {
            VersionDialog dialog = new VersionDialog("0.1.3");
            dialog.ShowDialog(this);
        }
    }
}
