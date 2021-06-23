using MAM.DataAccess.Interfaces;
using MAM.DataAccess.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int CreateUamp(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.UserImmovableAssetManagementPlans.Add(userImmovableAssetManagementPlan);
                db.SaveChanges();
                return userImmovableAssetManagementPlan.Id;
            }
        }

        public void UpdateUamp(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.UserImmovableAssetManagementPlans.Update(userImmovableAssetManagementPlan);
                db.SaveChanges();
            }
        }

        public void DeleteUamp(UserImmovableAssetManagementPlan userImmovableAssetManagementPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                userImmovableAssetManagementPlan.Status = "Deleted";
                db.UserImmovableAssetManagementPlans.Update(userImmovableAssetManagementPlan);
                db.SaveChanges();
            }
        }

        public List<UserImmovableAssetManagementPlan> GetUamps(string department)
        {
            using (var db = new DataContext(_connectionString))
            {
                var list = db.UserImmovableAssetManagementPlans.Where(f => f.Status.ToLower() != "deleted" && f.Department.ToLower().Trim() == department.ToLower().Trim())
                    .Include(u => u.User)
                    //.Include(a => a.Properties)
                    //.Include(f => f.OperationPlans)
                    //.Include(a => a.AcquisitionPlans)
                    //.Include(a => a.Programmes)
                    //.Include(a => a.MtefBudgetPeriods)
                    //.Include(a => a.SurrenderPlans)
                    //.Include(a => a.StrategicAssessments)
                    .ToList();
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
