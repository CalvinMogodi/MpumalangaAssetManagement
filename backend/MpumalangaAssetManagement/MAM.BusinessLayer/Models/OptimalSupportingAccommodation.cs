using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class OptimalSupportingAccommodation
    {
        public int Id { get; set; }
        public string Mission { get; set; }
        public string SupportingAccommodation { get; set; }

        public DataAccess.Tables.OptimalSupportingAccommodation ConvertToOptimalSupportingAccommodationTable(OptimalSupportingAccommodation osa) {
            return new DataAccess.Tables.OptimalSupportingAccommodation() { 
                Id = osa.Id,
                Mission = osa.Mission,
                SupportingAccommodation = osa.SupportingAccommodation,
            };
        }

        public OptimalSupportingAccommodation ConvertToOptimalSupportingAccommodation(DataAccess.Tables.OptimalSupportingAccommodation osa)
        {
            return new OptimalSupportingAccommodation()
            {
                Id = osa.Id,
                Mission = osa.Mission,
                SupportingAccommodation = osa.SupportingAccommodation,
            };
        }
    }
}
