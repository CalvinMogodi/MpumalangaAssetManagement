using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface NonResidentialFacilityInterface
    {
        int AddNonResidentialFacilities(NonResidentialFacility nonResidentialFacility);
        void UpdateNonResidentialFacilities(NonResidentialFacility nonResidentialFacility);
        List<NonResidentialFacility> GetNonResidentialFacilities();
        NonResidentialFacility GetNonResidentialFacilityById(int id);
        List<NonResidentialFacility> GetNonResidentialFacilities(string clientCode);
    }
}
