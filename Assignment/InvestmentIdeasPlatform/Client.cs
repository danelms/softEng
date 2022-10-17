using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentIdeasPlatform
{
    class Client : User
    {
        private List<String> preferenceType = new List<String>();
        private List<int> preferenceRisk = new List<int>();
        private List<String> preferenceCurrency = new List<String>();
        private List<String> preferenceRegion = new List<String>();
        public Client(String username, String password, byte type) : base(username, password, type)
        {
            name = username;
            pass = password;
            userType = type;
        }
    }
}
