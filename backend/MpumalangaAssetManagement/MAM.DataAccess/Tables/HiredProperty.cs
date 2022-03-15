using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class HiredProperty
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string District { get; set; }
        public string PropertyCode { get; set; }
        public string BuildingCondition { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public double? MonthlyRental { get; set; }
        public double? StartRentalAmount { get; set; }
        public string Town { get; set; }
        public string Status { get; set; }
        public string UserDepartment { get; set; }
        public string LandlandAgentName { get; set; }
        public string LandlandAgentContactDetails { get; set; }
        public int? NumberofStaff { get; set; }
        public DateTime? EscalationDate { get; set; }
        public double? EscalationRate { get; set; }
        public double? Area { get; set; }
        public string Address { get; set; }
        public bool IsDeteted { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
