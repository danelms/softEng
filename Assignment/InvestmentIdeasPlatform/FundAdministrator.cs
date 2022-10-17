using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Class to be utilised as a user account by Fund Administrators
    /// </summary>
    public class FundAdministrator : User
    {
        /// <summary>
        /// Constructor, inherits from User
        /// </summary>
        /// <param name="newName">Name to be assigned to new FundAdministrator</param>
        /// <param name="newUsername">Username to be assigned to new FundAdministrator</param>
        /// <param name="newPassword">Password to be assigned to new FundAdministrator</param>
        /// <param name="newType">Byte representing the type of User (Should be 3 for FundAdministrator)</param>
        public FundAdministrator(String newName, String newUsername, String newPassword, byte newType) : base(newName, newUsername, newPassword, newType)
        {
            name = newName;
            username = newUsername;
            pass = newPassword;
            userType = newType;
        }
    }
}
