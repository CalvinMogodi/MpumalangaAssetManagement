using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IAcquisitionPlanRepository
    {
        int AddAcquisitionPlan(AcquisitionPlan acquisitionPlan);
        void UpdateAcquisitionPlan(AcquisitionPlan acquisitionPlan);
        void DeleteUpdateAcquisitionPlan(AcquisitionPlan acquisitionPlan);
        List<AcquisitionPlan> GetAcquisitionPlans(int uampId);
    }
}
