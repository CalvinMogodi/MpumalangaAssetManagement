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
    [Route("api/fault")]
    [ApiController]
    public class FaultController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(FaultController));

        private IFaultService _faultService;

        public FaultController(IFaultService FaultService)
        {
            _faultService = FaultService;
            SetLog4NetConfiguration();
        }

        [HttpGet]
        [Route("getfaults")]
        public IActionResult GetFaults()
        {
            try
            {
                List<Fault> faults = _faultService.GetFaults();
                return Ok(faults);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpPost]
        [Route("addfault")]
        public IActionResult AddFault([FromBody] Fault fault)
        {
            try
            {
                int id = _faultService.AddFault(fault);
                return Ok(id);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [HttpGet]
        [Route("getfaultbyreferenceno/{referenceNo}")]
        public IActionResult GetFaultByReferenceNo(string referenceNo)
        {
            try
            {
                Fault fault = _faultService.GetFaultByReferenceNo(referenceNo);
                return Ok(fault);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("updatefault")]
        public IActionResult UpdateFault([FromBody] Fault fault)
        {
            try
            {
                bool isUpdated = _faultService.UpdateFault(fault);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("deletefault")]
        public IActionResult DeletFault([FromBody]Fault fault)
        {
            try
            {
                fault.IsDeleted = true;
                bool isUpdated = _faultService.DeleteFault(fault);
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
