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
    }
}
