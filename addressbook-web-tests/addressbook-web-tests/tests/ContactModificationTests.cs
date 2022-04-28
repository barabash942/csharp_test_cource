using NUnit.Framework;

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

            app.Contacts.Modify(1, 1, newData);
        }
    }
}