using MAM.DataAccess.Interfaces;
using MAM.DataAccess.Tables;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.DataAccess.Repositories
{
    public class LandFacilityRepository : LandFacilityInterface, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public LandFacilityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }        

        public int AddLandFacility(LandFacility landFacility)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.LandFacilities.Add(landFacility);
                db.SaveChanges();
                return landFacility.Id;
            }
        }

        public void UpdateLandFacility(LandFacility landFacility)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.LandFacilities.Update(landFacility);
                db.SaveChanges();
            }
        }

        public List<LandFacility> GetLandFacilities()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.LandFacilities.Where(f => f.Status != 0).ToList();
            }
        }

        public LandFacility GetLandFacilityById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.LandFacilities.FirstOrDefault(b => b.Id == id);
            }
        }

        public List<LandFacility> GetLandFacilities(string clientCode)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.LandFacilities.Where(b => b.ClientCode.ToLower() == clientCode.ToLower()).ToList();
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
