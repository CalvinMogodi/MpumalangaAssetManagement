using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class GeographicalLocation
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public string Town { get; set; }
        public string Suburb { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string DistrictMunicipality { get; set; }
        public string Region { get; set; }
        public string LocalAuthority { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MagisterialDistrict { get; set; }
    }
}
