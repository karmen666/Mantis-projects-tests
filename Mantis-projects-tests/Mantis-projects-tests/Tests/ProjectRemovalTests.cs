using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace MantisTests
{
    [TestFixture]

    public class ProjectRemovalTests : AuthTestBase
    {  
        [Test]
        public void ProjectRemovalTest()
        {
            app.Projects.CreateIfNoProjectsPresent();

            List<ProjectsData> oldProjects = app.Projects.GetProjectsList();
            ProjectsData toBeRemoved = oldProjects[0];

            app.Projects.Remove(toBeRemoved);
            List<ProjectsData> newProjects = app.Projects.GetProjectsList();

            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectsData project in newProjects)
            {
                Assert.AreNotEqual(project.Name, toBeRemoved.Name);
            }
        }
    }
}
