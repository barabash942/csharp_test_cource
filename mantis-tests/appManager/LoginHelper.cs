using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LoginHelper : BaseHelper
    {
        public LoginHelper (ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.XPath("//form[@id='login-form']/fieldset/div/span/input"), account.Username);
            Type(By.XPath("//form[@id='login-form']/fieldset/div[2]/span/input"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.Id("logout-link")).Click();
            }
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Username;
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.Id("logged-in-user")).Text;
            return text;
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Id("logout-link"));
        }

    }
}
