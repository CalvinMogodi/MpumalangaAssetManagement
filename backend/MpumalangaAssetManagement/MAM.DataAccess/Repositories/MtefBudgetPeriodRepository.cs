using MAM.DataAccess.Interfaces;
using MAM.DataAccess.Tables;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace MAM.DataAccess.Repositories
{
    public class MtefBudgetPeriodRepository : IMtefBudgetPeriodRepository, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public MtefBudgetPeriodRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddMtefBudgetPeriod(MtefBudgetPeriod mtefBudgetPeriod)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.MtefBudgetPeriods.Add(mtefBudgetPeriod);
                db.SaveChanges();
                return mtefBudgetPeriod.Id;
            }
        }

        public void DeleteMtefBudgetPeriod(MtefBudgetPeriod mtefBudgetPeriod)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.MtefBudgetPeriods.Remove(mtefBudgetPeriod);
                db.SaveChanges();
            }
        }

        public void UpdateMtefBudgetPeriod(MtefBudgetPeriod mtefBudgetPeriod)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.MtefBudgetPeriods.Update(mtefBudgetPeriod);
                db.SaveChanges();
            }
        }

        public List<MtefBudgetPeriod> GetMtefBudgetPeriods(int uampId)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.MtefBudgetPeriods.Where(m => m.UserImmovableAssetManagementPlanId == uampId).ToList();
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
