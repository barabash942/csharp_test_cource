using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovingTests : AuthTestBase
    {
        [SetUp]
        public void SetUp()
        {//тут должны быть проверки, но из-за спешки они не реализованы
            //app.ProgectHelper.ProjectPageOpenCheck();
            //app.ProgectHelper.ProjectCreatedCheck();
        }

        [Test]
        public void ProjectRemovingTest()
        {
            List<ProjectData> oldProjects = app.ProgectHelper.GetAll();
            ProjectData toBeRemoved = oldProjects[0];

            app.ProgectHelper.RemoveProject(toBeRemoved);

            Assert.AreEqual(oldProjects.Count - 1, app.ProgectHelper.GetProjectsCount());

            List<ProjectData> newProjects = app.ProgectHelper.GetAll();

            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
