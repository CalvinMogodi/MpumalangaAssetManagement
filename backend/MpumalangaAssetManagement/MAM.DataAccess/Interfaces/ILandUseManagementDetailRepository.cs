using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface ILandUseManagementDetailRepository
    {
        LandUseManagementDetail GetLandUseManagementDetailById(int id);
        void SetLandUseManagementDetailIncomeLeaseStatus(LandUseManagementDetail landUseManagementDetail);
    }
}
