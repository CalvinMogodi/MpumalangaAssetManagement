using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IOperationPlanRepository
    {
        int AddOperationPlan(OperationPlan operationPlan);
        bool UpdateOperationPlan(OperationPlan operationPlan);
        bool DeleteOperationPlan(OperationPlan operationPlan);
        List<OperationPlan> GetOperationPlans();
    }
}
