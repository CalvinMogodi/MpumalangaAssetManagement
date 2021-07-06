using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class MtefBudgetPeriod
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public string Name { get; set; }
        public virtual List<MtefYear> MtefYears { get; set; }
    }
}
