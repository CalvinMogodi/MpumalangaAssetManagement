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
        public LandUseManagementDetail LandUseManagementDetail { get; set; }
        public LeaseStatus LeaseStatus { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? TerminationDate { get; set; }

        public List<LeasedProperty> ConvertToLeasedProperties(List<DataAccess.Tables.LeasedProperty> leasedProperties)
        {
            return leasedProperties.Select(conditionAssessment => new LeasedProperty()
            {
                LeaseStatusesId = conditionAssessment.LeaseStatusesId,
                FileReference = conditionAssessment.FileReference,
                District = conditionAssessment.District,
                Type = conditionAssessment.Type,
                PropertyCode = conditionAssessment.PropertyCode,
                FacilityName = conditionAssessment.FacilityName,
                NatureofLease = conditionAssessment.NatureofLease,
                StartingDate = conditionAssessment.StartingDate,
                TerminationDate = conditionAssessment.TerminationDate,
                LandId = conditionAssessment.LandId,
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
