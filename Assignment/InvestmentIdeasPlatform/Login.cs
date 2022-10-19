using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace InvestmentIdeasPlatform
{
    public partial class Login: Form
    {
        private static int num = 0;
        RelationshipManager rm = null;
        public RelationshipManager getRelationShipManager() { return rm;  }

        public Login()
        {
            InitializeComponent();
            num++;
        }

        private void usernameTextBox_Click(object sender, EventArgs e)
        {
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

        private void minimiseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void continueGuestButton_Click(object sender, EventArgs e)
        {
            Debug.Print(num.ToString());
           
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            String name = File.ReadLines("admin.txt").ElementAtOrDefault(4 - 1);
            String username = File.ReadLines("admin.txt").ElementAtOrDefault(2 - 1);
            String password = File.ReadLines("admin.txt").ElementAtOrDefault(3 - 1);
            String typeName = File.ReadLines("admin.txt").ElementAtOrDefault(1 - 1);
            byte type= 2;
            rm = new RelationshipManager(name,username,password,type);

            if (username == usernameTextBox.Text && password == passwordTextBox.Text) 
            {
                
            }


        }
    }
}
