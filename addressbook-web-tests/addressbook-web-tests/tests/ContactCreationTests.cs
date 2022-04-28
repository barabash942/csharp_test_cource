using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactCreationTests : AuthTestBase
    {
        [SetUp]
        public void SetUp()
        {
            app.Contacts.OpenHomePageCheck();
        }

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Maria", "Potter");

            app.Contacts.Create(contact);
            app.Auth.Logout();
        }
    }
}
