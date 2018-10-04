using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Mantis_projects_tests.Mantis;

namespace MantisTests
{
   public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateNewProject(AccountData login, ProjectsData project)
        {
            MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();

            ProjectData mantisProjectData = new ProjectData();

            mantisProjectData.name = project.Name;
            mantisProjectData.description = project.Desc;

            client.mc_project_add(login.Username, login.Password, mantisProjectData);
        }

        public void RemoveProject(AccountData login, ProjectsData project)
        {
            MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();

            client.mc_project_delete(login.Username, login.Password, project.Id);
        }

        public List<ProjectsData> GetProjectsList(AccountData login)
        {
            List<ProjectsData> allData = new List<ProjectsData>();

            MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();

            ProjectData[] projects = client.mc_projects_get_user_accessible(login.Username, login.Password);
            
            for (int i = 0; i < projects.Count(); i ++)
            {
                ProjectData mantisProject = projects[i];
                allData.Add(new ProjectsData(mantisProject.name, mantisProject.description)
                {
                    Id = mantisProject.id
                });
            }

            return allData;
        }
    }
}
