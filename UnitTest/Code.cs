using Logica.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class Code
    {
        [TestMethod]
        public void GoodLength()
        {
            int length = GenerateCode.GetVerificationCode(6).Length;
            Assert.AreEqual(length, 6);
        }

        [TestMethod]
        public void BadLength()
        {
            int length = GenerateCode.GetVerificationCode(-1).Length;
            Assert.AreEqual(length, 0);
        }

    }
}
