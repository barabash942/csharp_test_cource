﻿using NUnit.Framework;

namespace addressbook_web_tests
{
    public class BaseTest
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}