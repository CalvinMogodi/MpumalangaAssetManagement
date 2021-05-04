using MAM.BusinessLayer.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.BusinessLayer.Repositories
{
    public class UtilisationRepository : IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public UtilisationRepository(AppSettings settings)
        {
            appSettings = settings;
        }

        public bool AddUtilisations(List<Utilisation> utilisations)
        {
            using (var dataAccess = new DataAccess.Repositories.UtilisationRepository(appSettings.ConnectionString))
            {
                try
                {
                    List<MAM.DataAccess.Tables.Utilisation> tableUtilisations = new List<DataAccess.Tables.Utilisation>();

                    utilisations.ForEach((utilisation) =>
                    {
                        tableUtilisations.Add(utilisation.ConvertToUtilisationTable(utilisation));
                    });

                    return dataAccess.AddUtilisations(tableUtilisations);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<Utilisation> GetUtilisations()
        {
            using (var dataAccess = new DataAccess.Repositories.UtilisationRepository(appSettings.ConnectionString))
            {
                Utilisation utilisation = new Utilisation();
                var utilisations = dataAccess.GetUtilisations();
                return utilisation.ConvertToUtilisations(utilisations);
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
