using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace InvestmentIdeasPlatform
{
    class BusinessMetaLayer
    {
        static private BusinessMetaLayer memInstance = null;

        private BusinessMetaLayer() { }

        static public BusinessMetaLayer instance()
        {
            if (null == memInstance)
            {
                memInstance = new BusinessMetaLayer();
            }
            return memInstance;
        }

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

        public List<RelationshipManager> getRelationshipManagers() 
        {
            List<RelationshipManager> relationshipManagerList = new List<RelationshipManager>();
            DBConnection con = DBFactory.instance();

            if (con.OpenConnection()) 
            {
                DbDataReader dr = con.Select("SELECT UserType, Name, Username, Password FROM RelationshipManager;");
                while (dr.Read()) 
                {
                    byte userType = dr.GetByte(0);
                    String name = dr.GetString(1);
                    String username = dr.GetString(2);
                    String password = dr.GetString(3);

                    RelationshipManager rm = new RelationshipManager(name, username, password, userType);
                    relationshipManagerList.Add(rm);

                }
                dr.Close();
                con.CloseConnection();
                
            }

            return relationshipManagerList;
        }

        public List<FundAdministrator> getFundAdministrators() 
        {
            List<FundAdministrator> fundAdministrators = new List<FundAdministrator>();
            DBConnection con = DBFactory.instance();

            if (con.OpenConnection()) 
            {
                DbDataReader dr = con.Select("SELECT CompanyID, UserType, Name, Username, Password, InvestmentProductList FROM FundAdministrator;");
                while (dr.Read()) 
                {
                    int companyId = dr.GetInt32(0);
                    byte userType = dr.GetByte(1);
                    String name = dr.GetString(2);
                    String username = dr.GetString(3);
                    String password = dr.GetString(4);
                    String investmentProductList = dr.GetString(5);

                    FundAdministrator fa = new FundAdministrator(name, username, password, userType);
                    fundAdministrators.Add(fa);
                }

                dr.Close();
                con.CloseConnection();
            
            }

            return fundAdministrators;
            
        }

        public List<Client> getClients() 
        {
            List<Client> clients = new List<Client>();
            DBConnection con = DBFactory.instance();

            if (con.OpenConnection()) 
            {
                DbDataReader dr = con.Select("SELECT UserType, Name, Username, Password, InvestProductPreferences, RiskLevel, Country FROM Client;");
                while (dr.Read()) 
                {
                    byte userType = dr.GetByte(0);
                    String name = dr.GetString(1);
                    String username = dr.GetString(2);
                    String password = dr.GetString(3);
                    String investProductPref = dr.GetString(4);
                    int riskLevel = dr.GetInt32(5);
                    String country = dr.GetString(6);

                    Client client = new Client(name, username, password, userType);
                    client.addPreferenceType(investProductPref);
                    clients.Add(client);
                }

                dr.Close();
                con.CloseConnection();
                
            }

            return clients;
        }
    }
}
