using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
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

        public DataAccess.Tables.FunctionalPerformance ConvertToFunctionalPerformanceTable(FunctionalPerformance functionalPerformance)
        {
            return new DataAccess.Tables.FunctionalPerformance()
            {
                Id = functionalPerformance.Id,
                UserId = 1033,
                Province = functionalPerformance.Province,
                Town = functionalPerformance.Town,
                UniqueIdentifyingCode = functionalPerformance.UniqueIdentifyingCode,
                PossibleNonAssetSolution = functionalPerformance.PossibleNonAssetSolution,
                CommonAssetDescription = functionalPerformance.CommonAssetDescription,
                CurrentUser = functionalPerformance.CurrentUser,
                RequiredPerformanceStandard = functionalPerformance.RequiredPerformanceStandard,
                AccessibilityRating = functionalPerformance.AccessibilityRating,
                SuitabilityIndex = functionalPerformance.SuitabilityIndex,
                ConditionalRating = functionalPerformance.ConditionalRating,
                OperatingperformanceIndex = functionalPerformance.OperatingperformanceIndex,
                FunctionalPerformanceRating = functionalPerformance.FunctionalPerformanceRating
            };
        }

        public List<FunctionalPerformance> ConvertToFunctionalPerformances(List<DataAccess.Tables.FunctionalPerformance> functionalPerformances)
        {
            return functionalPerformances.Select(f => new FunctionalPerformance()
            {
                Id = f.Id,
                UserId = f.UserId,
                Province = f.Province,
                Town = f.Town,
                UniqueIdentifyingCode = f.UniqueIdentifyingCode,
                PossibleNonAssetSolution = f.PossibleNonAssetSolution,
                CommonAssetDescription = f.CommonAssetDescription,
                CurrentUser = f.CurrentUser,
                RequiredPerformanceStandard = f.RequiredPerformanceStandard,
                AccessibilityRating = f.AccessibilityRating,
                SuitabilityIndex = f.SuitabilityIndex,
                ConditionalRating = f.ConditionalRating,
                OperatingperformanceIndex = f.OperatingperformanceIndex,
                FunctionalPerformanceRating = f.FunctionalPerformanceRating
            }).ToList();
        }
    }
}
