using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Class used to instantiate BusinessMetaLayer objects
    /// </summary>
    class BusinessMetaLayer
    {
        static private BusinessMetaLayer memInstance = null;

        private BusinessMetaLayer() { }

        /// <summary>
        /// Singleton constructor for BusinessMetaLayer class
        /// </summary>
        /// <returns></returns>
        static public BusinessMetaLayer instance()
        {
            if (null == memInstance)
            {
                memInstance = new BusinessMetaLayer();
            }
            return memInstance;
        }

        /// <summary>
        /// Fetches a list of all the <b>InvestmentProduct</b>s currently stored in the database
        /// </summary>
        /// <returns>The list of <b>InvestmentProduct</b>s</returns>
        public List<InvestmentProduct> getInvestmentProducts() 
        {
            List<InvestmentProduct> products = new List<InvestmentProduct>();

            DBConnection con = DBFactory.instance();

            String displayName = "";
            String instName = "";
            String assetType = "";
            String sectorL1 ="";
            String sectorL2 ="";
            String region = "";
            String country = "";
            String ticker = "";
            String iSIN = "";
            String issuer = "";
            String stockExchange = "";
            String currency ="";
            int denomination = 0;
            double closingPrice = 0;
            DateTime priceClosingDate = new DateTime();
            DateTime issueDate = new DateTime();
            DateTime maturityDate = new DateTime();
            int riskLevel = 0;

            if (con.OpenConnection()) 
            {
                DbDataReader dr = con.Select("SELECT InstrumentDisplayName, InvestmentName, AssetType, IndustrySectorL1, IndustrySectorL2, Region, Country, Ticker, ISIN, Issuer, StockExchange, PriceCurrency, Denomination, ClosingPrice, PriceClosingDate, IssueDate, MaturityDate, RiskLevel FROM InvestmentProduct");
                while (dr.Read()) 
                {

                    displayName = dr.GetString(0);
                    instName = dr.GetString(1);
                    assetType = dr.GetString(2);
                    sectorL1 = dr.GetString(3);
                    sectorL2 = dr.GetString(4);
                    region = dr.GetString(5);
                    country = dr.GetString(6);
                    ticker = dr.GetString(7);
                    iSIN = dr.GetString(8);
                    issuer = dr.GetString(9);
                    stockExchange = dr.GetString(10);
                    currency = dr.GetString(11);
                    denomination = dr.GetInt32(12);
                    closingPrice = dr.GetDouble(13);
                    priceClosingDate = dr.GetDateTime(14);
                    issueDate = dr.GetDateTime(15);
                    maturityDate = dr.GetDateTime(16);
                    riskLevel = dr.GetInt32(17);

                    InvestmentProduct investmentProduct = new InvestmentProduct(displayName,instName, assetType, sectorL1, sectorL2, region, country, ticker, iSIN, issuer, stockExchange, currency, denomination, closingPrice, priceClosingDate, issueDate, maturityDate, riskLevel);
                    products.Add(investmentProduct);
                }

                dr.Close();
                con.CloseConnection();
            }

            return products;

        }

        /// <summary>
        /// Fetches a list of all <b>Client</b>s currently stored in the database
        /// </summary>
        /// <returns>The list of <b>Client</b>s</returns>
        public List<User> getUsers() 
        {
            List<User> users = new List<User>();
            DBConnection con = DBFactory.instance();

            if (con.OpenConnection()) 
            {
                DbDataReader dr = con.Select("SELECT UserType, Name, Username, Password, FROM User;");
                while (dr.Read()) 
                {
                    byte userType = dr.GetByte(0);
                    String name = dr.GetString(1);
                    String username = dr.GetString(2);
                    String password = dr.GetString(3);

                    User user = new User(name, username, password, userType);
                    users.Add(user);
                }

                dr.Close();
                con.CloseConnection();
                
            }

            return users;
        }

        public void insertUserData(String query, int accountType, String username, String password) 
        {
            DBConnection con = DBFactory.instance();

            if (con.OpenConnection()) 
            {
                con.Insert(query, accountType, username, password);
            }

            con.CloseConnection();
        }
    }
}
