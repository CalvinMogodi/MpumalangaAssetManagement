using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Land
    {
        public int Id { get; set; }
        public string DeedOffice { get; set; }
        public string AssetClass { get; set; }
        public string AssetType { get; set; }
        public GeographicalLocation GeographicalLocation { get; set; }
        public PropertyDescription PropertyDescription { get; set; }
        public LandUseManagementDetail LandUseManagementDetail { get; set; }
        public LeaseStatus LeaseStatus { get; set; }
    }
}
