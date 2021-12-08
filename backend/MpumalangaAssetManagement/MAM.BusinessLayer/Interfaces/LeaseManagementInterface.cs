using MAM.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Interfaces
{
    public interface ILeaseManagementInterface
    {
        List<LeasedProperty> GetLeasedProperties();
    }
}
