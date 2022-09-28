using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Fault
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
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

        public List<Fault> ConvertToFaults(List<DataAccess.Tables.Fault> faults)
        {
            return faults.Select(f => new Fault()
            {
                Id = f.Id,
                FacilityId = f.FacilityId,
                PropertyDescription = f.PropertyDescription,
                IncidentDescription = f.IncidentDescription,
                ContactName = f.ContactName,
                ContactNumber = f.ContactNumber,
                CreatedDate = f.CreatedDate,
                ModifiedDate = f.ModifiedDate,
                ReferenceNo = f.ReferenceNo,
                HasCompletionCertificate = f.HasCompletionCertificate,
                HasContractInvoice = f.HasContractInvoice,
                SupplierId = f.SupplierId,
                ProjectId = f.ProjectId,
                Notes = f.Notes,
                Status = f.Status,
                IsDeleted = f.IsDeleted
            }).ToList();
        }

        public Fault ConvertToFault(DataAccess.Tables.Fault fault)
        {
            return new Fault(){
                Id = fault.Id,
                FacilityId = fault.FacilityId,
                PropertyDescription = fault.PropertyDescription,
                IncidentDescription = fault.IncidentDescription,
                ContactName = fault.ContactName,
                ContactNumber = fault.ContactNumber,
                CreatedDate = fault.CreatedDate,
                ModifiedDate = fault.ModifiedDate,
                ReferenceNo = fault.ReferenceNo,
                HasCompletionCertificate = fault.HasCompletionCertificate,
                HasContractInvoice = fault.HasContractInvoice,
                SupplierId = fault.SupplierId,
                ProjectId = fault.ProjectId,
                Notes = fault.Notes,
                Status = fault.Status,
                IsDeleted = fault.IsDeleted
            };
        }

        public DataAccess.Tables.Fault ConvertToFaultTable(Fault fault)
        {
            return new DataAccess.Tables.Fault() {
                Id = fault.Id,
                FacilityId = fault.FacilityId,
                PropertyDescription = fault.PropertyDescription,
                IncidentDescription = fault.IncidentDescription,
                ContactName = fault.ContactName,
                ContactNumber = fault.ContactNumber,
                CreatedDate = fault.CreatedDate,
                ModifiedDate = fault.ModifiedDate,
                ReferenceNo = fault.ReferenceNo,
                HasCompletionCertificate = fault.HasCompletionCertificate,
                HasContractInvoice = fault.HasContractInvoice,
                SupplierId = fault.SupplierId,
                ProjectId = fault.ProjectId,
                Notes = fault.Notes,
                Status = fault.Status,
                IsDeleted = fault.IsDeleted
            };
        }
    }
}
