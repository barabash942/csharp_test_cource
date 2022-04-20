using NUnit.Framework;

namespace addressbook_web_tests
{
    class ContactCreationTests : BaseTest
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Maria", "Potter");

            app.Contacts.Create(contact);
            app.Auth.Logout();
        }
    }
}
