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
    public class HiringRegisterRepository: IHiringRegisterRepository,  IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public HiringRegisterRepository(AppSettings settings)
        {
            appSettings = settings;
        }
        public List<HiredProperty> GetHiredProperties()
        {
            HiredProperty hiredProperty = new HiredProperty();
            using (var dataAccess = new DataAccess.Repositories.HiredPropertyRepository(appSettings.ConnectionString)) {
                List<HiredProperty> properties = hiredProperty.ConvertToHiredProperties(dataAccess.GetHiredProperties());
                return properties;
            };  
        }
        public bool UpdateHiredProperty(HiredProperty hiredProperty)
        {
            using (var dataAccess = new DataAccess.Repositories.HiredPropertyRepository(appSettings.ConnectionString))
            {
                dataAccess.UpdateHiredProperty(hiredProperty.ConvertToHiredPropertyTable(hiredProperty));
                return true;
            };
        }

        public bool DeleteHiredProperty(HiredProperty hiredProperty)
        {
            using (var dataAccess = new DataAccess.Repositories.HiredPropertyRepository(appSettings.ConnectionString))
            {
                dataAccess.DeleteHiredProperty(hiredProperty.ConvertToHiredPropertyTable(hiredProperty));
                return true;
            };
        }

        public int AddHiredProperty(HiredProperty hiredProperty)
        {
            using (var dataAccess = new DataAccess.Repositories.HiredPropertyRepository(appSettings.ConnectionString))
            {
                return dataAccess.AddHiredProperty(hiredProperty.ConvertToHiredPropertyTable(hiredProperty));
                
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
