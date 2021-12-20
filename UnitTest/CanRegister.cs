using Logica.AccountExist;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class CanRegister
    {
        [TestMethod]
        public void ValidAccount()
        {
            int code = AccountExist.Exist("testing@testing.com","testing");

            Assert.AreEqual(0, code);
        }

        [TestMethod]
        public void EmailExist()
        {
            int code = AccountExist.Exist("danielnochess@gmail.com", "testing");

            Assert.AreEqual(2, code);
        }

        [TestMethod]
        public void UserExist()
        {
            int code = AccountExist.Exist("testing@testing.com", "Daul123#");

            Assert.AreEqual(3, code);
        }

        [TestMethod]
        public void InvalidEntries()
        {
            int code = AccountExist.Exist("", "");

            Assert.AreEqual(1, code);
        }
    }
}
