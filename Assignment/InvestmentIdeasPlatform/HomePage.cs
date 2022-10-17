using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestmentIdeasPlatform
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimiseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //this is used to clear the textbox so the user can enter username
        private void usernameTextBox_Click(object sender, EventArgs e)
        {
            //this makes sure data enered by user is not deleted when textbox is clicked
            if (usernameTextBox.ForeColor != Color.Black) 
            {
                usernameTextBox.Text = "";
                usernameTextBox.ForeColor = Color.Black;
            }
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.ForeColor != Color.Black)
            {
                passwordTextBox.Text = "";
                passwordTextBox.ForeColor = Color.Black;
            }
        }

        private void loginSidebarLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
