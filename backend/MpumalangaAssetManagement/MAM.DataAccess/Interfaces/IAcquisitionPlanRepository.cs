using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IAcquisitionPlanRepository
    {
        int AddAcquisitionPlan(AcquisitionPlan acquisitionPlan);
        void UpdateFacility(AcquisitionPlan acquisitionPlan);
        void DeleteFacility(AcquisitionPlan acquisitionPlan);
        List<AcquisitionPlan> GetAcquisitionPlans();
    }
}
