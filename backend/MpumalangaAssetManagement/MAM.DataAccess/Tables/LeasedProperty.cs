using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class LeasedProperty
    {
        public int LeaseStatusesId { get; set; }
        public string FileReference { get; set; }
        public string Type { get; set; }
        public string PropertyCode { get; set; }
        public string FacilityName { get; set; }
        public string NatureofLease { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}
