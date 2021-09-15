using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class MtefBudgetPeriod
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public string Group { get; set; }
        public string Title { get; set; }
        public decimal? Year1Allocation { get; set; }
        public decimal? Year1RequiredBudget { get; set; }
        public double? Year1Shortfall { get; set; }
        public decimal? Year2Allocation { get; set; }
        public decimal? Year2RequiredBudget { get; set; }
        public double? Year2Shortfall { get; set; }
        public decimal? Year3Allocation { get; set; }
        public decimal? Year3RequiredBudget { get; set; }
        public double? Year3Shortfall { get; set; }
        public decimal? Year4Allocation { get; set; }
        public decimal? Year4RequiredBudget { get; set; }
        public double? Year4Shortfall { get; set; }
        public decimal? Year5Allocation { get; set; }
        public decimal? Year5RequiredBudget { get; set; }
        public double? Year5Shortfall { get; set; }
        public bool IsHeader { get; set; }
        public bool IsPercentage { get; set; }
        public int Order { get; set; }
    }
}
