using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class AcquisitionPlan
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public string Region { get; set; }
        public string Town { get; set; }
        public string ServiceDescription { get; set; }
        public string BudgetType { get; set; }
        public decimal? Extent { get; set; }
        public int? InitialNeedYear { get; set; }
        public string AcquisitionType { get; set; }
        public string Status { get; set; }
        public double? TotalAmountRequired { get; set; }
        public double? CashFlowYear1 { get; set; }
        public double? CashFlowYear2 { get; set; }
        public double? CashFlowYear3 { get; set; }
        public double? CashFlowYear4 { get; set; }
    }
}
