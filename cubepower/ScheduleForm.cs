/* ------------------------------------------------------------------------- */
/*
 *  ScheduleForm.cs
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

namespace CubePower {
    /* --------------------------------------------------------------------- */
    /// ScheduleForm
    /* --------------------------------------------------------------------- */
    public partial class ScheduleForm : Form {
        /* ----------------------------------------------------------------- */
        //  初期化
        /* ----------------------------------------------------------------- */
        #region Initialize operations

        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public ScheduleForm() {
            this.Initialize();
        }

        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public ScheduleForm(PowerScheme scheme) {
            this._Scheme = scheme;
            this.Initialize();
        }

        /* ----------------------------------------------------------------- */
        /// Initialize
        /* ----------------------------------------------------------------- */
        private void Initialize() {
            InitializeComponent();
            this.InitializeComboAppearance();
            this._EnableComboEvents = true;
        }

        /* ----------------------------------------------------------------- */
        /// InitializeComboAppearance
        /* ----------------------------------------------------------------- */
        private void InitializeComboAppearance() {
            this.ResetProfileList();
            this.ProfileComboBox.SelectedItem = this._Scheme.Active.Name;

            // 電源設定
            this.MonitorComboBox.Items.Clear();
            foreach (Parameter.ExpireTypes id in Enum.GetValues(typeof(Parameter.ExpireTypes))) {
                this.MonitorComboBox.Items.Add(Appearance.ExpireTypeString(id));
            }

            this.DiskComboBox.Items.Clear();
            foreach (Parameter.ExpireTypes id in Enum.GetValues(typeof(Parameter.ExpireTypes))) {
                this.DiskComboBox.Items.Add(Appearance.ExpireTypeString(id));
            }

            this.StandByComboBox.Items.Clear();
            foreach (Parameter.ExpireTypes id in Enum.GetValues(typeof(Parameter.ExpireTypes))) {
                this.StandByComboBox.Items.Add(Appearance.ExpireTypeString(id));
            }

            this.HibernationComboBox.Items.Clear();
            foreach (Parameter.ExpireTypes id in Enum.GetValues(typeof(Parameter.ExpireTypes))) {
                this.HibernationComboBox.Items.Add(Appearance.ExpireTypeString(id));
            }

            this.LoadSetting(this._Scheme.Active);
        }

        #endregion // Initialize operations

        /* ----------------------------------------------------------------- */
        //  プロパティ一覧
        /* ----------------------------------------------------------------- */
        #region Properties

        /* ----------------------------------------------------------------- */
        /// First
        /* ----------------------------------------------------------------- */
        public DateTime First {
            get { return this.FirstDateTimePicker.Value; }
            set { this.FirstDateTimePicker.Value = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Last
        /* ----------------------------------------------------------------- */
        public DateTime Last {
            get { return this.LastDateTimePicker.Value; }
            set { this.LastDateTimePicker.Value = value; }
        }

        /* ----------------------------------------------------------------- */
        /// ProfileName
        /* ----------------------------------------------------------------- */
        public string ProfileName {
            get { return this.ProfileComboBox.SelectedItem as string; }
            set { this.ProfileComboBox.SelectedItem = value; }
        }

        #endregion // Properties

        /* ----------------------------------------------------------------- */
        //  各種イベントハンドラ
        /* ----------------------------------------------------------------- */
        #region Event handlers

        /* ----------------------------------------------------------------- */
        /// SaveButton_Click
        /* ----------------------------------------------------------------- */
        private void SaveButton_Click(object sender, EventArgs e) {
            if (this._CustomizedItem != null) this.SaveProfile(this.FirstDateTimePicker.Text + "からの電源設定");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        /* ----------------------------------------------------------------- */
        /// SaveAsButton_Click
        /* ----------------------------------------------------------------- */
        private void SaveAsButton_Click(object sender, EventArgs e) {
            if (this._CustomizedItem == null) return;
            SaveProfileForm dialog = new SaveProfileForm();
            dialog.ProfileName = this.FirstDateTimePicker.Text + "からの電源設定";
            if (dialog.ShowDialog(this) == DialogResult.OK) this.SaveProfile(dialog.ProfileName);
        }

        /* ----------------------------------------------------------------- */
        /// DeleteButton_Click
        /* ----------------------------------------------------------------- */
        private void DeleteButton_Click(object sender, EventArgs e) {
            this._Scheme.Remove(this.ProfileComboBox.SelectedItem as string);
            this.ResetProfileList();
            this.ProfileComboBox.SelectedIndex = 0;
        }
        
        /* ----------------------------------------------------------------- */
        /// ExitButton_Click
        /* ----------------------------------------------------------------- */
        private void ExitButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /* ----------------------------------------------------------------- */
        /// ProfileComboBox_SelectedIndexChanged
        /* ----------------------------------------------------------------- */
        private void ProfileComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox control = sender as ComboBox;
            if (control == null || !this._EnableComboEvents) return;

            bool customize = this._CustomizedItem != null && this._CustomizedItem.Name == (string)control.SelectedItem;
            PowerSchemeElement selected = customize ? this._CustomizedItem : this._Scheme.Find(control.SelectedItem as string);
            this.LoadSetting(selected);
            this.SaveAsButton.Enabled = customize;
        }

        /* ----------------------------------------------------------------- */
        /// DetailComboBox_SelectedIndexChanged
        /* ----------------------------------------------------------------- */
        private void DetailComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox control = sender as ComboBox;
            if (control == null || !this._EnableComboEvents) return;
            this.CustomizeProfile();
            this.ProfileComboBox.SelectedItem = _CustomizedItem.Name;
        }

        #endregion // Event handlers

        /* ----------------------------------------------------------------- */
        //  その他のメソッド
        /* ----------------------------------------------------------------- */
        #region Other methods

        /* ----------------------------------------------------------------- */
        /// LoadSetting
        /* ----------------------------------------------------------------- */
        private void LoadSetting(PowerSchemeElement src) {
            if (src == null) return;

            bool prev = this._EnableComboEvents;
            this._EnableComboEvents = false;
            this.MonitorComboBox.SelectedIndex = Translator.ExpireTypeToIndex(
                Translator.SecondToExpireType(src.Policy.user.VideoTimeoutAc));
            this.DiskComboBox.SelectedIndex = Translator.ExpireTypeToIndex(
                Translator.SecondToExpireType(src.Policy.user.SpindownTimeoutAc));
            this.StandByComboBox.SelectedIndex = Translator.ExpireTypeToIndex(
                Translator.SecondToExpireType(src.Policy.user.IdleTimeoutAc));
            this.HibernationComboBox.SelectedIndex = Translator.ExpireTypeToIndex(
                Translator.SecondToExpireType(src.Policy.user.IdleTimeoutAc));
            this._EnableComboEvents = prev;

            this._DetailGroupBox.Text = "[" + src.Name + "] の電源設定";
        }

        /* ----------------------------------------------------------------- */
        /// SaveSetting
        /* ----------------------------------------------------------------- */
        private void SaveSetting(PowerSchemeElement dest) {
            if (dest == null) return;

            POWER_POLICY policy = dest.Policy;
            policy.user.VideoTimeoutAc = Translator.ExpireTypeToSecond(
                Translator.IndexToExpireType(this.MonitorComboBox.SelectedIndex));
            policy.user.SpindownTimeoutAc = Translator.ExpireTypeToSecond(
                Translator.IndexToExpireType(this.DiskComboBox.SelectedIndex));
            policy.user.IdleTimeoutAc = Translator.ExpireTypeToSecond(
                Translator.IndexToExpireType(this.StandByComboBox.SelectedIndex));
            dest.Policy = policy;
        }

        /* ----------------------------------------------------------------- */
        /// SaveProfile
        /* ----------------------------------------------------------------- */
        private void SaveProfile(string name) {
            if (this._CustomizedItem == null) return;
            this._CustomizedItem.Name = name;
            this._Scheme.Add(this._CustomizedItem);
            this.ResetProfileList();
            this.ProfileComboBox.SelectedItem = this._CustomizedItem.Name;
            this._CustomizedItem = null;
        }

        /* ----------------------------------------------------------------- */
        /// CustomizeProfile
        /* ----------------------------------------------------------------- */
        private void CustomizeProfile() {
            if (_CustomizedItem != null && _CustomizedItem.Name == (string)this.ProfileComboBox.SelectedItem) return;
            PowerSchemeElement existed = this._Scheme.Find(this.ProfileComboBox.SelectedItem as string);
            if (existed == null) return;

            if (_CustomizedItem == null) {
                _CustomizedItem = new PowerSchemeElement();
                _CustomizedItem.Name = "カスタム";
                this.ProfileComboBox.Items.Add(_CustomizedItem.Name);
            }
            _CustomizedItem.Policy = existed.Policy;
            this.SaveSetting(_CustomizedItem);
            this.SaveAsButton.Enabled = true;
        }

        /* ----------------------------------------------------------------- */
        /// ResetProfileList
        /* ----------------------------------------------------------------- */
        private void ResetProfileList() {
            this.ProfileComboBox.BeginUpdate();
            bool prev = this._EnableComboEvents;
            this._EnableComboEvents = false;
            this.ProfileComboBox.Items.Clear();
            foreach (PowerSchemeElement item in this._Scheme.Elements) {
                this.ProfileComboBox.Items.Add(item.Name);
            }
            this._EnableComboEvents = prev;
            this.ProfileComboBox.EndUpdate();
        }

        #endregion // Other methods

        /* ----------------------------------------------------------------- */
        //  メンバ変数
        /* ----------------------------------------------------------------- */
        #region Variables
        private PowerScheme _Scheme;
        private PowerSchemeElement _CustomizedItem;
        private bool _EnableComboEvents = false;
        #endregion // Variables
    }
}
