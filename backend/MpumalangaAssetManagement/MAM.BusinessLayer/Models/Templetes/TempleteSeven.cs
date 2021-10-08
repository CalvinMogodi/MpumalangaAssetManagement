using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteSeven
    {
        public int Id { get; set; }
        public List<MtefBudgetPeriod> MtefBudgetPeriods { get; set; }

        public TempleteSeven ConvertToTempleteSeven(List<DataAccess.Tables.MtefBudgetPeriod> mtefBudgetPeriods)
        {
            TempleteSeven templeteSeven = new TempleteSeven();
            MtefBudgetPeriod mtefBudgetPeriod = new MtefBudgetPeriod();
            templeteSeven.MtefBudgetPeriods = mtefBudgetPeriod.ConvertToMtefBudgetPeriods(mtefBudgetPeriods);
            return templeteSeven;
        }
    }
}
