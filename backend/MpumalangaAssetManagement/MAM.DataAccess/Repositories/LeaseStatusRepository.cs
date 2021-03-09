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
    public class LeaseStatusRepository : LeaseStatusInterface, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
    // Instantiate a SafeHandle instance.
    SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

    private string _connectionString { get; set; }

    public LeaseStatusRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public int AddLeaseStatus(LeaseStatus leaseStatus)
    {
        using (var db = new DataContext(_connectionString))
        {
            db.LeaseStatuses.Add(leaseStatus);
            db.SaveChanges();
            return leaseStatus.Id;
        }
    }

    public LeaseStatus GetLeaseStatusById(int id)
    {
        using (var db = new DataContext(_connectionString))
        {
            return db.LeaseStatuses.FirstOrDefault(b => b.Id == id);
        }
    }

    public List<LeaseStatus> GetLeaseStatuses()
    {
        using (var db = new DataContext(_connectionString))
        {
            return db.LeaseStatuses.Select(l => l).ToList();
        }
    }

    public void UpdateLeaseStatus(LeaseStatus leaseStatus)
    {
        using (var db = new DataContext(_connectionString))
        {
            db.LeaseStatuses.Update(leaseStatus);
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
