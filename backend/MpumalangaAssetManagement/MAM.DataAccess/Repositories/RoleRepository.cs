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
    public class RoleRepository : RoleInterface, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public RoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddRole(Role role)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Roles.Add(role);
                db.SaveChanges();
            }
        }

        public void UpdateRole(Role role)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Roles.Update(role);
                db.SaveChanges();
            }
        }

        public List<Role> GetRoles()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Roles.ToList();
            }
        }

        public Role GetRoleById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Roles.FirstOrDefault(b => b.Id == id);
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
