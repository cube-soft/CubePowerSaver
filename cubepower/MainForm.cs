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
            
            this.ResetProfileList();
            this.InitializeScheduleList();
            
            // TODO: 設定ファイルを置く場所は LocalApp\cubepower
            System.Reflection.Assembly exec = System.Reflection.Assembly.GetEntryAssembly();
            string dir = System.IO.Path.GetDirectoryName(exec.Location);
            this._Setting.Load(dir + @"\cubepower.xml");
            this.LoadSetting(this._Setting);
            this.ValidateSchedule();
        }

        /* ----------------------------------------------------------------- */
        /// InitializeScheduleList
        /* ----------------------------------------------------------------- */
        private void InitializeScheduleList() {
            ColumnHeader first = new ColumnHeader();
            first.Text = "開始時刻";
            first.Width = 100;
            this.ScheduleListView.Columns.Add(first);
            
            ColumnHeader last = new ColumnHeader();
            last.Text = "終了時刻";
            last.Width = 100;
            this.ScheduleListView.Columns.Add(last);

            ColumnHeader name = new ColumnHeader();
            name.Text = "プロファイル名";
            name.Width = 280;
            this.ScheduleListView.Columns.Add(name);

            // NOTE: アイコンがないと上下の余白が小さくなるのでダミーを設定する．
            ImageList dummy = new ImageList();
            dummy.ImageSize = new System.Drawing.Size(1, 16);
            this.ScheduleListView.SmallImageList = dummy;
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
            ListView control = sender as ListView;
            if (control == null || control.SelectedItems.Count <= 0) return;
            
            ScheduleForm dialog = new ScheduleForm(this._Setting.Scheme);
            dialog.First = DateTime.Parse(control.SelectedItems[0].SubItems[0].Text);
            dialog.Last  = DateTime.Parse(control.SelectedItems[0].SubItems[1].Text);
            if (this._Setting.Scheme.Find(control.SelectedItems[0].SubItems[2].Text) != null) {
                dialog.ProfileName = control.SelectedItems[0].SubItems[2].Text;
            }
            
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                control.SelectedItems[0].SubItems[0].Text = dialog.First.ToString("HH:mm");
                control.SelectedItems[0].SubItems[1].Text = dialog.Last.ToString("HH:mm");
                control.SelectedItems[0].SubItems[2].Text = dialog.ProfileName;
            }
            dialog.Dispose();
            this.ScheduleModified();
        }

        /* ----------------------------------------------------------------- */
        /// CreateButton_Click
        /* ----------------------------------------------------------------- */
        private void CreateButton_Click(object sender, EventArgs e) {
            ScheduleForm dialog = new ScheduleForm(this._Setting.Scheme);
            dialog.First = DateTime.Parse("00:00");
            dialog.Last  = DateTime.Parse("23:59");
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                this.AddSchedule(dialog.First, dialog.Last, dialog.ProfileName);
            }
            dialog.Dispose();
            this.ScheduleModified();
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
                this.ScheduleListView.Items.Remove((ListViewItem)selected.Current);
            }
            this.ScheduleListView.EndUpdate();
        }

        /* ----------------------------------------------------------------- */
        /// SaveButton_Click
        /* ----------------------------------------------------------------- */
        private void SaveButton_Click(object sender, EventArgs e) {
            if (this.ValidateSchedule()) {
                this.Close();
            }
            else {
                MessageBox.Show("不正な入力が存在します。入力を確認して下さい。",
                    "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* ----------------------------------------------------------------- */
        /// ExitButton_Click
        /* ----------------------------------------------------------------- */
        private void ExitButton_Click(object sender, EventArgs e) {
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
        //  その他のメソッド
        /* ----------------------------------------------------------------- */
        #region Other methods

        private void LoadSetting(UserSetting setting) {
            this.ScheduleListView.BeginUpdate();
            this.ScheduleListView.Items.Clear();
            foreach (ScheduleItem item in setting.Schedule) {
                this.AddSchedule(item.First, item.Last, item.ProfileName);
            }
            this.ScheduleListView.EndUpdate();
            this.DefaultSettingComboBox.SelectedItem = setting.DefaultSetting.ProfileName;
        }

        /* ----------------------------------------------------------------- */
        /// AddSchedule
        /* ----------------------------------------------------------------- */
        private void AddSchedule(DateTime first, DateTime last, string profile) {
            ListViewItem item = new ListViewItem();
            item.Text = first.ToString("HH:mm");
            item.SubItems.Add(last.ToString("HH:mm"));
            item.SubItems.Add(profile);
            this.ScheduleListView.Items.Add(item);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ValidateSchedule
        ///
        /// <summary>
        /// スケジュールの開始時刻/終了時刻，プロファイル名の整合性を
        /// チェックする．チェック項目は以下の通り．
        /// 
        /// 1. 開始時刻と終了時刻の整合性が取れているか．
        ///    開始時刻が終了時刻よりも遅れている場合は赤色で表示．
        ///    終了時刻が直後のスケジュールの開始時刻よりも遅れている場合は
        ///    直後のスケジュールの開始時刻に設定する．
        /// 2. 設定されているプロファイル名が存在するかどうか．
        ///    ユーザが削除した等の理由で設定されているプロファイルが存在
        ///    しない場合は赤色で表示．
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        bool ValidateSchedule() {
            bool status = true;
            for (int i = 0; i < this.ScheduleListView.Items.Count; ++i) {
                DateTime first = DateTime.Parse(this.ScheduleListView.Items[i].SubItems[0].Text);
                DateTime last = DateTime.Parse(this.ScheduleListView.Items[i].SubItems[1].Text);
                if (i < this.ScheduleListView.Items.Count - 1) {
                    DateTime next = DateTime.Parse(this.ScheduleListView.Items[i + 1].SubItems[0].Text);
                    if (next < last) {
                        last = next;
                        this.ScheduleListView.Items[i].SubItems[1].Text = last.ToString("HH:mm");
                    }
                }

                if (first >= last || this._Setting.Scheme.Find(this.ScheduleListView.Items[i].SubItems[2].Text) == null) {
                    this.ScheduleListView.Items[i].BackColor = Color.FromArgb(255, 102, 102);
                    status = false;
                }
                else this.ScheduleListView.Items[i].BackColor = SystemColors.Window;
            }
            return status;
        }

        /* ----------------------------------------------------------------- */
        /// ScheduleModified
        /* ----------------------------------------------------------------- */
        void ScheduleModified() {
            string selected = this.DefaultSettingComboBox.SelectedItem as string;
            this.ResetProfileList();
            if (this._Setting.Scheme.Find(selected) != null) this.DefaultSettingComboBox.SelectedItem = selected;
            else this.DefaultSettingComboBox.SelectedIndex = 0;
            this.ValidateSchedule();
        }

        /* ----------------------------------------------------------------- */
        /// ResetProfileList
        /* ----------------------------------------------------------------- */
        private void ResetProfileList() {
            this.DefaultSettingComboBox.Items.Clear();
            foreach (PowerSchemeElement elem in this._Setting.Scheme.Elements) {
                this.DefaultSettingComboBox.Items.Add(elem.Name);
            }
            this.DefaultSettingComboBox.SelectedItem = this._Setting.Scheme.Active.Name;
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  変数定義
        /* ----------------------------------------------------------------- */
        #region variables
        private UserSetting _Setting = new UserSetting();
        #endregion

        #region Constant variables
        private static int PROFILE_COLUMN = 1;
        #endregion
    }
}
