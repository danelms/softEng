using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Drawing;

namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Class used to instantiate BusinessMetaLayer objects
    /// </summary>
    public class BusinessMetaLayer
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
            String subType = "";
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
                DbDataReader dr = con.Select("SELECT * FROM InvestmentProduct");
                while (dr.Read()) 
                {
                    displayName = dr.GetString(1);
                    instName = dr.GetString(2);
                    assetType = dr.GetString(3);
                    subType = dr.GetString(4);
                    sectorL1 = dr.GetString(5);
                    sectorL2 = dr.GetString(6);
                    region = dr.GetString(7);
                    country = dr.GetString(8);
                    ticker = dr.GetString(9);
                    iSIN = dr.GetString(10);
                    issuer = dr.GetString(11);
                    stockExchange = dr.GetString(12);
                    currency = dr.GetString(13);
                    denomination = dr.GetInt32(14);
                    closingPrice = dr.GetDouble(15);
                    priceClosingDate = dr.GetDateTime(16);
                    issueDate = dr.GetDateTime(17);
                    maturityDate = dr.GetDateTime(18);
                    riskLevel = dr.GetInt32(19);

                    InvestmentProduct investmentProduct = new InvestmentProduct(displayName, instName, assetType, subType, sectorL1, sectorL2, region, country, ticker, iSIN, issuer, stockExchange, currency, denomination, closingPrice, priceClosingDate, issueDate, maturityDate, riskLevel);
                    products.Add(investmentProduct);
                }

                dr.Close();
                con.CloseConnection();
            }

            return products;

        }

        /// <summary>
        /// Fetches a list of all <b>User</b>s currently stored in the database
        /// </summary>
        /// <returns>The list of <b>User</b>s</returns>
        public List<User> getUsers() 
        {
            List<User> users = new List<User>();
            DBConnection con = DBFactory.instance();

            if (con.OpenConnection()) 
            {
                DbDataReader dr = con.Select("SELECT UserType, Name, Username, Password FROM User;");

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

        public List<User> getRelationshipManagers()
        {
            List<User> users = new List<User>();
            DBConnection con = DBFactory.instance();

            if (con.OpenConnection())
            {
                DbDataReader dr = con.Select("SELECT Name, Username, Password FROM User WHERE UserType=\"2\"");

                while (dr.Read())
                {
                    String name = dr.GetString(0);
                    String username = dr.GetString(1);
                    String password = dr.GetString(2);

                    User user = new User(name, username, password, 2);
                    users.Add(user);
                }

                dr.Close();
                con.CloseConnection();

            }

            return users;
        }

        public int getUserID(User user)
        {
            DBConnection con = DBFactory.instance();
            String username = user.getUsername();

            if (con.OpenConnection())
            {
                int userID = 0;
                DbDataReader dr = con.Select("SELECT id FROM User WHERE Username='" + username + "'");

                while (dr.Read())
                {
                    userID = dr.GetInt32(0);
                }
                dr.Close();
                con.CloseConnection();
                return userID;
            }
            else
            {
                MessageBox.Show("Failed to retrieve id from database for user: " + username);
                con.CloseConnection();
                return 0;
            }
        }

        public List<InvestmentIdea> getSuggestedIdeas(int clientID)
        {
            BusinessMetaLayer bml = BusinessMetaLayer.instance();
            List<InvestmentIdea> ideas = new List<InvestmentIdea>();
            InvestmentIdea idea = null;
            int ideaID;
            List<int>ideaIDs = new List<int>();
            DBConnection con = DBFactory.instance();
            con.OpenConnection();
            DbDataReader dr = con.Select("SELECT idea_id FROM IdeaSuggestion WHERE client_id ='" + clientID.ToString() + "'");

            while (dr.Read())
            {
                ideaID = dr.GetInt32(0);
                ideaIDs.Add(ideaID);
            }

            String overview;
            String publishDate;
            String expiryDate;
            String author;
            String title;
            List<int> productIDs = new List<int>();
            List<InvestmentProduct> products = new List<InvestmentProduct>();
            InvestmentProduct product = null;

            foreach (int id in ideaIDs)
            {
                dr = con.Select("SELECT * FROM InvestmentIdea WHERE id ='" + id + "'");

                while (dr.Read())
                {
                    overview = dr.GetString(1);
                    publishDate = dr.GetString(2);
                    expiryDate = dr.GetString(3);
                    author = dr.GetString(4);
                    title = dr.GetString(7);

                    dr = con.Select("SELECT product_id FROM ProductIdeaLink WHERE idea_id='" + id.ToString() + "'");

                    while(dr.Read())
                    {
                        productIDs.Add(dr.GetInt32(0));
                    }

                    String instDisplayName;
                    String instName;
                    String type;
                    String subType;
                    String sectorL1;
                    String sectorL2;
                    String region;
                    String country;
                    String ticker;
                    String ISIN;
                    String issuer;
                    String stockX;
                    String currency;
                    int denomination;
                    float closingPrice;
                    String priceClosingDate;
                    String issueDate;
                    String maturityDate;
                    int coupon;
                    int riskLevel;

                    foreach(int productID in productIDs)
                    {
                        dr = con.Select("SELECT * FROM InvestmentProduct WHERE id='" + productID.ToString() + "'");

                        while (dr.Read())
                        {
                            instDisplayName = dr.GetString(1);
                            instName = dr.GetString(2);
                            type = dr.GetString(3);
                            subType = dr.GetString(4);
                            sectorL1 = dr.GetString(5);
                            sectorL2 = dr.GetString(6);
                            region = dr.GetString(7);
                            country = dr.GetString(8);
                            ticker = dr.GetString(9);
                            ISIN = dr.GetString(10);
                            issuer = dr.GetString(11);
                            stockX = dr.GetString(12);
                            currency = dr.GetString(13);
                            denomination = dr.GetInt32(14);
                            closingPrice = dr.GetFloat(15);
                            priceClosingDate = dr.GetString(16);
                            issueDate = dr.GetString(17);
                            maturityDate = dr.GetString(18);
                            coupon = dr.GetInt32(19);
                            riskLevel = dr.GetInt32(20);

                            product = new InvestmentProduct(instDisplayName, instName, type, subType, sectorL1, sectorL1, region, country, ticker, ISIN, issuer, stockX, currency, denomination, closingPrice, DateTime.Parse(priceClosingDate), DateTime.Parse(issueDate), DateTime.Parse(maturityDate), riskLevel);
                            products.Add(product);
                        }
                    }

                    idea = new InvestmentIdea(title, overview, DateTime.Parse(publishDate), DateTime.Parse(expiryDate), author, products);
                    ideas.Add(idea);
                }
            }

            dr.Close();
            con.CloseConnection();

            return ideas;
        }

        public int getIdeaID(String ideaTitle)
        {
            DBConnection con = DBFactory.instance();

            if (con.OpenConnection())
            {
                int id = 0;
                DbDataReader dr = con.Select("SELECT id FROM InvestmentIdea WHERE Title='" + ideaTitle + "'");

                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                }
                dr.Close();
                con.CloseConnection();
                return id;
            }
            else
            {
                MessageBox.Show("Failed to retrieve id from database for InvestmentIdea: " + ideaTitle);
                con.CloseConnection();
                return 0;
            }
        }

        public int getProductID(InvestmentProduct product)
        {
            DBConnection con = DBFactory.instance();

            if (con.OpenConnection())
            {
                int userID = 0;
                DbDataReader dr = con.Select("SELECT id FROM InvestmentProduct WHERE InstrumentDisplayName='" + product.getInstrumentDisplayName() + "'");

                while (dr.Read())
                {
                    userID = dr.GetInt32(0);
                }
                dr.Close();
                con.CloseConnection();
                return userID;
            }
            else
            {
                MessageBox.Show("Failed to retrieve id from database for InvesmentProduct: " + product.getInstrumentName());
                con.CloseConnection();
                return 0;
            }
        }

        public void insertUserData(String name, int userType, String username, String password) 
        {
            DBConnection con = DBFactory.instance();
            if (con.OpenConnection())
            {
                String itemsString = "INSERT INTO User([Name], [UserType], [Username], [Password]) values(@name, @accountType, @username, @password)";
                String[] values = { name, userType.ToString(), username, password };
                con.Insert(1, itemsString, values);
            }
            con.CloseConnection();
        }

        public void insertIdeaData(String title, String overview, String publishDate, String expiryDate, String author, int rmID, int faID)
        {
            DBConnection con = DBFactory.instance();
            if (con.OpenConnection())
            {
                String itemString = "INSERT INTO InvestmentIdea([Title], [Overview], [PublishDate], [ExpiryDate], [Author], [rm_id], [fa_id]) values(@title, @overview, @publishDate, @expiryDate, @author, @rm_id, @fa_id)"; 
                String[] values = { title, overview, publishDate, expiryDate, author, rmID.ToString(), faID.ToString() };
                con.Insert(2, itemString, values);
            }
            con.CloseConnection();
        }

        public void insertProductIdeaLink(int ideaID, int productID)
        {
            DBConnection con = DBFactory.instance();
            if (con.OpenConnection())
            {
                String itemString = "INSERT INTO ProductIdeaLink([idea_id], [product_id]) values(@ideaID, @productID)";
                String[] values = { ideaID.ToString(), productID.ToString() };
                con.Insert(3, itemString, values);
            }
            con.CloseConnection();
        }
    }
}
