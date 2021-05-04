using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class FunctionalPerformance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Province { get; set; }
        public string Town { get; set; }
        public string UniqueIdentifyingCode { get; set; }
        public string PossibleNonAssetSolution { get; set; }
        public string CommonAssetDescription { get; set; }
        public string CurrentUser { get; set; }
        public string RequiredPerformanceStandard { get; set; }
        public string AccessibilityRating { get; set; }
        public string SuitabilityIndex { get; set; }
        public string ConditionalRating { get; set; }
        public string OperatingperformanceIndex { get; set; }
        public string FunctionalPerformanceRating { get; set; }
    }
}
