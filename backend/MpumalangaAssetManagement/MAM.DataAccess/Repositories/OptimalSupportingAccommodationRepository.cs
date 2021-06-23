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
    public class OptimalSupportingAccommodationRepository : IOptimalSupportingAccommodationRepository, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public OptimalSupportingAccommodationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int AddOptimalSupportingAccommodation(OptimalSupportingAccommodation optimalSupportingAccommodation)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.OptimalSupportingAccommodations.Add(optimalSupportingAccommodation);
                db.SaveChanges();
                return optimalSupportingAccommodation.Id;
            }
        }

        public void DeleteOptimalSupportingAccommodation(OptimalSupportingAccommodation optimalSupportingAccommodation)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.OptimalSupportingAccommodations.Remove(optimalSupportingAccommodation);
                db.SaveChanges();
            }
        }

        public OptimalSupportingAccommodation GetOptimalSupportingAccommodation(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.OptimalSupportingAccommodations.Find(id);
            }
        }

        public void UpdateOptimalSupportingAccommodation(OptimalSupportingAccommodation optimalSupportingAccommodation)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.OptimalSupportingAccommodations.Update(optimalSupportingAccommodation);
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
