using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
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

        public DataAccess.Tables.OperationPlan ConvertToOperationPlanTable(OperationPlan operationPlan)
        {
            return new DataAccess.Tables.OperationPlan()
            {
                Id = operationPlan.Id,
                UserImmovableAssetManagementPlanId = operationPlan.UserImmovableAssetManagementPlanId,
                TempleteNumber = operationPlan.TempleteNumber,
                DistrictRegion = operationPlan.DistrictRegion,
                Town = operationPlan.Town,
                ServiceDescription = operationPlan.ServiceDescription,
                BudgetType = operationPlan.BudgetType,
                LocalMunicipality = operationPlan.LocalMunicipality,
                AssetDescription = operationPlan.AssetDescription,
                RepairDescription = operationPlan.RepairDescription,
                PrioityServiceReanking = operationPlan.PrioityServiceReanking,
                StreetDescription = operationPlan.StreetDescription,
                PropertyDescription = operationPlan.PropertyDescription,
                LeaseType = operationPlan.LeaseType,
                NoofParkingBays = operationPlan.NoofParkingBays,
                UsableSpace = operationPlan.UsableSpace,
                ConstructionArea = operationPlan.ConstructionArea,
                ExtentofLand = operationPlan.ExtentofLand,
                LeaseStartDate = operationPlan.LeaseStartDate,
                LeaseStartEnd = operationPlan.LeaseStartEnd,
                RentalPM = operationPlan.RentalPM,
                RentalPA = operationPlan.RentalPA,
                InitialNeedYear = operationPlan.InitialNeedYear,
                Status = operationPlan.Status,
                TotalAmountRequired = operationPlan.TotalAmountRequired,
                CashFlowYear1 = operationPlan.CashFlowYear1,
                CashFlowYear2 = operationPlan.CashFlowYear2,
                CashFlowYear3 = operationPlan.CashFlowYear3,
                CashFlowYear4 = operationPlan.CashFlowYear4,
                CashFlowYear5 = operationPlan.CashFlowYear5,
            };
        }

        public List<OperationPlan> ConvertToOperationPlans(List<DataAccess.Tables.OperationPlan> operationPlans)
        {
            return operationPlans.Select(o => new OperationPlan()
            {
                Id = o.Id,
                UserImmovableAssetManagementPlanId = o.UserImmovableAssetManagementPlanId,
                TempleteNumber = o.TempleteNumber,
                DistrictRegion = o.DistrictRegion,
                Town = o.Town,
                ServiceDescription = o.ServiceDescription,
                BudgetType = o.BudgetType,
                LocalMunicipality = o.LocalMunicipality,
                AssetDescription = o.AssetDescription,
                RepairDescription = o.RepairDescription,
                PrioityServiceReanking = o.PrioityServiceReanking,
                StreetDescription = o.StreetDescription,
                PropertyDescription = o.PropertyDescription,
                LeaseType = o.LeaseType,
                NoofParkingBays = o.NoofParkingBays,
                UsableSpace = o.UsableSpace,
                ConstructionArea = o.ConstructionArea,
                ExtentofLand = o.ExtentofLand,
                LeaseStartDate = o.LeaseStartDate,
                LeaseStartEnd = o.LeaseStartEnd,
                RentalPM = o.RentalPM,
                RentalPA = o.RentalPA,
                InitialNeedYear = o.InitialNeedYear,
                Status = o.Status,
                TotalAmountRequired = o.TotalAmountRequired,
                CashFlowYear1 = o.CashFlowYear1,
                CashFlowYear2 = o.CashFlowYear2,
                CashFlowYear3 = o.CashFlowYear3,
                CashFlowYear4 = o.CashFlowYear4,
                CashFlowYear5 = o.CashFlowYear5,
            }).ToList();
        }
    }
}
