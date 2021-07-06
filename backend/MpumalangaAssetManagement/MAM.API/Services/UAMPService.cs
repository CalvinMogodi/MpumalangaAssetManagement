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
        List<UserImmovableAssetManagementPlan> GetUserImmovableAssetManagementPlans(string department);
        UserImmovableAssetManagementPlan GetUamp(int id);
        UserImmovableAssetManagementPlan SaveUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan);
        UserImmovableAssetManagementPlan StartUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan);
        bool DeleteProgramme(Programme programme);
        bool DeleteAcquisitionPlan(AcquisitionPlan acquisitionPlan);
        bool DeleteProperty(Property property);
        bool DeleteOperationPlan(OperationPlan operationPlan);
        bool DeleteStrategicAssessment(StrategicAssessment strategicAssessment);
        bool DeleteSurrenderPlan(SurrenderPlan surrenderPlan);
    }

    public class UAMPService : IUAMPService
    {
        private readonly AppSettings _appSettings;

        public UAMPService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public bool DeleteOperationPlan(OperationPlan operationPlan)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.DeleteOperationPlan(operationPlan);
            }
        }

        public bool DeleteProgramme(Programme programme)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.DeleteProgramme(programme);
            }
        }

        public bool DeleteAcquisitionPlan(AcquisitionPlan acquisitionPlan)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.DeleteAcquisitionPlan(acquisitionPlan);
            }
        }

        public bool DeleteProperty(Property property)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.DeleteProperty(property);
            }
        }

        public bool DeleteStrategicAssessment(StrategicAssessment strategicAssessment)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.DeleteStrategicAssessment(strategicAssessment);
            }
        }

        public bool DeleteSurrenderPlan(SurrenderPlan surrenderPlan)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.DeleteSurrenderPlan(surrenderPlan);
            }
        }

        public UserImmovableAssetManagementPlan GetUamp(int id) {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUamp(id);
            }
        }

        public List<UserImmovableAssetManagementPlan> GetUserImmovableAssetManagementPlans(string department) {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUserImmovableAssetManagementPlans(department);
            }
        }

        public UserImmovableAssetManagementPlan SaveUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan) {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.SaveUserImmovableAssetManagementPlan(userImmovableAssetManagementPlan);
            }
        }
        public UserImmovableAssetManagementPlan StartUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan) {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.StartUserImmovableAssetManagementPlan(userImmovableAssetManagementPlan);
            }
        }       
    }
}
