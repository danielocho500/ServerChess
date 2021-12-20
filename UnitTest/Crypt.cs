using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logica.helpers;

namespace UnitTest
{
    [TestClass]
    public class Crypt
    {
        [TestMethod]
        public void TestMethod1()
        {
            string result = "029d7b64668ea6751a957231c56630dc3c3bf7765cff857b9a23614b9835a520";
            Assert.AreEqual(result, Encrypt.GetSHA256("123#@42lf"));
        }
    }
}
