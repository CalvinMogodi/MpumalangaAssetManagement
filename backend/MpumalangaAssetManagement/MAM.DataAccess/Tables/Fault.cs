using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class Fault
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
        public string PropertyDescription { get; set; }
        public string IncidentDescription { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ReferenceNo { get; set; }
        public bool? HasCompletionCertificate { get; set; }
        public bool? HasContractInvoice { get; set; }
        public int? SupplierId { get; set; }
        public int? ProjectId { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
