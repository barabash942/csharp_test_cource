using System;
using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests: AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData("MyNewpro73", "24ksdhfkIj");

            List<ProjectData> oldProjects = app.ProgectHelper.GetAll();

            app.ProgectHelper.CreateProject(project);

            Assert.AreEqual(oldProjects.Count + 1, app.ProgectHelper.GetProjectsCount());

            app.ManagementMenuHelper.GoToManageProgectsMenu();
            List<ProjectData> newProjects = app.ProgectHelper.GetAll();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
