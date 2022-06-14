using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactDeletionTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (ContactData.GetAllFromDb().Count == 0)
            {
                string firstname = "UserNameForTest";
                string lastname = "UserFamilyForTest";
                ContactData contactForRemoving = new ContactData(firstname, lastname);
                app.Contacts.Create(contactForRemoving);
            }

            List<ContactData> oldContacts = ContactData.GetAllFromDb();

            app.Contacts.Remove(0);

            List<ContactData> newContacts = ContactData.GetAllFromDb();

            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}