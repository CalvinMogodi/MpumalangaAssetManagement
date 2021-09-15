using MAM.BusinessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
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
        public DataAccess.Tables.MtefBudgetPeriod ConvertToMtefBudgetPeriodTable(MtefBudgetPeriod mtefBudgetPeriod)
        {
            return new DataAccess.Tables.MtefBudgetPeriod()
            {
                Id = mtefBudgetPeriod.Id,
                Title = mtefBudgetPeriod.Title,
                Group = mtefBudgetPeriod.Group,
                UserImmovableAssetManagementPlanId = mtefBudgetPeriod.UserImmovableAssetManagementPlanId,
                Year1Allocation = mtefBudgetPeriod.Year1Allocation,
                Year1RequiredBudget = mtefBudgetPeriod.Year1RequiredBudget,
                Year1Shortfall = mtefBudgetPeriod.Year1Shortfall,
                Year2Allocation = mtefBudgetPeriod.Year2Allocation,
                Year2RequiredBudget = mtefBudgetPeriod.Year2RequiredBudget,
                Year2Shortfall = mtefBudgetPeriod.Year2Shortfall,
                Year3Allocation = mtefBudgetPeriod.Year3Allocation,
                Year3RequiredBudget = mtefBudgetPeriod.Year3RequiredBudget,
                Year3Shortfall = mtefBudgetPeriod.Year3Shortfall,
                Year4Allocation = mtefBudgetPeriod.Year4Allocation,
                Year4RequiredBudget = mtefBudgetPeriod.Year4RequiredBudget,
                Year4Shortfall = mtefBudgetPeriod.Year4Shortfall,
                Year5Allocation = mtefBudgetPeriod.Year5Allocation,
                Year5RequiredBudget = mtefBudgetPeriod.Year5RequiredBudget,
                Year5Shortfall = mtefBudgetPeriod.Year5Shortfall,
                IsHeader = mtefBudgetPeriod.IsHeader,
                IsPercentage = mtefBudgetPeriod.IsPercentage,
                Order = mtefBudgetPeriod.Order
            };
        }


        public List<MtefBudgetPeriod> ConvertToMtefBudgetPeriods(List<DataAccess.Tables.MtefBudgetPeriod> mtefBudgetPeriods)
        {
            MtefYear mtefYear = new MtefYear();
            return mtefBudgetPeriods.Select(o => new MtefBudgetPeriod()
            {
                Id = o.Id,
                Title = o.Title,
                Group = o.Group,
                UserImmovableAssetManagementPlanId = o.UserImmovableAssetManagementPlanId,
                Year1Allocation = o.Year1Allocation,
                Year1RequiredBudget = o.Year1RequiredBudget,
                Year1Shortfall = o.Year1Shortfall,
                Year2Allocation = o.Year2Allocation,
                Year2RequiredBudget = o.Year2RequiredBudget,
                Year2Shortfall = o.Year2Shortfall,
                Year3Allocation = o.Year3Allocation,
                Year3RequiredBudget = o.Year3RequiredBudget,
                Year3Shortfall = o.Year3Shortfall,
                Year4Allocation = o.Year4Allocation,
                Year4RequiredBudget = o.Year4RequiredBudget,
                Year4Shortfall = o.Year4Shortfall,
                Year5Allocation = o.Year5Allocation,
                Year5RequiredBudget = o.Year5RequiredBudget,
                Year5Shortfall = o.Year5Shortfall,
                IsHeader = o.IsHeader,
                IsPercentage = o.IsPercentage,
                Order = o.Order
            }).ToList();
        }

        public List<MtefBudgetPeriod> BuildMtefBudgetPeriod(int uampId)
        {
            List<MtefBudgetPeriod> mtefBudgetPeriods = new List<MtefBudgetPeriod>();
            for (int i = 0; i < 15; i++)
            {
                MtefBudgetPeriod mtefBudgetPeriod = new MtefBudgetPeriod() {
                    UserImmovableAssetManagementPlanId = uampId,
                    Order = 0,
                    IsHeader = false,
                    IsPercentage = false,
                    Title = null,
                    Group = null,
                    Year1Allocation = 0,
                    Year1RequiredBudget = null,
                    Year1Shortfall = null,
                    Year2Allocation = null,
                    Year2RequiredBudget = null,
                    Year2Shortfall = null,
                    Year3Allocation = null,
                    Year3RequiredBudget = null,
                    Year3Shortfall = null,
                    Year4Allocation = null,
                    Year4RequiredBudget = null,
                    Year4Shortfall = null,
                    Year5Allocation = null,
                    Year5RequiredBudget = null,
                    Year5Shortfall = null,
                };
               
                
                switch (i)
                {
                    case 0:
                        mtefBudgetPeriod.Title = "New Capital Works T4.1";
                        mtefBudgetPeriod.Group = "Capital Projects";
                        mtefBudgetPeriod.Order = 2;
                        break;
                    case 1:
                        mtefBudgetPeriod.Title = "Refurb., Re-config.& Additions) T5.1";
                        mtefBudgetPeriod.Group = "Capital Projects";
                        mtefBudgetPeriod.Order = 3;
                        break;
                    case 2:
                        mtefBudgetPeriod.Title = "Total Capital Costs";
                        mtefBudgetPeriod.Group = "Capital Projects";
                        mtefBudgetPeriod.Order = 4;
                        break;
                    case 3:
                        mtefBudgetPeriod.Title = "% Shortfall";
                        mtefBudgetPeriod.IsPercentage = true;
                        mtefBudgetPeriod.Group = "Capital Projects";
                        mtefBudgetPeriod.Order = 5;
                        break;
                    case 4:
                        mtefBudgetPeriod.Title = "Existing Leases T2.2";
                        mtefBudgetPeriod.Group = "Current Expenditure";
                        mtefBudgetPeriod.Order = 7;
                        break;
                    case 5:
                        mtefBudgetPeriod.Title = "New leases T4.2";
                        mtefBudgetPeriod.Group = "Current Expenditure";
                        mtefBudgetPeriod.Order = 8;
                        break;
                    case 7:
                        mtefBudgetPeriod.Title = "Municipal / Utility Services: Leased-in (Electricity, water, sewer & refuse) T2.2";
                        mtefBudgetPeriod.Group = "Current Expenditure";
                        mtefBudgetPeriod.Order = 9;
                        break;
                    case 9:
                        mtefBudgetPeriod.Title = "Property Rates & Taxes T2.1";
                        mtefBudgetPeriod.Group = "Current Expenditure";
                        mtefBudgetPeriod.Order = 10;
                        break;
                    case 10:
                        mtefBudgetPeriod.Title = "Maintenance Requirements (Repairs) T5.2";
                        mtefBudgetPeriod.Group = "Current Expenditure";
                        mtefBudgetPeriod.Order = 11;
                        break;
                    case 11:
                        mtefBudgetPeriod.Title = "Total Current Costs";
                        mtefBudgetPeriod.Group = "Current Expenditure";
                        mtefBudgetPeriod.Order = 12;
                        break;
                    case 12:
                        mtefBudgetPeriod.Title = "Total Capital Works & Recurrent Costs";
                        mtefBudgetPeriod.Group = "Current Expenditure";
                        mtefBudgetPeriod.Order = 13;
                        break;
                    case 13:
                        mtefBudgetPeriod.Title = "% Shortfall";
                        mtefBudgetPeriod.IsPercentage = true;
                        mtefBudgetPeriod.Group = "Current Expenditure";
                        mtefBudgetPeriod.Order = 14;
                        break;  
                    default:
                        break;
                }
                if (mtefBudgetPeriod.Title != null) {
                    mtefBudgetPeriods.Add(mtefBudgetPeriod);
                }                
            }
            return mtefBudgetPeriods;
        }
    }
}
