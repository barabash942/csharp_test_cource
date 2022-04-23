using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : BaseTest
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Frida", "Kahlo");

            app.Contacts.Modify(1, 1, newData);
        }
    }
}