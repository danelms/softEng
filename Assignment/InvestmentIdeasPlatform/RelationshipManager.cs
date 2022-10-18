using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
