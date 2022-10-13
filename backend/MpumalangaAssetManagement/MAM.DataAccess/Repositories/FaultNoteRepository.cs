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
    public class FaultNoteRepository : IFaultNote, IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string _connectionString { get; set; }

        public FaultNoteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddFaultNote(FaultNote note)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.FaultNotes.Add(note);
                db.SaveChanges();
                return note.Id;
            }
        }

        public void UpdateFaultNote(FaultNote note)
        {
            using (var db = new DataContext(_connectionString))
            {
                db.FaultNotes.Update(note);
                db.SaveChanges();
            }
        }

        public List<FaultNote> GetFaultNotesByFaultId(int faultId)
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.FaultNotes.Where(n => n.FaultId == faultId).ToList();
            }
        }
        
        public void DeleteFaultNotesByFaultId(int faultId)
        {
            using (var db = new DataContext(_connectionString))
            {
                var notes = GetFaultNotesByFaultId(faultId);
                db.FaultNotes.RemoveRange(notes);
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
