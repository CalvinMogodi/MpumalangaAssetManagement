using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IUampRepository
    {
        int AddUamp(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan);
        bool UpdateUamp(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan);
        bool DeleteUamp(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan);
        List<UserImmovableAssetManagementPlan> GetUamps();
    }
}
