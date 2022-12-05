using InvestmentIdeasPlatform.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Class used to instantiate a User object
    /// </summary>
    public class User
    {
        protected String name; //Name tied to User
        protected String username; //Username tied to User
        protected String pass; //Password tied to User
        protected byte userType; //Type of user e.g., 1 = Client
        protected Bitmap profilePicture; //Profile picture, defaults to Resources>userIcon.png

        /// <summary>
        /// Constructor for User (Abstract)
        /// </summary>
        /// <param name="newName">Name to be assigned to new User</param>
        /// <param name="newUsername">Username to be assigned to new User</param>
        /// <param name="newPassword">Password to be assigned to new User</param>
        /// <param name="newType">Byte representing the type of User (1=Client, 2=RelationshipManager, 3=FundAdministrator)</param>
        public User(String newName, String newUsername, String newPassword, byte newType)
        {
            name = newName;
            username = newUsername;
            pass = newPassword;
            userType = newType;            
            profilePicture = new Bitmap(Resources.userIcon);
        }

        /// <returns>The User's name as a <b>String</b></returns>
        public String getName()
        {
            return name;
        }
        /// <returns>The User's username as a <b>String</b></returns>
        public String getUsername()
        {
            return username;
        }
        /// <returns>The User's password as a <b>String</b></returns>
        public String getPass()
        {
            return pass;
        }
        /// <returns>The User's profile picture as a <b>Bitmap</b></returns>
        public Bitmap getProfilePicture()
        {
            return profilePicture;
        }
        /// <summary>
        /// Used to set the User's profile picture
        /// </summary>
        /// <param name="picture"><b>Bitmap</b></param>
        public void setProfilePicture(Bitmap picture)
        {
            profilePicture = picture;
        }
        /// <returns>The User's type as a <b>Byte</b></returns>
        public byte getUserType()
        {
            return userType;
        }
    }
}
