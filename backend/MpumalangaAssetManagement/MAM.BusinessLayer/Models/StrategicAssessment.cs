using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class StrategicAssessment
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public string District { get; set; }
        public string PostDescriptionTitle { get; set; }
        public double? AllocatedSpace { get; set; }
        public double? SurplusShortageAccommodation { get; set; }
        public double? PercentageUtilised { get; set; }
        public double? FbpLevel { get; set; }
        public int? FbpQuantity { get; set; }
        public double? FbpNorm { get; set; }
        public double? FbpRequirement { get; set; }
        public double? AoLevel { get; set; }
        public int? AoQuantity { get; set; }
        public double? AoNorm { get; set; }
        public double? AoRequirement { get; set; }        

        public DataAccess.Tables.StrategicAssessment ConvertToStrategicAssessmentTable(StrategicAssessment strategicAssessment) {
            return new DataAccess.Tables.StrategicAssessment() {
                Id = strategicAssessment.Id,
                UserImmovableAssetManagementPlanId = strategicAssessment.UserImmovableAssetManagementPlanId,
                District = strategicAssessment.District,
                PostDescriptionTitle = strategicAssessment.PostDescriptionTitle,
                AllocatedSpace = strategicAssessment.AllocatedSpace,
                SurplusShortageAccommodation = strategicAssessment.SurplusShortageAccommodation,
                PercentageUtilised = strategicAssessment.PercentageUtilised,
                FbpLevel = strategicAssessment.FbpLevel,
                FbpQuantity = strategicAssessment.FbpQuantity,
                FbpNorm = strategicAssessment.FbpNorm,
                FbpRequirement = strategicAssessment.FbpRequirement,
                AoLevel = strategicAssessment.AoLevel,
                AoQuantity = strategicAssessment.AoQuantity,
                AoNorm = strategicAssessment.AoNorm,
                AoRequirement = strategicAssessment.AoRequirement,
            };
        }

        public List<StrategicAssessment> ConvertToStrategicAssessments(List<DataAccess.Tables.StrategicAssessment> strategicAssessments) {
            return strategicAssessments.Select(s => new StrategicAssessment()
            {
                Id = s.Id,
                UserImmovableAssetManagementPlanId = s.UserImmovableAssetManagementPlanId,
                District = s.District,
                PostDescriptionTitle = s.PostDescriptionTitle,
                AllocatedSpace = s.AllocatedSpace,
                SurplusShortageAccommodation = s.SurplusShortageAccommodation,
                PercentageUtilised = s.PercentageUtilised,
                FbpLevel = s.FbpLevel,
                FbpQuantity = s.FbpQuantity,
                FbpNorm = s.FbpNorm,
                FbpRequirement = s.FbpRequirement,
                AoLevel = s.AoLevel,
                AoQuantity = s.AoQuantity,
                AoNorm = s.AoNorm,
                AoRequirement = s.AoRequirement,
            }).ToList();
        }
    }
}
