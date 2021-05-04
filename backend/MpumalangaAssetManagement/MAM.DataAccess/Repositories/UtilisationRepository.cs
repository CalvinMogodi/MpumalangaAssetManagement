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
    public class UtilisationRepository : IUtilisation, IDisposable
    {
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private string _connectionString { get; set; }

        public UtilisationRepository(string connectionString)
        {
            _connectionString = connectionString;
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

        public bool AddUtilisations(List<Utilisation> utilisations)
        {
            try
            {
                using (var db = new DataContext(_connectionString))
                {
                    utilisations.ForEach((utilisation) =>
                    {
                        if (utilisation.Id == 0)
                            db.Utilisation.Add(utilisation);
                        else
                            db.Utilisation.Update(utilisation);

                        db.SaveChanges();
                    });

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Utilisation> GetUtilisations()
        {
            using (var db = new DataContext(_connectionString))
            {
                return db.Utilisation.Where(p => p.UserId == 1033).ToList();
            }
        }
    }
}
