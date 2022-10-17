using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Abstract base class that all User types (Client, RM, FA) will inherit from
    /// </summary>
    public abstract class User
    {
        protected String name;
        protected String username;
        protected String pass;
        protected byte userType;
        protected Bitmap profilePicture;

        public User(String newName, String newUsername, String newPassword, byte newType)
        {
            name = newName;
            username = newUsername;
            pass = newPassword;
            userType = newType;
        }

        public String getName()
        {
            return name;
        }

        public String getUsername()
        {
            return username;
        }

        public String getPass()
        {
            return pass;
        }

        public Bitmap getProfilePicture()
        {
            return profilePicture;
        }

        public void setProfilePicture(Bitmap picture)
        {
            profilePicture = picture;
        }

        public byte getUserType()
        {
            return userType;
        }
    }
}
