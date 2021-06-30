
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
    public class OperationPlanRepository : IOperationPlanRepository, IDisposable
    {
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private string _connectionString { get; set; }

        public OperationPlanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddOperationPlan(OperationPlan operationPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.OperationPlans.Add(operationPlan);
                db.SaveChanges();
                return operationPlan.Id;
            }
        }

        public void UpdateOperationPlan(OperationPlan operationPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.OperationPlans.Update(operationPlan);
                db.SaveChanges();
            }
        }

        public void DeleteOperationPlan(OperationPlan operationPlan)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.OperationPlans.Remove(operationPlan);
                db.SaveChanges();
            }
        }

        public List<OperationPlan> GetOperationPlans(int uampId)
        {
            using (var db = new DataContext(_connectionString))
            {
                var list = db.OperationPlans.Where(s => s.UserImmovableAssetManagementPlanId == uampId).ToList();
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
