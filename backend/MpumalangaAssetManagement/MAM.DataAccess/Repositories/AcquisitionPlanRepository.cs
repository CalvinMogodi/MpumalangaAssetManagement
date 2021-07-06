﻿using MAM.DataAccess.Interfaces;
using MAM.DataAccess.Tables;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.DataAccess.Repositories
{
    public class AcquisitionPlanRepository : IAcquisitionPlanRepository, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public AcquisitionPlanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddAcquisitionPlan(AcquisitionPlan acquisitionPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.AcquisitionPlans.Add(acquisitionPlan);
                db.SaveChanges();
                return acquisitionPlan.Id;
            }
        }

        public void UpdateAcquisitionPlan(AcquisitionPlan acquisitionPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.AcquisitionPlans.Update(acquisitionPlan);
                db.SaveChanges();
            }
        }

        public void DeleteAcquisitionPlan(AcquisitionPlan acquisitionPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.AcquisitionPlans.Remove(acquisitionPlan);
                db.SaveChanges();
            }
        }

        public List<AcquisitionPlan> GetAcquisitionPlans(int uampId)
        {
            using (var db = new DataContext(_connectionString))
            {
                var list = db.AcquisitionPlans.Where(s => s.UserImmovableAssetManagementPlanId == uampId).ToList();
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
