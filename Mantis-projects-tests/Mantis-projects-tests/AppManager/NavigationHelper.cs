using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MantisTests
{
   public class NavigationHelper:HelperBase 
    {
        private string baseURL;
        private string MANTISBASEURL = "/mantisbt-2.17.1/";

        public NavigationHelper(ApplicationManager manager,string baseURL):base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToLoginPage()
        {
            if (driver.Url == baseURL + MANTISBASEURL + "login_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + MANTISBASEURL + "login_page.php");
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + MANTISBASEURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + MANTISBASEURL);
        }

        public void GoToProjectsPage()
        {
            if (driver.Url == baseURL + MANTISBASEURL + "manage_proj_page.php")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + MANTISBASEURL + "manage_proj_page.php");
        }
    }
}
