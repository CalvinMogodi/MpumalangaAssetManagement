using MAM.BusinessLayer.Interfaces;
using MAM.BusinessLayer.Model;
using MAM.BusinessLayer.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.BusinessLayer.Repositories
{
    public class FaultRepository: IFaultRepository,  IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public FaultRepository(AppSettings settings)
        {
            appSettings = settings;
        }
        public List<Fault> GetFaults()
        {
            Fault Fault = new Fault();
            using (var dataAccess = new DataAccess.Repositories.FaultRepository(appSettings.ConnectionString)) {
                List<Fault> properties = Fault.ConvertToFaults(dataAccess.GetFaults());
                return properties;
            };  
        }

        public Fault GetFaultByReferenceNo(string referenceNo)
        {
            Fault Fault = new Fault();
            using (var dataAccess = new DataAccess.Repositories.FaultRepository(appSettings.ConnectionString))
            {
                Fault fault = Fault.ConvertToFault(dataAccess.GetFaultByReferenceNo(referenceNo));
                return fault;
            };
        }

        public bool UpdateFault(Fault fault)
        {
            using (var dataAccess = new DataAccess.Repositories.FaultRepository(appSettings.ConnectionString))
            {
                dataAccess.UpdateFault(fault.ConvertToFaultTable(fault));
                return true;
            };
        }

        public bool DeleteFault(Fault fault)
        {
            using (var dataAccess = new DataAccess.Repositories.FaultRepository(appSettings.ConnectionString))
            {
                dataAccess.UpdateFault(fault.ConvertToFaultTable(fault));
                return true;
            };
        }

        public int AddFault(Fault fault)
        {
            using (var dataAccess = new DataAccess.Repositories.FaultRepository(appSettings.ConnectionString))
            {
                return dataAccess.AddFault(fault.ConvertToFaultTable(fault));
                
            };
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
