using log4net;
using MAM.API.Services;
using MAM.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private static void SetLog4NetConfiguration()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(System.IO.File.OpenRead("log4net.config"));
            log4net.Config.XmlConfigurator.Configure(log4net.LogManager.GetRepository(Assembly.GetEntryAssembly()), log4netConfig["log4net"]);
        }
    }
}
