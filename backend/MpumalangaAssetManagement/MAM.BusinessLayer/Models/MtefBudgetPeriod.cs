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
        public DataAccess.Tables.MtefBudgetPeriod ConvertToMtefBudgetPeriodTable(MtefBudgetPeriod mtefBudgetPeriod)
        {
            return new DataAccess.Tables.MtefBudgetPeriod()
            {
                Id = mtefBudgetPeriod.Id,
                Name = mtefBudgetPeriod.Name,
                UserImmovableAssetManagementPlanId = mtefBudgetPeriod.UserImmovableAssetManagementPlanId,
                MtefAllocationY1 = mtefBudgetPeriod.MtefAllocationY1,
                RequiredBudgetY1 = mtefBudgetPeriod.RequiredBudgetY1,
                ShortfallY1 = mtefBudgetPeriod.ShortfallY1,
                MtefAllocationY2 = mtefBudgetPeriod.MtefAllocationY2,
                RequiredBudgetY2 = mtefBudgetPeriod.RequiredBudgetY2,
                ShortfallY2 = mtefBudgetPeriod.ShortfallY2,
                MtefAllocationY3 = mtefBudgetPeriod.MtefAllocationY3,
                RequiredBudgetY3 = mtefBudgetPeriod.RequiredBudgetY3,
                ShortfallY3 = mtefBudgetPeriod.ShortfallY3,
                MtefAllocationY4 = mtefBudgetPeriod.MtefAllocationY4,
                RequiredBudgetY4 = mtefBudgetPeriod.RequiredBudgetY4,
                ShortfallY4 = mtefBudgetPeriod.ShortfallY4,
                MtefAllocationY5 = mtefBudgetPeriod.MtefAllocationY4,
                RequiredBudgetY5 = mtefBudgetPeriod.RequiredBudgetY5,
                ShortfallY5 = mtefBudgetPeriod.ShortfallY5,
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
                Name = o.Name,
                UserImmovableAssetManagementPlanId = o.UserImmovableAssetManagementPlanId,
                MtefAllocationY1 = o.MtefAllocationY1,
                RequiredBudgetY1 = o.RequiredBudgetY1,
                ShortfallY1  = o.ShortfallY1,
                MtefAllocationY2 = o.MtefAllocationY2,
                RequiredBudgetY2 = o.RequiredBudgetY2,
                ShortfallY2 = o.ShortfallY2,
                MtefAllocationY3 = o.MtefAllocationY3,
                RequiredBudgetY3 = o.RequiredBudgetY3,
                ShortfallY3 = o.ShortfallY3,
                MtefAllocationY4 = o.MtefAllocationY4,
                RequiredBudgetY4 = o.RequiredBudgetY4,
                ShortfallY4 = o.ShortfallY4,
                MtefAllocationY5 = o.MtefAllocationY4,
                RequiredBudgetY5 = o.RequiredBudgetY5,
                ShortfallY5 = o.ShortfallY5,
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
                    MtefAllocationY1 = 0,
                    RequiredBudgetY1 = 0,
                    ShortfallY1 = 0,
                    MtefAllocationY2 = 0,
                    RequiredBudgetY2 = 0,
                    ShortfallY2 = 0,
                    MtefAllocationY3 = 0,
                    RequiredBudgetY3 = 0,
                    ShortfallY3 = 0,
                    MtefAllocationY4 = 0,
                    RequiredBudgetY4 = 0,
                    ShortfallY4 = 0,
                    MtefAllocationY5 = 0,
                    RequiredBudgetY5 = 0,
                    ShortfallY5 = 0
                };
               
                
                switch (i)
                {
                    case 0:
                        mtefBudgetPeriod.Name = "New Capital Works T4.1";
                        mtefBudgetPeriod.Order = 2;
                        break;
                    case 1:
                        mtefBudgetPeriod.Name = "Refurb., Re-config.& Additions) T5.1";
                        mtefBudgetPeriod.Order = 3;
                        break;
                    case 2:
                        mtefBudgetPeriod.Name = "Total Capital Costs";
                        mtefBudgetPeriod.Order = 4;
                        break;
                    case 3:
                        mtefBudgetPeriod.Name = "% Shortfall";
                        mtefBudgetPeriod.IsPercentage = true;
                        mtefBudgetPeriod.Order = 5;
                        break;
                    case 4:
                        mtefBudgetPeriod.Name = "Existing Leases T2.2";
                        mtefBudgetPeriod.Order = 7;
                        break;
                    case 5:
                        mtefBudgetPeriod.Name = "New leases T4.2";
                        mtefBudgetPeriod.Order = 8;
                        break;
                    case 7:
                        mtefBudgetPeriod.Name = "Municipal / Utility Services: Leased-in (Electricity, water, sewer & refuse) T2.2";
                        mtefBudgetPeriod.Order = 9;
                        break;
                    case 9:
                        mtefBudgetPeriod.Name = "Property Rates & Taxes T2.1";
                        mtefBudgetPeriod.Order = 10;
                        break;
                    case 10:
                        mtefBudgetPeriod.Name = "Maintenance Requirements (Repairs) T5.2";
                        mtefBudgetPeriod.Order = 11;
                        break;
                    case 11:
                        mtefBudgetPeriod.Name = "Total Current Costs";
                        mtefBudgetPeriod.Order = 12;
                        break;
                    case 12:
                        mtefBudgetPeriod.Name = "Total Capital Works & Recurrent Costs";
                        mtefBudgetPeriod.Order = 13;
                        break;
                    case 13:
                        mtefBudgetPeriod.Name = "% Shortfall";
                        mtefBudgetPeriod.IsPercentage = true;
                        mtefBudgetPeriod.Order = 14;
                        break;
                    case 14:
                        mtefBudgetPeriod.Name = "Capital Projects";
                        mtefBudgetPeriod.IsHeader = true;
                        mtefBudgetPeriod.Order = 1;
                        break;
                    case 15:
                        mtefBudgetPeriod.Name = "Current Expenditure";
                        mtefBudgetPeriod.IsHeader = true;
                        mtefBudgetPeriod.Order = 6;
                        break;
                    case 16:
                        mtefBudgetPeriod.Name = "Municipal / Utility Services";
                        mtefBudgetPeriod.IsHeader = true;
                        mtefBudgetPeriod.Order = 9;
                        break;
                    default:
                        break;
                }

                mtefBudgetPeriods.Add(mtefBudgetPeriod);
            }
            return mtefBudgetPeriods;
        }
    }
}
