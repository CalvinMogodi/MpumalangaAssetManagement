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

        public List<StrategicAssessment> GetStrategicAssessments()
        {
            throw new NotImplementedException();
        }

        public int AddStrategicAssessment(StrategicAssessment StrategicAssessments)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStrategicAssessment(StrategicAssessment StrategicAssessments)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStrategicAssessment(StrategicAssessment StrategicAssessments)
        {
            throw new NotImplementedException();
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
