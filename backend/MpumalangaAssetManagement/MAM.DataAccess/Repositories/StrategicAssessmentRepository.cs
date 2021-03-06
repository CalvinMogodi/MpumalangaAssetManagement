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
    public class StrategicAssessmentRepository : IStrategicAssessmentRepository, IDisposable
    {
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private string _connectionString { get; set; }

        public StrategicAssessmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<StrategicAssessment> GetStrategicAssessments(int uampId)
        {
            using (var db = new DataContext(_connectionString))
            {
                var list = db.StrategicAssessments.Where(s => s.UserImmovableAssetManagementPlanId == uampId).ToList();
                return list;
            }
        }

        public int AddStrategicAssessment(StrategicAssessment strategicAssessments)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.StrategicAssessments.Add(strategicAssessments);
                db.SaveChanges();
                return strategicAssessments.Id;
            }
        }

        public void UpdateStrategicAssessment(StrategicAssessment strategicAssessment)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.StrategicAssessments.Update(strategicAssessment);
                db.SaveChanges();
            }
        }

        public void DeleteStrategicAssessment(StrategicAssessment strategicAssessments)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.StrategicAssessments.Remove(strategicAssessments);
                db.SaveChanges();
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
