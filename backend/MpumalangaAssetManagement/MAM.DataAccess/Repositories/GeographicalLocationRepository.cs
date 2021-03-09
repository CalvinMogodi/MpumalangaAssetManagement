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
    public class GeographicalLocationRepository : GeographicalLocationInterface, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public GeographicalLocationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddGeographicalLocation(GeographicalLocation geographicalLocation)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.GeographicalLocations.Add(geographicalLocation);
                db.SaveChanges();
                return geographicalLocation.Id;
            }
        }

        public void UpdateGeographicalLocation(GeographicalLocation geographicalLocation)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.GeographicalLocations.Update(geographicalLocation);
                db.SaveChanges();
            }
        }

        public List<GeographicalLocation> GetGeographicalLocations()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.GeographicalLocations.Select(f => f).ToList();
            }
        }

        public GeographicalLocation GetGeographicalLocationById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.GeographicalLocations.FirstOrDefault(b => b.Id == id);
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
