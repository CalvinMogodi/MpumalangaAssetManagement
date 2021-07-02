using MAM.BusinessLayer.Model;
using MAM.BusinessLayer.Models.Templetes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class UserImmovableAssetManagementPlan
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string FileReference { get; set; }
        public int? OptimalSupportingAccommodationId { get; set; }
        public string Department { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public TempleteOne TempleteOne { get; set; }
        public TempleteTwoPointOne TempleteTwoPointOne { get; set; }
        public TempleteTwoPointTwo TempleteTwoPointTwo { get; set; }
        public TempleteThree TempleteThree { get; set; }
        public TempleteFourPointOne TempleteFourPointOne { get; set; }
        public TempleteFourPointTwo TempleteFourPointTwo { get; set; }
        public TempleteFivePointOne TempleteFivePointOne { get; set; }
        public TempleteFivePointTwo TempleteFivePointTwo { get; set; }
        public TempleteFivePointThree TempleteFivePointThree { get; set; }
        public TempleteSix TempleteSix { get; set; }
        public TempleteSeven TempleteSeven { get; set; }
        public User User { get; set; }

        public List<UserImmovableAssetManagementPlan> ConvertToUserImmovableAssetManagementPlans(List<DataAccess.Tables.UserImmovableAssetManagementPlan> uamp) {
            OptimalSupportingAccommodation optimalSupportingAccommodation = new OptimalSupportingAccommodation();
            Programme programme = new Programme();
            Property property = new Property();
            StrategicAssessment strategicAssessment = new StrategicAssessment();

            List<Programme> Programmes = new List<Programme>();
            List<AcquisitionPlan> AcquisitionPlans = new List<AcquisitionPlan>();
            List<MtefBudgetPeriod> MtefBudgetPeriods = new List<MtefBudgetPeriod>();
            List<MtefYear> MtefYears = new List<MtefYear>();
            List<MunicipalUtilityService> MunicipalUtilityServices = new List<MunicipalUtilityService>();
            List<OperationPlan> OperationPlans = new List<OperationPlan>();
            List<Property> Properties = new List<Property>();
            List<StrategicAssessment> StrategicAssessments = new List<StrategicAssessment>();
            List<SurrenderPlan> SurrenderPlans = new List<SurrenderPlan>();

            List<UserImmovableAssetManagementPlan> userImmovableAssetManagementPlans = uamp.Select(f => new UserImmovableAssetManagementPlan()
            {
                Id = f.Id,
                Status = f.Status,
                FileReference = f.FileReference,
                OptimalSupportingAccommodationId = f.OptimalSupportingAccommodationId,
                Department = f.Department,
                CreatedDate = f.CreatedDate,
                UserId = f.UserId,
                ModifiedDate = f.ModifiedDate,
                ModifiedBy = f.ModifiedBy,
                User = new User() { 
                    Name = f.User.Name,
                    Surname = f.User.Surname
                },
                TempleteOne = new TempleteOne()
                {
                    Id = 0,
                    OptimalSupportingAccommodation = f.OptimalSupportingAccommodation != null ? optimalSupportingAccommodation.ConvertToOptimalSupportingAccommodation(f.OptimalSupportingAccommodation) : null,
                    Programmes = f.Programmes != null ? programme.ConvertToProgrammes(f.Programmes.Where(p => p.UserImmovableAssetManagementPlanId == f.Id).ToList()) : new List<Programme>(),
                },
                TempleteTwoPointOne = new TempleteTwoPointOne() { 
                    Id = 0,
                    Properties = f.Properties != null ? property.ConvertToProperties(f.Properties.Where(p => p.UserImmovableAssetManagementPlanId == f.Id && p.TempleteNumber == 2.1).ToList()) : new List<Property>(),
                },
                TempleteTwoPointTwo = new TempleteTwoPointTwo()
                {
                    Id = 0,
                    Properties = f.Properties != null ? property.ConvertToProperties(f.Properties.Where(p => p.UserImmovableAssetManagementPlanId == f.Id && p.TempleteNumber == 2.2).ToList()) : new List<Property>(),
                },
                TempleteThree = new TempleteThree()
                {
                    Id = 0,
                    StrategicAssessments = f.StrategicAssessments != null ? strategicAssessment.ConvertToStrategicAssessments(f.StrategicAssessments.Where(p => p.UserImmovableAssetManagementPlanId == f.Id).ToList()) : new List<StrategicAssessment>(),
                }
            }).ToList();
            return userImmovableAssetManagementPlans;
        }

        public DataAccess.Tables.UserImmovableAssetManagementPlan ConvertToDBUserImmovableAssetManagementPlans(UserImmovableAssetManagementPlan uamp) {
            return new DataAccess.Tables.UserImmovableAssetManagementPlan()
            {
                Id = uamp.Id,
                Status = uamp.Status,
                FileReference = uamp.FileReference,
                OptimalSupportingAccommodationId = uamp.OptimalSupportingAccommodationId,
                Department = uamp.Department,
                CreatedDate = uamp.CreatedDate,
                UserId = uamp.UserId,
                ModifiedDate = uamp.ModifiedDate,
                ModifiedBy = uamp.ModifiedBy
            };       
        }
    }
}
