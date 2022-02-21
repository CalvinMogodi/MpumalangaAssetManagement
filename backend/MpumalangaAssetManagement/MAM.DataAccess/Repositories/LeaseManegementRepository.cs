using MAM.DataAccess.Interfaces;
using MAM.DataAccess.Tables;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;

namespace MAM.DataAccess.Repositories
{
    public class LeaseManegementRepository : ILeaseManegement, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public LeaseManegementRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<LeasedProperty> GetLeasedProperties()
        {
            using (var db = new DataContext(_connectionString))
            {
                var leasedProperties = (from ls in db.LeaseStatuses
                                  join l in db.Lands on ls.Id equals l.LeaseStatusId
                                  join f in db.Facilities on l.Id equals f.LandId
                                  join lumd in db.LandUseManagementDetails on l.LandUseManagementDetailId equals lumd.Id
                                  join gl in db.GeographicalLocations on l.GeographicalLocationId equals gl.Id
                                  where lumd.IncomeLeaseStatus == "Yes"
                                  select new LeasedProperty
                                  {
                                      LeaseStatusesId = ls.Id,
                                      FileReference = f.FileReference,
                                      District = gl.Region,
                                      Type = f.Type,
                                      PropertyCode = f.ClientCode,
                                      FacilityName = f.Name,
                                      NatureofLease = ls.NatureOfLease,
                                      StartingDate = ls.StartingDate,
                                      TerminationDate = ls.TerminationDate,
                                      LandId = l.Id
                                  }).ToList();

                return leasedProperties;
            }
        }       

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
    }
}
