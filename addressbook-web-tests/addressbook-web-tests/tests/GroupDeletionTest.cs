using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupDeletionTests : AuthTestBase
    {
        [SetUp]
        public void SetUp()
        {
            app.Groups.GroupPageOpenCheck();
            app.Groups.GroupCreatedCheck();
        }

        [Test]
        public void GroupDeletionTest()
        {
            app.Groups.Remove(1);
            
        }
    }
}
