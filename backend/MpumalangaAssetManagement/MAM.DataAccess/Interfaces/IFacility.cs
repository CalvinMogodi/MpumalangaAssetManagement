using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IFacility
    {
        int AddFacility(Facility facility);
        void UpdateFacility(Facility facility);
        List<Facility> GetFacilities();
        Facility GetFacilityById(int id);
        List<Facility> GetAssetRegisterFacilities();
    }
}
