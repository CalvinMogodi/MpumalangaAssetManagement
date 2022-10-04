using MAM.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Interfaces
{
    public interface IProjectRepository
    {
        List<Project> GetProjects();
        Project UpdateProject(Project project);
        bool DeleteProject(Project project);
        int AddProject(Project project);
    }
}
