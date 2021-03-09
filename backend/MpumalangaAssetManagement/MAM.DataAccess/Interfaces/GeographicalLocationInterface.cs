using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface GeographicalLocationInterface
    {
        int AddGeographicalLocation(GeographicalLocation geographicalLocation);
        void UpdateGeographicalLocation(GeographicalLocation geographicalLocation);
        List<GeographicalLocation> GetGeographicalLocations();
        GeographicalLocation GetGeographicalLocationById(int id);
    }
}
