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
        public double? MtefAllocation { get; set; }
        public double? RequiredBudget { get; set; }
        public double? Shortfall { get; set; }
    }
}
