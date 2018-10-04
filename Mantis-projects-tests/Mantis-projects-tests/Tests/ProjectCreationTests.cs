using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace MantisTests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        public static IEnumerable<ProjectsData> RandomProjectDataProvider()
        {
            List<ProjectsData> projects = new List<ProjectsData>();
            for (int i = 0; i < 3; i++)
            {
                projects.Add(new ProjectsData(GenerateRandomString(15))
                {
                    Desc = GenerateRandomString(20),
                });
            }
            return projects;
        }

        [Test, TestCaseSource("RandomProjectDataProvider")]
        public void ProjectCreationTest(ProjectsData project)
        {
            AccountData login = new AccountData("administrator", "root");

            List<ProjectsData> oldProjects = app.API.GetProjectsList(login);

            app.Projects.Create(project);

            List<ProjectsData> newProjects = app.API.GetProjectsList(login);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
