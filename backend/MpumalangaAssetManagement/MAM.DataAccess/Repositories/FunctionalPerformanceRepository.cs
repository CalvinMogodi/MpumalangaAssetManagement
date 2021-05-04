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
    public class FunctionalPerformanceRepository : IFunctionalPerformance, IDisposable
    {
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private string _connectionString { get; set; }

        public FunctionalPerformanceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool AddFunctionalPerformances(List<FunctionalPerformance> functionalPerformances)
        {
            try
            {
                using (var db = new DataContext(_connectionString))
                {
                    functionalPerformances.ForEach((functionalPerformance) =>
                    {
                        if (functionalPerformance.Id == 0)
                            db.FunctionalPerformance.Add(functionalPerformance);
                        else
                            db.FunctionalPerformance.Update(functionalPerformance);

                        db.SaveChanges();
                    });

                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<FunctionalPerformance> GetFunctionalPerformances()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.FunctionalPerformance.Where(p => p.UserId == 1033).ToList();
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
