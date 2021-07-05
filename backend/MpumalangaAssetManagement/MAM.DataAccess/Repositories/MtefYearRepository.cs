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
            using (var db = new DataContext(_connectionString))
            {
                db.MtefYears.Add(mtefYear);
                db.SaveChanges();
                return mtefYear.Id;
            }
        }

        public void UpdateMtefYear(MtefYear mtefYear)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.MtefYears.Update(mtefYear);
                db.SaveChanges();
            }
        }

        public void DeleteMtefYear(MtefYear mtefYear)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.MtefYears.Remove(mtefYear);
                db.SaveChanges();
            }
        }

        public List<MtefYear> GetMtefYears(int mtefBudgetPeriodId)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.MtefYears.Where(m => m.MtefBudgetPeriodId == mtefBudgetPeriodId).ToList();
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
