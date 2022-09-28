using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IFault
    {
        int AddFault(Fault fault);
        void UpdateFault(Fault fault);
        List<Fault> GetFaults();
        Fault GetFaultById(int id);
        Fault GetFaultByReferenceNo(string referenceNo);
    }
}
