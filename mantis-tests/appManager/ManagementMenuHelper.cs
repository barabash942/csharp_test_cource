using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ManagementMenuHelper : BaseHelper
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void GoToManageProgectsMenu()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            driver.FindElement(By.XPath("//a[contains(text(),'Manage')]")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            driver.FindElement(By.XPath("//a[contains(text(),'Manage Projects')]")).Click();
        }
    }
}
