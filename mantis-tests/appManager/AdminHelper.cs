using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AdminHelper : BaseHelper
    {
        public AdminHelper(ApplicationManager manager) : base(manager) { }

        public List<AccountData> GetAllAccounts()
        {
            return null;
        }

        //public void DeleteAccount(AccountData account)
        //{
        //    IWebDriver driver = OpenAppAndLogin();
        //}

        //private IWebDriver OpenAppAndLogin()
        //{
        //    IWebDriver driver = new SimpleBrowserDriver();
        //}
    }
}
