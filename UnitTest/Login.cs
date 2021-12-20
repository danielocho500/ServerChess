using Logica.login;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class Login
    {
        [TestMethod]
        public void Success()
        {
            int status = LoginAccount.Login("Daul123#", "Daul123#");
            Assert.AreEqual(0 , status);
        }

        [TestMethod]
        public void fail()
        {
            int status = LoginAccount.Login("KJLsjlksa", "Daul123#");
            Assert.AreEqual(2, status);
        }

        [TestMethod]
        public void empty()
        {
            int status = LoginAccount.Login("", "Daul123#");
            Assert.AreEqual(3, status);
        }

        [TestMethod]
        public void empty_()
        {
            int status = LoginAccount.Login("KJLsjlksa", "");
            Assert.AreEqual(3, status);
        }
    }
}
