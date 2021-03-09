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
    public class LandRepository : LandInterface, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public LandRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddLand(Land land)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Lands.Add(land);
                db.SaveChanges();
                return land.Id;
            }
        }

        public Land GetLandById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Lands.FirstOrDefault(b => b.Id == id);
            }
        }

        public List<Land> GetLands()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Lands.Select(l => l).ToList();
            }
        }

        public void UpdateLand(Land land)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Lands.Update(land);
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
