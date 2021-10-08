using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class AcquisitionPlan
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public double TempleteNumber { get; set; }
        public string DistrictRegion { get; set; }
        public string Town { get; set; }
        public string ServiceDescription { get; set; }
        public string BudgetType { get; set; }
        public double? Extent { get; set; }
        public int? InitialNeedYear { get; set; }
        public string AcquisitionType { get; set; }
        public string Status { get; set; }
        public decimal? TotalAmountRequired { get; set; }
        public decimal? CashFlowYear1 { get; set; }
        public decimal? CashFlowYear2 { get; set; }
        public decimal? CashFlowYear3 { get; set; }
        public decimal? CashFlowYear4 { get; set; }
        public decimal? CashFlowYear5 { get; set; }
        public bool? IsRequired { get; set; }
    }
}
