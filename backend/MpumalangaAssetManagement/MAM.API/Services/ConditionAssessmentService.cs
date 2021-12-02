using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Services
{
    public interface IConditionAssessmentService
    {
        List<ConditionAssessment> GetConditionAssessments(int facilityId);
        bool DeleteConditionAssessment(int id);
        int AddConditionAssessment(ConditionAssessment conditionAssessment);
    }
    public class ConditionAssessmentService : IConditionAssessmentService
    {
        private readonly AppSettings _appSettings;

        public ConditionAssessmentService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public int AddConditionAssessment(ConditionAssessment conditionAssessment)
        {
            using var _facilityRepository = new ConditionAssessmentRepository(_appSettings);
            return _facilityRepository.AddConditionAssessment(conditionAssessment);
        }

        public bool DeleteConditionAssessment(int id)
        {
            using var _facilityRepository = new ConditionAssessmentRepository(_appSettings);
            return _facilityRepository.DeleteConditionAssessment(id);
        }

        public List<ConditionAssessment> GetConditionAssessments(int facilityId)
        {
            using var _facilityRepository = new ConditionAssessmentRepository(_appSettings);
            return _facilityRepository.GetConditionAssessments(facilityId);
        }
    }
}
