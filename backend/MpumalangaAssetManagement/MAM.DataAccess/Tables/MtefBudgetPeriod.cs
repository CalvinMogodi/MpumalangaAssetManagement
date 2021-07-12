using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class MtefBudgetPeriod
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public string Name { get; set; }
        public decimal? MtefAllocationY1 { get; set; }
        public decimal? RequiredBudgetY1 { get; set; }
        public double? ShortfallY1 { get; set; }
        public decimal? MtefAllocationY2 { get; set; }
        public decimal? RequiredBudgetY2 { get; set; }
        public double? ShortfallY2 { get; set; }
        public decimal? MtefAllocationY3 { get; set; }
        public decimal? RequiredBudgetY3 { get; set; }
        public double? ShortfallY3 { get; set; }
        public decimal? MtefAllocationY4 { get; set; }
        public decimal? RequiredBudgetY4 { get; set; }
        public double? ShortfallY4 { get; set; }
        public decimal? MtefAllocationY5 { get; set; }
        public decimal? RequiredBudgetY5 { get; set; }
        public double? ShortfallY5 { get; set; }
        public bool IsHeader { get; set; }
        public bool IsPercentage { get; set; }
        public int Order { get; set; }
    }
}
