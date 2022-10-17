using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentIdeasPlatform
{
    abstract class User
    {
        protected String name;
        protected String pass;
        protected byte userType;

        public User(String username, String password, byte type)
        {
            name = username;
            pass = password;
            userType = type;
        }

        public String getUserName()
        {
            return name;
        }

        public String getPass()
        {
            return pass;
        }

        public byte getUserType()
        {
            return userType;
        }
    }
}
