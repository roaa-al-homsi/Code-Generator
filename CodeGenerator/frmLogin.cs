using System;
using System.Windows.Forms;

namespace CodeGenerator
{
    public partial class frmLogin : Form
    {
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
            this.Close();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }
    }
}
