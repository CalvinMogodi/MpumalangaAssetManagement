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
    public class FinanceRepository : IFinance , IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public FinanceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddFinance(Finance finance)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Finances.Add(finance);
                db.SaveChanges();
                return finance.Id;
            }
        }

        public void UpdateFinance(Finance finance)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Finances.Update(finance);
                db.SaveChanges();
            }
        }

        public List<Finance> GetFinances()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Finances.Select(f => f).ToList();
            }
        }

        public Finance GetFinanceById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Finances.FirstOrDefault(b => b.Id == id);
            }
        }

        public int AddSecondaryInformationNote(SecondaryInformationNote secondaryInformationNote)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.SecondaryInformationNotes.Add(secondaryInformationNote);
                db.SaveChanges();
                return secondaryInformationNote.Id;
            }
        }

        public void UpdateSecondaryInformationNote(SecondaryInformationNote secondaryInformationNote)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.SecondaryInformationNotes.Update(secondaryInformationNote);
                db.SaveChanges();
            }
        }

        public List<SecondaryInformationNote> GetSecondaryInformationNotes()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.SecondaryInformationNotes.Select(f => f).ToList();
            }
        }

        public SecondaryInformationNote GetSecondaryInformationNoteById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.SecondaryInformationNotes.FirstOrDefault(b => b.Id == id);
            }
        }

        public int AddValuation(Valuation valuation)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Valuations.Add(valuation);
                db.SaveChanges();
                return valuation.Id;
            }
        }

        public void UpdateValuation(Valuation valuation)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.Valuations.Update(valuation);
                db.SaveChanges();
            }
        }

        public List<Valuation> GetValuations()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Valuations.Select(f => f).ToList();
            }
        }

        public Valuation GetValuationById(int id)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Valuations.FirstOrDefault(b => b.Id == id);
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
