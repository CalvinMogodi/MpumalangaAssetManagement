using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IOperationPlanRepository
    {
        int AddOperationPlan(OperationPlan operationPlan);
        void UpdateOperationPlan(OperationPlan operationPlan);
        void DeleteOperationPlan(OperationPlan operationPlan);
        List<OperationPlan> GetOperationPlans(int uampId);
    }
}
