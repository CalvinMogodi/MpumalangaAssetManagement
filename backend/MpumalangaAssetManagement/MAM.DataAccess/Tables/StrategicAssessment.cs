using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class StrategicAssessment
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
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
    }
}
