using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using MAM.API.Services;
using MAM.BusinessLayer.Model;
using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Models.Enums;
using MAM.BusinessLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MAM.API.Controllers
{
    [Route("api/facility")]
    [ApiController]
    public class FacilityController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserController));

        private IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
            SetLog4NetConfiguration();
        }
        
        [HttpGet]
        [Route("getfacilityzonings")]
        public IActionResult GetFacilityZonings()
        {
            try
            {                
                List<FacilityType> facilityTypes = _facilityService.GetFacilityZonings();
                return Ok(facilityTypes);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpGet]
        [Route("getdashboardwedges")]
        public IActionResult GetDashboardWedges()
        {
            try
            {
                List<DashboardWedge> dashboardWedges = _facilityService.GetDashboardWedges();
                return Ok(dashboardWedges);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpGet]
        [Route("getfacilitysummaries")]
        public IActionResult GetFacilitySummaries()
        {
            try
            {
                List<FacilitySummaryChart> dashboardWedges = _facilityService.GetFacilitySummaries();
                return Ok(dashboardWedges);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpGet]
        [Route("getmapcoordinates")]
        public IActionResult GetMapCoordinates() {
            try
            {
                List<MapCoordinate> mapCoordinates = _facilityService.GetMapCoordinates();
                return Ok(mapCoordinates);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpGet]
        [Route("getallfacilities")]
        public IActionResult GetAllFacilities()
        {
            try
            {
                List<Facility> facilities = _facilityService.GetAllFacilities();
                return Ok(facilities);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpGet]
        [Route("getFacilityByCode/{id}/{facilityType}")]
        public IActionResult GetFacilityById(int id, FacilityTypes facilityType)
        {
            try
            {
                Facility facility = _facilityService.GetFacilityById(id, facilityType);
                return Ok(facility);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpDelete]
        [Route("deleteFacility/{id}")]
        public IActionResult DeleteFacility(int id)
        {
            try
            {
                return Ok(_facilityService.DeleteFacility(id));
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpPost]
        [Route("updateFacility/{step}")]
        public IActionResult UpdateFacility(string step, Facility facility)
        {
            try
            {
                return Ok(_facilityService.UpdateFacility(step, facility));
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpPost]
        [Route("saveFacility/{step}")]
        public IActionResult SaveFacility(string step, Facility facility)
        {
            try
            {
                facility = _facilityService.SaveFacility(step, facility);
                return Ok(facility);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadFiles")]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            bool isUploaded = false;

            string path = Path.Combine("C:\\Users\\cmogo\\OneDrive\\Pictures\\Screenshots", "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in files)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
            }
            isUploaded = true;
            return Ok(isUploaded);
        }

            private static void SetLog4NetConfiguration()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(System.IO.File.OpenRead("log4net.config"));
            log4net.Config.XmlConfigurator.Configure(log4net.LogManager.GetRepository(Assembly.GetEntryAssembly()), log4netConfig["log4net"]);
        }
    }
}