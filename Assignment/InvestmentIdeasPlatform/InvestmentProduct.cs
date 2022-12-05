using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Class used to isntantiate an InvestmentProduct object
    /// </summary>
    public class InvestmentProduct
    {
        private String instDisplayName; //Instrument display name
        private String instName; //Instrument name
        private String assetType; //The type of asset
        private String subType; //The asset subtype
        private String sectorL1; //Industry sector L1
        private String sectorL2; //Industry sector L2
        private String region; //Region the product exists in e.g. "Europe"
        private String country; //Country the products exists in e.g. "France"
        private String ticker; //Stock ticker
        private String ISIN; //International Securities Identification Number
        private String issuer; //Name of the product's issuer
        private String stockExchange; //The stock exchange
        private String currency; //The currency the product is dealt in
        private int denomination; //The denomination
        private double closingPrice; //The closing price
        private DateTime priceClosingDate; //The date of the closing price
        private DateTime issueDate; //The issue date
        private DateTime maturityDate; //The maturity date
        private int riskLevel; //A number representing the level of risk associated with this product

        /// <summary>
        /// Constructor for InvestmentProduct
        /// </summary>
        /// <param name="instDisplayName">Instrument display name</param>
        /// <param name="instName">Instrument name</param>
        /// <param name="assetType">The asset's type</param>
        /// <param name="subType">The asset's sub-type</param>
        /// <param name="sectorL1">Industry sector L1</param>
        /// <param name="sectorL2">Industry sector L2</param>
        /// <param name="region">Region e.g. "Europe"</param>
        /// <param name="country">Country e.g. "France"</param>
        /// <param name="ticker">Stock ticker</param>
        /// <param name="ISIN">International Securities Identification Number</param>
        /// <param name="issuer">Name of product's issuer</param>
        /// <param name="stockExchange">Stock exchange</param>
        /// <param name="currency">Currency</param>
        /// <param name="denomination">Denomination</param>
        /// <param name="closingPrice">Closing price</param>
        /// <param name="priceClosingDate">Date of closing price</param>
        /// <param name="issueDate">Date issued</param>
        /// <param name="maturityDate">Maturity date</param>
        /// <param name="riskLevel">Risk level</param>
        public InvestmentProduct(String instDisplayName, String instName, String assetType, String subType, String sectorL1, String sectorL2, String region, String country, String ticker, String ISIN, String issuer, String stockExchange, String currency, int denomination, double closingPrice, DateTime priceClosingDate, DateTime issueDate, DateTime maturityDate, int riskLevel)
        {
            this.instDisplayName = instDisplayName;
            this.instName = instName;
            this.assetType = assetType;
            this.subType = subType;
            this.sectorL1 = sectorL1;
            this.sectorL2 = sectorL2;
            this.region = region;
            this.country = country;
            this.ticker = ticker;
            this.ISIN = ISIN;
            this.issuer = issuer;
            this.stockExchange = stockExchange;
            this.currency = currency;
            this.denomination = denomination;
            this.closingPrice = closingPrice;
            this.priceClosingDate = priceClosingDate;
            this.issueDate = issueDate;
            this.maturityDate = maturityDate;
            this.riskLevel = riskLevel;
        }

        /// <returns>The instrument display name associated with the product as a <b>String</b></returns>
        public String getInstrumentDisplayName()
        {
            return instDisplayName;
        }

        /// <returns>The instument name associated with the product as a <b>String</b></returns>
        public String getInstrumentName()
        {
            return instName;
        }

        /// <returns>The type of asset the product is as a <b>String</b></returns>
        public String getAssetType()
        {
            return assetType;
        }

        public String getSubType()
        {
            return subType;
        }

        /// <returns>The industry sector (L1) as a <b>String</b></returns>
        public String getSectorL1()
        {
            return sectorL1;
        }

        /// <returns>The industry sector (L2) as a <b>String</b></returns>
        public String getSectorL2()
        {
            return sectorL2;
        }

        /// <returns>The product's region as a <b>String</b></returns>
        public String getRegion()
        {
            return region;
        }

        /// <returns>The product's country as a <b>String</b></returns>
        public String getCountry()
        {
            return country;
        }

        /// <returns>The stock ticker as a <b>String</b></returns>
        public String getTicker()
        {
            return ticker;
        }

        /// <returns>The ISIN as a <b>String</b></returns>
        public String getISIN()
        {
            return ISIN;
        }

        /// <returns>The name of the product's issuer as a <b>String</b></returns>
        public String getIssuer()
        {
            return issuer;
        }

        /// <returns>The name of the stock exchange as a <b>String</b></returns>
        public String getStockExchange()
        {
            return stockExchange;
        }

        /// <returns>The currency as a <b>String</b></returns>
        public String getCurrency()
        {
            return currency;
        }

        /// <returns>The denomination as an <b>int</b></returns>
        public int getDenomination()
        {
            return denomination;
        }

        /// <returns>Closing price as a <b>double</b></returns>
        public double getClosingPrice()
        {
            return closingPrice;
        }

        /// <returns>Date of closing price as <b>DateTime</b></returns>
        public DateTime getPriceClosingDate()
        {
            return priceClosingDate;
        }

        /// <returns>Issue date as <b>DateTime</b></returns>
        public DateTime getIssueDate()
        {
            return issueDate;
        }

        /// <returns>Maturity date as <b>DateTime</b></returns>
        public DateTime getMaturityDate()
        {
            return maturityDate;
        }

        /// <returns>The product's risk level as an <b>int</b></returns>
        public int getRiskLevel()
        {
            return riskLevel;
        }
    }
}
