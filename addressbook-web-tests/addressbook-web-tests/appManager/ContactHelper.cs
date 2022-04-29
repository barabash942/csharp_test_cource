using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactHelper : BaseHelper
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void OpenHomePageCheck()
        {
            if (!IsHomePageOpen())
            {
                manager.Navigator.OpenHomePage();
            }
        }

        public void ContactCreatedCheck()
        {
            if (!IsAnyContactCreated())
            {
                ContactData newcontact = new ContactData("Uno", "Dos");
                Create(newcontact);
            }
        }

        public bool IsHomePageOpen()
        {
            return driver.Url == manager.Navigator.baseURL;
        }

        public bool IsAnyContactCreated()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper Create(ContactData contact)
        {
            AddNewContact();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int v, int e, ContactData newData)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(v);
            InitContactModification(e);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(p);
            DeleteContact();
            SubmitContactDeleting();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name= 'selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(.//input[@name= 'selected[]'])[" + index + "]/following::img[2]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value= 'Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitContactDeleting()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
