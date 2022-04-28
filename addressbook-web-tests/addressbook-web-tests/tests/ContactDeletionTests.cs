using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactDeletionTests : AuthTestBase
    {
        [SetUp]
        public void SetUp()
        {
            app.Contacts.OpenHomePageCheck();
            app.Contacts.ContactCreatedCheck();
        }

        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(1);
        }
    }
}