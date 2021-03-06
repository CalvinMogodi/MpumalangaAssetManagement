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
            OptimalSupportingAccommodation OptimalSupportingAccommodation = new OptimalSupportingAccommodation();
            Programme Programme = new Programme();
            Property Property = new Property();
            StrategicAssessment StrategicAssessment = new StrategicAssessment();
            AcquisitionPlan AcquisitionPlan = new AcquisitionPlan();
            OperationPlan OperationPlan = new OperationPlan();
            MtefBudgetPeriod MtefBudgetPeriod = new MtefBudgetPeriod();
            SurrenderPlan SurrenderPlan = new SurrenderPlan();

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
                    OptimalSupportingAccommodation = f.OptimalSupportingAccommodation != null ? OptimalSupportingAccommodation.ConvertToOptimalSupportingAccommodation(f.OptimalSupportingAccommodation) : new OptimalSupportingAccommodation(),
                    Programmes = f.Programmes != null ? Programme.ConvertToProgrammes(f.Programmes.Where(p => p.UserImmovableAssetManagementPlanId == f.Id).ToList()) : new List<Programme>(),
                },
                TempleteTwoPointOne = new TempleteTwoPointOne() { 
                    Id = 0,
                    Properties = f.Properties != null ? Property.ConvertToProperties(f.Properties.Where(p => p.UserImmovableAssetManagementPlanId == f.Id && p.TempleteNumber == 2.1).ToList()) : new List<Property>(),
                },
                TempleteTwoPointTwo = new TempleteTwoPointTwo()
                {
                    Id = 0,
                    Properties = f.Properties != null ? Property.ConvertToProperties(f.Properties.Where(p => p.UserImmovableAssetManagementPlanId == f.Id && p.TempleteNumber == 2.2).ToList()) : new List<Property>(),
                },
                TempleteThree = new TempleteThree()
                {
                    Id = 0,
                    StrategicAssessments = f.StrategicAssessments != null ? StrategicAssessment.ConvertToStrategicAssessments(f.StrategicAssessments.Where(p => p.UserImmovableAssetManagementPlanId == f.Id).ToList()) : new List<StrategicAssessment>(),
                },
                TempleteFourPointOne = new TempleteFourPointOne()
                {
                    Id = 0,
                    AcquisitionPlans = f.AcquisitionPlans != null ? AcquisitionPlan.ConvertToAcquisitionPlans(f.AcquisitionPlans.Where(p => p.UserImmovableAssetManagementPlanId == f.Id && p.TempleteNumber == 4.1).ToList()) : new List<AcquisitionPlan>(),
                },
                TempleteFourPointTwo = new TempleteFourPointTwo()
                {
                    Id = 0,
                    AcquisitionPlans = f.AcquisitionPlans != null ? AcquisitionPlan.ConvertToAcquisitionPlans(f.AcquisitionPlans.Where(p => p.UserImmovableAssetManagementPlanId == f.Id && p.TempleteNumber == 4.2).ToList()) : new List<AcquisitionPlan>(),
                },
                TempleteFivePointOne = new TempleteFivePointOne()
                {
                    Id = 0,
                    OperationPlans = f.OperationPlans.Count > 0 ? OperationPlan.ConvertToOperationPlans(f.OperationPlans.Where(p => p.UserImmovableAssetManagementPlanId == f.Id && p.TempleteNumber == 5.1).ToList()) : new List<OperationPlan>(),
                },
                TempleteFivePointTwo = new TempleteFivePointTwo()
                {
                    Id = 0,
                    OperationPlans = f.OperationPlans.Count > 0 ? OperationPlan.ConvertToOperationPlans(f.OperationPlans.Where(p => p.UserImmovableAssetManagementPlanId == f.Id && p.TempleteNumber == 5.2).ToList()) : new List<OperationPlan>(),
                },
                TempleteFivePointThree = new TempleteFivePointThree()
                {
                    Id = 0,
                    OperationPlans = f.OperationPlans.Count > 0 ? OperationPlan.ConvertToOperationPlans(f.OperationPlans.Where(p => p.UserImmovableAssetManagementPlanId == f.Id && p.TempleteNumber == 5.3).ToList()) : new List<OperationPlan>(),
                },
                TempleteSix = new TempleteSix()
                {
                    Id = 0,
                    SurrenderPlans = f.OperationPlans.Count > 0 ? SurrenderPlan.ConvertToSurrenderPlans(f.SurrenderPlans.Where(p => p.UserImmovableAssetManagementPlanId == f.Id).ToList()) : new List<SurrenderPlan>(),
                },
                TempleteSeven = new TempleteSeven()
                {
                    Id = 0,
                    MtefBudgetPeriods = new List<MtefBudgetPeriod>()// f.OperationPlans.Count > 0 ? MtefBudgetPeriod.ConvertToMtefBudgetPeriods(f.MtefBudgetPeriods.Where(p => p.UserImmovableAssetManagementPlanId == f.Id).ToList()) : new List<MtefBudgetPeriod>(),
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
