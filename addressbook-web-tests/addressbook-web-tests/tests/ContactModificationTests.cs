using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [SetUp]
        public void SetUp()
        {
            app.Contacts.OpenHomePageCheck();
            app.Contacts.ContactCreatedCheck();
        }

        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Frida", "Kahlo");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(1, 1, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[1].FirstName = newData.FirstName;
            oldContacts[1].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}