using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class LandUseManagementDetail
    {
        public int Id { get; set; }
        public string TitleDeedNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
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
    }
}
