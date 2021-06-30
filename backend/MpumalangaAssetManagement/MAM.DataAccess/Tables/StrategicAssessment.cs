﻿using System;
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
        public string SurplusShortageAccommodation { get; set; }
        public double? PercentageUtilised { get; set; }
        public decimal? FbpLevel { get; set; }
        public decimal? FbpQuantity { get; set; }
        public decimal? FbpNorm { get; set; }
        public decimal? FbpRequirement { get; set; }
        public decimal? AoLevel { get; set; }
        public decimal? AoQuantity { get; set; }
        public decimal? AoNorm { get; set; }
        public decimal? AoRequirement { get; set; }
    }
}
