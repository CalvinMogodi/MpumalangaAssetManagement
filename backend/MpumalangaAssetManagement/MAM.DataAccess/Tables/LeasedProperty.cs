using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class LeasedProperty
    {
        public int LeaseStatusesId { get; set; }
        public string FileReference { get; set; }
        public string District { get; set; }
        public string Type { get; set; }
        public string PropertyCode { get; set; }
        public string FacilityName { get; set; }
        public int LandId { get; set; }
        public string NatureofLease { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public LandUseManagementDetail LandUseManagementDetail { get; set; }
        public LeaseStatus LeaseStatus { get; set; }
    }
}
