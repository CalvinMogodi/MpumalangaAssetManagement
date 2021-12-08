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
        public string Type { get; set; }
        public string PropertyCode { get; set; }
        public string FacilityName { get; set; }
        public string NatureofLease { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? TerminationDate { get; set; }

        public List<LeasedProperty> ConvertToLeasedProperties(List<DataAccess.Tables.LeasedProperty> leasedProperties)
        {
            return leasedProperties.Select(conditionAssessment => new LeasedProperty()
            {
                LeaseStatusesId = conditionAssessment.LeaseStatusesId,
                FileReference = conditionAssessment.FileReference,
                Type = conditionAssessment.Type,
                PropertyCode = conditionAssessment.PropertyCode,
                FacilityName = conditionAssessment.FacilityName,
                NatureofLease = conditionAssessment.NatureofLease,
                StartingDate = conditionAssessment.StartingDate,
                TerminationDate = conditionAssessment.TerminationDate,
            }).ToList();
        }
    }
}
