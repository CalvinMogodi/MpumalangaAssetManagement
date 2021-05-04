
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
    public class ProgrammeRepository : IProgramme, IDisposable
    {
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private string _connectionString { get; set; }

        public ProgrammeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddProgrammes(List<Programme> programmes)
        {
            using (var db = new DataContext(_connectionString))
            {
                programmes.ForEach((programme) =>
                {
                    if (programme.Id == 0)
                        db.Programme.Add(programme);
                    else
                        db.Programme.Update(programme);

                    db.SaveChanges();
                });
            }
        }



        public List<Programme> GetProgrammes()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Programme.Where(p => p.UserId == 1033).ToList();
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
