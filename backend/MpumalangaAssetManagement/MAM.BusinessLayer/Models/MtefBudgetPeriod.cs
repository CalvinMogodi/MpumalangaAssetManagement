using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class MtefBudgetPeriod
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public int Name { get; set; }
        public MtefYear MtefYearOne { get; set; }
        public MtefYear MtefYearTwo { get; set; }
        public MtefYear MtefYearThree { get; set; }
        public MtefYear MtefYearFour { get; set; }
        public MtefYear MtefYearFive { get; set; }
    }
}
