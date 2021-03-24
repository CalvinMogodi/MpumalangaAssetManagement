using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class LandUseManagementDetail
    {
        public int Id { get; set; }
        public string TitleDeedNumber { get; set; }
        public string RegistrationDate { get; set; }
        public string RegisteredOwner { get; set; }
        public DateTime VestingDate { get; set; }
        public string ConditionsOfTitle { get; set; }
        public string OwnershipCategory { get; set; }
        public int StateOwnedPercentage { get; set; }
        public string LandUse { get; set; }
        public string Zoning { get; set; }
        public string UserDepartment { get; set; }
        public string FacilityName { get; set; }
        public string IncomeLeaseStatus { get; set; }

        public LandUseManagementDetail ConvertLandUseManagementDetail(DataAccess.Tables.LandUseManagementDetail landUseManagementDetail)
        {
            return new LandUseManagementDetail
            {
                Id = landUseManagementDetail.Id,
                TitleDeedNumber = landUseManagementDetail.TitleDeedNumber,
                RegistrationDate = landUseManagementDetail.RegistrationDate,
                RegisteredOwner = landUseManagementDetail.RegisteredOwner,
                VestingDate = landUseManagementDetail.VestingDate,
                ConditionsOfTitle = landUseManagementDetail.ConditionsOfTitle,
                OwnershipCategory = landUseManagementDetail.OwnershipCategory,
                StateOwnedPercentage = landUseManagementDetail.StateOwnedPercentage,
                LandUse = landUseManagementDetail.LandUse,
                Zoning = landUseManagementDetail.Zoning,
                UserDepartment = landUseManagementDetail.UserDepartment,
                FacilityName = landUseManagementDetail.FacilityName,
                IncomeLeaseStatus = landUseManagementDetail.IncomeLeaseStatus,
            };
        }

        public DataAccess.Tables.LandUseManagementDetail ConvertLandUseManagementDetail(LandUseManagementDetail landUseManagementDetail)
        {
            return new DataAccess.Tables.LandUseManagementDetail
            {
                Id = landUseManagementDetail.Id,
                TitleDeedNumber = landUseManagementDetail.TitleDeedNumber,
                RegistrationDate = landUseManagementDetail.RegistrationDate,
                RegisteredOwner = landUseManagementDetail.RegisteredOwner,
                VestingDate = landUseManagementDetail.VestingDate,
                ConditionsOfTitle = landUseManagementDetail.ConditionsOfTitle,
                OwnershipCategory = landUseManagementDetail.OwnershipCategory,
                StateOwnedPercentage = landUseManagementDetail.StateOwnedPercentage,
                LandUse = landUseManagementDetail.LandUse,
                Zoning = landUseManagementDetail.Zoning,
                UserDepartment = landUseManagementDetail.UserDepartment,
                FacilityName = landUseManagementDetail.FacilityName,
                IncomeLeaseStatus = landUseManagementDetail.IncomeLeaseStatus,
            };
        }
    }
}
