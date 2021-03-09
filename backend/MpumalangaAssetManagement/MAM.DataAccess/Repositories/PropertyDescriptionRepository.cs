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
    public class PropertyDescriptionRepository : PropertyDescriptionInterface, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public PropertyDescriptionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddPropertyDescription(PropertyDescription propertyDescription)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.PropertyDescriptions.Add(propertyDescription);
                db.SaveChanges();
                return propertyDescription.Id;
            }
        }

        public List<PropertyDescription> GetPropertyDescriptions()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.PropertyDescriptions.Select(f => f).ToList();
            }
        }

        public PropertyDescription GetPropertyDescriptionById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.PropertyDescriptions.FirstOrDefault(b => b.Id == id);
            }
        }

        public void UpdatePropertyDescription(PropertyDescription propertyDescription)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.PropertyDescriptions.Update(propertyDescription);
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
