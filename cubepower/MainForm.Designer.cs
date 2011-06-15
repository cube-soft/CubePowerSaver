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
            this._MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this._DummySplitContainer = new System.Windows.Forms.SplitContainer();
            this._ScheduleSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ScheduleListView = new System.Windows.Forms.ListView();
            this._ScheduleControlSplitContainer = new System.Windows.Forms.SplitContainer();
            this.RecommendButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this._FooterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.NavigationMenuStrip.SuspendLayout();
            this._MainSplitContainer.Panel1.SuspendLayout();
            this._MainSplitContainer.Panel2.SuspendLayout();
            this._MainSplitContainer.SuspendLayout();
            this._DummySplitContainer.Panel1.SuspendLayout();
            this._DummySplitContainer.SuspendLayout();
            this._ScheduleSplitContainer.Panel1.SuspendLayout();
            this._ScheduleSplitContainer.Panel2.SuspendLayout();
            this._ScheduleSplitContainer.SuspendLayout();
            this._ScheduleControlSplitContainer.Panel2.SuspendLayout();
            this._ScheduleControlSplitContainer.SuspendLayout();
            this._FooterSplitContainer.Panel2.SuspendLayout();
            this._FooterSplitContainer.SuspendLayout();
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
            this.NavigationMenuStrip.Size = new System.Drawing.Size(792, 24);
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
            this.ImportToolStripMenuItem.Click += new System.EventHandler(this.ImportToolStripMenuItem_Click);
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ExportToolStripMenuItem.Text = "エクスポート(&S)";
            this.ExportToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
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
            this.VersionToolStripMenuItem.Click += new System.EventHandler(this.VersionToolStripMenuItem_Click);
            // 
            // _MainSplitContainer
            // 
            this._MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._MainSplitContainer.IsSplitterFixed = true;
            this._MainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this._MainSplitContainer.Name = "_MainSplitContainer";
            this._MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _MainSplitContainer.Panel1
            // 
            this._MainSplitContainer.Panel1.Controls.Add(this._DummySplitContainer);
            // 
            // _MainSplitContainer.Panel2
            // 
            this._MainSplitContainer.Panel2.Controls.Add(this._FooterSplitContainer);
            this._MainSplitContainer.Panel2MinSize = 30;
            this._MainSplitContainer.Size = new System.Drawing.Size(792, 192);
            this._MainSplitContainer.SplitterDistance = 161;
            this._MainSplitContainer.SplitterWidth = 1;
            this._MainSplitContainer.TabIndex = 1;
            this._MainSplitContainer.TabStop = false;
            // 
            // _DummySplitContainer
            // 
            this._DummySplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._DummySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._DummySplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._DummySplitContainer.IsSplitterFixed = true;
            this._DummySplitContainer.Location = new System.Drawing.Point(0, 0);
            this._DummySplitContainer.Name = "_DummySplitContainer";
            this._DummySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _DummySplitContainer.Panel1
            // 
            this._DummySplitContainer.Panel1.Controls.Add(this._ScheduleSplitContainer);
            this._DummySplitContainer.Panel2MinSize = 30;
            this._DummySplitContainer.Size = new System.Drawing.Size(792, 161);
            this._DummySplitContainer.SplitterDistance = 130;
            this._DummySplitContainer.SplitterWidth = 1;
            this._DummySplitContainer.TabIndex = 0;
            this._DummySplitContainer.TabStop = false;
            // 
            // _ScheduleSplitContainer
            // 
            this._ScheduleSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ScheduleSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._ScheduleSplitContainer.IsSplitterFixed = true;
            this._ScheduleSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._ScheduleSplitContainer.Name = "_ScheduleSplitContainer";
            this._ScheduleSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _ScheduleSplitContainer.Panel1
            // 
            this._ScheduleSplitContainer.Panel1.Controls.Add(this.ScheduleListView);
            // 
            // _ScheduleSplitContainer.Panel2
            // 
            this._ScheduleSplitContainer.Panel2.Controls.Add(this._ScheduleControlSplitContainer);
            this._ScheduleSplitContainer.Panel2MinSize = 30;
            this._ScheduleSplitContainer.Size = new System.Drawing.Size(788, 126);
            this._ScheduleSplitContainer.SplitterDistance = 95;
            this._ScheduleSplitContainer.SplitterWidth = 1;
            this._ScheduleSplitContainer.TabIndex = 0;
            this._ScheduleSplitContainer.TabStop = false;
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
            this.ScheduleListView.Size = new System.Drawing.Size(788, 95);
            this.ScheduleListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ScheduleListView.TabIndex = 0;
            this.ScheduleListView.UseCompatibleStateImageBehavior = false;
            this.ScheduleListView.View = System.Windows.Forms.View.Details;
            this.ScheduleListView.SelectedIndexChanged += new System.EventHandler(this.ScheduleListView_SelectedIndexChanged);
            this.ScheduleListView.DoubleClick += new System.EventHandler(this.PropertyButton_Click);
            // 
            // _ScheduleControlSplitContainer
            // 
            this._ScheduleControlSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ScheduleControlSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._ScheduleControlSplitContainer.IsSplitterFixed = true;
            this._ScheduleControlSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._ScheduleControlSplitContainer.Name = "_ScheduleControlSplitContainer";
            this._ScheduleControlSplitContainer.Panel1MinSize = 5;
            // 
            // _ScheduleControlSplitContainer.Panel2
            // 
            this._ScheduleControlSplitContainer.Panel2.Controls.Add(this.RecommendButton);
            this._ScheduleControlSplitContainer.Panel2.Controls.Add(this.CreateButton);
            this._ScheduleControlSplitContainer.Panel2.Controls.Add(this.DeleteButton);
            this._ScheduleControlSplitContainer.Size = new System.Drawing.Size(788, 30);
            this._ScheduleControlSplitContainer.SplitterDistance = 232;
            this._ScheduleControlSplitContainer.SplitterWidth = 1;
            this._ScheduleControlSplitContainer.TabIndex = 0;
            this._ScheduleControlSplitContainer.TabStop = false;
            // 
            // RecommendButton
            // 
            this.RecommendButton.Location = new System.Drawing.Point(445, 3);
            this.RecommendButton.Name = "RecommendButton";
            this.RecommendButton.Size = new System.Drawing.Size(100, 23);
            this.RecommendButton.TabIndex = 7;
            this.RecommendButton.Text = "推奨設定";
            this.RecommendButton.UseVisualStyleBackColor = true;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(183, 3);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(150, 23);
            this.CreateButton.TabIndex = 6;
            this.CreateButton.Text = "新しいスケジュールを追加";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(339, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 23);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "削除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // _FooterSplitContainer
            // 
            this._FooterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._FooterSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._FooterSplitContainer.IsSplitterFixed = true;
            this._FooterSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._FooterSplitContainer.Name = "_FooterSplitContainer";
            // 
            // _FooterSplitContainer.Panel2
            // 
            this._FooterSplitContainer.Panel2.Controls.Add(this.SaveButton);
            this._FooterSplitContainer.Panel2.Controls.Add(this.ExitButton);
            this._FooterSplitContainer.Size = new System.Drawing.Size(792, 30);
            this._FooterSplitContainer.SplitterDistance = 562;
            this._FooterSplitContainer.SplitterWidth = 1;
            this._FooterSplitContainer.TabIndex = 0;
            this._FooterSplitContainer.TabStop = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(11, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "OK";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(117, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "キャンセル";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 216);
            this.Controls.Add(this._MainSplitContainer);
            this.Controls.Add(this.NavigationMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.NavigationMenuStrip;
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "MainForm";
            this.Text = "CubePowerSaver";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.NavigationMenuStrip.ResumeLayout(false);
            this.NavigationMenuStrip.PerformLayout();
            this._MainSplitContainer.Panel1.ResumeLayout(false);
            this._MainSplitContainer.Panel2.ResumeLayout(false);
            this._MainSplitContainer.ResumeLayout(false);
            this._DummySplitContainer.Panel1.ResumeLayout(false);
            this._DummySplitContainer.ResumeLayout(false);
            this._ScheduleSplitContainer.Panel1.ResumeLayout(false);
            this._ScheduleSplitContainer.Panel2.ResumeLayout(false);
            this._ScheduleSplitContainer.ResumeLayout(false);
            this._ScheduleControlSplitContainer.Panel2.ResumeLayout(false);
            this._ScheduleControlSplitContainer.ResumeLayout(false);
            this._FooterSplitContainer.Panel2.ResumeLayout(false);
            this._FooterSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip NavigationMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer _MainSplitContainer;
        private System.Windows.Forms.SplitContainer _DummySplitContainer;
        private System.Windows.Forms.SplitContainer _ScheduleSplitContainer;
        private System.Windows.Forms.ListView ScheduleListView;
        private System.Windows.Forms.ToolStripMenuItem ImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator FileToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem VersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer _ScheduleControlSplitContainer;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.SplitContainer _FooterSplitContainer;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button RecommendButton;
    }
}

