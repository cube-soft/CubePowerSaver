/* ------------------------------------------------------------------------- */
/*
 *  MainForm.cs
 *
 *  Copyright (c) 2011 CubeSoft Inc. All rights reserved.
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see < http://www.gnu.org/licenses/ >.
 */
/* ------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace CubePower {
    /* --------------------------------------------------------------------- */
    /// MainForm
    /* --------------------------------------------------------------------- */
    public partial class MainForm : Form {
        /* ----------------------------------------------------------------- */
        //  初期化
        /* ----------------------------------------------------------------- */
        #region Initialize operations

        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public MainForm() {
            InitializeComponent();
            
            this._DummySplitContainer.Panel2Collapsed = true;
            this.InitializeScheduleList();
            
            // TODO: 設定ファイルを置く場所は LocalApp\cubepower
            System.Reflection.Assembly exec = System.Reflection.Assembly.GetEntryAssembly();
            string dir = System.IO.Path.GetDirectoryName(exec.Location);
            string path = dir + @"\cubepower.xml";
            this.LoadSetting(path);
        }

        /* ----------------------------------------------------------------- */
        /// InitializeScheduleList
        /* ----------------------------------------------------------------- */
        private void InitializeScheduleList() {
            ColumnHeader first = new ColumnHeader();
            first.Text = "時間";
            first.Width = 100;
            this.ScheduleListView.Columns.Add(first);
            
            ColumnHeader name = new ColumnHeader();
            name.Text = "プロファイル";
            name.Width = 150;
            this.ScheduleListView.Columns.Add(name);

            ColumnHeader monitor = new ColumnHeader();
            monitor.Text = "モニタの電源を切る";
            monitor.Width = 120;
            this.ScheduleListView.Columns.Add(monitor);

            ColumnHeader disk = new ColumnHeader();
            disk.Text = "ディスクの電源を切る";
            disk.Width = 120;
            this.ScheduleListView.Columns.Add(disk);

            ColumnHeader standby = new ColumnHeader();
            standby.Text = "システムスタンバイ";
            standby.Width = 120;
            this.ScheduleListView.Columns.Add(standby);

            ColumnHeader hibernation = new ColumnHeader();
            hibernation.Text = "システム休止状態";
            hibernation.Width = 120;
            this.ScheduleListView.Columns.Add(hibernation);

            ColumnHeader dim = new ColumnHeader();
            dim.Text = "モニタを暗くする";
            dim.Width = 120;
            this.ScheduleListView.Columns.Add(dim);

            // NOTE: アイコンがないと上下の余白が小さくなるのでダミーを設定する．
            ImageList dummy = new ImageList();
            dummy.ImageSize = new System.Drawing.Size(1, 16);
            this.ScheduleListView.SmallImageList = dummy;

            this.CreateContextMenu();
        }

        #endregion // Initialize operations

        /* ----------------------------------------------------------------- */
        //  各種ボタンのイベント・ハンドラ
        /* ----------------------------------------------------------------- */
        #region Button event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// ScheduleListView_MouseDoubleClick
        ///
        /// <summary>
        /// 既に登録されているスケジュールがダブルクリックされたときの
        /// イベントハンドラ．スケジュールの修正を行う．
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ScheduleListView_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.PropertyButton_Click(sender, e);
        }

        /* ----------------------------------------------------------------- */
        /// PropertyButton_Click
        /* ----------------------------------------------------------------- */
        private void PropertyButton_Click(object sender, EventArgs e) {
            ListView control = this.ScheduleListView;
            if (control.SelectedItems.Count <= 0) return;

            ScheduleForm dialog = new ScheduleForm(this._setting.Scheme);
            if (this._schedule.ContainsKey(control.SelectedItems[0].Text)) {
                ScheduleItem item = this._schedule[control.SelectedItems[0].Text];
                if (control.SelectedItems[0].Text == DEFAULT_SETTING_NAME) dialog.DefaultSetting = true;
                else {
                    dialog.First = item.First;
                    dialog.Last = item.Last;
                }
                dialog.ProfileName = item.ProfileName;
                if (item.ProfileName == CUSTOM_PROFILE) dialog.PowerSetting = item.ACValues;
            }

            if (dialog.ShowDialog(this) == DialogResult.OK) {
                ScheduleItem item = this.CreateScheduleItem(dialog);
                string key = dialog.DefaultSetting ? DEFAULT_SETTING_NAME : dialog.First.ToString(TIME_FORMAT) + " - " + dialog.Last.ToString(TIME_FORMAT);
                ListViewItem row = null;
                if (dialog.DefaultSetting) {
                    foreach (ListViewItem pos in this.ScheduleListView.Items) {
                        if (pos.Text == DEFAULT_SETTING_NAME) {
                            row = pos;
                            break;
                        }
                    }
                }
                else {
                    row = control.SelectedItems[0];
                    this._schedule.Remove(control.SelectedItems[0].Text);
                }
                this.UpdateSchedule(key, item, row);
                this._status = CloseStatus.Confirm;
            }
            dialog.Dispose();
        }

        /* ----------------------------------------------------------------- */
        /// CreateButton_Click
        /* ----------------------------------------------------------------- */
        private void CreateButton_Click(object sender, EventArgs e) {
            ScheduleForm dialog = new ScheduleForm(this._setting.Scheme);
            dialog.First = DateTime.Parse("00:00");
            dialog.Last  = DateTime.Parse("23:59");
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                ScheduleItem item = this.CreateScheduleItem(dialog);
                string key = dialog.DefaultSetting ? DEFAULT_SETTING_NAME : dialog.First.ToString(TIME_FORMAT) + " - " + dialog.Last.ToString(TIME_FORMAT);
                ListViewItem row = null;
                foreach (ListViewItem pos in this.ScheduleListView.Items) {
                    if (key == pos.Text) {
                        row = pos;
                        break;
                    }
                }
                this.UpdateSchedule(key, item, row);
                this._status = CloseStatus.Confirm;
            }
            dialog.Dispose();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// DeleteButton_Click
        ///
        /// <summary>
        /// 既に登録されているスケジュールを削除する．
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void DeleteButton_Click(object sender, EventArgs e) {
            this.ScheduleListView.BeginUpdate();
            System.Collections.IEnumerator selected = this.ScheduleListView.SelectedItems.GetEnumerator();
            while (selected.MoveNext()) {
                ListViewItem item = selected.Current as ListViewItem;
                if (item == null) continue;
                this._schedule.Remove(item.Text);
                this.ScheduleListView.Items.Remove(item);
                this._status = CloseStatus.Confirm;
            }
            this.ScheduleListView.EndUpdate();
        }

        /* ----------------------------------------------------------------- */
        /// SaveButton_Click
        /* ----------------------------------------------------------------- */
        private void SaveButton_Click(object sender, EventArgs e) {
            this._status = CloseStatus.Save;
            this.Close();
        }

        /* ----------------------------------------------------------------- */
        /// ExitButton_Click
        /* ----------------------------------------------------------------- */
        private void ExitButton_Click(object sender, EventArgs e) {
            this._status = CloseStatus.Cancel;
            this.Close();
        }

        #endregion // Button event handlers

        /* ----------------------------------------------------------------- */
        //  メニューのイベント・ハンドラ
        /* ----------------------------------------------------------------- */
        #region Menu event handlers

        /* ----------------------------------------------------------------- */
        /// ExitToolStripMenuItem_Click
        /* ----------------------------------------------------------------- */
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion // Menu event handlers

        /* ----------------------------------------------------------------- */
        //  その他のイベント・ハンドラ
        /* ----------------------------------------------------------------- */
        #region Other event handlers

        /* ----------------------------------------------------------------- */
        /// ImportToolStripMenuItem_Click
        /* ----------------------------------------------------------------- */
        private void ImportToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML ファイル (*.xml)|*.xml|すべてのファイル (*.*)|*.*";
            dialog.CheckPathExists = true;
            if (dialog.ShowDialog() == DialogResult.OK) {
                this.LoadSetting(dialog.FileName);
                this._status = CloseStatus.Confirm;
            }
        }

        /* ----------------------------------------------------------------- */
        /// ExportToolStripMenuItem_Click
        /* ----------------------------------------------------------------- */
        private void ExportToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = EXPORT_FILENAME;
            dialog.Filter = "XML ファイル (*.xml)|*.xml|すべてのファイル (*.*)|*.*";
            dialog.OverwritePrompt = true;
            if (dialog.ShowDialog() == DialogResult.OK) {
                this.SaveSetting(dialog.FileName);
            }
        }

        #endregion
        
        /* ----------------------------------------------------------------- */
        //  その他のメソッド
        /* ----------------------------------------------------------------- */
        #region Other methods

        /* ----------------------------------------------------------------- */
        /// LoadSetting
        /* ----------------------------------------------------------------- */
        private void LoadSetting(string path) {
            this._setting.Load(path);
            this.ScheduleListView.BeginUpdate();
            this.ScheduleListView.Items.Clear();
            this._schedule.Clear();
            this.AddSchedule(DEFAULT_SETTING_NAME, this._setting.DefaultSetting);
            foreach (ScheduleItem item in this._setting.Schedule) {
                string key = item.First.ToString(TIME_FORMAT) + " - " + item.Last.ToString(TIME_FORMAT);
                this.AddSchedule(key, item);
            }
            this.ScheduleListView.EndUpdate();
            this.ValidateSchedule();
        }

        /* ----------------------------------------------------------------- */
        /// SaveSetting
        /* ----------------------------------------------------------------- */
        private void SaveSetting(string path) {
            UserSetting setting = new UserSetting();
            foreach (KeyValuePair<string, ScheduleItem> item in this._schedule) {
                if (item.Key == DEFAULT_SETTING_NAME) setting.DefaultSetting = item.Value;
                else setting.Schedule.Add(item.Value);
            }
            setting.Save(path);
        }

        /* ----------------------------------------------------------------- */
        /// AddSchedule
        /* ----------------------------------------------------------------- */
        private void AddSchedule(string key, ScheduleItem value) {
            if (!this._schedule.ContainsKey(key)) {
                ListViewItem item = new ListViewItem();
                item.Text = key;
                item.SubItems.Add(value.ProfileName);
                item.SubItems.Add(Appearance.ExpireTypeString(Translator.SecondToExpireType(value.ACValues.MonitorTimeout)));
                item.SubItems.Add(Appearance.ExpireTypeString(Translator.SecondToExpireType(value.ACValues.DiskTimeout)));
                item.SubItems.Add(Appearance.ExpireTypeString(Translator.SecondToExpireType(value.ACValues.StandByTimeout)));
                item.SubItems.Add(Appearance.ExpireTypeString(Translator.SecondToExpireType(value.ACValues.HibernationTimeout)));
                item.SubItems.Add(Appearance.ExpireTypeString(Translator.SecondToExpireType(value.ACValues.DimTimeout)));
                this.ScheduleListView.Items.Add(item);
                this._schedule.Add(key, value);
                this.ValidateSchedule();
            }
        }

        private void UpdateSchedule(string key, ScheduleItem value, ListViewItem dest) {
            if (dest == null) this.AddSchedule(key, value);
            else {
                if (this._schedule.ContainsKey(key)) this._schedule[key] = value;
                else this._schedule.Add(key, value);
                dest.Text = key;
                dest.SubItems[1].Text = value.ProfileName;
                dest.SubItems[2].Text = Appearance.ExpireTypeString(Translator.SecondToExpireType(value.ACValues.MonitorTimeout));
                dest.SubItems[3].Text = Appearance.ExpireTypeString(Translator.SecondToExpireType(value.ACValues.DiskTimeout));
                dest.SubItems[4].Text = Appearance.ExpireTypeString(Translator.SecondToExpireType(value.ACValues.StandByTimeout));
                dest.SubItems[5].Text = Appearance.ExpireTypeString(Translator.SecondToExpireType(value.ACValues.HibernationTimeout));
                dest.SubItems[6].Text = Appearance.ExpireTypeString(Translator.SecondToExpireType(value.ACValues.DimTimeout));
                this.ValidateSchedule();
            }
        }

        /* ----------------------------------------------------------------- */
        /// ValidateSchedule
        /* ----------------------------------------------------------------- */
        private bool ValidateSchedule() {
            bool status = true;

            // 前回のチェック結果をリセットする．
            foreach (ListViewItem item in this.ScheduleListView.Items) {
                item.BackColor = System.Drawing.SystemColors.Window;
            }

            for (int i = 0; i < this.ScheduleListView.Items.Count; i++) {
                bool row_status = true;
                string key = this.ScheduleListView.Items[i].Text;
                if (!this._schedule.ContainsKey(key)) row_status = false;
                else {
                    ScheduleItem sched = this._schedule[key];
                    if (sched.ProfileName != CUSTOM_PROFILE && this._setting.Scheme.Find(sched.ProfileName) == null) {
                        sched.ProfileName = CUSTOM_PROFILE;
                        this.ScheduleListView.Items[i].SubItems[1].Text = CUSTOM_PROFILE;
                    }

                    if (key != DEFAULT_SETTING_NAME) {
                        for (int j = i + 1; j < this.ScheduleListView.Items.Count; j++) {
                            if (this.ScheduleListView.Items[j].Text == DEFAULT_SETTING_NAME) continue;
                            if (!this._schedule.ContainsKey(this.ScheduleListView.Items[j].Text)) continue;
                            ScheduleItem compared = this._schedule[this.ScheduleListView.Items[j].Text];
                            if (sched.Last > compared.First) {
                                this.ScheduleListView.Items[j].BackColor = System.Drawing.Color.FromArgb(ERROR_COLOR);
                                row_status = false;
                            }
                        }
                    }
                }

                if (!row_status) this.ScheduleListView.Items[i].BackColor = System.Drawing.Color.FromArgb(ERROR_COLOR);
                status &= row_status;
            }

            return status;
        }

        private void RecommendSchedule() {
            this.ScheduleListView.BeginUpdate();
            this.ScheduleListView.Items.Clear();
            this._schedule.Clear();

            string key = null;

            // デフォルトの設定
            ScheduleItem sched = new ScheduleItem();
            sched.First = DateTime.Parse("00:00");
            sched.Last  = DateTime.Parse("23:59");
            sched.ProfileName = "カスタム";
            sched.ACValues.MonitorTimeout = 3600;
            sched.ACValues.DiskTimeout = 3600;
            sched.ACValues.StandByTimeout = 3600;
            sched.ACValues.HibernationTimeout = 0;
            this.AddSchedule(DEFAULT_SETTING_NAME, sched);

            // 深夜の設定
            sched = new ScheduleItem();
            sched.First = DateTime.Parse("00:00");
            sched.Last  = DateTime.Parse("8:00");
            sched.ProfileName = "カスタム";
            sched.ACValues.MonitorTimeout = 300;
            sched.ACValues.DiskTimeout = 600;
            sched.ACValues.StandByTimeout = 600;
            sched.ACValues.HibernationTimeout = 0;
            key = sched.First.ToString("HH:mm") + " - " + sched.Last.ToString("HH:mm");
            this.AddSchedule(key, sched);

            // お昼の設定
            sched = new ScheduleItem();
            sched.First = DateTime.Parse("12:00");
            sched.Last = DateTime.Parse("13:00");
            sched.ProfileName = "カスタム";
            sched.ACValues.MonitorTimeout = 300;
            sched.ACValues.DiskTimeout = 600;
            sched.ACValues.StandByTimeout = 600;
            sched.ACValues.HibernationTimeout = 0;
            key = sched.First.ToString("HH:mm") + " - " + sched.Last.ToString("HH:mm");
            this.AddSchedule(key, sched);

            // 退社後の設定
            sched = new ScheduleItem();
            sched.First = DateTime.Parse("21:00");
            sched.Last = DateTime.Parse("23:59");
            sched.ProfileName = "カスタム";
            sched.ACValues.MonitorTimeout = 300;
            sched.ACValues.DiskTimeout = 600;
            sched.ACValues.StandByTimeout = 600;
            sched.ACValues.HibernationTimeout = 0;
            key = sched.First.ToString("HH:mm") + " - " + sched.Last.ToString("HH:mm");
            this.AddSchedule(key, sched);

            this._status = CloseStatus.Confirm;

            this.ScheduleListView.EndUpdate();
            this.ValidateSchedule();
        }

        private ScheduleItem CreateScheduleItem(ScheduleForm dialog) {
            ScheduleItem dest = new ScheduleItem();
            dest.First = dialog.First;
            dest.Last = dialog.Last;
            dest.ProfileName = dialog.ProfileName;
            dest.ACValues = dialog.PowerSetting;
            return dest;
        }

        private void CreateContextMenu() {
            ContextMenuStrip context = new ContextMenuStrip();

            ToolStripMenuItem create = new ToolStripMenuItem();
            create.Text = "新しいスケジュールを追加";
            create.Click += new EventHandler(CreateButton_Click);
            context.Items.Add(create);

            ToolStripMenuItem remove = new ToolStripMenuItem();
            remove.Text = "削除";
            remove.Click += new EventHandler(DeleteButton_Click);
            context.Items.Add(remove);

            context.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem property = new ToolStripMenuItem();
            property.Text = "プロパティ";
            property.Click += new EventHandler(PropertyButton_Click);
            context.Items.Add(property);

            this.ScheduleListView.ContextMenuStrip = context;
        }

        private void ExecScheduler() {
            System.Reflection.Assembly exec = System.Reflection.Assembly.GetEntryAssembly();
            string dir = System.IO.Path.GetDirectoryName(exec.Location);
            string path = dir + @"\cubepower-scheduler.exe";
            if (System.IO.File.Exists(path)) {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = path;
                proc.Start();
            }
            else {
                MessageBox.Show("cubepower-scheduler.exe が見つかりませんでした。実行したディレクトリに cubepower-scheduler.exe が存在するかどうか確認して下さい。",
                    "CubePowerSaver 実行エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  変数
        /* ----------------------------------------------------------------- */
        #region Constant variables
        private const string CUSTOM_PROFILE = "カスタム";
        private const string DEFAULT_SETTING_NAME = "その他の時間";
        private const string TIME_FORMAT = "HH:mm";
        private const string EXPORT_FILENAME = "CubePowerSaver の設定.xml";
        private const int ERROR_COLOR = 0xff6666;
        private enum CloseStatus {
            Confirm = 0,
            Save,
            Cancel
        }
        #endregion

        /* ----------------------------------------------------------------- */
        //  変数
        /* ----------------------------------------------------------------- */
        #region variables
        private UserSetting _setting = new UserSetting();
        private Dictionary<string, ScheduleItem> _schedule = new Dictionary<string, ScheduleItem>();
        private CloseStatus _status = CloseStatus.Cancel;
        #endregion

        private void VersionToolStripMenuItem_Click(object sender, EventArgs e) {
            VersionDialog dialog = new VersionDialog("0.1.1");
            dialog.ShowDialog(this);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            bool status = false;
            if (this._status == CloseStatus.Confirm) {
                if (MessageBox.Show("設定を保存しますか？", "設定の保存の確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                    status = true;
                }
            }
            else if (this._status == CloseStatus.Save) status = true;

            if (status) {
                if (this.ValidateSchedule()) {
                    System.Reflection.Assembly exec = System.Reflection.Assembly.GetEntryAssembly();
                    string dir = System.IO.Path.GetDirectoryName(exec.Location);
                    this.SaveSetting(dir + @"\cubepower.xml");
                    this.ExecScheduler();
                }
                else {
                    MessageBox.Show("不正な入力が存在します。入力を確認して下さい。",
                        "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            else this.ExecScheduler();
        }

        private void ScheduleListView_SelectedIndexChanged(object sender, EventArgs e) {
            ListView control = sender as ListView;
            if (control == null) return;

            this.DeleteButton.Enabled = (control.SelectedItems.Count > 0);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.All;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                foreach (string path in (string[])e.Data.GetData(DataFormats.FileDrop)) {
                    if (MessageBox.Show(path + " から設定をインポートします。よろしいですか？", "設定のインポート", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                        this.LoadSetting(path);
                        this._status = CloseStatus.Confirm;
                    }
                    break;
                }
            }
        }

        private void RecommendButton_Click(object sender, EventArgs e) {
            this.RecommendSchedule();
        }

    }
}
