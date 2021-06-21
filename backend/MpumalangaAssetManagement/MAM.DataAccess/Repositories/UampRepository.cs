using MAM.DataAccess.Interfaces;
using MAM.DataAccess.Tables;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.DataAccess.Repositories
{
    public class UampRepository : IUampRepository, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public UampRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddUamp(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUamp(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUamp(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan)
        {
            throw new NotImplementedException();
        }

        public List<UserImmovableAssetManagementPlan> GetUamps()
        {
            throw new NotImplementedException();
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
