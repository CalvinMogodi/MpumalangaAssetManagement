using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
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
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public LandUseManagementDetail LandUseManagementDetail { get; set; }
        public LeaseStatus LeaseStatus { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? TerminationDate { get; set; }

        public List<LeasedProperty> ConvertToLeasedProperties(List<DataAccess.Tables.LeasedProperty> leasedProperties)
        {
            return leasedProperties.Select(leasedProperty => new LeasedProperty()
            {
                LeaseStatusesId = leasedProperty.LeaseStatusesId,
                FileReference = leasedProperty.FileReference,
                District = leasedProperty.District,
                Type = leasedProperty.Type,
                PropertyCode = leasedProperty.PropertyCode,
                FacilityName = leasedProperty.FacilityName,
                NatureofLease = leasedProperty.NatureofLease,
                StartingDate = leasedProperty.StartingDate,
                TerminationDate = leasedProperty.TerminationDate,
                Latitude = leasedProperty.Latitude,
                Longitude = leasedProperty.Longitude,
                LandId = leasedProperty.LandId,
            }).ToList();
        }

        public DataAccess.Tables.LeasedProperty ConvertToLeasedPropertyTable(LeasedProperty leasedProperty)
        {
            return new DataAccess.Tables.LeasedProperty()
            {
                LeaseStatusesId = leasedProperty.LeaseStatusesId,
                FileReference = leasedProperty.FileReference,
                District = leasedProperty.District,
                Type = leasedProperty.Type,
                PropertyCode = leasedProperty.PropertyCode,
                FacilityName = leasedProperty.FacilityName,
                NatureofLease = leasedProperty.NatureofLease,
                StartingDate = leasedProperty.StartingDate,
                TerminationDate = leasedProperty.TerminationDate,
                LandId = leasedProperty.LandId,
            };
        }
    }
}
