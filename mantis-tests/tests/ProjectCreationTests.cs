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
        public static IEnumerable<ProjectData> RandomProjectDataProvider()
        {
            List<ProjectData> prj = new List<ProjectData>();
            for (int i = 0; i < 5; i++)
            {
                prj.Add(new ProjectData()
                {
                    Name = GenerateRandomString(100),
                    Description = GenerateRandomString(100)
                });
            }
            return prj;
        }

        [Test, TestCaseSource("RandomProjectDataProvider")]
        public void ProjectCreationTest(ProjectData project)
        {
            //ProjectData project = new ProjectData("MyNewpro00", "00ksdhfkIj");

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
