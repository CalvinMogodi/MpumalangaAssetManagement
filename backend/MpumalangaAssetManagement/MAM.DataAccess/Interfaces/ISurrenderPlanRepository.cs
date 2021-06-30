using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface ISurrenderPlanRepository
    {
        int AddSurrenderPlan(SurrenderPlan surrenderPlan);
        void UpdateSurrenderPlan(SurrenderPlan surrenderPlan);
        void DeleteSurrenderPlan(SurrenderPlan surrenderPlan);
        List<SurrenderPlan> GetSurrenderPlans(int uampId);
    }
}
