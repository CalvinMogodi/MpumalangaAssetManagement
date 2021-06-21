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
    public class MtefYearRepository : IMtefYearRepository, IDisposable
    {
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private string _connectionString { get; set; }

        public MtefYearRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddMtefYear(MtefYear mtefYear)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMtefYear(MtefYear mtefYear)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMtefYear(MtefYear municipalUtilityService)
        {
            throw new NotImplementedException();
        }

        public List<MtefYear> GetMtefYears()
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
