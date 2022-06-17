using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public LoginHelper LoginHelper { get; set; }
        public ProgectHelper ProgectHelper { get; set; }
        public ManagementMenuHelper ManagementMenuHelper { get; set; }
        public AdminHelper AdminHelper { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-1.3.17/mantisbt-1.3.17/login_page.php";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            LoginHelper = new LoginHelper(this);
            ProgectHelper = new ProgectHelper(this);
            ManagementMenuHelper = new ManagementMenuHelper(this);
            AdminHelper = new AdminHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-1.3.17/mantisbt-1.3.17/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}
