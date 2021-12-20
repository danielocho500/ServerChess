using Logica.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class Connected
    {
        [TestMethod]
        public void IsConnected()
        {
            bool isConnected = CheckConnection.IsConnected();
            Assert.IsTrue(isConnected);
        }
    }
}
