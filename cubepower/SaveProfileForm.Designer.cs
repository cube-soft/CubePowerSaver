namespace CubePower {
    partial class SaveProfileForm {
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
            this._SaveAsLabel = new System.Windows.Forms.Label();
            this.SaveAsTextBox = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _SaveAsLabel
            // 
            this._SaveAsLabel.AutoSize = true;
            this._SaveAsLabel.Location = new System.Drawing.Point(12, 9);
            this._SaveAsLabel.Name = "_SaveAsLabel";
            this._SaveAsLabel.Size = new System.Drawing.Size(105, 12);
            this._SaveAsLabel.TabIndex = 0;
            this._SaveAsLabel.Text = "電源設定の保存名：";
            // 
            // SaveAsTextBox
            // 
            this.SaveAsTextBox.Location = new System.Drawing.Point(12, 24);
            this.SaveAsTextBox.Name = "SaveAsTextBox";
            this.SaveAsTextBox.Size = new System.Drawing.Size(300, 19);
            this.SaveAsTextBox.TabIndex = 1;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(210, 51);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 23);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "キャンセル";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(104, 51);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "OK";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 86);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SaveAsTextBox);
            this.Controls.Add(this._SaveAsLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveProfileForm";
            this.Text = "電源設定の保存";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _SaveAsLabel;
        private System.Windows.Forms.TextBox SaveAsTextBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveButton;
    }
}