using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Services
{
    public interface IProjectService
    {
        List<Project> GetProjects();
        bool UpdateProject(Project project);
        bool DeleteProject(Project project);
        int AddProject(Project project);
    }

    public class ProjectService : IProjectService
    {
        private readonly AppSettings _appSettings;

        public ProjectService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public List<Project> GetProjects()
        {
            using var _projectRepository = new ProjectRepository(_appSettings);
            return _projectRepository.GetProjects();
        }
        public bool UpdateProject(Project project)
        {
            using var _projectRepository = new ProjectRepository(_appSettings);
            return _projectRepository.UpdateProject(project);
        }
        public bool DeleteProject(Project project)
        {
            using var _projectRepository = new ProjectRepository(_appSettings);
            return _projectRepository.DeleteProject(project);
        }
        public int AddProject(Project project)
        {
            using var _projectRepository = new ProjectRepository(_appSettings);
            return _projectRepository.AddProject(project);
        }
    }
}
