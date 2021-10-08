using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
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

        public DataAccess.Tables.AcquisitionPlan ConvertToAcquisitionPlanTable(AcquisitionPlan acquisitionPlan)
        {
            return new DataAccess.Tables.AcquisitionPlan()
            {
                Id = acquisitionPlan.Id,
                UserImmovableAssetManagementPlanId = acquisitionPlan.UserImmovableAssetManagementPlanId,
                TempleteNumber = acquisitionPlan.TempleteNumber,
                DistrictRegion = acquisitionPlan.DistrictRegion,
                Town = acquisitionPlan.Town,
                ServiceDescription = acquisitionPlan.ServiceDescription,
                BudgetType = acquisitionPlan.BudgetType,
                Extent = acquisitionPlan.Extent,
                InitialNeedYear = acquisitionPlan.InitialNeedYear,
                AcquisitionType = acquisitionPlan.AcquisitionType,
                Status = acquisitionPlan.Status,
                TotalAmountRequired = acquisitionPlan.TotalAmountRequired,
                CashFlowYear1 = acquisitionPlan.CashFlowYear1,
                CashFlowYear2 = acquisitionPlan.CashFlowYear2,
                CashFlowYear3 = acquisitionPlan.CashFlowYear3,
                CashFlowYear4 = acquisitionPlan.CashFlowYear4,
                CashFlowYear5 = acquisitionPlan.CashFlowYear5,
                IsRequired = acquisitionPlan.IsRequired,
            };
        }

        public List<AcquisitionPlan> ConvertToAcquisitionPlans(List<DataAccess.Tables.AcquisitionPlan> acquisitionPlans)
        {
            return acquisitionPlans.Select(a => new AcquisitionPlan()
            {
                Id = a.Id,
                UserImmovableAssetManagementPlanId = a.UserImmovableAssetManagementPlanId,
                TempleteNumber = a.TempleteNumber,
                DistrictRegion = a.DistrictRegion,
                Town = a.Town,
                ServiceDescription = a.ServiceDescription,
                BudgetType = a.BudgetType,
                Extent = a.Extent,
                InitialNeedYear = a.InitialNeedYear,
                AcquisitionType = a.AcquisitionType,
                Status = a.Status,
                TotalAmountRequired = a.TotalAmountRequired,
                CashFlowYear1 = a.CashFlowYear1,
                CashFlowYear2 = a.CashFlowYear2,
                CashFlowYear3 = a.CashFlowYear3,
                CashFlowYear4 = a.CashFlowYear4,
                CashFlowYear5 = a.CashFlowYear5,
                IsRequired = a.IsRequired,
            }).ToList();
        }
    }
}
