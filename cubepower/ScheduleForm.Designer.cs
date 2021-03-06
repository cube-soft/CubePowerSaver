﻿namespace CubePower {
    partial class ScheduleForm {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this._FooterButtonsSplitContainer = new System.Windows.Forms.SplitContainer();
            this._ProfileGroupBox = new System.Windows.Forms.GroupBox();
            this.ProfileComboBox = new System.Windows.Forms.ComboBox();
            this._DetailGroupBox = new System.Windows.Forms.GroupBox();
            this._ExtendTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._DimLabel = new System.Windows.Forms.Label();
            this.DimComboBox = new System.Windows.Forms.ComboBox();
            this._BrightnessLabel = new System.Windows.Forms.Label();
            this._DimBrightnessLabel = new System.Windows.Forms.Label();
            this._BrightnessPanel = new System.Windows.Forms.Panel();
            this._BrightnessPercentLabel = new System.Windows.Forms.Label();
            this.BrightnessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._DimBrightnessPanel = new System.Windows.Forms.Panel();
            this._DimBrightnessPercentLabel = new System.Windows.Forms.Label();
            this.DimBrightnessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._ExtendLabel = new System.Windows.Forms.Label();
            this.DetailTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._MonitorLabel = new System.Windows.Forms.Label();
            this._DiskLabel = new System.Windows.Forms.Label();
            this._StandByLabel = new System.Windows.Forms.Label();
            this._HibernationLabel = new System.Windows.Forms.Label();
            this.MonitorComboBox = new System.Windows.Forms.ComboBox();
            this.DiskComboBox = new System.Windows.Forms.ComboBox();
            this.StandByComboBox = new System.Windows.Forms.ComboBox();
            this.HibernationComboBox = new System.Windows.Forms.ComboBox();
            this._PowerThrottleLabel = new System.Windows.Forms.Label();
            this.PowerThrottleComboBox = new System.Windows.Forms.ComboBox();
            this._ScheduleGroupBox = new System.Windows.Forms.GroupBox();
            this.DefaultSettingCheckBox = new System.Windows.Forms.CheckBox();
            this._ScheduleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._FirstTimeLabel = new System.Windows.Forms.Label();
            this._LastTimeLabel = new System.Windows.Forms.Label();
            this.FirstDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.LastDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this._PowerThrottleDetailLabel = new System.Windows.Forms.Label();
            this._PowerThrottleDetailPanel = new System.Windows.Forms.Panel();
            this.MinPowerThrottleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxPowerThrottleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._MinPowerThrottlePercentLabel = new System.Windows.Forms.Label();
            this._MaxPowerThrottlePercentLabel = new System.Windows.Forms.Label();
            this._FooterButtonsSplitContainer.Panel1.SuspendLayout();
            this._FooterButtonsSplitContainer.Panel2.SuspendLayout();
            this._FooterButtonsSplitContainer.SuspendLayout();
            this._ProfileGroupBox.SuspendLayout();
            this._DetailGroupBox.SuspendLayout();
            this._ExtendTableLayoutPanel.SuspendLayout();
            this._BrightnessPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessNumericUpDown)).BeginInit();
            this._DimBrightnessPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DimBrightnessNumericUpDown)).BeginInit();
            this.DetailTableLayoutPanel.SuspendLayout();
            this._ScheduleGroupBox.SuspendLayout();
            this._ScheduleTableLayoutPanel.SuspendLayout();
            this._PowerThrottleDetailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinPowerThrottleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPowerThrottleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _FooterButtonsSplitContainer
            // 
            this._FooterButtonsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._FooterButtonsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._FooterButtonsSplitContainer.IsSplitterFixed = true;
            this._FooterButtonsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._FooterButtonsSplitContainer.Name = "_FooterButtonsSplitContainer";
            this._FooterButtonsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _FooterButtonsSplitContainer.Panel1
            // 
            this._FooterButtonsSplitContainer.Panel1.Controls.Add(this._ProfileGroupBox);
            this._FooterButtonsSplitContainer.Panel1.Controls.Add(this._DetailGroupBox);
            this._FooterButtonsSplitContainer.Panel1.Controls.Add(this._ScheduleGroupBox);
            // 
            // _FooterButtonsSplitContainer.Panel2
            // 
            this._FooterButtonsSplitContainer.Panel2.Controls.Add(this.SaveButton);
            this._FooterButtonsSplitContainer.Panel2.Controls.Add(this.ExitButton);
            this._FooterButtonsSplitContainer.Panel2MinSize = 40;
            this._FooterButtonsSplitContainer.Size = new System.Drawing.Size(452, 498);
            this._FooterButtonsSplitContainer.SplitterDistance = 457;
            this._FooterButtonsSplitContainer.SplitterWidth = 1;
            this._FooterButtonsSplitContainer.TabIndex = 0;
            // 
            // _ProfileGroupBox
            // 
            this._ProfileGroupBox.Controls.Add(this.ProfileComboBox);
            this._ProfileGroupBox.Location = new System.Drawing.Point(12, 116);
            this._ProfileGroupBox.Name = "_ProfileGroupBox";
            this._ProfileGroupBox.Size = new System.Drawing.Size(428, 44);
            this._ProfileGroupBox.TabIndex = 2;
            this._ProfileGroupBox.TabStop = false;
            this._ProfileGroupBox.Text = "プロファイル";
            // 
            // ProfileComboBox
            // 
            this.ProfileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfileComboBox.FormattingEnabled = true;
            this.ProfileComboBox.Location = new System.Drawing.Point(8, 18);
            this.ProfileComboBox.Name = "ProfileComboBox";
            this.ProfileComboBox.Size = new System.Drawing.Size(411, 20);
            this.ProfileComboBox.TabIndex = 0;
            this.ProfileComboBox.SelectedIndexChanged += new System.EventHandler(this.ProfileComboBox_SelectedIndexChanged);
            // 
            // _DetailGroupBox
            // 
            this._DetailGroupBox.Controls.Add(this._ExtendTableLayoutPanel);
            this._DetailGroupBox.Controls.Add(this._ExtendLabel);
            this._DetailGroupBox.Controls.Add(this.DetailTableLayoutPanel);
            this._DetailGroupBox.Location = new System.Drawing.Point(12, 166);
            this._DetailGroupBox.Name = "_DetailGroupBox";
            this._DetailGroupBox.Size = new System.Drawing.Size(428, 280);
            this._DetailGroupBox.TabIndex = 1;
            this._DetailGroupBox.TabStop = false;
            this._DetailGroupBox.Text = "電源設定";
            // 
            // _ExtendTableLayoutPanel
            // 
            this._ExtendTableLayoutPanel.ColumnCount = 2;
            this._ExtendTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this._ExtendTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._ExtendTableLayoutPanel.Controls.Add(this._DimLabel, 0, 0);
            this._ExtendTableLayoutPanel.Controls.Add(this.DimComboBox, 1, 0);
            this._ExtendTableLayoutPanel.Controls.Add(this._BrightnessLabel, 0, 1);
            this._ExtendTableLayoutPanel.Controls.Add(this._DimBrightnessLabel, 0, 2);
            this._ExtendTableLayoutPanel.Controls.Add(this._BrightnessPanel, 1, 1);
            this._ExtendTableLayoutPanel.Controls.Add(this._DimBrightnessPanel, 1, 2);
            this._ExtendTableLayoutPanel.Location = new System.Drawing.Point(6, 196);
            this._ExtendTableLayoutPanel.Name = "_ExtendTableLayoutPanel";
            this._ExtendTableLayoutPanel.RowCount = 3;
            this._ExtendTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this._ExtendTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this._ExtendTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this._ExtendTableLayoutPanel.Size = new System.Drawing.Size(416, 78);
            this._ExtendTableLayoutPanel.TabIndex = 5;
            // 
            // _DimLabel
            // 
            this._DimLabel.AutoSize = true;
            this._DimLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._DimLabel.Location = new System.Drawing.Point(3, 3);
            this._DimLabel.Margin = new System.Windows.Forms.Padding(3);
            this._DimLabel.Name = "_DimLabel";
            this._DimLabel.Size = new System.Drawing.Size(110, 20);
            this._DimLabel.TabIndex = 0;
            this._DimLabel.Text = "ディスプレイを暗くする：";
            this._DimLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DimComboBox
            // 
            this.DimComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DimComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DimComboBox.FormattingEnabled = true;
            this.DimComboBox.Location = new System.Drawing.Point(203, 3);
            this.DimComboBox.Name = "DimComboBox";
            this.DimComboBox.Size = new System.Drawing.Size(210, 20);
            this.DimComboBox.TabIndex = 1;
            this.DimComboBox.SelectedIndexChanged += new System.EventHandler(this.DetailComboBox_SelectedIndexChanged);
            // 
            // _BrightnessLabel
            // 
            this._BrightnessLabel.AutoSize = true;
            this._BrightnessLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._BrightnessLabel.Location = new System.Drawing.Point(3, 29);
            this._BrightnessLabel.Margin = new System.Windows.Forms.Padding(3);
            this._BrightnessLabel.Name = "_BrightnessLabel";
            this._BrightnessLabel.Size = new System.Drawing.Size(103, 20);
            this._BrightnessLabel.TabIndex = 2;
            this._BrightnessLabel.Text = "ディスプレイの明るさ：";
            this._BrightnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _DimBrightnessLabel
            // 
            this._DimBrightnessLabel.AutoSize = true;
            this._DimBrightnessLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._DimBrightnessLabel.Location = new System.Drawing.Point(3, 55);
            this._DimBrightnessLabel.Margin = new System.Windows.Forms.Padding(3);
            this._DimBrightnessLabel.Name = "_DimBrightnessLabel";
            this._DimBrightnessLabel.Size = new System.Drawing.Size(139, 20);
            this._DimBrightnessLabel.TabIndex = 3;
            this._DimBrightnessLabel.Text = "ディスプレイ暗転時の明るさ：";
            this._DimBrightnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _BrightnessPanel
            // 
            this._BrightnessPanel.Controls.Add(this._BrightnessPercentLabel);
            this._BrightnessPanel.Controls.Add(this.BrightnessNumericUpDown);
            this._BrightnessPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._BrightnessPanel.Location = new System.Drawing.Point(203, 29);
            this._BrightnessPanel.Name = "_BrightnessPanel";
            this._BrightnessPanel.Size = new System.Drawing.Size(210, 20);
            this._BrightnessPanel.TabIndex = 6;
            // 
            // _BrightnessPercentLabel
            // 
            this._BrightnessPercentLabel.AutoSize = true;
            this._BrightnessPercentLabel.Location = new System.Drawing.Point(190, 3);
            this._BrightnessPercentLabel.Name = "_BrightnessPercentLabel";
            this._BrightnessPercentLabel.Size = new System.Drawing.Size(17, 12);
            this._BrightnessPercentLabel.TabIndex = 6;
            this._BrightnessPercentLabel.Text = "％";
            this._BrightnessPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BrightnessNumericUpDown
            // 
            this.BrightnessNumericUpDown.Location = new System.Drawing.Point(0, 1);
            this.BrightnessNumericUpDown.Name = "BrightnessNumericUpDown";
            this.BrightnessNumericUpDown.Size = new System.Drawing.Size(184, 19);
            this.BrightnessNumericUpDown.TabIndex = 5;
            this.BrightnessNumericUpDown.ValueChanged += new System.EventHandler(this.DetailNumericUpDown_ValueChanged);
            // 
            // _DimBrightnessPanel
            // 
            this._DimBrightnessPanel.Controls.Add(this._DimBrightnessPercentLabel);
            this._DimBrightnessPanel.Controls.Add(this.DimBrightnessNumericUpDown);
            this._DimBrightnessPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._DimBrightnessPanel.Location = new System.Drawing.Point(203, 55);
            this._DimBrightnessPanel.Name = "_DimBrightnessPanel";
            this._DimBrightnessPanel.Size = new System.Drawing.Size(210, 20);
            this._DimBrightnessPanel.TabIndex = 7;
            // 
            // _DimBrightnessPercentLabel
            // 
            this._DimBrightnessPercentLabel.AutoSize = true;
            this._DimBrightnessPercentLabel.Location = new System.Drawing.Point(190, 4);
            this._DimBrightnessPercentLabel.Name = "_DimBrightnessPercentLabel";
            this._DimBrightnessPercentLabel.Size = new System.Drawing.Size(17, 12);
            this._DimBrightnessPercentLabel.TabIndex = 7;
            this._DimBrightnessPercentLabel.Text = "％";
            this._DimBrightnessPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DimBrightnessNumericUpDown
            // 
            this.DimBrightnessNumericUpDown.Location = new System.Drawing.Point(0, 1);
            this.DimBrightnessNumericUpDown.Name = "DimBrightnessNumericUpDown";
            this.DimBrightnessNumericUpDown.Size = new System.Drawing.Size(184, 19);
            this.DimBrightnessNumericUpDown.TabIndex = 6;
            this.DimBrightnessNumericUpDown.ValueChanged += new System.EventHandler(this.DetailNumericUpDown_ValueChanged);
            // 
            // _ExtendLabel
            // 
            this._ExtendLabel.AutoSize = true;
            this._ExtendLabel.Location = new System.Drawing.Point(9, 181);
            this._ExtendLabel.Name = "_ExtendLabel";
            this._ExtendLabel.Size = new System.Drawing.Size(366, 12);
            this._ExtendLabel.TabIndex = 4;
            this._ExtendLabel.Text = "※これ以降の設定は Windows Vista 以降のノートパソコンでのみ有効です。";
            // 
            // DetailTableLayoutPanel
            // 
            this.DetailTableLayoutPanel.ColumnCount = 2;
            this.DetailTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.DetailTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.DetailTableLayoutPanel.Controls.Add(this._MonitorLabel, 0, 0);
            this.DetailTableLayoutPanel.Controls.Add(this._DiskLabel, 0, 1);
            this.DetailTableLayoutPanel.Controls.Add(this._StandByLabel, 0, 2);
            this.DetailTableLayoutPanel.Controls.Add(this._HibernationLabel, 0, 3);
            this.DetailTableLayoutPanel.Controls.Add(this.MonitorComboBox, 1, 0);
            this.DetailTableLayoutPanel.Controls.Add(this.DiskComboBox, 1, 1);
            this.DetailTableLayoutPanel.Controls.Add(this.StandByComboBox, 1, 2);
            this.DetailTableLayoutPanel.Controls.Add(this.HibernationComboBox, 1, 3);
            this.DetailTableLayoutPanel.Controls.Add(this._PowerThrottleLabel, 0, 4);
            this.DetailTableLayoutPanel.Controls.Add(this.PowerThrottleComboBox, 1, 4);
            this.DetailTableLayoutPanel.Controls.Add(this._PowerThrottleDetailLabel, 0, 5);
            this.DetailTableLayoutPanel.Controls.Add(this._PowerThrottleDetailPanel, 1, 5);
            this.DetailTableLayoutPanel.Location = new System.Drawing.Point(6, 18);
            this.DetailTableLayoutPanel.Name = "DetailTableLayoutPanel";
            this.DetailTableLayoutPanel.RowCount = 6;
            this.DetailTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.DetailTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.DetailTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.DetailTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.DetailTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.DetailTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DetailTableLayoutPanel.Size = new System.Drawing.Size(416, 156);
            this.DetailTableLayoutPanel.TabIndex = 3;
            // 
            // _MonitorLabel
            // 
            this._MonitorLabel.AutoSize = true;
            this._MonitorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._MonitorLabel.Location = new System.Drawing.Point(3, 3);
            this._MonitorLabel.Margin = new System.Windows.Forms.Padding(3);
            this._MonitorLabel.Name = "_MonitorLabel";
            this._MonitorLabel.Size = new System.Drawing.Size(194, 20);
            this._MonitorLabel.TabIndex = 0;
            this._MonitorLabel.Text = "ディスプレイの電源を切る：";
            this._MonitorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _DiskLabel
            // 
            this._DiskLabel.AutoSize = true;
            this._DiskLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._DiskLabel.Location = new System.Drawing.Point(3, 29);
            this._DiskLabel.Margin = new System.Windows.Forms.Padding(3);
            this._DiskLabel.Name = "_DiskLabel";
            this._DiskLabel.Size = new System.Drawing.Size(194, 20);
            this._DiskLabel.TabIndex = 1;
            this._DiskLabel.Text = "ハードディスクの電源を切る：";
            this._DiskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _StandByLabel
            // 
            this._StandByLabel.AutoSize = true;
            this._StandByLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._StandByLabel.Location = new System.Drawing.Point(3, 55);
            this._StandByLabel.Margin = new System.Windows.Forms.Padding(3);
            this._StandByLabel.Name = "_StandByLabel";
            this._StandByLabel.Size = new System.Drawing.Size(194, 20);
            this._StandByLabel.TabIndex = 2;
            this._StandByLabel.Text = "システムスタンバイ：";
            this._StandByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _HibernationLabel
            // 
            this._HibernationLabel.AutoSize = true;
            this._HibernationLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._HibernationLabel.Location = new System.Drawing.Point(3, 81);
            this._HibernationLabel.Margin = new System.Windows.Forms.Padding(3);
            this._HibernationLabel.Name = "_HibernationLabel";
            this._HibernationLabel.Size = new System.Drawing.Size(97, 20);
            this._HibernationLabel.TabIndex = 3;
            this._HibernationLabel.Text = "システム休止状態：";
            this._HibernationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MonitorComboBox
            // 
            this.MonitorComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonitorComboBox.FormattingEnabled = true;
            this.MonitorComboBox.Location = new System.Drawing.Point(203, 3);
            this.MonitorComboBox.Name = "MonitorComboBox";
            this.MonitorComboBox.Size = new System.Drawing.Size(210, 20);
            this.MonitorComboBox.TabIndex = 4;
            this.MonitorComboBox.SelectedIndexChanged += new System.EventHandler(this.DetailComboBox_SelectedIndexChanged);
            // 
            // DiskComboBox
            // 
            this.DiskComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiskComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DiskComboBox.FormattingEnabled = true;
            this.DiskComboBox.Location = new System.Drawing.Point(203, 29);
            this.DiskComboBox.Name = "DiskComboBox";
            this.DiskComboBox.Size = new System.Drawing.Size(210, 20);
            this.DiskComboBox.TabIndex = 5;
            this.DiskComboBox.SelectedIndexChanged += new System.EventHandler(this.DetailComboBox_SelectedIndexChanged);
            // 
            // StandByComboBox
            // 
            this.StandByComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StandByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StandByComboBox.FormattingEnabled = true;
            this.StandByComboBox.Location = new System.Drawing.Point(203, 55);
            this.StandByComboBox.Name = "StandByComboBox";
            this.StandByComboBox.Size = new System.Drawing.Size(210, 20);
            this.StandByComboBox.TabIndex = 6;
            this.StandByComboBox.SelectedIndexChanged += new System.EventHandler(this.DetailComboBox_SelectedIndexChanged);
            // 
            // HibernationComboBox
            // 
            this.HibernationComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HibernationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HibernationComboBox.FormattingEnabled = true;
            this.HibernationComboBox.Location = new System.Drawing.Point(203, 81);
            this.HibernationComboBox.Name = "HibernationComboBox";
            this.HibernationComboBox.Size = new System.Drawing.Size(210, 20);
            this.HibernationComboBox.TabIndex = 7;
            this.HibernationComboBox.SelectedIndexChanged += new System.EventHandler(this.DetailComboBox_SelectedIndexChanged);
            // 
            // _PowerThrottleLabel
            // 
            this._PowerThrottleLabel.AutoSize = true;
            this._PowerThrottleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._PowerThrottleLabel.Location = new System.Drawing.Point(3, 107);
            this._PowerThrottleLabel.Margin = new System.Windows.Forms.Padding(3);
            this._PowerThrottleLabel.Name = "_PowerThrottleLabel";
            this._PowerThrottleLabel.Size = new System.Drawing.Size(80, 20);
            this._PowerThrottleLabel.TabIndex = 8;
            this._PowerThrottleLabel.Text = "プロセッサ調整：";
            this._PowerThrottleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PowerThrottleComboBox
            // 
            this.PowerThrottleComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PowerThrottleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PowerThrottleComboBox.FormattingEnabled = true;
            this.PowerThrottleComboBox.Location = new System.Drawing.Point(203, 107);
            this.PowerThrottleComboBox.Name = "PowerThrottleComboBox";
            this.PowerThrottleComboBox.Size = new System.Drawing.Size(210, 20);
            this.PowerThrottleComboBox.TabIndex = 9;
            this.PowerThrottleComboBox.SelectedIndexChanged += new System.EventHandler(this.PowerThrottleDetailComboBox_SelectedIndexChanged);
            // 
            // _ScheduleGroupBox
            // 
            this._ScheduleGroupBox.Controls.Add(this.DefaultSettingCheckBox);
            this._ScheduleGroupBox.Controls.Add(this._ScheduleTableLayoutPanel);
            this._ScheduleGroupBox.Location = new System.Drawing.Point(12, 12);
            this._ScheduleGroupBox.Name = "_ScheduleGroupBox";
            this._ScheduleGroupBox.Size = new System.Drawing.Size(428, 98);
            this._ScheduleGroupBox.TabIndex = 0;
            this._ScheduleGroupBox.TabStop = false;
            this._ScheduleGroupBox.Text = "スケジュール";
            // 
            // DefaultSettingCheckBox
            // 
            this.DefaultSettingCheckBox.AutoSize = true;
            this.DefaultSettingCheckBox.Location = new System.Drawing.Point(8, 76);
            this.DefaultSettingCheckBox.Name = "DefaultSettingCheckBox";
            this.DefaultSettingCheckBox.Size = new System.Drawing.Size(123, 16);
            this.DefaultSettingCheckBox.TabIndex = 1;
            this.DefaultSettingCheckBox.Text = "その他の時間の設定";
            this.DefaultSettingCheckBox.UseVisualStyleBackColor = true;
            this.DefaultSettingCheckBox.CheckedChanged += new System.EventHandler(this.DefaultSettingCheckBox_CheckedChanged);
            // 
            // _ScheduleTableLayoutPanel
            // 
            this._ScheduleTableLayoutPanel.ColumnCount = 2;
            this._ScheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this._ScheduleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._ScheduleTableLayoutPanel.Controls.Add(this._FirstTimeLabel, 0, 0);
            this._ScheduleTableLayoutPanel.Controls.Add(this._LastTimeLabel, 0, 1);
            this._ScheduleTableLayoutPanel.Controls.Add(this.FirstDateTimePicker, 1, 0);
            this._ScheduleTableLayoutPanel.Controls.Add(this.LastDateTimePicker, 1, 1);
            this._ScheduleTableLayoutPanel.Location = new System.Drawing.Point(6, 18);
            this._ScheduleTableLayoutPanel.Name = "_ScheduleTableLayoutPanel";
            this._ScheduleTableLayoutPanel.RowCount = 2;
            this._ScheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this._ScheduleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._ScheduleTableLayoutPanel.Size = new System.Drawing.Size(416, 52);
            this._ScheduleTableLayoutPanel.TabIndex = 0;
            // 
            // _FirstTimeLabel
            // 
            this._FirstTimeLabel.AutoSize = true;
            this._FirstTimeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._FirstTimeLabel.Location = new System.Drawing.Point(3, 3);
            this._FirstTimeLabel.Margin = new System.Windows.Forms.Padding(3);
            this._FirstTimeLabel.Name = "_FirstTimeLabel";
            this._FirstTimeLabel.Size = new System.Drawing.Size(59, 20);
            this._FirstTimeLabel.TabIndex = 0;
            this._FirstTimeLabel.Text = "開始時刻：";
            this._FirstTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _LastTimeLabel
            // 
            this._LastTimeLabel.AutoSize = true;
            this._LastTimeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._LastTimeLabel.Location = new System.Drawing.Point(3, 29);
            this._LastTimeLabel.Margin = new System.Windows.Forms.Padding(3);
            this._LastTimeLabel.Name = "_LastTimeLabel";
            this._LastTimeLabel.Size = new System.Drawing.Size(59, 20);
            this._LastTimeLabel.TabIndex = 1;
            this._LastTimeLabel.Text = "終了時刻：";
            this._LastTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FirstDateTimePicker
            // 
            this.FirstDateTimePicker.CustomFormat = "HH:mm";
            this.FirstDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FirstDateTimePicker.Location = new System.Drawing.Point(203, 3);
            this.FirstDateTimePicker.Name = "FirstDateTimePicker";
            this.FirstDateTimePicker.ShowUpDown = true;
            this.FirstDateTimePicker.Size = new System.Drawing.Size(210, 19);
            this.FirstDateTimePicker.TabIndex = 3;
            // 
            // LastDateTimePicker
            // 
            this.LastDateTimePicker.CustomFormat = "HH:mm";
            this.LastDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LastDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.LastDateTimePicker.Location = new System.Drawing.Point(203, 29);
            this.LastDateTimePicker.Name = "LastDateTimePicker";
            this.LastDateTimePicker.ShowUpDown = true;
            this.LastDateTimePicker.Size = new System.Drawing.Size(210, 19);
            this.LastDateTimePicker.TabIndex = 4;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(234, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "OK";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(340, 5);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "キャンセル";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // _PowerThrottleDetailLabel
            // 
            this._PowerThrottleDetailLabel.AutoSize = true;
            this._PowerThrottleDetailLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._PowerThrottleDetailLabel.Location = new System.Drawing.Point(3, 133);
            this._PowerThrottleDetailLabel.Margin = new System.Windows.Forms.Padding(3);
            this._PowerThrottleDetailLabel.Name = "_PowerThrottleDetailLabel";
            this._PowerThrottleDetailLabel.Size = new System.Drawing.Size(181, 20);
            this._PowerThrottleDetailLabel.TabIndex = 10;
            this._PowerThrottleDetailLabel.Text = "プロセッサ調整の詳細 (Vista 以降)：";
            this._PowerThrottleDetailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _PowerThrottleDetailPanel
            // 
            this._PowerThrottleDetailPanel.Controls.Add(this._MaxPowerThrottlePercentLabel);
            this._PowerThrottleDetailPanel.Controls.Add(this._MinPowerThrottlePercentLabel);
            this._PowerThrottleDetailPanel.Controls.Add(this.MaxPowerThrottleNumericUpDown);
            this._PowerThrottleDetailPanel.Controls.Add(this.MinPowerThrottleNumericUpDown);
            this._PowerThrottleDetailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PowerThrottleDetailPanel.Location = new System.Drawing.Point(203, 133);
            this._PowerThrottleDetailPanel.Name = "_PowerThrottleDetailPanel";
            this._PowerThrottleDetailPanel.Size = new System.Drawing.Size(210, 20);
            this._PowerThrottleDetailPanel.TabIndex = 11;
            // 
            // MinPowerThrottleNumericUpDown
            // 
            this.MinPowerThrottleNumericUpDown.Location = new System.Drawing.Point(0, 1);
            this.MinPowerThrottleNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinPowerThrottleNumericUpDown.Name = "MinPowerThrottleNumericUpDown";
            this.MinPowerThrottleNumericUpDown.Size = new System.Drawing.Size(70, 19);
            this.MinPowerThrottleNumericUpDown.TabIndex = 0;
            this.MinPowerThrottleNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MinPowerThrottleNumericUpDown.ValueChanged += new System.EventHandler(this.PowerThrottleDetailNumericUpDown_ValueChanged);
            // 
            // MaxPowerThrottleNumericUpDown
            // 
            this.MaxPowerThrottleNumericUpDown.Location = new System.Drawing.Point(114, 0);
            this.MaxPowerThrottleNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxPowerThrottleNumericUpDown.Name = "MaxPowerThrottleNumericUpDown";
            this.MaxPowerThrottleNumericUpDown.Size = new System.Drawing.Size(70, 19);
            this.MaxPowerThrottleNumericUpDown.TabIndex = 1;
            this.MaxPowerThrottleNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.MaxPowerThrottleNumericUpDown.ValueChanged += new System.EventHandler(this.PowerThrottleDetailNumericUpDown_ValueChanged);
            // 
            // _MinPowerThrottlePercentLabel
            // 
            this._MinPowerThrottlePercentLabel.AutoSize = true;
            this._MinPowerThrottlePercentLabel.Location = new System.Drawing.Point(76, 4);
            this._MinPowerThrottlePercentLabel.Name = "_MinPowerThrottlePercentLabel";
            this._MinPowerThrottlePercentLabel.Size = new System.Drawing.Size(33, 12);
            this._MinPowerThrottlePercentLabel.TabIndex = 2;
            this._MinPowerThrottlePercentLabel.Text = "％ －";
            // 
            // _MaxPowerThrottlePercentLabel
            // 
            this._MaxPowerThrottlePercentLabel.AutoSize = true;
            this._MaxPowerThrottlePercentLabel.Location = new System.Drawing.Point(190, 4);
            this._MaxPowerThrottlePercentLabel.Name = "_MaxPowerThrottlePercentLabel";
            this._MaxPowerThrottlePercentLabel.Size = new System.Drawing.Size(17, 12);
            this._MaxPowerThrottlePercentLabel.TabIndex = 3;
            this._MaxPowerThrottlePercentLabel.Text = "％";
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 498);
            this.Controls.Add(this._FooterButtonsSplitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleForm";
            this.ShowInTaskbar = false;
            this.Text = "CubePowerSaver";
            this._FooterButtonsSplitContainer.Panel1.ResumeLayout(false);
            this._FooterButtonsSplitContainer.Panel2.ResumeLayout(false);
            this._FooterButtonsSplitContainer.ResumeLayout(false);
            this._ProfileGroupBox.ResumeLayout(false);
            this._DetailGroupBox.ResumeLayout(false);
            this._DetailGroupBox.PerformLayout();
            this._ExtendTableLayoutPanel.ResumeLayout(false);
            this._ExtendTableLayoutPanel.PerformLayout();
            this._BrightnessPanel.ResumeLayout(false);
            this._BrightnessPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessNumericUpDown)).EndInit();
            this._DimBrightnessPanel.ResumeLayout(false);
            this._DimBrightnessPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DimBrightnessNumericUpDown)).EndInit();
            this.DetailTableLayoutPanel.ResumeLayout(false);
            this.DetailTableLayoutPanel.PerformLayout();
            this._ScheduleGroupBox.ResumeLayout(false);
            this._ScheduleGroupBox.PerformLayout();
            this._ScheduleTableLayoutPanel.ResumeLayout(false);
            this._ScheduleTableLayoutPanel.PerformLayout();
            this._PowerThrottleDetailPanel.ResumeLayout(false);
            this._PowerThrottleDetailPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinPowerThrottleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPowerThrottleNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _FooterButtonsSplitContainer;
        private System.Windows.Forms.GroupBox _ScheduleGroupBox;
        private System.Windows.Forms.TableLayoutPanel _ScheduleTableLayoutPanel;
        private System.Windows.Forms.Label _FirstTimeLabel;
        private System.Windows.Forms.Label _LastTimeLabel;
        private System.Windows.Forms.DateTimePicker FirstDateTimePicker;
        private System.Windows.Forms.DateTimePicker LastDateTimePicker;
        private System.Windows.Forms.GroupBox _DetailGroupBox;
        private System.Windows.Forms.TableLayoutPanel DetailTableLayoutPanel;
        private System.Windows.Forms.Label _MonitorLabel;
        private System.Windows.Forms.Label _DiskLabel;
        private System.Windows.Forms.Label _StandByLabel;
        private System.Windows.Forms.Label _HibernationLabel;
        private System.Windows.Forms.GroupBox _ProfileGroupBox;
        private System.Windows.Forms.ComboBox ProfileComboBox;
        private System.Windows.Forms.ComboBox MonitorComboBox;
        private System.Windows.Forms.ComboBox DiskComboBox;
        private System.Windows.Forms.ComboBox StandByComboBox;
        private System.Windows.Forms.ComboBox HibernationComboBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.CheckBox DefaultSettingCheckBox;
        private System.Windows.Forms.TableLayoutPanel _ExtendTableLayoutPanel;
        private System.Windows.Forms.Label _ExtendLabel;
        private System.Windows.Forms.Label _DimLabel;
        private System.Windows.Forms.ComboBox DimComboBox;
        private System.Windows.Forms.Label _BrightnessLabel;
        private System.Windows.Forms.Label _DimBrightnessLabel;
        private System.Windows.Forms.Panel _BrightnessPanel;
        private System.Windows.Forms.NumericUpDown BrightnessNumericUpDown;
        private System.Windows.Forms.Label _BrightnessPercentLabel;
        private System.Windows.Forms.Panel _DimBrightnessPanel;
        private System.Windows.Forms.Label _DimBrightnessPercentLabel;
        private System.Windows.Forms.NumericUpDown DimBrightnessNumericUpDown;
        private System.Windows.Forms.Label _PowerThrottleLabel;
        private System.Windows.Forms.ComboBox PowerThrottleComboBox;
        private System.Windows.Forms.Label _PowerThrottleDetailLabel;
        private System.Windows.Forms.Panel _PowerThrottleDetailPanel;
        private System.Windows.Forms.NumericUpDown MinPowerThrottleNumericUpDown;
        private System.Windows.Forms.Label _MaxPowerThrottlePercentLabel;
        private System.Windows.Forms.Label _MinPowerThrottlePercentLabel;
        private System.Windows.Forms.NumericUpDown MaxPowerThrottleNumericUpDown;
    }
}