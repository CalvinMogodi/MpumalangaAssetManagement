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
    public class ProjectRepository: IProjectRepository,  IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public ProjectRepository(AppSettings settings)
        {
            appSettings = settings;
        }
        public List<Project> GetProjects()
        {
            Project Project = new Project();
            using (var dataAccess = new DataAccess.Repositories.ProjectRepository(appSettings.ConnectionString)) {
                List<Project> projects = Project.ConvertToProjects(dataAccess.GetProjects());
                return projects;
            };  
        }
        public Project UpdateProject(Project project)
        {
            using (var dataAccess = new DataAccess.Repositories.ProjectRepository(appSettings.ConnectionString))
            {
                dataAccess.UpdateProject(project.ConvertToProjectTable(project));
                AddUpdateProjectSupplier(project);
                return project;
            };
        }

        public void AddUpdateProjectSupplier(Project project)
        {
            using (var dataAccess = new DataAccess.Repositories.ProjectSupplierRepository(appSettings.ConnectionString))
            {
                foreach (var projectSupplier in project.ProjectSuppliers)
                {
                    if (projectSupplier.Id > 0)
                    {
                        dataAccess.UpdateProjectSupplier(projectSupplier.ConvertToProjectSupplierTable(projectSupplier));
                    }
                    else {
                        dataAccess.AddProjectSupplier(projectSupplier.ConvertToProjectSupplierTable(projectSupplier));
                    }                   
                }
            };
        }

        public bool DeleteProject(Project project)
        {
            using (var dataAccess = new DataAccess.Repositories.ProjectRepository(appSettings.ConnectionString))
            {
                project.IsDeleted = true;
                dataAccess.UpdateProject(project.ConvertToProjectTable(project));
                return true;
            };
        }

        public bool DeleteProjectSupplier(int projectId)
        {
            using (var dataAccess = new DataAccess.Repositories.ProjectSupplierRepository(appSettings.ConnectionString))
            {
                dataAccess.DeleteProjectSupplierById(projectId);
                return true;
            };
        }

        public int AddProject(Project project)
        {
            using (var dataAccess = new DataAccess.Repositories.ProjectRepository(appSettings.ConnectionString))
            {
                return dataAccess.AddProject(project.ConvertToProjectTable(project));
                
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
