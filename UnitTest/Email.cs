using Logica.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class Email
    {
        [TestMethod]
        public void validEmail()
        {
            bool status = SendEmail.Send("correo@gmail.com ", "000000","Nalgón Curry");

            Assert.AreEqual(true, status);
        }

        [TestMethod]
        public void invalidEmail()
        {
            bool status = SendEmail.Send("correo", "000000", "Nalgón Curry");

            Assert.AreEqual(false, status);
        }
    }
}
