using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Models.Templetes;
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
        UserImmovableAssetManagementPlan GetUampWithTemplateOne(int id);
        UserImmovableAssetManagementPlan SaveUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan);
        UserImmovableAssetManagementPlan StartUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan);
        TempleteOne GetUAMPTempleteOne(int uampId);
        TempleteTwoPointOne GetUAMPTempleteTwoPointOne(int uampId);
        TempleteTwoPointTwo GetUAMPTempleteTwoPointTwo(int uampId);
        TempleteThree GetUAMPTempleteThree(int uampId);
        TempleteFourPointOne GetUAMPTempleteFourPointOne(int uampId);
        TempleteFourPointTwo GetUAMPTempleteFourPointTwo(int uampId);
        TempleteFivePointOne GetUAMPTempleteFivePointOne(int uampId);
        TempleteFivePointTwo GetUAMPTempleteFivePointTwo(int uampId);
        TempleteFivePointThree GetUAMPTempleteFivePointThree(int uampId);
        TempleteSix GetUAMPTempleteSix(int uampId);
        TempleteSeven GetUAMPTempleteSeven(int uampId);
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

        public TempleteOne GetUAMPTempleteOne(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteOne(uampId);
            }
        }

        public TempleteTwoPointOne GetUAMPTempleteTwoPointOne(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteTwoPointOne(uampId);
            }
        }

        public TempleteTwoPointTwo GetUAMPTempleteTwoPointTwo(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteTwoPointTwo(uampId);
            }
        }

        public TempleteThree GetUAMPTempleteThree(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteThree(uampId);
            }
        }

        public TempleteFourPointOne GetUAMPTempleteFourPointOne(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteFourPointOne(uampId);
            }
        }

        public TempleteFourPointTwo GetUAMPTempleteFourPointTwo(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteFourPointTwo(uampId);
            }
        }

        public TempleteFivePointOne GetUAMPTempleteFivePointOne(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteFivePointOne(uampId);
            }
        }

        public TempleteFivePointTwo GetUAMPTempleteFivePointTwo(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteFivePointTwo(uampId);
            }
        }

        public TempleteFivePointThree GetUAMPTempleteFivePointThree(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteFivePointThree(uampId);
            }
        }

        public TempleteSix GetUAMPTempleteSix(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteSix(uampId);
            }
        }

        public TempleteSeven GetUAMPTempleteSeven(int uampId)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUAMPTempleteSeven(uampId);
            }
        }

        public UserImmovableAssetManagementPlan GetUampWithTemplateOne(int id)
        {
            using (var _userImmovableAssetManagementPlan = new UserImmovableAssetManagementPlanRepository(_appSettings))
            {
                return _userImmovableAssetManagementPlan.GetUampWithTemplateOne(id);
            }
        }
    }
}
