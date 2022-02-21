﻿using log4net;
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
    [Route("api/conditionassessment")]
    [ApiController]
    public class ConditionAssessmentController : BaseController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserController));

        private readonly IConditionAssessmentService _conditionAssessmentService;

        public ConditionAssessmentController(IConditionAssessmentService conditionAssessmentService)
        {
            _conditionAssessmentService = conditionAssessmentService;
            SetLog4NetConfiguration();
        }

        [HttpGet]
        [Route("getconditionassessments/{facilityId}")]
        public IActionResult GetConditionAssessments(int facilityId)
        {
            try
            {
                List<ConditionAssessment> conditionsAssessments = _conditionAssessmentService.GetConditionAssessments(facilityId);
                return Ok(conditionsAssessments);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpPost]
        [Route("saveConditionAssessment")]
        public IActionResult SaveConditionAssessment(ConditionAssessment conditionAssessment)
        {
            try
            {
                int conditionAssessmentId = _conditionAssessmentService.AddConditionAssessment(conditionAssessment);
                return Ok(conditionAssessmentId);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }

        [HttpDelete]
        [Route("deleteConditionAssessment/{id}")]
        public IActionResult DeleteConditionAssessment(int id)
        {
            try
            {
                bool isDeleted = _conditionAssessmentService.DeleteConditionAssessment(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                log.Info("Error");
                throw ex;
            }
        }
    }
}
