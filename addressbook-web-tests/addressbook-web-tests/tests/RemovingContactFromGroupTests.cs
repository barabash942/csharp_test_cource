using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    class RemovingContactFromGroupTests
    {
        public class RemovingContactFromGroupTest : AuthTestBase
        {
            [Test]
            public void TestRemovingContactFromGroup()
            {
                app.Contacts.ContactCreatedCheck();
                app.Groups.GroupCreatedCheck();

                GroupData group = GroupData.GetAllFromDb()[0];
                List<ContactData> oldList = group.GetContacts();
                ContactData contact = ContactData.GetAllFromDb().First();
                app.Contacts.ContactAddedInGroupCheck(contact, oldList, group);

                app.Contacts.RemoveContactFromGroup(contact, group);

                List<ContactData> newList = group.GetContacts();
                oldList.Remove(contact);
                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);
            }
        }
    }
}
