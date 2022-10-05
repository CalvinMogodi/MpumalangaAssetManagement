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
    public class FaultRepository : IFault, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public FaultRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddFault(Fault fault)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Faults.Add(fault);
                db.SaveChanges();
                return fault.Id;
            }
        }

        public void UpdateFault(Fault fault)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Faults.Update(fault);
                db.SaveChanges();
            }
        }

        public List<Fault> GetFaults()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Faults.Where(f => f.IsDeleted == false)
                    .Include(a => a.Facility).ToList();
            }
        }

        public Fault GetFaultById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Faults.FirstOrDefault(b => b.Id == id);
            }
        }

        public Fault GetFaultByReferenceNo(string referenceNo)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Faults.FirstOrDefault(b => b.ReferenceNo == referenceNo);
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
