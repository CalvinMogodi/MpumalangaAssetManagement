using MAM.BusinessLayer.Interfaces;
using MAM.BusinessLayer.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.BusinessLayer.Repositories
{
    public class SupplierRepository : ISupplierRepository, IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public SupplierRepository(AppSettings settings)
        {
            appSettings = settings;
        }
        public List<Supplier> AddSuppliers(List<Supplier> suppliers)
        {
            using (var dataAccess = new DataAccess.Repositories.SupplierRepository(appSettings.ConnectionString))
            {
                foreach (var supplier in suppliers)
                {
                    supplier.Id = dataAccess.AddSupplier(supplier.ConvertToSupplierTable(supplier));
                }
                
                return suppliers;
            };
        }

        public List<Supplier> GetSuppliers()
        {
            using (var dataAccess = new DataAccess.Repositories.SupplierRepository(appSettings.ConnectionString))
            {
                Supplier supplier = new Supplier();
                return supplier.ConvertToSupplier(dataAccess.GetSuppliers());
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
