using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Class used to instantiate a Client object
    /// </summary>
    public class Client : User
    {
        private List<String> preferenceType = new List<String>(); //List of preferred investment types
        private List<int> preferenceRisk = new List<int>(); //List of preferred risk levels
        private List<String> preferenceCurrency = new List<String>(); //List of preferred currencies
        private List<String> preferenceRegion = new List<String>(); //List of preferred regions

        /// <summary>
        /// Class to be utilised as a user account by Clients
        /// </summary>
        /// <param name="name">Name to be assigned to the new Client</param>
        /// <param name="username">Username to be assigned to the new Client</param>
        /// <param name="pass">Password to be assigned to the new Client</param>
        /// <param name="userType">Byte representing the type of User (Should be 1 for Client)</param>
        public Client(String name, String username, String pass, byte userType) : base(name, username, pass, userType)
        {
            this.name = name;
            this.username = username;
            this.pass = pass;
            this.userType = userType;
        }
 
        /// <returns>A <b>List</b> of type <b>String</b> containing the Client's preferred invesment types</returns>
        public List<String> getPrefTypes()
        {
            return preferenceType;
        }

        /// <summary>
        /// Used to remove an investment type from the Client's preferences
        /// </summary>
        /// <param name="type">The type to be removed</param>
        public void removePreferenceType(String type)
        {
            preferenceType.Remove(type);
        }

        /// <summary>
        /// Used to add an investment type to the Client's preferences
        /// </summary>
        /// <param name="type">The investment type to be added</param>
        public void addPreferenceType(String type)
        {
            preferenceType.Add(type);
        }

        /// <returns>A <b>List</b> of type <b>int</b> containing the Client's preferred invesment risk levels</returns>
        public List<int> getPrefRisk()
        {
            return preferenceRisk;
        }

        /// <summary>
        /// Used to remove a risk level from the Client's preferences
        /// </summary>
        /// <param name="risk">The risk level to be removed</param>
        public void removePreferenceRisk(int risk)
        {
            preferenceRisk.Remove(risk);
        }

        /// <summary>
        /// Used to add an investment risk level to the Client's preferences
        /// </summary>
        /// <param name="risk">The investment risk level to be added</param>
        public void addPreferenceRisk(int risk)
        {
            preferenceRisk.Add(risk);
        }

        /// <returns>A <b>List</b> of type <b>String</b> containing the Client's preferred currencies</returns>
        public List<String> getPrefCurrency()
        {
            return preferenceCurrency;
        }

        /// <summary>
        /// Used to remove a currency from the Client's preferences
        /// </summary>
        /// <param name="currency">The currency to be removed</param>
        public void removePreferenceCurrency(String currency)
        {
            preferenceCurrency.Remove(currency);
        }

        /// <summary>
        /// Used to add an investment currency to the Client's preferences
        /// </summary>
        /// <param name="currency">The investment currency to be added</param>
        public void addPreferenceCurrency(String currency)
        {
            preferenceCurrency.Add(currency);
        }

        /// <returns>A <b>List</b> of type <b>String</b> containing the Client's preferred regions</returns>
        public List<String> getPrefRegion()
        {
            return preferenceRegion;
        }

        /// <summary>
        /// Used to remove a region from the Client's preferences
        /// </summary>
        /// <param name="region">The region to be removed</param>
        public void removePreferenceRegion(String region)
        {
            preferenceRegion.Remove(region);
        }

        /// <summary>
        /// Used to add an investment region to the Client's preferences
        /// </summary>
        /// <param name="currency">The region to be added</param>
        public void addPreferenceRegion(string region)
        {
            preferenceRegion.Add(region);
        }
    }
}
