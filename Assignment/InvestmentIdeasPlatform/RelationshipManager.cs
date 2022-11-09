using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Class to be utilised as a user account by Relationship Managers
    /// </summary>
    public class RelationshipManager : User
    {
        /// <summary>
        /// Constructor, inherits from User
        /// </summary>
        /// <param name="newName">Name to be assigned to the new RelationshipManager</param>
        /// <param name="newUsername">Username to be assigned to the new RelationshipManager</param>
        /// <param name="newPassword">Password to be assigned to the new RelationshipManager</param>
        /// <param name="newType">Byte representing the type of User (Should be 2 for RelationshipManager)</param>
        public RelationshipManager(String newName, String newUsername, String newPassword, byte newType) : base(newName, newUsername, newPassword, newType)
        {
            name = newName;
            username = newUsername;
            pass = newPassword;
            userType = newType;
        }

        Button viewIdeas = new Button();
        Button viewClient = new Button();
        Button createUser = new Button();
        Button logout = new Button();

        Panel viewIdeasPanel = new Panel();
        Panel viewClientPanel = new Panel();
        Panel createUserPanel = new Panel();


        public void addRmMenu(Panel panel) 
        {
            
            void styleButton(Button button , String title) 
            {
                button.Width = 220;
                button.Height = 34;
                button.Dock = DockStyle.Top;
                button.Text = title;
                button.FlatStyle = FlatStyle.Flat;
                button.Font = new Font("Arial", 14);
                button.FlatAppearance.BorderSize = 0;
                button.BringToFront();
            }
            
            panel.Controls.Add(viewIdeas);
            panel.Controls.Add(viewClient);
            panel.Controls.Add(createUser);
            panel.Controls.Add(logout);

            styleButton(viewIdeas, "View Ideas");
            styleButton(viewClient, "View Clients");
            styleButton(createUser, "Create User");
            styleButton(logout, "Log Out");
        }

        public void addRmPanels(Form form)
        {
            stylePanel(viewIdeasPanel);
            stylePanel(viewClientPanel);
            stylePanel(createUserPanel);

            Label title = new Label();
            title.Text = "1";
            title.Font = new Font("Arial", 32);
            title.Location = new Point(130, 50);
            title.ForeColor = Color.Black;
            title.Width = 600;
            title.Height = 60;
            viewIdeasPanel.Controls.Add(title);

            Label title2 = new Label();
            title2.Text = "2";
            title2.Font = new Font("Arial", 32);
            title2.Location = new Point(130, 50);
            title2.ForeColor = Color.Black;
            title2.Width = 600;
            title2.Height = 60;
            viewClientPanel.Controls.Add(title2);

            Label title3 = new Label();
            title3.Text = "3";
            title3.Font = new Font("Arial", 32);
            title3.Location = new Point(130, 50);
            title3.ForeColor = Color.Black;
            title3.Width = 600;
            title3.Height = 60;
            createUserPanel.Controls.Add(title3);

            addButtonEventHandlers();
            
            form.Controls.Add(viewIdeasPanel);
            form.Controls.Add(viewClientPanel);
            form.Controls.Add(createUserPanel);
        }

        public void stylePanel(Panel panel)
        {
            panel.AutoScroll = true;
            panel.Location = new Point(220, 30);
            panel.Size = new Size(800, 550);
            panel.BackColor = Color.FromArgb(181, 190, 198);
            panel.Visible = true;
        }

        private void addButtonEventHandlers() 
        {
            viewClient.Click += ViewClient_Click;
            viewIdeas.Click += ViewIdeas_Click;
            createUser.Click += CreateUser_Click;
            logout.Click += Logout_Click;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            createUserPanel.BringToFront();
        }

        private void ViewClient_Click(object sender, EventArgs e)
        {
            viewClientPanel.BringToFront();
        }

        private void ViewIdeas_Click(object sender, EventArgs e)
        {
            viewIdeasPanel.BringToFront();
        }
    }
}
