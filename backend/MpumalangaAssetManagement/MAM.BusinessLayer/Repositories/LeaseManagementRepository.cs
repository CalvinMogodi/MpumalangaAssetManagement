using MAM.BusinessLayer.Interfaces;
using MAM.BusinessLayer.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.BusinessLayer.Repositories
{
    public class LeaseManagementRepository : ILeaseManagementRepository, IDisposable
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

        public bool DeleteLeasedProperty(LeasedProperty leasedProperty)
        {
            using (var dataAccess = new DataAccess.Repositories.LandUseManagementDetailRepository(appSettings.ConnectionString))
            {
                dataAccess.SetLandUseManagementDetailIncomeLeaseStatus(leasedProperty.LandUseManagementDetail.ConvertLandUseManagementDetail(leasedProperty.LandUseManagementDetail));
                return true;
            };
        }

        public LeasedProperty GetLeasedPropertyDetails(LeasedProperty leasedProperty) {
            using (var dataAccess = new DataAccess.Repositories.LandRepository(appSettings.ConnectionString))
            {
                LandUseManagementDetail landUseManagementDetail = new LandUseManagementDetail();
                LeaseStatus leaseStatus = new LeaseStatus();
                var land = dataAccess.GetLeasedPropertyOnLandById(leasedProperty.LandId);
                leasedProperty.LandUseManagementDetail = landUseManagementDetail.ConvertLandUseManagementDetail(land.LandUseManagementDetail);
                leasedProperty.LeaseStatus = leaseStatus.ConvertLeaseStatus(land.LeaseStatus);
                return leasedProperty;
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
