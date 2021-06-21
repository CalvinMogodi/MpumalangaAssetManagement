using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface ISurrenderPlanRepository
    {
        int AddSurrenderPlan(SurrenderPlan surrenderPlan);
        bool UpdateSurrenderPlan(SurrenderPlan surrenderPlan);
        bool DeleteSurrenderPlan(SurrenderPlan surrenderPlan);
        List<SurrenderPlan> GetSurrenderPlans();
    }
}
