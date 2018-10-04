using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MantisTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LogInHelper logIn_LogOut_Helper;
        protected NavigationHelper navigator;
        protected ProjectsHelper projectHelper;

        private static ThreadLocal <ApplicationManager> app=new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            //options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost";

            logIn_LogOut_Helper = new LogInHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            projectHelper = new ProjectsHelper(this);
            API = new APIHelper(this);
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
                newInstance.Navigator.GoToHomePage();
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
            set
            {
                this.Driver = value;
            }
        }

        public LogInHelper Auth
        {
            get
            {
                return logIn_LogOut_Helper;
            }
        }

        public NavigationHelper Navigator
        {
        get 
            {
                return navigator;
             }
        }

        public ProjectsHelper Projects
        {
            get
            {
                return projectHelper;
            }
        }

        public APIHelper API { get; private set; }
    }
}
