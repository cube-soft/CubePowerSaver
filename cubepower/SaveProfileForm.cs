using System;
using System.Windows.Forms;

namespace CubePower {
    public partial class SaveProfileForm : Form {
        public SaveProfileForm() {
            InitializeComponent();
        }

        public string ProfileName {
            get { return this.SaveAsTextBox.Text; }
            set { this.SaveAsTextBox.Text = value; }
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
