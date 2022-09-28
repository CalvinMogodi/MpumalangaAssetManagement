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
    public class SupplierRepository : ISupplier, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public SupplierRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddSupplier(Supplier supplier)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Suppliers.Update(supplier);
                db.SaveChanges();
            }
        }

        public List<Supplier> GetSuppliers()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Suppliers.ToList();
            }
        }

        public Supplier GetSupplierById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Suppliers.FirstOrDefault(b => b.Id == id);
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
