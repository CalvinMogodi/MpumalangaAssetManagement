using MAM.BusinessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class MtefYear
    {
        public int Id { get; set; }
        public int MtefBudgetPeriodId { get; set; }
        public ResultType ResultType { get; set; }
        public int ResultTypeId { get; set; }
        public int Year { get; set; }
        public double? MtefAllocation { get; set; }
        public double? RequiredBudget { get; set; }
        public double? Shortfall { get; set; }

        public DataAccess.Tables.MtefYear ConvertToMtefYearTable(MtefYear mtefYear) {
            return new DataAccess.Tables.MtefYear()
            {
                Id = mtefYear.Id,
                MtefBudgetPeriodId = mtefYear.MtefBudgetPeriodId,
                ResultTypeId = mtefYear.ResultTypeId,
                MtefAllocation = mtefYear.MtefAllocation,
                RequiredBudget = mtefYear.RequiredBudget,
                Shortfall = mtefYear.Shortfall,
                Year = mtefYear.Year
            };
        }

        public MtefYear ConvertToMtefYear(DataAccess.Tables.MtefYear mtefYear)
        {
            return new MtefYear()
            {
                Id = mtefYear.Id,
                MtefBudgetPeriodId = mtefYear.MtefBudgetPeriodId,
                ResultTypeId = mtefYear.ResultTypeId,
                MtefAllocation = mtefYear.MtefAllocation,
                RequiredBudget = mtefYear.RequiredBudget,
                Shortfall = mtefYear.Shortfall,
                Year = mtefYear.Year
            };
        }
    }
}
