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
        public void Testa()
        {
            SendStatus status = ContactsHelper.SendRequest(29, 23);

            Assert.AreEqual(status, SendStatus.success);
        }

        [TestMethod]
        public void Testb()
        {
            SendStatus status = ContactsHelper.SendRequest(25, 23);

            Assert.AreEqual(status, SendStatus.success);
        }

        [TestMethod]
        public void Testc()
        {
            SendStatus status = ContactsHelper.SendRequest(26, 23);

            Assert.AreEqual(status, SendStatus.success);
        }

        [TestMethod]
        public void Testd()
        {
            SendStatus status = ContactsHelper.SendRequest(-1, -1);

            Assert.AreEqual(status, SendStatus.failed);
        }

        [TestMethod]
        public void Teste()
        {
            Dictionary<int, string> request = ContactsHelper.GetRequest(23);
            int results = request.Count;

            Assert.AreEqual(results, 3);
        }

        [TestMethod]
        public void Testf()
        {
            Dictionary<int, string> request = ContactsHelper.GetRequest(29);
            int results = request.Count;

            Assert.AreEqual(results, 0);
        }

        [TestMethod]
        public void Testg()
        {
            Dictionary<int, string> request = ContactsHelper.GetRequest(-1);
            int results = request.Count;

            Assert.AreEqual(results, 0);
        }

        [TestMethod]
        public void Testh()
        {
            StatusRespond status = ContactsHelper.ConfirmRequest(true, 23, 25);

            Assert.AreEqual(status, StatusRespond.success);
        }
        
        [TestMethod]
        public void Testi()
        {
            StatusRespond status = ContactsHelper.ConfirmRequest(false, 23, 26);

            Assert.AreEqual(status,StatusRespond.success);
        }

        [TestMethod]
        public void Testj()
        {
            StatusRespond status = ContactsHelper.ConfirmRequest(false, -1, -1);

            Assert.AreEqual(status, StatusRespond.failed);
        }

        [TestMethod]
        public void Testk()
        {
            Dictionary<int, string> friends = ContactsHelper.GetFriends(23);

            int count = friends.Count;

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Testm()
        {
            Dictionary<int, string> friends = ContactsHelper.GetFriends(24);

            int count = friends.Count;

            Assert.AreEqual(count, 0);
        }

        [TestMethod]
        public void Testn()
        {
            Dictionary<int, string> friends = ContactsHelper.GetFriends(-1);

            int count = friends.Count;

            Assert.AreEqual(count, 0);
        }

        [TestMethod]
        public void Testo()
        {
            ContactsStatus status = ContactsHelper.ContactsRelation(23,24);
            Assert.AreEqual(ContactsStatus.noRelation, status);
        }

        [TestMethod]
        public void Testp()
        {
            ContactsStatus status = ContactsHelper.ContactsRelation(23, 25);
            Assert.AreEqual(ContactsStatus.friends, status);
        }

        [TestMethod]
        public void Testq()
        {
            ContactsStatus status = ContactsHelper.ContactsRelation(23, 26);
            Assert.AreEqual(ContactsStatus.rejected, status);
        }

        [TestMethod]
        public void Testr()
        {
            ContactsStatus status = ContactsHelper.ContactsRelation(23, 29);
            Assert.AreEqual(ContactsStatus.requested, status);
        }

        [TestMethod]
        public void Tests()
        {
            ContactsStatus status = ContactsHelper.ContactsRelation(-1, -1);
            Assert.AreEqual(ContactsStatus.noRelation, status);

            ContactsHelper.DeleteTest();
        }
    }
}
