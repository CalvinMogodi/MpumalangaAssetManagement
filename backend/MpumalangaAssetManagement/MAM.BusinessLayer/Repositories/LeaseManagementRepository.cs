﻿using MAM.BusinessLayer.Interfaces;
using MAM.BusinessLayer.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.BusinessLayer.Repositories
{
    public class LeaseManagementRepository : ILeaseManagementInterface, IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public LeaseManagementRepository(AppSettings settings)
        {
            appSettings = settings;
        }

        public List<LeasedProperty> GetLeasedProperties()
        {
            LeasedProperty leasedProperty = new LeasedProperty();
            using (var dataAccess = new DataAccess.Repositories.LeaseManegementRepository(appSettings.ConnectionString))
            {
                return leasedProperty.ConvertToLeasedProperties(dataAccess.GetLeasedProperties());
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
