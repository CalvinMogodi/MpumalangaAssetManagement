using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface LandFacilityInterface
    {
        int AddLandFacility(LandFacility landFacility);
        void UpdateLandFacility(LandFacility landFacility);
        List<LandFacility> GetLandFacilities();
        LandFacility GetLandFacilityById(int id);
        List<LandFacility> GetLandFacilities(string clientCode);
    }
}
