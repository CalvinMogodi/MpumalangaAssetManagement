using MAM.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Interfaces
{
    public interface IProjectRepository
    {
        List<Project> GetProjects();
        bool UpdateProject(Project project);
        bool DeleteProject(Project project);
        int AddProject(Project project);
    }
}
