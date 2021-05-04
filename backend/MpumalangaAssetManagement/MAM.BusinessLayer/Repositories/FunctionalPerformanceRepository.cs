using MAM.BusinessLayer.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.BusinessLayer.Repositories
{
    public class FunctionalPerformanceRepository : IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public FunctionalPerformanceRepository(AppSettings settings)
        {
            appSettings = settings;
        }

        public bool AddFunctionalPerformances(List<FunctionalPerformance> functionalPerformances)
        {
            using (var dataAccess = new DataAccess.Repositories.FunctionalPerformanceRepository(appSettings.ConnectionString))
            {
                try
                {
                    List<MAM.DataAccess.Tables.FunctionalPerformance> tableFunctionalPerformances = new List<DataAccess.Tables.FunctionalPerformance>();

                    functionalPerformances.ForEach((functionalPerformance) =>
                    {
                        tableFunctionalPerformances.Add(functionalPerformance.ConvertToFunctionalPerformanceTable(functionalPerformance));
                    });

                    return dataAccess.AddFunctionalPerformances(tableFunctionalPerformances);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<FunctionalPerformance> GetFunctionalPerformances()
        {
            using (var dataAccess = new DataAccess.Repositories.FunctionalPerformanceRepository(appSettings.ConnectionString))
            {
                FunctionalPerformance functionalPerformance = new FunctionalPerformance();
                var functionalPerformances = dataAccess.GetFunctionalPerformances();
                return functionalPerformance.ConvertToFunctionalPerformances(functionalPerformances);
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
