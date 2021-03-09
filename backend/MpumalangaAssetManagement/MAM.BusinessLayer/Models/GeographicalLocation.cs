using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
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

        public GeographicalLocation ConvertGeographicalLocation(DataAccess.Tables.GeographicalLocation geographicalLocation) {
            return new GeographicalLocation {
                Id = geographicalLocation.Id,
                Province = geographicalLocation.Province,
                Town = geographicalLocation.Town,
                Suburb = geographicalLocation.Suburb,
                StreetName = geographicalLocation.StreetName,
                StreetNumber = geographicalLocation.StreetNumber,
                DistrictMunicipality = geographicalLocation.DistrictMunicipality,
                Region = geographicalLocation.Region,
                LocalAuthority = geographicalLocation.LocalAuthority,
                Latitude = geographicalLocation.Latitude,
                Longitude = geographicalLocation.Longitude,
                MagisterialDistrict = geographicalLocation.MagisterialDistrict
            };
        }

        public DataAccess.Tables.GeographicalLocation ConvertGeographicalLocation(GeographicalLocation geographicalLocation)
        {
            return new DataAccess.Tables.GeographicalLocation
            {
                Id = geographicalLocation.Id,
                Province = geographicalLocation.Province,
                Town = geographicalLocation.Town,
                Suburb = geographicalLocation.Suburb,
                StreetName = geographicalLocation.StreetName,
                StreetNumber = geographicalLocation.StreetNumber,
                DistrictMunicipality = geographicalLocation.DistrictMunicipality,
                Region = geographicalLocation.Region,
                LocalAuthority = geographicalLocation.LocalAuthority,
                Latitude = geographicalLocation.Latitude,
                Longitude = geographicalLocation.Longitude,
                MagisterialDistrict = geographicalLocation.MagisterialDistrict
            };
        }
    }
}
