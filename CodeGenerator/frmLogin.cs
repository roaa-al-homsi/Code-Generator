using System;
using System.Windows.Forms;

namespace CodeGenerator
{
    public partial class frmLogin : Form
    {
        private MainScreen _mainForm = new MainScreen();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the current form
            _mainForm.ShowDialog(); // Open MainForm as a modal dialog
            this.Show(); // Show the LoginForm again when MainForm is closed

        }
    }
}
