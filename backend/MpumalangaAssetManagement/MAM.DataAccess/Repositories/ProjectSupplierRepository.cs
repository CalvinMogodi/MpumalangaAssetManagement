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
    public class ProjectSupplierRepository : IProjectSupplier, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public ProjectSupplierRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddProjectSupplier(ProjectSupplier projectSupplier)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.ProjectSuppliers.Add(projectSupplier);
                db.SaveChanges();
                return projectSupplier.Id;
            }
        }

        public void UpdateProjectSupplier(ProjectSupplier projectSupplier)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.ProjectSuppliers.Update(projectSupplier);
                db.SaveChanges();
            }
        }

        public List<ProjectSupplier> GetProjectSuppliers()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.ProjectSuppliers.ToList();
            }
        }

        public ProjectSupplier GetProjectSupplierById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.ProjectSuppliers.FirstOrDefault(b => b.Id == id);
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
