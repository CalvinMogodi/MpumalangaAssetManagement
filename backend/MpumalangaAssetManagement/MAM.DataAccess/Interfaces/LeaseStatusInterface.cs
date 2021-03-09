using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface LeaseStatusInterface
    {
        int AddLeaseStatus(LeaseStatus leaseStatus);
        void UpdateLeaseStatus(LeaseStatus leaseStatus);
        List<LeaseStatus> GetLeaseStatuses();
        LeaseStatus GetLeaseStatusById(int id);
    }
}
