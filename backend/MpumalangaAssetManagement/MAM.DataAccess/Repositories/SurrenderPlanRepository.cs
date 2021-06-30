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
    public class SurrenderPlanRepository : ISurrenderPlanRepository, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public SurrenderPlanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int AddSurrenderPlan(SurrenderPlan surrenderPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.SurrenderPlans.Add(surrenderPlan);
                db.SaveChanges();
                return surrenderPlan.Id;
            }
        }

        public void UpdateSurrenderPlan(SurrenderPlan surrenderPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.SurrenderPlans.Update(surrenderPlan);
                db.SaveChanges();
            }
        }

        public void DeleteSurrenderPlan(SurrenderPlan surrenderPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.SurrenderPlans.Remove(surrenderPlan);
                db.SaveChanges();
            }
        }

        public List<SurrenderPlan> GetSurrenderPlans(int uampId)
        {
            using (var db = new DataContext(_connectionString))
            {
                var list = db.SurrenderPlans.Where(s => s.UserImmovableAssetManagementPlanId == uampId).ToList();
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
