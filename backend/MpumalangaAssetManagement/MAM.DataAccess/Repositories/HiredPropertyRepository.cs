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
    public class HiredPropertyRepository : IHiredPropertyRepository, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public HiredPropertyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddHiredProperty(HiredProperty hiredProperty)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.HiredProperties.Add(hiredProperty);
                db.SaveChanges();
                return hiredProperty.Id;
            }
        }

        public void UpdateHiredProperty(HiredProperty hiredProperty)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.HiredProperties.Update(hiredProperty);
                db.SaveChanges();
            }
        }

        public void DeleteHiredProperty(HiredProperty hiredProperty)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.HiredProperties.Remove(hiredProperty);
                db.SaveChanges();
            }
        }

        public List<HiredProperty> GetHiredProperties()
        {
            using (var db = new DataContext(_connectionString))
            {
                var list = db.HiredProperties.Where(s => s.IsDeteted == false).ToList();
                return list;
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
