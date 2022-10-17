using NUnit.Framework;
using InvestmentIdeasPlatform;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Client test = new InvestmentIdeasPlatform.Client("Fred", "freddyboi", "password", 2);

            Assert.AreEqual("Fred", test.getName(), "Name not set correctly");
            Assert.AreEqual("password", test.getPass(), "Password not set correctly");
            Assert.AreEqual("freddyboi", test.getUsername(), "Username not set correctly");
            //Assert.AreEqual("toadrage", test.getUsername(), "This should fail");

            FundAdministrator testRM = new InvestmentIdeasPlatform.FundAdministrator("Graham", "bigG", "securePass", 1);

            Assert.AreEqual("Graham", testRM.getName(), "Name not set correctly");
            Assert.AreEqual("securePass", testRM.getPass(), "Password not set correctly");
            Assert.AreEqual("bigG", testRM.getUsername(), "Username not set correctly");
            Assert.AreEqual(1, testRM.GetUserType());
        }
    }
}