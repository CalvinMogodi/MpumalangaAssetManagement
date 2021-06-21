using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class MtefYear
    {
        public int Id { get; set; }
        public int ResultTypeId { get; set; }
        public int Year { get; set; }
        public double? MtefAllocation { get; set; }
        public double? RequiredBudget { get; set; }
        public double? Shortfall { get; set; }
    }
}
