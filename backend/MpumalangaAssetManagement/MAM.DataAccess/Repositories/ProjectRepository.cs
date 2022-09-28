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
    public class ProjectRepository : IProject, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public ProjectRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddProject(Project project)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return project.Id;
            }
        }

        public void UpdateProject(Project project)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Projects.Update(project);
                db.SaveChanges();
            }
        }

        public List<Project> GetProjects()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Projects.ToList();
            }
        }

        public Project GetProjectById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Projects.FirstOrDefault(b => b.Id == id);
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
