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
    public class ProgrammeRepository : IProgrammeRepository, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public ProgrammeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int AddProgramme(Programme programme)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Programmes.Add(programme);
                db.SaveChanges();
                return programme.Id;
            }
        }

        public void DeleteProgramme(Programme programme)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Programmes.Remove(programme);
                db.SaveChanges();
            }
        }

        public List<Programme> GetProgrammes(int uampId)
        {
            using(var db = new DataContext(_connectionString))
            {
                return db.Programmes.Where(p => p.UserImmovableAssetManagementPlanId == uampId).ToList();
            }
        }

        public void UpdateProgramme(Programme programme)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Programmes.Update(programme);
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
