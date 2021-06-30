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
    public class PropertyRepository : IPropertyRepository, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public PropertyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddProperty(Property property)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Properties.Add(property);
                db.SaveChanges();
                return property.Id;
            }
        }

        public void UpdateProperty(Property property)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Properties.Update(property);
                db.SaveChanges();
            }
        }

        public void DeleteProperty(Property property)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Properties.Remove(property);
                db.SaveChanges();
            }
        }

        public List<Property> GetProperties(int uampId)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Properties.Where(p => p.UserImmovableAssetManagementPlanId == uampId).ToList();
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
