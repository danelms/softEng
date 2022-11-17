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
            if (con.OpenConnection()) 
            {
                DbDataReader dr = con.Select("SELECT InstrumentDisplayName, InvestmentName, AssetType, IndustrySectorL1, IndustrySectorL2, Region, Country, Ticker, ISIN, Issuer, StockExchange, PriceCurrency, Denomination, ClosingPrice, PriceClosingDate, IssueDate, MaturityDate, RiskLevel FROM InvestmentProduct");
                while (dr.Read()) 
                {
                    String displayName = dr.GetString(0);
                    String instName = dr.GetString(1);
                    String assetType = dr.GetString(2);
                    String sectorL1 = dr.GetString(3);
                    String sectorL2 = dr.GetString(4);
                    String region = dr.GetString(5);
                    String country = dr.GetString(6);
                    String ticker = dr.GetString(7);
                    String iSIN = dr.GetString(8);
                    String issuer = dr.GetString(9);
                    String stockExchange = dr.GetString(10);
                    String currency = dr.GetString(11);
                    int denomination = dr.GetInt32(12);
                    double closingPrice = dr.GetDouble(13);
                    DateTime priceClosingDate = dr.GetDateTime(14);
                    DateTime issueDate = dr.GetDateTime(15);
                    DateTime maturityDate = dr.GetDateTime(16);
                    int riskLevel = dr.GetInt32(17);

                    InvestmentProduct investmentProduct = new InvestmentProduct(displayName,instName, assetType, sectorL1, sectorL2, region, country, ticker, iSIN, issuer, stockExchange, currency, denomination, closingPrice, priceClosingDate, issueDate, maturityDate, riskLevel);
                    products.Add(investmentProduct);
                }

                dr.Close();
                con.CloseConnection();
            }

            return products;

            
        }
    }
}
