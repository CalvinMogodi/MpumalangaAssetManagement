﻿using MAM.DataAccess.Interfaces;
using MAM.DataAccess.Tables;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.DataAccess.Repositories
{
    public class ImprovementRepository : IImprovement, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public ImprovementRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddImprovement(Improvement improvement)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Improvements.Add(improvement);
                db.SaveChanges();
                return improvement.Id;
            }
        }

        public List<Improvement> GetImprovements()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Improvements.Select(f => f).ToList();
            }
        }

        public List<Improvement> GetImprovementsByFacilityId(int facilityId)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Improvements.Where(b => b.FacilityId == facilityId).ToList();
            }
        }

        public Improvement GetImprovementById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Improvements.FirstOrDefault(b => b.Id == id);
            }
        }

        public void UpdateImprovement(Improvement improvement)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Improvements.Update(improvement);
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
