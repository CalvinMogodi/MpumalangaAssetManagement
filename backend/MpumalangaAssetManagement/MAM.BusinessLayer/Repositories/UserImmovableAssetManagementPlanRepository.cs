using MAM.BusinessLayer.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.BusinessLayer.Repositories
{
    public class UserImmovableAssetManagementPlanRepository : IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public UserImmovableAssetManagementPlanRepository(AppSettings settings)
        {
            appSettings = settings;
        }

        public List<UserImmovableAssetManagementPlan> GetUserImmovableAssetManagementPlans(string department)
        {
            UserImmovableAssetManagementPlan uamp = new UserImmovableAssetManagementPlan();
            List<UserImmovableAssetManagementPlan> userImmovableAssetManagementPlans = new List<UserImmovableAssetManagementPlan>();
            using (var dataAccess = new DataAccess.Repositories.UampRepository(appSettings.ConnectionString))
            {
                var uamps = uamp.ConvertToUserImmovableAssetManagementPlans(dataAccess.GetUamps(department));
                userImmovableAssetManagementPlans.AddRange(uamps);
                return userImmovableAssetManagementPlans;
            }
        }

        public UserImmovableAssetManagementPlan SaveUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan uamp)
        {
            using (var dataAccess = new DataAccess.Repositories.UampRepository(appSettings.ConnectionString))
            {
                if (uamp.TempleteOne != null)
                {
                    if (uamp.TempleteOne.Programmes != null)
                        uamp.TempleteOne.Programmes = SaveProgramme(uamp.TempleteOne.Programmes);
                    if (uamp.TempleteOne.OptimalSupportingAccommodation != null)
                        uamp.OptimalSupportingAccommodationId = SaveOptimalSupportingAccommodationRepository(uamp.TempleteOne.OptimalSupportingAccommodation).Id;
                }
                
                
                dataAccess.UpdateUamp(uamp.ConvertToDBUserImmovableAssetManagementPlans(uamp));
                return uamp;
            }
        }

        public UserImmovableAssetManagementPlan StartUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan uamp)
        {
            using (var dataAccess = new DataAccess.Repositories.UampRepository(appSettings.ConnectionString))
            {
                uamp.Id = dataAccess.CreateUamp(uamp.ConvertToDBUserImmovableAssetManagementPlans(uamp));
                return uamp;
            }
        }

        public List<Programme> SaveProgramme(List<Programme> programmes) {
            using (var dataAccess = new DataAccess.Repositories.ProgrammeRepository(appSettings.ConnectionString))
            {
                foreach (var programme in programmes)
                {
                    if(programme.Id == 0)
                        programme.Id = dataAccess.AddProgramme(programme.ConvertToProgrammeTable(programme));
                    else
                        dataAccess.UpdateProgramme(programme.ConvertToProgrammeTable(programme));
                }               
                return programmes;
            }            
        }

        public OptimalSupportingAccommodation SaveOptimalSupportingAccommodationRepository(OptimalSupportingAccommodation optimalSupportingAccommodation) {
            using (var dataAccess = new DataAccess.Repositories.OptimalSupportingAccommodationRepository(appSettings.ConnectionString))
            {
                if (optimalSupportingAccommodation.Id == 0)
                    optimalSupportingAccommodation.Id = dataAccess.AddOptimalSupportingAccommodation(optimalSupportingAccommodation.ConvertToOptimalSupportingAccommodationTable(optimalSupportingAccommodation));
                    else
                        dataAccess.UpdateOptimalSupportingAccommodation(optimalSupportingAccommodation.ConvertToOptimalSupportingAccommodationTable(optimalSupportingAccommodation));              
                return optimalSupportingAccommodation;
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
