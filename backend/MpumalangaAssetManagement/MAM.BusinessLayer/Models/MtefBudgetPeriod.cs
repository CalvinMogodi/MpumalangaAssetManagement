﻿using MAM.BusinessLayer.Models.Enums;
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
        public MtefYear MtefYearOne { get; set; }
        public MtefYear MtefYearTwo { get; set; }
        public MtefYear MtefYearThree { get; set; }
        public MtefYear MtefYearFour { get; set; }
        public MtefYear MtefYearFive { get; set; }

        public DataAccess.Tables.MtefBudgetPeriod ConvertToMtefBudgetPeriodTable(MtefBudgetPeriod mtefBudgetPeriod)
        {
            return new DataAccess.Tables.MtefBudgetPeriod()
            {
                Id = mtefBudgetPeriod.Id,
            };
        }


        public List<MtefBudgetPeriod> ConvertToMtefBudgetPeriods(List<DataAccess.Tables.MtefBudgetPeriod> mtefBudgetPeriods)
        {
            return mtefBudgetPeriods.Select(o => new MtefBudgetPeriod()
            {
                Id = o.Id,
            }).ToList();
        }

        public List<MtefBudgetPeriod> BuildMtefBudgetPeriod(int uampId)
        {
            List<MtefBudgetPeriod> mtefBudgetPeriods = new List<MtefBudgetPeriod>();
            for (int i = 0; i < 14; i++)
            {
                MtefBudgetPeriod mtefBudgetPeriod = new MtefBudgetPeriod();
                switch (i)
                {
                    case 0:
                        mtefBudgetPeriod.Name = "New Capital Works T4.1";
                        break;
                    case 1:
                        mtefBudgetPeriod.Name = "Refurb., Re-config.& Additions) T5.1";
                        break;
                    case 2:
                        mtefBudgetPeriod.Name = "Total Capital Costs";
                        break;
                    case 3:
                        mtefBudgetPeriod.Name = "% Shortfall";
                        break;
                    case 4:
                        mtefBudgetPeriod.Name = "Existing Leases T2.2";
                        break;
                    case 5:
                        mtefBudgetPeriod.Name = "New leases T4.2";
                        break;
                    case 6:
                        mtefBudgetPeriod.Name = "Municipal / Utility Services: State-owned (Electricity, water, sewer & refuse) T2.1";
                        break;
                    case 7:
                        mtefBudgetPeriod.Name = "Municipal / Utility Services: Leased-in (Electricity, water, sewer & refuse) T2.2";
                        break;
                    case 8:
                        mtefBudgetPeriod.Name = "Property Rates & Taxes T2.1";
                        break;
                    case 9:
                        mtefBudgetPeriod.Name = "Maintenance Requirements (Repairs) T5.2";
                        break;
                    case 10:
                        mtefBudgetPeriod.Name = "Total Current Costs";
                        break;
                    case 11:
                        mtefBudgetPeriod.Name = "Total Capital Works & Recurrent Costs";
                        break;
                    case 12:
                        mtefBudgetPeriod.Name = "% Shortfall";                    
                        break;
                    default:
                        break;
                }
                mtefBudgetPeriod.UserImmovableAssetManagementPlanId = uampId;
                MtefYear mtefYear = new MtefYear() {
                    Id = 0,
                    MtefBudgetPeriodId = 0,
                    MtefAllocation = 0,
                    RequiredBudget = 0,
                    Shortfall = 0,
                    ResultType = ResultType.Percentage
                };
                mtefBudgetPeriod.MtefYearOne = mtefYear;
                mtefBudgetPeriod.MtefYearTwo = mtefYear;
                mtefBudgetPeriod.MtefYearThree = mtefYear;
                mtefBudgetPeriod.MtefYearFour = mtefYear;
                mtefBudgetPeriod.MtefYearFive = mtefYear;
                mtefBudgetPeriods.Add(mtefBudgetPeriod);
            }
            return mtefBudgetPeriods;
        }
    }
}
