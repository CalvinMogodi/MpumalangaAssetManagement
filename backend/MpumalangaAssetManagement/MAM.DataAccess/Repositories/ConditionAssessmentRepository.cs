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
    public class ConditionAssessmentRepository : IConditionAssessment, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public ConditionAssessmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddConditionAssessment(ConditionAssessment conditionAssessment)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.ConditionAssessments.Add(conditionAssessment);
                db.SaveChanges();
                return conditionAssessment.Id;
            }
        }

        public void DeleteConditionAssessment(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                ConditionAssessment conditionAssessment = db.ConditionAssessments.FirstOrDefault(b => b.Id == id); 
                db.ConditionAssessments.Remove(conditionAssessment);
                db.SaveChanges();
            }
        }

        public ConditionAssessment GetConditionAssessmentById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.ConditionAssessments.FirstOrDefault(b => b.Id == id);
            }
        }

        public List<ConditionAssessment> GetConditionAssessments(int facilityId)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.ConditionAssessments.Where(b => b.FacilityId == facilityId).Include(a => a.User).ToList();
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
