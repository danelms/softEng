using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using InvestmentIdeasPlatform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestClient()
        {
            Client test = new Client("Fred", "freddyboi", "password", 1);

            Assert.AreEqual("Fred", test.getName(), "Name not set correctly");
            Assert.AreNotEqual("Jenny", test.getName(), "Name not set correctly");
            Assert.AreEqual("password", test.getPass(), "Password not set correctly");
            Assert.AreNotEqual("password!!#@3", test.getPass(), "Password not set correctly");
            Assert.AreEqual("freddyboi", test.getUsername(), "Username not set correctly");
            Assert.AreNotEqual("toadrage", test.getUsername(), "Username not set correctly");
            Assert.AreEqual(1, test.getUserType(), "userType not set correctly");
            Assert.AreNotEqual("1", test.getUserType(), "userType not set correctly");
            test.setPreferenceRisk(2);
            Assert.AreEqual(2, test.getPrefRisk(), "Preference risk not set correctly");
            Assert.AreNotEqual("2", test.getPrefRisk(), "Preference risk not set correctly");
        }
        
        [TestMethod]
        public void TestUser()
        {
            User rm = new User("Bob", "bobbyboy", "password123", 2);

            Assert.AreEqual("Bob", rm.getName(), "Name not set correctly");
            Assert.AreNotEqual("Jake", rm.getName(), "Name not set correctly");
            Assert.AreEqual("password123", rm.getPass(), "Password not set correctly");
            Assert.AreNotEqual("PASSWORD123", rm.getPass(), "Password not set correctly");
            Assert.AreEqual("bobbyboy", rm.getUsername(), "Username not set correctly");
            Assert.AreNotEqual("freddyboi", rm.getUsername(), "Username not set correctly");
            Assert.AreEqual(2, rm.getUserType(), "User type not set correctly");
            Assert.AreNotEqual("2", rm.getUserType(), "User type not set correctly");
        }

        [TestMethod]
        public void TestIdea()
        {
            List<InvestmentProduct> products = new List<InvestmentProduct>() { null };

            InvestmentIdea idea = new InvestmentIdea("title", "overview", DateTime.Today, DateTime.Today.AddDays(10), "bob", products);

            Assert.AreEqual("title", idea.getTitle(), "Title not set correctly");
            Assert.AreNotEqual(null, idea.getTitle(), "Title not set correctly");
            Assert.AreEqual("overview", idea.getOverview(), "Title not set correctly");
            Assert.AreNotEqual(null, idea.getOverview(), "Title not set correctly");
            Assert.AreEqual(DateTime.Today, idea.getPublishDate(), "Publish date not set correctly");
            Assert.AreNotEqual(DateTime.Today.AddDays(1), idea.getPublishDate(), "Publish date not set correctly");
            Assert.AreEqual(DateTime.Today.AddDays(10), idea.getExpiryDate(), "Expiry date not set correctly");
            Assert.AreNotEqual(DateTime.Today, idea.getExpiryDate(), "Expiry date not set correctly");
            Assert.AreEqual("bob", idea.getAuthor(), "Author not set correctly");
            Assert.AreNotEqual("BOB", idea.getAuthor(), "Author not set correctly");
            Assert.AreEqual(null, idea.getSingleProduct(0), "Products not set correctly");
        }

        [TestMethod]
        public void TestProduct()
        {
            InvestmentProduct product = new InvestmentProduct("displayName", "instName", "assetType", "subType", "sectorL1", "sectorL2", "region", "country", "ticker", "ISIN", "issuer", "stockExchange", "currency", 1, 9.99, DateTime.Today.AddDays(10), DateTime.Today, DateTime.Today.AddDays(1), 1);

            Assert.AreEqual("displayName", product.getInstrumentDisplayName(), "Display name not set correctly");
            Assert.AreNotEqual("displayname", product.getInstrumentDisplayName(), "Display name not set correctly");
            Assert.AreEqual("instName", product.getInstrumentName(), "Instrument name not set correctly");
            Assert.AreNotEqual("", product.getInstrumentName(), "Instrument name not set correctly");
            Assert.AreEqual("assetType", product.getAssetType(), "Asset type not set correctly");
            Assert.AreNotEqual("badger", product.getAssetType(), "Asset type not set correctly");
            Assert.AreEqual("subType", product.getSubType(), "Sub-type not set correctly");
            Assert.AreNotEqual("sub Type", product.getSubType(), "Sub-type not set correctly");
            Assert.AreEqual("sectorL1", product.getSectorL1(), "Sector L1 not set correctly");
            Assert.AreNotEqual("L1", product.getSectorL1(), "Sector L1 not set correctly");
            Assert.AreEqual("sectorL2", product.getSectorL2(), "Sector L2 not set correctly");
            Assert.AreNotEqual(null, product.getSectorL2(), "Sector L2 not set correctly");
            Assert.AreEqual("region", product.getRegion(), "Region not set correctly");
            Assert.AreNotEqual("REGION", product.getRegion(), "Region not set correctly");
            Assert.AreEqual("country", product.getCountry(), "Country not set correctly");
            Assert.AreNotEqual(null, product.getCountry(), "Country not set correctly");
            Assert.AreEqual("ticker", product.getTicker(), "Ticker not set correctly");
            Assert.AreNotEqual("tiktok", product.getTicker(), "Ticker not set correctly");
            Assert.AreEqual("ISIN", product.getISIN(), "ISIN not set correctly");
            Assert.AreNotEqual("isin", product.getISIN(), "ISIN not set correctly");
            Assert.AreEqual("issuer", product.getIssuer(), "Issuer not set correctly");
            Assert.AreNotEqual(0, product.getIssuer(), "Issuer not set correctly");
            Assert.AreEqual("stockExchange", product.getStockExchange(), "Stock Exchange not set correctly");
            Assert.AreNotEqual("stonks", product.getStockExchange(), "Stock Exchange not set correctly");
            Assert.AreEqual("currency", product.getCurrency(), "Currency not set correctly");
            Assert.AreNotEqual("GBP", product.getCurrency(), "Currency not set correctly");
            Assert.AreEqual(1, product.getDenomination(), "Den not set correctly");
            Assert.AreNotEqual("denomination", product.getDenomination(), "Den not set correctly");
            Assert.AreEqual(9.99, product.getClosingPrice(), "CP not set correctly");
            Assert.AreNotEqual(10, product.getISIN(), "CP not set correctly");
            Assert.AreEqual(DateTime.Today.AddDays(10), product.getPriceClosingDate(), "PCD not set correctly");
            Assert.AreNotEqual(null, product.getPriceClosingDate(), "PCD not set correctly");
            Assert.AreEqual(DateTime.Today, product.getIssueDate(), "ID not set correctly");
            Assert.AreNotEqual(null, product.getIssueDate(), "ID not set correctly");
            Assert.AreEqual(DateTime.Today.AddDays(1), product.getMaturityDate(), "MD not set correctly");
            Assert.AreNotEqual(null, product.getMaturityDate(), "MD not set correctly");
            Assert.AreEqual(1, product.getRiskLevel(), "Risk level not set correctly");
            Assert.AreNotEqual(0, product.getRiskLevel(), "Risk level not set correctly");
        }
    }
}
