using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupDeletionTests : BaseTest
    {
        [Test]
        public void GroupDeletionTest()
        {
            app.Groups.Remove(1);
            
        }
    }
}
