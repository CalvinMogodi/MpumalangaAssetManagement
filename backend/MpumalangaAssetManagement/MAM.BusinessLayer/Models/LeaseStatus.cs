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

        public LeaseStatus ConvertLeaseStatus(DataAccess.Tables.LeaseStatus leaseStatus) {
            return new LeaseStatus
            {
                Id = leaseStatus.Id,
                NatureOfLease = leaseStatus.NatureOfLease,
                IDNumberCompanyRegistrationNumber = leaseStatus.IDNumberCompanyRegistrationNumber,
                POBox = leaseStatus.POBox,
                ContactNumber = leaseStatus.ContactNumber,
                CapacityofContactPerson = leaseStatus.CapacityofContactPerson,
                ContactPerson = leaseStatus.ContactPerson,
                PostalCode = leaseStatus.PostalCode,
                LeaseStatusTown = leaseStatus.LeaseStatusTown,
                RentalAmount = leaseStatus.RentalAmount,
                TerminationDate = leaseStatus.TerminationDate,
                StartingDate = leaseStatus.StartingDate,
                OccupationDate = leaseStatus.OccupationDate,
                Escalation = leaseStatus.Escalation,
                Vat = leaseStatus.Vat,
                LeaseNumber = leaseStatus.LeaseNumber,
                OtherCharges = leaseStatus.OtherCharges,
            };
        }

        public DataAccess.Tables.LeaseStatus ConvertLeaseStatus(LeaseStatus leaseStatus)
        {
            return new DataAccess.Tables.LeaseStatus
            {
                Id = leaseStatus.Id,
                NatureOfLease = leaseStatus.NatureOfLease,
                IDNumberCompanyRegistrationNumber = leaseStatus.IDNumberCompanyRegistrationNumber,
                POBox = leaseStatus.POBox,
                ContactNumber = leaseStatus.ContactNumber,
                CapacityofContactPerson = leaseStatus.CapacityofContactPerson,
                ContactPerson = leaseStatus.ContactPerson,
                PostalCode = leaseStatus.PostalCode,
                LeaseStatusTown = leaseStatus.LeaseStatusTown,
                RentalAmount = leaseStatus.RentalAmount,
                TerminationDate = leaseStatus.TerminationDate,
                StartingDate = leaseStatus.StartingDate,
                OccupationDate = leaseStatus.OccupationDate,
                Escalation = leaseStatus.Escalation,
                Vat = leaseStatus.Vat,
                LeaseNumber = leaseStatus.LeaseNumber,
                OtherCharges = leaseStatus.OtherCharges,
            };
        }
    }
}
