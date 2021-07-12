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
        [HttpGet]
        [Route("getuamps/{department}")]
        public IActionResult GetUAMPs(string department)
        {
            try
            {
                var result = _uampService.GetUserImmovableAssetManagementPlans(department);
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
        [Route("getampbyid/{id}")]
        public IActionResult GetUamp(int id)
        {
            try
            {
                var result = _uampService.GetUamp(id);
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
        [Route("saveuamp")]
        public IActionResult SaveUserImmovableAssetManagementPlan([FromBody] UserImmovableAssetManagementPlan userImmovableAssetManagementPlan)
        {
            try
            {
                var result = _uampService.SaveUserImmovableAssetManagementPlan(userImmovableAssetManagementPlan);
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
        [Route("startuamp")]
        public IActionResult StartUserImmovableAssetManagementPlan([FromBody] UserImmovableAssetManagementPlan userImmovableAssetManagementPlan)
        {
            try
            {
                var result = _uampService.StartUserImmovableAssetManagementPlan(userImmovableAssetManagementPlan);
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
        [Route("deleteacquisitionplan")]
        public IActionResult DeleteAcquisitionPlan([FromBody] AcquisitionPlan acquisitionPlan)
        {
            try
            {
                var result = _uampService.DeleteAcquisitionPlan(acquisitionPlan);
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
        [Route("deleteprogramme")]
        public IActionResult DeleteProgramme([FromBody] Programme programme)
        {
            try
            {
                var result = _uampService.DeleteProgramme(programme);
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
        [Route("deleteproperty")]
        public IActionResult DeleteProperty([FromBody] Property property)
        {
            try
            {
                var result = _uampService.DeleteProperty(property);
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
        [Route("deleteoperationplan")]
        public IActionResult DeleteOperationPlan([FromBody] OperationPlan operationPlan)
        {
            try
            {
                var result = _uampService.DeleteOperationPlan(operationPlan);
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
        [Route("deletestrategicassessment")]
        public IActionResult DeleteStrategicAssessment([FromBody] StrategicAssessment strategicAssessment)
        {
            try
            {
                var result = _uampService.DeleteStrategicAssessment(strategicAssessment);
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
        [Route("deletesurrenderplan")]
        public IActionResult DeleteSurrenderPlan([FromBody] SurrenderPlan surrenderPlan)
        {
            try
            {
                var result = _uampService.DeleteSurrenderPlan(surrenderPlan);
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
