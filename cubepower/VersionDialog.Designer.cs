﻿namespace CubePower
{
    partial class VersionDialog
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.TitlePictureBox = new System.Windows.Forms.PictureBox();
            this.CubePDFLinkLabel = new System.Windows.Forms.LinkLabel();
            this.OKButton = new System.Windows.Forms.Button();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.IsSplitterFixed = true;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.MainSplitContainer.Panel1.Controls.Add(this.CopyrightLabel);
            this.MainSplitContainer.Panel1.Controls.Add(this.VersionLabel);
            this.MainSplitContainer.Panel1.Controls.Add(this.TitlePictureBox);
            this.MainSplitContainer.Panel1.Controls.Add(this.CubePDFLinkLabel);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.OKButton);
            this.MainSplitContainer.Size = new System.Drawing.Size(333, 168);
            this.MainSplitContainer.SplitterDistance = 123;
            this.MainSplitContainer.SplitterWidth = 2;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.AutoSize = true;
            this.CopyrightLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CopyrightLabel.Location = new System.Drawing.Point(84, 81);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(153, 12);
            this.CopyrightLabel.TabIndex = 5;
            this.CopyrightLabel.Text = "Copyright (c) 2010 CubeSoft.";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.VersionLabel.Location = new System.Drawing.Point(113, 69);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(102, 12);
            this.VersionLabel.TabIndex = 4;
            this.VersionLabel.Text = "Version: 1.0.0 (x86)";
            // 
            // TitlePictureBox
            // 
            this.TitlePictureBox.Image = global::CubePower.Properties.Resources.logo;
            this.TitlePictureBox.Location = new System.Drawing.Point(45, 12);
            this.TitlePictureBox.Name = "TitlePictureBox";
            this.TitlePictureBox.Size = new System.Drawing.Size(240, 54);
            this.TitlePictureBox.TabIndex = 12;
            this.TitlePictureBox.TabStop = false;
            // 
            // CubePDFLinkLabel
            // 
            this.CubePDFLinkLabel.AutoSize = true;
            this.CubePDFLinkLabel.Location = new System.Drawing.Point(70, 93);
            this.CubePDFLinkLabel.Name = "CubePDFLinkLabel";
            this.CubePDFLinkLabel.Size = new System.Drawing.Size(192, 12);
            this.CubePDFLinkLabel.TabIndex = 2;
            this.CubePDFLinkLabel.TabStop = true;
            this.CubePDFLinkLabel.Text = "http://www.cube-soft.jp/cubepower/";
            this.CubePDFLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CubePDFLinkLabel_LinkClicked);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(130, 8);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // VersionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 168);
            this.Controls.Add(this.MainSplitContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CubePowerSaver について";
            this.Shown += new System.EventHandler(this.VersionDialog_Shown);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel1.PerformLayout();
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TitlePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.LinkLabel CubePDFLinkLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label CopyrightLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.PictureBox TitlePictureBox;


    }
}