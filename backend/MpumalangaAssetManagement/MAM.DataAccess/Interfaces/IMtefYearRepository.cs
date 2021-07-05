using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IMtefYearRepository
    {
        int AddMtefYear(MtefYear mtefYear);
        void UpdateMtefYear(MtefYear mtefYear);
        void DeleteMtefYear(MtefYear municipalUtilityService);
        List<MtefYear> GetMtefYears(int mtefBudgetPeriodId);
    }
}
