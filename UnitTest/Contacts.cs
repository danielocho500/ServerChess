using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logica.helpers;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class Contacts
    {
        [TestMethod]
        public void SendRequest1()
        {
            SendStatus status = ContactsHelper.SendRequest(29, 23);

            Assert.AreEqual(status, SendStatus.success);
        }

        [TestMethod]
        public void SendRequest2()
        {
            SendStatus status = ContactsHelper.SendRequest(25, 23);

            Assert.AreEqual(status, SendStatus.success);
        }

        [TestMethod]
        public void SendRequest3()
        {
            SendStatus status = ContactsHelper.SendRequest(26, 23);

            Assert.AreEqual(status, SendStatus.success);
        }

        public void SendRequestFail()
        {
            SendStatus status = ContactsHelper.SendRequest(-1, -1);

            Assert.AreEqual(status, SendStatus.failed);
        }

        [TestMethod]
        public void GetRequestMultiple()
        {
            Dictionary<int, string> request = ContactsHelper.GetRequest(23);
            int results = request.Count;

            Assert.AreEqual(results, 3);
        }

        [TestMethod]
        public void GetRequestNull()
        {
            Dictionary<int, string> request = ContactsHelper.GetRequest(29);
            int results = request.Count;

            Assert.AreEqual(results, 0);
        }

        [TestMethod]
        public void GetRequestNoId()
        {
            Dictionary<int, string> request = ContactsHelper.GetRequest(-1);
            int results = request.Count;

            Assert.AreEqual(results, 0);
        }

        [TestMethod]
        public void ConfirmRequest()
        {
            StatusRespond status = ContactsHelper.ConfirmRequest(true, 25, 23);

            Assert.AreEqual(status, StatusRespond.success);
        }

        public void RejectRequest()
        {
            StatusRespond status = ContactsHelper.ConfirmRequest(false, 26, 23);

            Assert.AreEqual(status, StatusRespond.success);
        }
    }
}
