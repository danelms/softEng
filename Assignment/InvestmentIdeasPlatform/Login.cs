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
        List<RelationshipManager> rm = new List<RelationshipManager>();
        List<FundAdministrator> fa = new List<FundAdministrator>();
        List<Client> clients = new List<Client>();

        
        User user = null;
        public User getCurrentUser() 
        {
            return user;  
        }

        public Login()
        {
            InitializeComponent();
            rm = ml.getRelationshipManagers();
            fa = ml.getFundAdministrators();
            clients = ml.getClients();
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

            foreach (RelationshipManager rmanager in rm)
            {
                if (rmanager.getUsername() == usernameTextBox.Text && rmanager.getPass() == passwordTextBox.Text)
                {
                    name = rmanager.getName();
                    type = rmanager.getUserType();
                }
            }

            foreach (FundAdministrator fundAdmin in fa)
            {
                if (fundAdmin.getUsername() == usernameTextBox.Text && fundAdmin.getPass() == passwordTextBox.Text)
                {
                    name = fundAdmin.getName();
                    type = fundAdmin.getUserType();
                }
            }

            foreach (Client client in clients)
            {
                if (client.getUsername() == usernameTextBox.Text && client.getPass() == passwordTextBox.Text)
                {
                    name = client.getName();
                    type = client.getUserType();
                }
            }


            switch (type)
            {
                case 0:
                    user = null;
                    break;
                case 1:
                    user = new Client(name, username, password, type);
                    break;
                case 2:
                    user = new RelationshipManager(name, username, password, type);
                    break;
                case 3:
                    user = new FundAdministrator(name, username, password, type);
                    break;
            }
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            foreach (RelationshipManager rmanager in rm) 
            {
                if (rm != null) 
                {
                    if (usernameTextBox.Text == rmanager.getUsername() && passwordTextBox.Text == rmanager.getPass())
                    {
                        loginButton.DialogResult = DialogResult.OK;
                    }
                }
            }

            foreach (FundAdministrator fundAdmin in fa)
            {
                if (rm != null)
                {
                    if (usernameTextBox.Text == fundAdmin.getUsername() && passwordTextBox.Text == fundAdmin.getPass())
                    {
                        loginButton.DialogResult = DialogResult.OK;
                    }
                }
            }

            foreach (Client client in clients)
            {
                if (rm != null)
                {
                    if (usernameTextBox.Text == client.getUsername() && passwordTextBox.Text == client.getPass())
                    {
                        loginButton.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            foreach (RelationshipManager rmanager in rm)
            {
                if (rm != null)
                {
                    if (usernameTextBox.Text == rmanager.getUsername() && passwordTextBox.Text == rmanager.getPass())
                    {

                        loginButton.DialogResult = DialogResult.OK;
                    }
                }
            }

            foreach (FundAdministrator fundAdmin in fa)
            {
                if (rm != null)
                {
                    if (usernameTextBox.Text == fundAdmin.getUsername() && passwordTextBox.Text == fundAdmin.getPass())
                    {
                        loginButton.DialogResult = DialogResult.OK;
                    }
                }
            }

            foreach (Client client in clients)
            {
                if (rm != null)
                {
                    if (usernameTextBox.Text == client.getUsername() && passwordTextBox.Text == client.getPass())
                    {

                        loginButton.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
    }
}
