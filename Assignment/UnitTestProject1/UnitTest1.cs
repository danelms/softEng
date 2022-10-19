using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using InvestmentIdeasPlatform;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var fileName = "test.png";
                var fs = new FileStream(fileName, FileMode.Open);
                Bitmap profilePicture = new Bitmap(fs);
                fs.Close();
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }

            Client test = new Client("Fred", "freddyboi", "password", 2);

            Assert.AreEqual("Fred", test.getName(), "Name not set correctly");
            Assert.AreEqual("password", test.getPass(), "Password not set correctly");
            Assert.AreEqual("freddyboi", test.getUsername(), "Username not set correctly");
            //Assert.AreEqual("toadrage", test.getUsername(), "This should fail");

            FundAdministrator testRM = new InvestmentIdeasPlatform.FundAdministrator("Graham", "bigG", "securePass", 1);

            Assert.AreEqual("Graham", testRM.getName(), "Name not set correctly");
            Assert.AreEqual("securePass", testRM.getPass(), "Password not set correctly");
            Assert.AreEqual("bigG", testRM.getUsername(), "Username not set correctly");
            Assert.AreEqual(1, testRM.getUserType(), "User Type not set correctly");
        }
    }
}
