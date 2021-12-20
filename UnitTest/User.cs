using Logica.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class User
    {
        [TestMethod]
        public void Exist()
        {
            bool status = UserHelper.Exist("Daul123#");

            Assert.AreEqual(true, status);
        }

        [TestMethod]
        public void NotExist()
        {
            bool status = UserHelper.Exist("i'm don't exist");

            Assert.AreEqual(false, status);
        }

        [TestMethod]
        public void Username()
        {
            int id = UserHelper.GetIdUser("Daniel123#");

            Assert.AreEqual(10, id);
        }

        [TestMethod]
        public void UsernameInvalid()
        {
            int id = UserHelper.GetIdUser("i'm don't exist");

            Assert.AreEqual(-1, id);
        }

        [TestMethod]
        public void GetUsername()
        {
            string username = UserHelper.GetUsername(10);

            Assert.AreEqual("Daniel123#", username);
        }

        [TestMethod]
        public void GetUsernameInvalid()
        {
            string username = UserHelper.GetUsername(0);

            Assert.AreEqual("", username);
        }
    }
}
