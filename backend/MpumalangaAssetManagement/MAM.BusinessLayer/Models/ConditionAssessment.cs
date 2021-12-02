using MAM.BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class ConditionAssessment
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public List<Rate> Rates { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public User Creator { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }


        public ConditionAssessment ConvertConditionAssessment(DataAccess.Tables.ConditionAssessment conditionAssessment)
        {
            User user = new User();
            Rate rate = new Rate();
            return new ConditionAssessment
            {
                Id = conditionAssessment.Id,
                FacilityId = conditionAssessment.FacilityId,
                CreatedBy = conditionAssessment.UserId,
                CreatedDate = conditionAssessment.CreatedDate,
                ModifiedBy = conditionAssessment.ModifiedBy,
                ModifiedDate = conditionAssessment.ModifiedDate,
                Creator = user.ConvertToUser(conditionAssessment.User),
                Rates = rate.GetRates(conditionAssessment),
            };
        }

        public DataAccess.Tables.ConditionAssessment ConvertConditionAssessment(ConditionAssessment conditionAssessment)
        {
            return new DataAccess.Tables.ConditionAssessment
            {
                Id = conditionAssessment.Id,
                FacilityId = conditionAssessment.FacilityId,
                UserId = conditionAssessment.CreatedBy,
                CreatedDate = conditionAssessment.CreatedDate,
                ModifiedBy = conditionAssessment.ModifiedBy,
                ModifiedDate = conditionAssessment.ModifiedDate,
                RequiredPerformanceStandard = conditionAssessment.Rates.FirstOrDefault(c => c.Key == 1).Value,
                AccessibilityRating = conditionAssessment.Rates.FirstOrDefault(c => c.Key == 2).Value,
                ConditionRating = conditionAssessment.Rates.FirstOrDefault(c => c.Key == 3).Value,
                SuitabilityIndex = conditionAssessment.Rates.FirstOrDefault(c => c.Key == 4).Value,
                OperatingPerformanceIndex = conditionAssessment.Rates.FirstOrDefault(c => c.Key == 5).Value,
                FunctionalPerformanceStandard = conditionAssessment.Rates.FirstOrDefault(c => c.Key == 6).Value,
            };
        }

        public List<ConditionAssessment> ConvertToConditionAssessments(List<DataAccess.Tables.ConditionAssessment> conditionAssessments)
        {
            User user = new User();
            Rate rate = new Rate();

            return conditionAssessments.Select(conditionAssessment => new ConditionAssessment()
            {
                Id = conditionAssessment.Id,
                FacilityId = conditionAssessment.FacilityId,
                CreatedBy = conditionAssessment.UserId,
                CreatedDate = conditionAssessment.CreatedDate,
                ModifiedBy = conditionAssessment.ModifiedBy,
                ModifiedDate = conditionAssessment.ModifiedDate,
                Creator = user.ConvertToUser(conditionAssessment.User),
                Rates = rate.GetRates(conditionAssessment),
            }).ToList();
        }
    }
}
