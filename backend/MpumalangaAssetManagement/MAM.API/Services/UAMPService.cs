using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Services
{
    public interface IUAMPService
    {
        List<UserImmovableAssetManagementPlan> GetUserImmovableAssetManagementPlans();
        UserImmovableAssetManagementPlan SaveUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan);
        UserImmovableAssetManagementPlan AddUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan);   
    }

    public class UAMPService : IUAMPService
    {
        private readonly AppSettings _appSettings;

        public UAMPService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public List<UserImmovableAssetManagementPlan> GetUserImmovableAssetManagementPlans() {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUserImmovableAssetManagementPlans();
            }
        }

        public UserImmovableAssetManagementPlan SaveUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan) {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.SaveUserImmovableAssetManagementPlan(userImmovableAssetManagementPlan);
            }
        }
        public UserImmovableAssetManagementPlan AddUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan) {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.AddUserImmovableAssetManagementPlan(userImmovableAssetManagementPlan);
            }
        }       
    }
}
