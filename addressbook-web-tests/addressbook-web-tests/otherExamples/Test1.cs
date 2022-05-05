using System;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] s = new string[] { "text", "next" };
            foreach (string element in s)
            {
                Console.Out.Write(element + "\n");
            }
        }

        public void TestMethod2()
        {
            IWebDriver driver = null;
            int attempt = 0;

            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60)
            {
                Thread.Sleep(1000);
                attempt++;
            }
        }

        public void TestMethod3()
        {
            IWebDriver driver = null;
            int attempt = 0;

            do
            {
                Thread.Sleep(1000);
                attempt++;
            }
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60);
        }
    }
}
