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
        BusinessMetaLayer ml = BusinessMetaLayer.instance();
        List<User> users = new List<User>();

        User user = null;

        public User getCurrentUser() 
        {
            return user;  
        }

        public Login()
        {
            InitializeComponent();
            users = ml.getUsers();
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

        private void loginButton_Click(object sender, EventArgs e)
        {
            String name = "";
            String username = usernameTextBox.Text;
            String password = passwordTextBox.Text;
            byte type = 0;

            foreach (User user in users)
            {
                if (user.getUsername() == usernameTextBox.Text && user.getPass() == passwordTextBox.Text)
                {
                    name = user.getName();
                    type = user.getUserType();
                }
            }

            user = new User(name, username, password, type);
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

            foreach (User user in users)
            {
                if (user != null)
                {
                    if (usernameTextBox.Text == user.getUsername() && passwordTextBox.Text == user.getPass())
                    {
                        loginButton.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            foreach (User user in users)
            {
                if (user != null)
                {
                    if (usernameTextBox.Text == user.getUsername() && passwordTextBox.Text == user.getPass())
                    {
                        loginButton.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
    }
}
