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
   public class ProjectsHelper:HelperBase
    {
        public ProjectsHelper(ApplicationManager manager):base(manager)
        {
        }
        
        public ProjectsHelper Create(ProjectsData project)
        {
            manager.Navigator.GoToProjectsPage();
            InitializeProjectCreation();
            FillInProjectForm(project);
            SubmitProjectCreation();
            ReturnToProjectsPage();
            projectsCache = null;
            return this;
        }

        public ProjectsHelper Remove(ProjectsData project)
        {
            manager.Navigator.GoToProjectsPage();
            FindAndClickProject(project.Name);
            RemoveProject();
            projectsCache = null;
            return this;
        }
        
        public ProjectsHelper InitializeProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }
    
        public ProjectsHelper FillInProjectForm(ProjectsData project)
        {
            Type(By.Name("name"), project.Name);
            Type(By.Name("description"), project.Desc);
            return this;
        }

        public ProjectsHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            projectsCache = null;
            return this;
        }

        public ProjectsHelper FindAndClickProject(string id)
        {
            IList<IWebElement> elements = driver.FindElements(By.TagName("tbody"));
            elements = elements[0].FindElements(By.TagName("tr"));

            for (int i = 0; i < elements.Count; i ++)
            {
                IWebElement projectLink = elements[i].FindElement(By.TagName("td")).FindElement(By.TagName("a"));
                if (projectLink.Text == id)
                {
                    projectLink.Click();
                    break;
                }
            }

            return this;
        }

        public ProjectsHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return this;
        }
     
        public ProjectsHelper ReturnToProjectsPage()
        {
            driver.FindElement(By.LinkText("Proceed")).Click();
            return this;
        }

        public int GetProjectsCount()
        {
            IList<IWebElement> elements = driver.FindElements(By.TagName("tbody"));
            elements = elements[0].FindElements(By.TagName("tr"));

            return elements.Count;
        }

        public void CreateIfNoProjectsPresent()
        {
            manager.Navigator.GoToProjectsPage();

            if (GetProjectsCount() == 0)
            {
               Create(new ProjectsData("Orange", "Tree"));
            }
        }

        public List<ProjectsData> projectsCache = null;

        public  List<ProjectsData> GetProjectsList()
        {
            if (projectsCache == null)
            {
                projectsCache = new List<ProjectsData>();

                manager.Navigator.GoToProjectsPage();
                IList<IWebElement> elements = driver.FindElements(By.TagName("tbody"));
                elements = elements[0].FindElements(By.TagName("tr"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string name = cells[0].FindElement(By.TagName("a")).Text;
                    string desc = cells[4].Text;
                    projectsCache.Add(new ProjectsData(name, desc));
                }
            }

            return new List<ProjectsData>(projectsCache);
        }
    }
}
