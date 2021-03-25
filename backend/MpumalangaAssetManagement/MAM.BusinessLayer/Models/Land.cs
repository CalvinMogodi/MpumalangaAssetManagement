using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Land
    {
        public int Id { get; set; }
        public string DeedsOffice { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public int? GeographicalLocationId { get; set; }
        public int? PropertyDescriptionId { get; set; }
        public int? LandUseManagementDetailId { get; set; }
        public int? LeaseStatusId { get; set; }
        public GeographicalLocation GeographicalLocation { get; set; }
        public PropertyDescription PropertyDescription { get; set; }
        public LandUseManagementDetail LandUseManagementDetail { get; set; }
        public LeaseStatus LeaseStatus { get; set; }

        public Land ConvertLand(DataAccess.Tables.Land land) {
            return new Land {
                Id = land.Id,
                DeedsOffice = land.DeedsOffice,
                Class = land.Class,
                Type = land.Type,
                GeographicalLocationId = land.GeographicalLocationId,
                PropertyDescriptionId = land.PropertyDescriptionId,
                LandUseManagementDetailId = land.LandUseManagementDetailId,
                LeaseStatusId = land.LeaseStatusId,
            };
        }

        public DataAccess.Tables.Land ConvertLand(Land land)
        {
            return new DataAccess.Tables.Land
            {
                Id = land.Id,
                DeedsOffice = land.DeedsOffice,
                Class = land.Class,
                Type = land.Type,
                GeographicalLocationId = land.GeographicalLocationId,
                PropertyDescriptionId = land.PropertyDescriptionId,
                LandUseManagementDetailId = land.LandUseManagementDetailId,
                LeaseStatusId = land.LeaseStatusId,
            };
        }
    }
}
