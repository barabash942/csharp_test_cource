using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [SetUp]
        public void SetUp()
        {
            app.Groups.GroupPageOpenCheck();
            app.Groups.GroupCreatedCheck();
        }

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("SomeNewText");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);
        }
    }
}