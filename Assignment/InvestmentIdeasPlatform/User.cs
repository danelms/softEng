﻿using System;
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

        /// <summary>
        /// Base Constructor
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
