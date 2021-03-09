using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface FacilityStatementInterface
    {
        void AddFacilityStatement(FacilityStatement facilityStatement);
        void UpdateFacilityStatement(FacilityStatement facilityStatement);
        List<FacilityStatement> GetFacilityStatements();
        FacilityStatement GetFacilityStatementById(int id);
        List<FacilityStatement> GetFacilityStatements(string clientCode);
    }
}
