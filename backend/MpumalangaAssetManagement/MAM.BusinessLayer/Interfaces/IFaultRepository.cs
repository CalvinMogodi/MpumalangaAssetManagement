using MAM.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Interfaces
{
    public interface IFaultRepository
    {
        List<Fault> GetFaults();
        bool UpdateFault(Fault Fault);
        bool DeleteFault(Fault Fault);
        int AddFault(Fault Fault);
        Fault GetFaultByReferenceNo(string referenceNo);
    }
}
