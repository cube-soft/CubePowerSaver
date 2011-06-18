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
        public ScheduleForm(IPowerScheme scheme) {
            this._scheme = scheme;
            this.Initialize();
        }

        /* ----------------------------------------------------------------- */
        /// Initialize
        /* ----------------------------------------------------------------- */
        private void Initialize() {
            InitializeComponent();
            this.InitializeComboAppearance();
            this._EnableComboEvents = true;
            this.ProfileComboBox.SelectedIndex = 0;
        }

        /* ----------------------------------------------------------------- */
        /// InitializeComboAppearance
        /* ----------------------------------------------------------------- */
        private void InitializeComboAppearance() {
            this.ResetProfileList();

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

            this.PowerThrottleComboBox.Items.Clear();
            foreach (PowerThrottlePolicy id in Enum.GetValues(typeof(PowerThrottlePolicy))) {
                // CubePowerSaver では DEGRADE は使用しない．
                if (id == PowerThrottlePolicy.PO_THROTTLE_DEGRADE) continue;
                this.PowerThrottleComboBox.Items.Add(Appearance.PowerThrottlePolicyString(id));
            }

            this.DimComboBox.Items.Clear();
            foreach (Parameter.ExpireTypes id in Enum.GetValues(typeof(Parameter.ExpireTypes))) {
                this.DimComboBox.Items.Add(Appearance.ExpireTypeString(id));
            }
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
        /// DefaultSetting
        /* ----------------------------------------------------------------- */
        public bool DefaultSetting {
            get { return this.DefaultSettingCheckBox.Checked; }
            set { this.DefaultSettingCheckBox.Checked = value; }
        }

        /* ----------------------------------------------------------------- */
        /// ProfileName
        /* ----------------------------------------------------------------- */
        public string ProfileName {
            get { return this.ProfileComboBox.SelectedItem as string; }
            set {
                if (this.ProfileComboBox.Items.Contains(value)) this.ProfileComboBox.SelectedItem = value;
                else if (value == CUSTOM_PROFILE) {
                    this.ProfileComboBox.Items.Add(value);
                    this.ProfileComboBox.SelectedItem = value;
                }
            }
        }

        /* ----------------------------------------------------------------- */
        /// PowerSetting
        /* ----------------------------------------------------------------- */
        public PowerSetting PowerSetting {
            get { return this._setting; }
            set {
                this._setting = value;
                this.LoadSetting(this._setting);
            }
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
            this.SaveSetting(this._setting);
            this.DialogResult = DialogResult.OK;
            this.Close();
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

            string profile = control.SelectedItem as string;
            if (profile != CUSTOM_PROFILE) {
                PowerSchemeItem selected = this._scheme.Find(profile);
                if (selected != null) this.LoadProfile(selected);
            }
            else this.LoadSetting(this._setting);
        }

        /* ----------------------------------------------------------------- */
        /// DetailComboBox_SelectedIndexChanged
        /* ----------------------------------------------------------------- */
        private void DetailComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox control = sender as ComboBox;
            if (control == null || !this._EnableComboEvents) return;
            this.SaveSetting(this._setting);
            if (!this.ProfileComboBox.Items.Contains(CUSTOM_PROFILE)) {
                this.ProfileComboBox.Items.Add(CUSTOM_PROFILE);
            }
            this.ProfileComboBox.SelectedIndex = this.ProfileComboBox.Items.Count - 1;
        }

        /* ----------------------------------------------------------------- */
        /// PowerThrottleDetailComboBox_SelectedIndexChanged
        /* ----------------------------------------------------------------- */
        private void PowerThrottleDetailComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox control = sender as ComboBox;
            if (control == null || !this._EnableComboEvents) return;

            int index = control.SelectedIndex;
            bool prev = this._EnableComboEvents;
            this._EnableComboEvents = false;
            int min = 5;
            int max = 100;
            if (Translator.IndexToPowerThrottlePolicy(index) == PowerThrottlePolicy.PO_THROTTLE_NONE) min = 100;
            else if (Translator.IndexToPowerThrottlePolicy(index) == PowerThrottlePolicy.PO_THROTTLE_CONSTANT) max = 50;
            this.MinPowerThrottleNumericUpDown.Value = min;
            this.MaxPowerThrottleNumericUpDown.Value = max;
            this._EnableComboEvents = prev;

            this.DetailComboBox_SelectedIndexChanged(sender, e);
        }

        /* ----------------------------------------------------------------- */
        /// DetailNumericUpDown_ValueChanged
        /* ----------------------------------------------------------------- */
        private void DetailNumericUpDown_ValueChanged(object sender, EventArgs e) {
            NumericUpDown control = sender as NumericUpDown;
            if (control == null || !this._EnableComboEvents) return;
            this.SaveSetting(this._setting);
            if (!this.ProfileComboBox.Items.Contains(CUSTOM_PROFILE)) {
                this.ProfileComboBox.Items.Add(CUSTOM_PROFILE);
            }
            this.ProfileComboBox.SelectedIndex = this.ProfileComboBox.Items.Count - 1;
        }

        /* ----------------------------------------------------------------- */
        /// PowerThrottleDetailNumericUpDown_ValueChanged
        /* ----------------------------------------------------------------- */
        private void PowerThrottleDetailNumericUpDown_ValueChanged(object sender, EventArgs e) {
            NumericUpDown control = sender as NumericUpDown;
            if (control == null || !this._EnableComboEvents) return;

            bool prev = this._EnableComboEvents;
            this._EnableComboEvents = false;
            this.PowerThrottleComboBox.SelectedIndex = Translator.PowerThrottlePolicyToIndex(PowerThrottlePolicy.PO_THROTTLE_ADAPTIVE);
            this._EnableComboEvents = prev;

            this.DetailNumericUpDown_ValueChanged(sender, e);
        }

        /* ----------------------------------------------------------------- */
        /// DefaultSettingCheckBox_CheckedChanged
        /* ----------------------------------------------------------------- */
        private void DefaultSettingCheckBox_CheckedChanged(object sender, EventArgs e) {
            CheckBox control = sender as CheckBox;
            if (control == null) return;
            this.FirstDateTimePicker.Enabled = !control.Checked;
            this.LastDateTimePicker.Enabled = !control.Checked;
        }

        #endregion // Event handlers

        /* ----------------------------------------------------------------- */
        //  その他のメソッド
        /* ----------------------------------------------------------------- */
        #region Other methods

        /* ----------------------------------------------------------------- */
        /// LoadProfile
        /* ----------------------------------------------------------------- */
        private void LoadProfile(PowerSchemeItem src) {
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
                Translator.SecondToExpireType(src.Policy.mach.DozeS4TimeoutAc));
            this.DimComboBox.SelectedIndex = Translator.ExpireTypeToIndex(
                Translator.SecondToExpireType(src.DimTimeout));
            this.BrightnessNumericUpDown.Value = src.Brightness;
            this.DimBrightnessNumericUpDown.Value = src.DimBrightness;

            PowerThrottlePolicy processor = (PowerThrottlePolicy)src.Policy.user.ThrottlePolicyAc;
            this.PowerThrottleComboBox.SelectedIndex = Translator.PowerThrottlePolicyToIndex(processor);
            switch (processor) {
            case PowerThrottlePolicy.PO_THROTTLE_NONE:
                this.MinPowerThrottleNumericUpDown.Value = 100;
                this.MaxPowerThrottleNumericUpDown.Value = 100;
                break;
            case PowerThrottlePolicy.PO_THROTTLE_CONSTANT:
                this.MinPowerThrottleNumericUpDown.Value = 5;
                this.MaxPowerThrottleNumericUpDown.Value = 50;
                break;
            default:
                this.MinPowerThrottleNumericUpDown.Value = 5;
                this.MaxPowerThrottleNumericUpDown.Value = 100;
                break;
            }

            this._EnableComboEvents = prev;

            this._DetailGroupBox.Text = "[" + src.Name + "] の電源設定";
        }

        /* ----------------------------------------------------------------- */
        /// LoadSetting
        /* ----------------------------------------------------------------- */
        private void LoadSetting(PowerSetting src) {
            if (src == null) return;

            bool prev = this._EnableComboEvents;
            this._EnableComboEvents = false;
            this.MonitorComboBox.SelectedIndex = Translator.ExpireTypeToIndex(
                Translator.SecondToExpireType(src.MonitorTimeout));
            this.DiskComboBox.SelectedIndex = Translator.ExpireTypeToIndex(
                Translator.SecondToExpireType(src.DiskTimeout));
            this.StandByComboBox.SelectedIndex = Translator.ExpireTypeToIndex(
                Translator.SecondToExpireType(src.StandByTimeout));
            this.HibernationComboBox.SelectedIndex = Translator.ExpireTypeToIndex(
                Translator.SecondToExpireType(src.HibernationTimeout));
            this.PowerThrottleComboBox.SelectedIndex = Translator.PowerThrottlePolicyToIndex(src.ThrottlePolicy);
            this.DimComboBox.SelectedIndex = Translator.ExpireTypeToIndex(
                Translator.SecondToExpireType(src.DimTimeout));
            this.BrightnessNumericUpDown.Value = src.Brightness;
            this.DimBrightnessNumericUpDown.Value = src.DimBrightness;
            this._EnableComboEvents = prev;

            this.ProfileComboBox.SelectedIndex = this.ProfileComboBox.Items.Count - 1;
            this._DetailGroupBox.Text = "[" + CUSTOM_PROFILE + "] の電源設定";
        }

        /* ----------------------------------------------------------------- */
        /// SaveSetting
        /* ----------------------------------------------------------------- */
        private void SaveSetting(PowerSetting dest) {
            if (dest == null) return;

            dest.MonitorTimeout = Translator.ExpireTypeToSecond(
                Translator.IndexToExpireType(this.MonitorComboBox.SelectedIndex));
            dest.DiskTimeout = Translator.ExpireTypeToSecond(
                Translator.IndexToExpireType(this.DiskComboBox.SelectedIndex));
            dest.StandByTimeout = Translator.ExpireTypeToSecond(
                Translator.IndexToExpireType(this.StandByComboBox.SelectedIndex));
            dest.HibernationTimeout = Translator.ExpireTypeToSecond(
                Translator.IndexToExpireType(this.HibernationComboBox.SelectedIndex));
            dest.ThrottlePolicy = Translator.IndexToPowerThrottlePolicy(
                this.PowerThrottleComboBox.SelectedIndex);
            dest.DimTimeout = Translator.ExpireTypeToSecond(
                Translator.IndexToExpireType(this.DimComboBox.SelectedIndex));
            dest.Brightness = (uint)this.BrightnessNumericUpDown.Value;
            dest.DimBrightness = (uint)this.DimBrightnessNumericUpDown.Value;
        }

        /* ----------------------------------------------------------------- */
        /// ResetProfileList
        /* ----------------------------------------------------------------- */
        private void ResetProfileList() {
            this.ProfileComboBox.BeginUpdate();
            bool prev = this._EnableComboEvents;
            this._EnableComboEvents = false;
            this.ProfileComboBox.Items.Clear();
            foreach (PowerSchemeItem item in this._scheme.Elements) {
                this.ProfileComboBox.Items.Add(item.Name);
            }

            if (this.ProfileComboBox.Items.Contains(CUBEPOWER_PROFILENAME)) {
                this.ProfileComboBox.Items.Remove(CUBEPOWER_PROFILENAME);
            }

            this._EnableComboEvents = prev;
            this.ProfileComboBox.EndUpdate();
        }

        #endregion // Other methods

        /* ----------------------------------------------------------------- */
        //  メンバ変数
        /* ----------------------------------------------------------------- */
        #region Variables
        private IPowerScheme _scheme;
        private PowerSetting _setting = new PowerSetting();
        private bool _EnableComboEvents = false;
        #endregion // Variables

        /* ----------------------------------------------------------------- */
        //  定数
        /* ----------------------------------------------------------------- */
        #region Constant variables
        private const string CUSTOM_PROFILE = "カスタム";
        private static readonly string CUBEPOWER_PROFILENAME = "CubePowerSaver の電源設定";
        #endregion
    }
}
