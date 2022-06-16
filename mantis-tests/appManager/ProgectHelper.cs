using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProgectHelper : BaseHelper
    {
        public ProgectHelper(ApplicationManager manager) : base(manager) { }

        public ProgectHelper CreateProject(ProjectData project)
        {
            manager.ManagementMenuHelper.GoToManageProgectsMenu();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.XPath("//input[@value='Create New Project']")).Count > 0);
            return this;
        }

        public ProgectHelper RemoveProject(ProjectData p)
        {
            manager.ManagementMenuHelper.GoToManageProgectsMenu();
            SelectProject(p.Id);
            DeleteProject();
            return this;
        }

        public ProgectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            return this;
        }

        public ProgectHelper FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            Type(By.Id("project-description"), project.Description);
            return this;
        }

        public ProgectHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Create New Project']")).Click();
            return this;
        }

        private List<ProjectData> projectsCache = null;
        public List<ProjectData> GetAll()
        {
            if (projectsCache == null)
            {
                projectsCache = new List<ProjectData>();

                manager.ManagementMenuHelper.GoToManageProgectsMenu();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@id='content']/div[2]/table/tbody/tr"));
                foreach (IWebElement element in elements)
                {
                    var name = element.FindElement(By.XPath(".//td[1]"));
                    var description = element.FindElement(By.XPath(".//td[5]"));
                    projectsCache.Add(new ProjectData(name.Text, description.Text));
                }
            }
            return new List<ProjectData>(projectsCache);
        }

        public int GetProjectsCount()
        {
            return driver.FindElements(By.XPath("//div[@id='content']/div[2]/table/tbody/tr")).Count;
        }

        public ProgectHelper SelectProject(string id)
        {
            driver.FindElement(By.XPath("//div[@id='content']/div[2]/table/tbody" + (id) + "/tr/td/a")).Click();
            return this;
        }

        public void DeleteProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }
    }
}
