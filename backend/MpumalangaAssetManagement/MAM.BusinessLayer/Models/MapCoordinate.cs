using MAM.BusinessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class MapCoordinate
    {
        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string Description { get; set; }

        public int FacilityId { get; set; }

        public FacilityTypes FacilityType { get; set; }
    }
}
