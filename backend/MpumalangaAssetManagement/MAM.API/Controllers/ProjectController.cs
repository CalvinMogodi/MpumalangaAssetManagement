using log4net;
using MAM.API.Services;
using MAM.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(ProjectController));

        private IProjectService _projectService;

        public ProjectController(IProjectService ProjectService)
        {
            _projectService = ProjectService;
            SetLog4NetConfiguration();
        }

        [HttpGet]
        [Route("getprojects")]
        public IActionResult GetProjects()
        {
            try
            {
                List<Project> projects = _projectService.GetProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpPost]
        [Route("addproject")]
        public IActionResult AddProject([FromBody] Project project)
        {
            try
            {
                int id = _projectService.AddProject(project);
                return Ok(id);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("updateproject")]
        public IActionResult UpdateProject([FromBody] Project project)
        {
            try
            {
                bool isUpdated = _projectService.UpdateProject(project);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("deleteproject")]
        public IActionResult DeletProject([FromBody]Project project)
        {
            try
            {
                bool isUpdated = _projectService.DeleteProject(project);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
    }
}
