using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : BaseTest
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("SomeNewText");
            newData.Header = "SomeNewHeader";
            newData.Footer = "SomeNewFooter";

            app.Groups.Modify(1, newData);
        }
    }
}