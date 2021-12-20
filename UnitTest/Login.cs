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
            int status = LoginAccount.loginAccount("Daul123#", "Daul123#");
            Assert.AreEqual(0 , status);
        }
    }
}
