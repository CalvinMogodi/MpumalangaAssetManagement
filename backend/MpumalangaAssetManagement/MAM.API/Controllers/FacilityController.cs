using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
    public class FacilityController : BaseController
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
        public IActionResult GetMapCoordinates()
        {
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
        [Route("getproperties/{userDepartment}")]
        public IActionResult GetProperties(string userDepartment)
        {
            try
            {
                List<Facility> facilities = _facilityService.GetProperties(userDepartment);
                return Ok(facilities);
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
        [Route("getassetregisterfacilities")]
        public IActionResult GetAssetRegisterFacilities()
        {
            try
            {
                List<Facility> facilities = _facilityService.GetAssetRegisterFacilities();
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

        [HttpGet]
        [Route("getFiles/{fileReference}")]
        public IActionResult GetFiles(string fileReference)
        {
            var pathToSave = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(pathToSave, "Uploads","Facilities");
            var files = Directory.GetFiles(fullPath).Where(f => f.Contains(fileReference)).ToList();
            return Ok(files);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadFiles/{fileName}")]
        public IActionResult UploadFiles(string fileName)
        {
            
            bool isUploaded = false;

            try
            {
                for (int i = 0; i < Request.Form.Files.Count(); i++)
                {
                    var file = Request.Form.Files[i];
                    //fileName = fileName + '_' + i;
                    var oFileName =  ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string _fileName = fileName +"_" + i + Path.GetExtension(oFileName);
                    var folderName = Path.Combine("Uploads", "Facilities");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (file.Length > 0)
                    {
                        var fullPath = Path.Combine(pathToSave, _fileName);
                        var dbPath = Path.Combine(folderName, _fileName);
                        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                    else {
                        return BadRequest();
                    }
                }               
            }
            catch (Exception ex)
            {

                throw;
            }
          
            isUploaded = true;
            return Ok(isUploaded);
        }
    }
}
/*
public static class Counter
{
    private int count = 0;
    private int increment;

    public int Counter()
    {
        increment = increment;
    }

    protected int getAndIncrement()
    {
        this.count += this.increment;
        return this.count;
    }

}

public static class DocumentNameCreator
{
    private String prefix;

    public static DocumentNameCreator(int increment, String prefix)
    {
        prefix = getNewDocumentName();
    }

    String static getNewDocumentName()
    {
        return prefix + getAndIncrement();
    }
}*/