using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface LandUseManagementDetailInterface
    {
        int AddLandUseManagementDetail(LandUseManagementDetail landUseManagementDetail);
        void UpdateLandUseManagementDetail(LandUseManagementDetail landUseManagementDetail);
        List<LandUseManagementDetail> GetLandUseManagementDetails();
        LandUseManagementDetail GetLandUseManagementDetailById(int id);
    }
}
