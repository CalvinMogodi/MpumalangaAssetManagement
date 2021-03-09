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
    public class DwellingFacilityRepository : DwellingFacilityInterface, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public DwellingFacilityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddDwellingFacility(DwellingFacility dwellingFacility)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.DwellingFacilities.Add(dwellingFacility);
                db.SaveChanges();
                return dwellingFacility.Id;
            }
        }

        public List<DwellingFacility> GetDwellingFacilities()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.DwellingFacilities.Where(f => f.Status != 0).ToList();
            }
        }

        public List<DwellingFacility> GetDwellingFacilities(string clientCode)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.DwellingFacilities.Where(b => b.ClientCode.ToLower() == clientCode.ToLower()).ToList();
            }
        }

        public DwellingFacility GetDwellingFacilityById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.DwellingFacilities.FirstOrDefault(b => b.Id == id);
            }
        }

        public void UpdateDwellingFacility(DwellingFacility dwellingFacility)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.DwellingFacilities.Update(dwellingFacility);
                db.SaveChanges();
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
