using MAM.BusinessLayer.Interfaces;
using MAM.BusinessLayer.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.BusinessLayer.Repositories
{
    public class ConditionAssessmentRepository : IConditionAssessmentRepository, IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public ConditionAssessmentRepository(AppSettings settings)
        {
            appSettings = settings;
        }

        public int AddConditionAssessment(ConditionAssessment conditionAssessment)
        {
            using (var dataAccess = new DataAccess.Repositories.ConditionAssessmentRepository(appSettings.ConnectionString))
            {
                return dataAccess.AddConditionAssessment(conditionAssessment.ConvertConditionAssessment(conditionAssessment));
            }
        }

        public bool DeleteConditionAssessment(int id)
        {
            using (var dataAccess = new DataAccess.Repositories.ConditionAssessmentRepository(appSettings.ConnectionString))
            {
                dataAccess.DeleteConditionAssessment(id);
                return true;
            }
        }

        public List<ConditionAssessment> GetConditionAssessments(int facilityId)
        {
            ConditionAssessment conditionAssessment = new ConditionAssessment();
            using (var dataAccess = new DataAccess.Repositories.ConditionAssessmentRepository(appSettings.ConnectionString))
            {
                return conditionAssessment.ConvertToConditionAssessments(dataAccess.GetConditionAssessments(facilityId));
            }
        }

        public ConditionAssessment GetConditionAssessmentById(int id)
        {
            ConditionAssessment conditionAssessment = new ConditionAssessment();
            using (var dataAccess = new DataAccess.Repositories.ConditionAssessmentRepository(appSettings.ConnectionString))
            {
                return conditionAssessment.ConvertConditionAssessment(dataAccess.GetConditionAssessmentById(id));
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
