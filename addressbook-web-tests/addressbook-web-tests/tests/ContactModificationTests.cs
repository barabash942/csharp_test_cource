using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (ContactData.GetAllFromDb().Count == 0)
            {
                string firstname = "UserNameForTest";
                string lastname = "UserFamilyForTest";
                ContactData contactForModication = new ContactData(firstname, lastname);
                app.Contacts.Create(contactForModication);
            }

            ContactData newData = new ContactData();
            newData.FirstName = "Tasha";
            newData.LastName = "White";

            List<ContactData> oldContacts = ContactData.GetAllFromDb();

            app.Contacts.Modify(0, 0, newData);

            List<ContactData> newContacts = ContactData.GetAllFromDb();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}