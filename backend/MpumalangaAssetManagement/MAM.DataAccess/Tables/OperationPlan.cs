using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class OperationPlan
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public double TempleteNumber { get; set; }
        public string DistrictRegion { get; set; }
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
        public int? NoofParkingBays { get; set; }
        public double? UsableSpace { get; set; }
        public double? ConstructionArea { get; set; }
        public double? ExtentofLand { get; set; }
        public DateTime? LeaseStartDate { get; set; }
        public DateTime? LeaseStartEnd { get; set; }
        public decimal? RentalPM { get; set; }
        public decimal? RentalPA { get; set; }
        public int? InitialNeedYear { get; set; }
        public string Status { get; set; }
        public decimal? TotalAmountRequired { get; set; }
        public decimal? CashFlowYear1 { get; set; }
        public decimal? CashFlowYear2 { get; set; }
        public decimal? CashFlowYear3 { get; set; }
        public decimal? CashFlowYear4 { get; set; }
        public decimal? CashFlowYear5 { get; set; }
    }
}
