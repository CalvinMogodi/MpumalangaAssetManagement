using MAM.BusinessLayer.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.BusinessLayer.Repositories
{

    public class ProgrammeRepository : IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public ProgrammeRepository(AppSettings settings)
        {
            appSettings = settings;
        }

        public bool AddProgrammes(List<Programme> programmes)
        {
            using (var dataAccess = new DataAccess.Repositories.ProgrammeRepository(appSettings.ConnectionString))
            {
                try
                {
                    List<MAM.DataAccess.Tables.Programme> tableProgrammes = new List<DataAccess.Tables.Programme>();

                    programmes.ForEach((programme) =>
                    {
                        tableProgrammes.Add(programme.ConvertToProgrammeTable(programme));
                    });

                    dataAccess.AddProgrammes(tableProgrammes);

                    return true;
                }
                catch(Exception ex)
                {
                    throw ex;
                   // return false;
                }
            }
        }

        public List<Programme> GetProgrammes()
        {
            using (var dataAccess = new DataAccess.Repositories.ProgrammeRepository(appSettings.ConnectionString))
            {
                Programme programme = new Programme();
                var programmes = dataAccess.GetProgrammes();
                return programme.ConvertToProgrammes(programmes);
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
