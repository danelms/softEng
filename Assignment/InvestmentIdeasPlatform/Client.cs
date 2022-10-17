using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentIdeasPlatform
{
    public class Client : User
    {
        private List<String> preferenceType = new List<String>();
        private List<int> preferenceRisk = new List<int>();
        private List<String> preferenceCurrency = new List<String>();
        private List<String> preferenceRegion = new List<String>();
        public Client(String newName, String newUsername, String newPassword, byte newType) : base(newName, newUsername, newPassword, newType)
        {
            name = newName;
            username = newUsername;
            pass = newPassword;
            userType = newType;
        }

        public List<String> getPrefTypes()
        {
            return preferenceType;
        }

        public void removePreferenceType(String type)
        {
            preferenceType.Remove(type);
        }

        public void addPreferenceType(String type)
        {
            preferenceType.Add(type);
        }

        public List<int> getPrefRisk()
        {
            return preferenceRisk;
        }

        public List<String> getPrefCurrency()
        {
            return preferenceCurrency;
        }

        public List<String> getPrefRegion()
        {
            return preferenceRegion;
        }
    }
}
