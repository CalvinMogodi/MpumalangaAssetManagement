using MAM.DataAccess.Interfaces;
using MAM.DataAccess.Tables;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace MAM.DataAccess.Repositories
{
    public class FacilityStatementRepository : FacilityStatementInterface, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public FacilityStatementRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddFacilityStatement(FacilityStatement facilityStatement)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.FacilityStatements.Add(facilityStatement);
                db.SaveChanges();
            }
        }

        public void UpdateFacilityStatement(FacilityStatement facilityStatement)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.FacilityStatements.Update(facilityStatement);
                db.SaveChanges();
            }
        }

        public List<FacilityStatement> GetFacilityStatements()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.FacilityStatements.Select(f => new FacilityStatement() {
                    Id = f.Id,
                    OpeningBalance = f.OpeningBalance != "" ? f.OpeningBalance.Replace(" ", "")  : "0",
                    ValueAdjustment = f.ValueAdjustment != "" ? f.ValueAdjustment.Replace(" ", "") : "0",
                    PpeaIN = f.PpeaIN != "" ? f.PpeaIN.Replace(" ", "") : "0",
                    PpeaOut = f.PpeaOut != "" ? f.PpeaOut.Replace(" ", "") : "0",
                    Disposal = f.Disposal != "" ? f.Disposal.Replace(" ", "") : "0",
                    Additions = f.Additions != "" ? f.Additions.Replace(" ", "") : "0",
                    Year = f.Year,
                    ClosingBalance = f.ClosingBalance != "" ? f.ClosingBalance.Replace(" ", "") : "0",
                    ClientCode = f.ClientCode,
                    FacilityType = f.FacilityType
                }).ToList();
            }
        }

        public FacilityStatement GetFacilityStatementById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.FacilityStatements.FirstOrDefault(b => b.Id == id);
            }
        }

        public List<FacilityStatement> GetFacilityStatements(string clientCode)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.FacilityStatements.Where(b => b.ClientCode.ToLower() == clientCode.ToLower()).ToList();
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
