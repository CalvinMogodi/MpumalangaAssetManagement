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
    [Route("api/hiringregister")]
    [ApiController]
    public class HiringRegisterController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(HiringRegisterController));

        private IHiringRegisterService _hiringRegisterService;

        public HiringRegisterController(IHiringRegisterService leaseManagementService)
        {
            _hiringRegisterService = leaseManagementService;
            SetLog4NetConfiguration();
        }

        [HttpGet]
        [Route("gethiredproperties")]
        public IActionResult GetHiredProperties()
        {
            try
            {
                List<HiredProperty> properties = _hiringRegisterService.GetHiredProperties();
                return Ok(properties);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpPost]
        [Route("addhiredproperty")]
        public IActionResult AddHiredProperty([FromBody] HiredProperty hiredProperty)
        {
            try
            {
                int id = _hiringRegisterService.AddHiredProperty(hiredProperty);
                return Ok(id);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("updatehiredproperty")]
        public IActionResult UpdateHiredProperty([FromBody] HiredProperty hiredProperty)
        {
            try
            {
                bool isUpdated = _hiringRegisterService.UpdateHiredProperty(hiredProperty);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [HttpDelete]
        [Route("deletehiredproperty")]
        public IActionResult DeletHiredProperty(HiredProperty hiredProperty)
        {
            try
            {
                bool isUpdated = _hiringRegisterService.DeleteHiredProperty(hiredProperty);
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
