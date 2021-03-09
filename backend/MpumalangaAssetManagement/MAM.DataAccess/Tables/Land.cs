using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class Land
    {  
        public int Id { get; set; }
        public string DeedOffice { get; set; }
        public string AssetClass { get; set; }
        public string AssetType { get; set; }
        public int GeographicalLocationId { get; set; }
        public int PropertyDescriptionId { get; set; }
        public int LandUseManagementDetailId { get; set; }
        public int LeaseStatusId { get; set; }
        public GeographicalLocation GeographicalLocation { get; set; }
        public PropertyDescription PropertyDescription { get; set; }
        public LandUseManagementDetail LandUseManagementDetail { get; set; }
        public LeaseStatus LeaseStatus { get; set; }
    }
}
