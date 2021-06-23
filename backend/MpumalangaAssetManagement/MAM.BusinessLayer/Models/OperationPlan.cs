using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class OperationPlan
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public decimal TempleteNumber { get; set; }
        public string District { get; set; }
        public string Town { get; set; }
        public string ServiceDescription { get; set; }
        public string BudgetType { get; set; }
        public string LocalMunicipality { get; set; }
        public string AssetDescription { get; set; }
        public string RepairDescription { get; set; }
        public string PrioityServiceReanking { get; set; }
        public string StreetDescription { get; set; }
        public string PropertyDescription { get; set; }
        public string LeaseType { get; set; }
        public string NoofParkingBays { get; set; }
        public decimal? UsableSpace { get; set; }
        public decimal? ConstructionArea { get; set; }
        public decimal? ExtentofLand { get; set; }
        public DateTime? LeaseStartDate { get; set; }
        public DateTime? LeaseStartEnd { get; set; }
        public decimal? RentalPM { get; set; }
        public decimal? RentalPA { get; set; }
        public string InitialNeedYear { get; set; }
        public string Status { get; set; }
        public string TotalAmountRequired { get; set; }
        public double? CashFlowYear1 { get; set; }
        public double? CashFlowYear2 { get; set; }
        public double? CashFlowYear3 { get; set; }
        public double? CashFlowYear4 { get; set; }
        public double? CashFlowYear5 { get; set; }
    }
}
