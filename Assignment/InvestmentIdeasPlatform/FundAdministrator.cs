using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentIdeasPlatform
{
    public class FundAdministrator : User
    {
        public FundAdministrator(String newName, String newUsername, String newPassword, byte newType) : base(newName, newUsername, newPassword, newType)
        {

        }
    }
}
