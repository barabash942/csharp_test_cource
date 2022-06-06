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
            ContactData newData = new ContactData("Frida", "Kahlo");

            List<ContactData> oldContacts = ContactData.GetAllFromDb();
            ContactData oldContactData = oldContacts[0];

            app.Contacts.Modify(0, 0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetAllFromDb();
            oldContacts[1].FirstName = newData.FirstName;
            oldContacts[1].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }
        }
    }
}