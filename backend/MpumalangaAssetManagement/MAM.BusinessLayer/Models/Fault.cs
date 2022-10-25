using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Fault
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
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
        public List<FaultNote> FaultNotes { get; set; }
        public string Status { get; set; }
        public bool? IsDeleted { get; set; }

        public List<Fault> ConvertToFaults(List<DataAccess.Tables.Fault> faults)
        {
            var faultList = new List<Fault>();
            foreach (var fault in faults)
            {
                var faultNote = new FaultNote();
                var notes = faultNote.ConvertToFaults(fault.FaultNotes);
                var newFault = new Fault()
                {
                    Id = fault.Id,
                    Town = fault.Town,
                    FacilityId = fault.FacilityId,
                    FacilityName = fault.Facility.Name,
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
                    FaultNotes = notes,
                    Status = fault.Status,
                    IsDeleted = fault.IsDeleted
                };
                faultList.Add(newFault);
            }
            return faultList;
        }

        public Fault ConvertToFault(DataAccess.Tables.Fault fault)
        {
            if(fault == null)
            {
                return new Fault();
            }
            var faultNote = new FaultNote();
            var notes = faultNote.ConvertToFaults(fault.FaultNotes);

            return new Fault(){
                Id = fault.Id,
                Town = fault.Town,
                FacilityId = fault.FacilityId,
                FacilityName = fault.Facility != null ? fault.Facility.Name : null,
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
                FaultNotes = notes,
                Status = fault.Status,
                IsDeleted = fault.IsDeleted
            };
        }

        public DataAccess.Tables.Fault ConvertToFaultTable(Fault fault)
        {
            return new DataAccess.Tables.Fault() {
                Id = fault.Id,
                Town = fault.Town,
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
                Status = fault.Status,
                IsDeleted = fault.IsDeleted
            };
        }
    }
}
