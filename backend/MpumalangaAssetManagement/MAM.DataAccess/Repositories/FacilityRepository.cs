using MAM.DataAccess.Interfaces;
using MAM.DataAccess.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.DataAccess.Repositories
{
    public class FacilityRepository : IFacility, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public FacilityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddFacility(Facility facility)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Facilities.Add(facility);
                db.SaveChanges();
                return facility.Id;
            }
        }

        public void UpdateFacility(Facility facility)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Facilities.Update(facility);
                db.SaveChanges();
            }
        }

        public List<Facility> GetProperties(string userDepartment)
        {
            using (var db = new DataContext(_connectionString))
            {
                 var list = db.Facilities.Where(f => f.Status != "Deleted" && f.Land.LandUseManagementDetail.UserDepartment.Trim().ToLower() == userDepartment.Trim().ToLower())
                    .Include(a => a.Land)
                    .Include(f => f.Land.PropertyDescription)
                   .Include(a => a.Land.GeographicalLocation)
                    .Include(a => a.Land.LandUseManagementDetail)
                    .Include(a => a.Land.LeaseStatus)
                   .Include(a => a.Improvements)
                   .Include(a => a.Finance)
                   .Include(f => f.Finance.Valuation)
                    .Include(f => f.Finance.SecondaryInformationNote)
                    .ToList();
                return list;
            }            
        }

        public List<Facility> GetFacilities()
        {
            using (var db = new DataContext(_connectionString))
            {
                var list = db.Facilities.Where(f => f.Status.ToLower() != "deleted")
                   .Include(a => a.Land)
                   .Include(f => f.Land.PropertyDescription)
                  .Include(a => a.Land.GeographicalLocation)
                   .Include(a => a.Land.LandUseManagementDetail)
                   .Include(a => a.Land.LeaseStatus)
                  .Include(a => a.Improvements)
                  .Include(a => a.Finance)
                  .Include(f => f.Finance.Valuation)
                   .Include(f => f.Finance.SecondaryInformationNote)
                   .ToList();
                return list;
            }
        }

        public Facility GetFacilityById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Facilities.Where(f => f.Status != "Deleted" && f.Id == id)
                    .Include(a => a.Land)
                    .Include(f => f.Land.PropertyDescription)
                   .Include(a => a.Land.GeographicalLocation)
                    .Include(a => a.Land.LandUseManagementDetail)
                    .Include(a => a.Land.LeaseStatus).
                    Include(a => a.Improvements).Include(a => a.Finance).Include(f => f.Finance.Valuation)
                    .Include(f => f.Finance.SecondaryInformationNote)
                    .FirstOrDefault();
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
