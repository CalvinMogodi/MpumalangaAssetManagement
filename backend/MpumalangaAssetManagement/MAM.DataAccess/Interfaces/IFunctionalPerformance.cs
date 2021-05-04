using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IFunctionalPerformance
    {
        bool AddFunctionalPerformances(List<FunctionalPerformance> programmes);
        List<FunctionalPerformance> GetFunctionalPerformances();
    }
}
