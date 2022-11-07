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

        public void addRmMenu(Panel panel) 
        {
            Button viewIdeas = new Button();
            Button viewClient = new Button();
            Button createUser = new Button();
            Button logout = new Button();

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
    }
}
