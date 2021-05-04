using log4net;
using MAM.API.Services;
using MAM.BusinessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Controllers
{
    [Route("api/uamp")]
    [ApiController]
    public class UAMPController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserController));

        private IUAMPService _uampService;

        public UAMPController(IUAMPService uampService)
        {
            _uampService = uampService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("test")]
        public IActionResult Test()
        {
            try
            {
                return Ok(true);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("addprogrammes")]
        public IActionResult AddProgrammes([FromBody] List<Programme> programmes)
        {
            try
            {
                var result = _uampService.AddProgrammes(programmes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("addfunctionalperformances")]
        public IActionResult AddFunctionalPerformances([FromBody] List<FunctionalPerformance> functionalPerformances)
        {
            try
            {
                var result = _uampService.AddFunctionalPerformances(functionalPerformances);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("addutilisations")]
        public IActionResult AddUtilisations([FromBody] List<Utilisation> utilisations)
        {
            try
            {
                var result = _uampService.AddUtilisations(utilisations);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("programmes")]
        public IActionResult GetProgrammes()
        {
            try
            {
                var result = _uampService.GetProgrammes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("functionalperformances")]
        public IActionResult GetFunctionalPerformances()
        {
            try
            {
                var result = _uampService.GetFunctionalPerformances();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("utilisations")]
        public IActionResult GetUtilisations()
        {
            try
            {
                var result = _uampService.GetUtilisations();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
    }
}
