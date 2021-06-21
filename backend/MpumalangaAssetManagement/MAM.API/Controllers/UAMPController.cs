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
        [Route("getuamp")]
        public IActionResult GetUAMP()
        {
            try
            {
                var result = _uampService.GetUserImmovableAssetManagementPlans();
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
        [Route("saveuserimmovableassetmanagementplan")]
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
        [Route("adduserimmovableassetmanagementplan")]
        public IActionResult AddUserImmovableAssetManagementPlan([FromBody] UserImmovableAssetManagementPlan userImmovableAssetManagementPlan)
        {
            try
            {
                var result = _uampService.AddUserImmovableAssetManagementPlan(userImmovableAssetManagementPlan);
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
