using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [SetUp]
        public void SetUp()
        {
            app.Groups.GroupPageOpenCheck();
        }

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("Aprlil12");
            group.Header = "Sky";
            group.Footer = "Moon";

            app.Groups.Create(group);
            app.Auth.Logout();
        }

        [Test]
        public void EmptyNamesGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
            app.Auth.Logout();
        }
    }
}
