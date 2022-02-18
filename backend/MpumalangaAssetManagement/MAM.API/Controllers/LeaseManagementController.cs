using log4net;
using MAM.API.Services;
using MAM.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace MAM.API.Controllers
{
    [Route("api/leasemanagement")]
    [ApiController]
    public class LeaseManagementController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserController));

        private ILeaseManagementService _leaseManagementService;

        public LeaseManagementController(ILeaseManagementService leaseManagementService)
        {
            _leaseManagementService = leaseManagementService;
            SetLog4NetConfiguration();
        }

        [HttpGet]
        [Route("getleasedproperties")]
        public IActionResult GetLeasedProperties()
        {
            try
            {
                List<LeasedProperty> properties = _leaseManagementService.GetLeasedProperties();
                return Ok(properties);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpPost]
        [Route("getleasedpropertydetails")]
        public IActionResult GetLeasedPropertyDetails(LeasedProperty leasedProperty)
        {
            try
            {
                leasedProperty = _leaseManagementService.GetLeasedPropertyDetails(leasedProperty);
                return Ok(leasedProperty);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadHandoverDocuments/{fileName}")]
        public IActionResult UploadHandoverDocuments(string fileName)
        {

            bool isUploaded = false;

            try
            {
                for (int i = 0; i < Request.Form.Files.Count(); i++)
                {
                    var file = Request.Form.Files[i];
                    //fileName = fileName + '_' + i;
                    var oFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string _fileName = fileName + "_" + i + Path.GetExtension(oFileName);
                    var folderName = Path.Combine("Uploads", "HandoverDocuments");
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
                    else
                    {
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

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadSnagListFiles/{fileName}")]
        public IActionResult UploadSnagListFiles(string fileName)
        {

            bool isUploaded = false;

            try
            {
                for (int i = 0; i < Request.Form.Files.Count(); i++)
                {
                    var file = Request.Form.Files[i];
                    //fileName = fileName + '_' + i;
                    var oFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string _fileName = fileName + "_" + i + Path.GetExtension(oFileName);
                    var folderName = Path.Combine("Uploads", "SnagList");
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
                    else
                    {
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

        private static void SetLog4NetConfiguration()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(System.IO.File.OpenRead("log4net.config"));
            log4net.Config.XmlConfigurator.Configure(log4net.LogManager.GetRepository(Assembly.GetEntryAssembly()), log4netConfig["log4net"]);
        }
    }
}
