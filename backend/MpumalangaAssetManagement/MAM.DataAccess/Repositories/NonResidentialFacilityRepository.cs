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
    public class NonResidentialFacilityRepository : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public NonResidentialFacilityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddNonResidentialFacilities(NonResidentialFacility nonResidentialFacility)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.NonResidentialFacilities.Add(nonResidentialFacility);
                db.SaveChanges();
                return nonResidentialFacility.Id;
            }
        }

        public void UpdateNonResidentialFacilities(NonResidentialFacility nonResidentialFacility)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.NonResidentialFacilities.Update(nonResidentialFacility);
                db.SaveChanges();
            }
        }

        public List<NonResidentialFacility> GetNonResidentialFacilities()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.NonResidentialFacilities.Where(f => f.Status != 0).ToList();
            }
        }

        public NonResidentialFacility GetNonResidentialFacilityById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.NonResidentialFacilities.FirstOrDefault(b => b.Id == id);
            }
        }

        public List<NonResidentialFacility> GetNonResidentialFacilities(string clientCode)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.NonResidentialFacilities.Where(b => b.ClientCode.ToLower() == clientCode.ToLower()).ToList();
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
