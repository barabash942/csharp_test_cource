using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactDeletionTests : BaseTest
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(1);
        }
    }
}