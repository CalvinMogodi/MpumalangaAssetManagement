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
    public class CampRepository : ICampRepository, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public int CreateUamp(Camp camp)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Camps.Add(camp);
                db.SaveChanges();
                return camp.Id;
            }
        }

        public List<Camp> GetCamps(string department)
        {
            using (var db = new DataContext(_connectionString))
            {
                var list = db.Camps.Where(f => f.Status.ToLower() != "deleted" && f.Department.ToLower().Trim() == department.ToLower().Trim())
                    .Include(u => u.User)
                    .ToList();
                return list;
            }
        }

        public CampRepository(string connectionString)
        {
            _connectionString = connectionString;
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
