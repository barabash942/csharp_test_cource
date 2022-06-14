using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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
            if (GroupData.GetAllFromDb().Count == 0)
            {
                string name = "GroupNameForTest";
                GroupData groupForModication = new GroupData(name);
                app.Groups.Create(groupForModication);
            }

            GroupData newData = new GroupData();
            newData.Name = "UpdatedText";
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GetAllFromDb();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAllFromDb();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}