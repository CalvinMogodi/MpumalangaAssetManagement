using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class LeaseStatus
    {
        public int Id { get; set; }
        public string NatureOfLease { get; set; }
        public string IDNumberCompanyRegistrationNumber { get; set; }
        public string POBox { get; set; }
        public string ContactNumber { get; set; }
        public string CapacityofContactPerson { get; set; }
        public string ContactPerson { get; set; }
        public int PostalCode { get; set; }
        public string LeaseStatusTown { get; set; }
        public decimal RentalAmount { get; set; }
        public DateTime TerminationDate { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime OccupationDate { get; set; }
        public string Escalation { get; set; }
        public string Vat { get; set; }
        public int LeaseNumber { get; set; }
        public int OtherCharges { get; set; }
    }
}
