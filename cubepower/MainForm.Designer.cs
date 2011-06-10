namespace CubePower {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NavigationMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._FooterButtonsSplitContainer = new System.Windows.Forms.SplitContainer();
            this._ScheduleSplitContainer = new System.Windows.Forms.SplitContainer();
            this._ScheduleControlSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ScheduleListView = new System.Windows.Forms.ListView();
            this.CreateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this._DefaultSettingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this._DefaultSettingLabel = new System.Windows.Forms.Label();
            this.DefaultSettingComboBox = new System.Windows.Forms.ComboBox();
            this.NavigationMenuStrip.SuspendLayout();
            this._FooterButtonsSplitContainer.Panel1.SuspendLayout();
            this._FooterButtonsSplitContainer.Panel2.SuspendLayout();
            this._FooterButtonsSplitContainer.SuspendLayout();
            this._ScheduleSplitContainer.Panel1.SuspendLayout();
            this._ScheduleSplitContainer.Panel2.SuspendLayout();
            this._ScheduleSplitContainer.SuspendLayout();
            this._ScheduleControlSplitContainer.Panel1.SuspendLayout();
            this._ScheduleControlSplitContainer.Panel2.SuspendLayout();
            this._ScheduleControlSplitContainer.SuspendLayout();
            this._DefaultSettingTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NavigationMenuStrip
            // 
            this.NavigationMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.NavigationMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.NavigationMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.NavigationMenuStrip.Name = "NavigationMenuStrip";
            this.NavigationMenuStrip.Size = new System.Drawing.Size(492, 24);
            this.NavigationMenuStrip.TabIndex = 0;
            this.NavigationMenuStrip.Text = "NavigationMenuStrip";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportToolStripMenuItem,
            this.ExportToolStripMenuItem,
            this.FileToolStripSeparator,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.FileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // ImportToolStripMenuItem
            // 
            this.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem";
            this.ImportToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ImportToolStripMenuItem.Text = "インポート(&O)";
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ExportToolStripMenuItem.Text = "エクスポート(&S)";
            // 
            // FileToolStripSeparator
            // 
            this.FileToolStripSeparator.Name = "FileToolStripSeparator";
            this.FileToolStripSeparator.Size = new System.Drawing.Size(136, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ExitToolStripMenuItem.Text = "終了(&X)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VersionToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.HelpToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // VersionToolStripMenuItem
            // 
            this.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem";
            this.VersionToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.VersionToolStripMenuItem.Text = "CubePowerSaver について(&A)";
            // 
            // _FooterButtonsSplitContainer
            // 
            this._FooterButtonsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._FooterButtonsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._FooterButtonsSplitContainer.IsSplitterFixed = true;
            this._FooterButtonsSplitContainer.Location = new System.Drawing.Point(0, 24);
            this._FooterButtonsSplitContainer.Name = "_FooterButtonsSplitContainer";
            this._FooterButtonsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _FooterButtonsSplitContainer.Panel1
            // 
            this._FooterButtonsSplitContainer.Panel1.Controls.Add(this._ScheduleSplitContainer);
            // 
            // _FooterButtonsSplitContainer.Panel2
            // 
            this._FooterButtonsSplitContainer.Panel2.Controls.Add(this.SaveButton);
            this._FooterButtonsSplitContainer.Panel2.Controls.Add(this.ExitButton);
            this._FooterButtonsSplitContainer.Panel2MinSize = 30;
            this._FooterButtonsSplitContainer.Size = new System.Drawing.Size(492, 342);
            this._FooterButtonsSplitContainer.SplitterDistance = 311;
            this._FooterButtonsSplitContainer.SplitterWidth = 1;
            this._FooterButtonsSplitContainer.TabIndex = 1;
            // 
            // _ScheduleSplitContainer
            // 
            this._ScheduleSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ScheduleSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ScheduleSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._ScheduleSplitContainer.IsSplitterFixed = true;
            this._ScheduleSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._ScheduleSplitContainer.Name = "_ScheduleSplitContainer";
            this._ScheduleSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _ScheduleSplitContainer.Panel1
            // 
            this._ScheduleSplitContainer.Panel1.Controls.Add(this._ScheduleControlSplitContainer);
            // 
            // _ScheduleSplitContainer.Panel2
            // 
            this._ScheduleSplitContainer.Panel2.Controls.Add(this._DefaultSettingTableLayoutPanel);
            this._ScheduleSplitContainer.Panel2MinSize = 30;
            this._ScheduleSplitContainer.Size = new System.Drawing.Size(492, 311);
            this._ScheduleSplitContainer.SplitterDistance = 280;
            this._ScheduleSplitContainer.SplitterWidth = 1;
            this._ScheduleSplitContainer.TabIndex = 0;
            // 
            // _ScheduleControlSplitContainer
            // 
            this._ScheduleControlSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ScheduleControlSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._ScheduleControlSplitContainer.IsSplitterFixed = true;
            this._ScheduleControlSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._ScheduleControlSplitContainer.Name = "_ScheduleControlSplitContainer";
            this._ScheduleControlSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _ScheduleControlSplitContainer.Panel1
            // 
            this._ScheduleControlSplitContainer.Panel1.Controls.Add(this.ScheduleListView);
            // 
            // _ScheduleControlSplitContainer.Panel2
            // 
            this._ScheduleControlSplitContainer.Panel2.Controls.Add(this.CreateButton);
            this._ScheduleControlSplitContainer.Panel2.Controls.Add(this.DeleteButton);
            this._ScheduleControlSplitContainer.Panel2MinSize = 30;
            this._ScheduleControlSplitContainer.Size = new System.Drawing.Size(488, 276);
            this._ScheduleControlSplitContainer.SplitterDistance = 245;
            this._ScheduleControlSplitContainer.SplitterWidth = 1;
            this._ScheduleControlSplitContainer.TabIndex = 0;
            // 
            // ScheduleListView
            // 
            this.ScheduleListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduleListView.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ScheduleListView.FullRowSelect = true;
            this.ScheduleListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ScheduleListView.Location = new System.Drawing.Point(0, 0);
            this.ScheduleListView.MultiSelect = false;
            this.ScheduleListView.Name = "ScheduleListView";
            this.ScheduleListView.Size = new System.Drawing.Size(488, 245);
            this.ScheduleListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ScheduleListView.TabIndex = 0;
            this.ScheduleListView.UseCompatibleStateImageBehavior = false;
            this.ScheduleListView.View = System.Windows.Forms.View.Details;
            this.ScheduleListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ScheduleListView_MouseDoubleClick);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(229, 3);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(150, 23);
            this.CreateButton.TabIndex = 1;
            this.CreateButton.Text = "新しいスケジュールを追加";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(385, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 23);
            this.DeleteButton.TabIndex = 0;
            this.DeleteButton.Text = "削除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // _DefaultSettingTableLayoutPanel
            // 
            this._DefaultSettingTableLayoutPanel.ColumnCount = 2;
            this._DefaultSettingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._DefaultSettingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._DefaultSettingTableLayoutPanel.Controls.Add(this._DefaultSettingLabel, 0, 0);
            this._DefaultSettingTableLayoutPanel.Controls.Add(this.DefaultSettingComboBox, 1, 0);
            this._DefaultSettingTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._DefaultSettingTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._DefaultSettingTableLayoutPanel.Name = "_DefaultSettingTableLayoutPanel";
            this._DefaultSettingTableLayoutPanel.RowCount = 1;
            this._DefaultSettingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._DefaultSettingTableLayoutPanel.Size = new System.Drawing.Size(488, 26);
            this._DefaultSettingTableLayoutPanel.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(283, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "OK";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(389, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 23);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "キャンセル";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // _DefaultSettingLabel
            // 
            this._DefaultSettingLabel.AutoSize = true;
            this._DefaultSettingLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._DefaultSettingLabel.Location = new System.Drawing.Point(3, 3);
            this._DefaultSettingLabel.Margin = new System.Windows.Forms.Padding(3);
            this._DefaultSettingLabel.Name = "_DefaultSettingLabel";
            this._DefaultSettingLabel.Size = new System.Drawing.Size(76, 20);
            this._DefaultSettingLabel.TabIndex = 0;
            this._DefaultSettingLabel.Text = "その他の時間：";
            this._DefaultSettingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DefaultSettingComboBox
            // 
            this.DefaultSettingComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefaultSettingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DefaultSettingComboBox.FormattingEnabled = true;
            this.DefaultSettingComboBox.Location = new System.Drawing.Point(153, 3);
            this.DefaultSettingComboBox.Name = "DefaultSettingComboBox";
            this.DefaultSettingComboBox.Size = new System.Drawing.Size(332, 20);
            this.DefaultSettingComboBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 366);
            this.Controls.Add(this._FooterButtonsSplitContainer);
            this.Controls.Add(this.NavigationMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.NavigationMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CubePowerSaver";
            this.NavigationMenuStrip.ResumeLayout(false);
            this.NavigationMenuStrip.PerformLayout();
            this._FooterButtonsSplitContainer.Panel1.ResumeLayout(false);
            this._FooterButtonsSplitContainer.Panel2.ResumeLayout(false);
            this._FooterButtonsSplitContainer.ResumeLayout(false);
            this._ScheduleSplitContainer.Panel1.ResumeLayout(false);
            this._ScheduleSplitContainer.Panel2.ResumeLayout(false);
            this._ScheduleSplitContainer.ResumeLayout(false);
            this._ScheduleControlSplitContainer.Panel1.ResumeLayout(false);
            this._ScheduleControlSplitContainer.Panel2.ResumeLayout(false);
            this._ScheduleControlSplitContainer.ResumeLayout(false);
            this._DefaultSettingTableLayoutPanel.ResumeLayout(false);
            this._DefaultSettingTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip NavigationMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer _FooterButtonsSplitContainer;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.SplitContainer _ScheduleSplitContainer;
        private System.Windows.Forms.TableLayoutPanel _DefaultSettingTableLayoutPanel;
        private System.Windows.Forms.SplitContainer _ScheduleControlSplitContainer;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.ListView ScheduleListView;
        private System.Windows.Forms.ToolStripMenuItem ImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator FileToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem VersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.Label _DefaultSettingLabel;
        private System.Windows.Forms.ComboBox DefaultSettingComboBox;
    }
}

