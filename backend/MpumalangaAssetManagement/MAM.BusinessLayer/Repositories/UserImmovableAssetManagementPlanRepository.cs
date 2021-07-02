using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Models.Templetes;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (uamp.TempleteOne != null)
            {
               
                if (uamp.TempleteOne.OptimalSupportingAccommodation != null)
                    uamp = SaveOptimalSupportingAccommodationRepository(uamp);
                if (uamp.TempleteOne.Programmes != null)
                    uamp.TempleteOne.Programmes = SaveProgramme(uamp.TempleteOne.Programmes);
                if (uamp.TempleteTwoPointOne?.Properties != null)
                    uamp = SaveTempleteTwo(uamp);   
                if (uamp.TempleteThree?.StrategicAssessments != null)
                    uamp = SaveTempleteThree(uamp);
                if (uamp.TempleteFourPointOne?.AcquisitionPlans != null)
                    uamp = SaveTempleteFour(uamp);
                if (uamp.TempleteFivePointOne?.OperationPlans != null)
                    uamp = SaveTempleteFive(uamp);
                if (uamp.TempleteSix?.SurrenderPlans != null)
                    uamp = SaveTempleteSix(uamp);
                if (uamp.TempleteSeven?.MtefBudgetPeriods != null)
                    uamp = SaveTempleteSeven(uamp);
            }
            return uamp;
        }

        public UserImmovableAssetManagementPlan SaveUamp(UserImmovableAssetManagementPlan uamp)
        {
            using (var dataAccess = new DataAccess.Repositories.UampRepository(appSettings.ConnectionString))
            {
                if (uamp.Id == 0)
                {
                    uamp.Id = dataAccess.CreateUamp(uamp.ConvertToDBUserImmovableAssetManagementPlans(uamp));
                }
                else
                {
                    dataAccess.UpdateUamp(uamp.ConvertToDBUserImmovableAssetManagementPlans(uamp));
                }
                return uamp;
            }
        }

        public UserImmovableAssetManagementPlan SaveTempleteThree(UserImmovableAssetManagementPlan uamp)
        {
            using (var dataAccess = new DataAccess.Repositories.StrategicAssessmentRepository(appSettings.ConnectionString))
            {
                foreach (var strategicAssessment in uamp.TempleteThree.StrategicAssessments)
                {
                    if (strategicAssessment.Id == 0)
                    {
                        strategicAssessment.Id = dataAccess.AddStrategicAssessment(strategicAssessment.ConvertToStrategicAssessmentTable(strategicAssessment));
                    }
                    else
                    {
                        dataAccess.UpdateStrategicAssessment(strategicAssessment.ConvertToStrategicAssessmentTable(strategicAssessment));
                    }
                }
                return uamp;
            }
        }

        public UserImmovableAssetManagementPlan SaveTempleteFour(UserImmovableAssetManagementPlan uamp)
        {
            using (var dataAccess = new DataAccess.Repositories.AcquisitionPlanRepository(appSettings.ConnectionString))
            {
                List<AcquisitionPlan> acquisitionPlans = new List<AcquisitionPlan>();
                acquisitionPlans.AddRange(uamp.TempleteFourPointOne.AcquisitionPlans);
                acquisitionPlans.AddRange(uamp.TempleteFourPointTwo.AcquisitionPlans);
                foreach (var acquisitionPlan in acquisitionPlans)
                {
                    if (acquisitionPlan.Id == 0)
                    {
                        acquisitionPlan.Id = dataAccess.AddAcquisitionPlan(acquisitionPlan.ConvertToAcquisitionPlanTable(acquisitionPlan));
                    }
                    else
                    {
                        dataAccess.UpdateAcquisitionPlan(acquisitionPlan.ConvertToAcquisitionPlanTable(acquisitionPlan));
                    }
                }
                return uamp;
            }
        }

        public UserImmovableAssetManagementPlan SaveTempleteFive(UserImmovableAssetManagementPlan uamp)
        {
            using (var dataAccess = new DataAccess.Repositories.OperationPlanRepository(appSettings.ConnectionString))
            {
                List<OperationPlan> operationPlans = new List<OperationPlan>();
                if(uamp.TempleteFivePointOne.OperationPlans.Count > 0)
                    operationPlans.AddRange(uamp.TempleteFivePointOne?.OperationPlans);
                if (uamp.TempleteFivePointTwo != null)
                    operationPlans.AddRange(uamp.TempleteFivePointTwo?.OperationPlans);
                if (uamp.TempleteFivePointThree != null)
                    operationPlans.AddRange(uamp.TempleteFivePointThree?.OperationPlans);

                foreach (var operationPlan in operationPlans)
                {
                    if (operationPlan.Id == 0)
                    {
                        operationPlan.Id = dataAccess.AddOperationPlan(operationPlan.ConvertToOperationPlanTable(operationPlan));
                    }
                    else
                    {
                        dataAccess.UpdateOperationPlan(operationPlan.ConvertToOperationPlanTable(operationPlan));
                    }
                }
                return uamp;
            }
        }

        public UserImmovableAssetManagementPlan SaveTempleteSix(UserImmovableAssetManagementPlan uamp)
        {
            using (var dataAccess = new DataAccess.Repositories.SurrenderPlanRepository(appSettings.ConnectionString))
            {
                List<SurrenderPlan> surrenderPlans = uamp.TempleteSix.SurrenderPlans;
                foreach (var surrenderPlan in surrenderPlans)
                {
                    if (surrenderPlan.Id == 0)
                    {
                        surrenderPlan.Id = dataAccess.AddSurrenderPlan(surrenderPlan.ConvertToSurrenderPlanTable(surrenderPlan));
                    }
                    else
                    {
                        dataAccess.UpdateSurrenderPlan(surrenderPlan.ConvertToSurrenderPlanTable(surrenderPlan));
                    }
                }
                return uamp;
            }
        }

        public UserImmovableAssetManagementPlan SaveTempleteSeven(UserImmovableAssetManagementPlan uamp)
        {
            using (var dataAccess = new DataAccess.Repositories.MtefBudgetPeriodRepository(appSettings.ConnectionString))
            {
                List<MtefBudgetPeriod> mtefBudgetPeriods = uamp.TempleteSeven.MtefBudgetPeriods;
                foreach (var mtefBudgetPeriod in mtefBudgetPeriods)
                {
                    if (mtefBudgetPeriod.Id == 0)
                    {
                        mtefBudgetPeriod.Id = dataAccess.AddMtefBudgetPeriod(mtefBudgetPeriod.ConvertToMtefBudgetPeriodTable(mtefBudgetPeriod));
                    }
                    else
                    {
                        dataAccess.UpdateMtefBudgetPeriod(mtefBudgetPeriod.ConvertToMtefBudgetPeriodTable(mtefBudgetPeriod));
                    }
                }
                return uamp;
            }
        }

        public UserImmovableAssetManagementPlan SaveMtefYear(UserImmovableAssetManagementPlan uamp)
        {
            using (var dataAccess = new DataAccess.Repositories.MtefYearRepository(appSettings.ConnectionString))
            {
                return uamp;
            }
        }

        public UserImmovableAssetManagementPlan SaveTempleteTwo(UserImmovableAssetManagementPlan uamp) {
            using (var dataAccess = new DataAccess.Repositories.PropertyRepository(appSettings.ConnectionString))
            {
                List<Property> properties = new List<Property>();
                properties.AddRange(uamp.TempleteTwoPointOne.Properties);
                properties.AddRange(uamp.TempleteTwoPointTwo.Properties);
                foreach (var property in properties)
                {
                    if (property.Id == 0)
                    {
                        property.Id = dataAccess.AddProperty(property.ConvertToPropertyTable(property));
                    }
                    else
                    {
                        dataAccess.UpdateProperty(property.ConvertToPropertyTable(property));
                    }
                }                
                return uamp;
            }
        }

        public UserImmovableAssetManagementPlan StartUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan uamp)
        {
            using (var fDataAccess = new DataAccess.Repositories.FacilityRepository(appSettings.ConnectionString))
            {
                var facilities = fDataAccess.GetSignedOffFacilities();
                uamp = SaveUamp(uamp);
                foreach (var item in facilities)
                {
                    uamp.TempleteTwoPointOne = new TempleteTwoPointOne
                    {
                        Id = 0,
                        Properties = facilities.Select(f => new Property()
                        {
                            Id = 0,
                            UserImmovableAssetManagementPlanId = uamp.Id,
                            TempleteNumber = 2.1,
                            FileReferenceNo = f.FileReference,
                            SerialNo = f.FileReference,
                            DistrictRegion = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Region : null,
                            Town = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Town : null,
                            LocalAuthority = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.LocalAuthority : null,
                            AssetDescription = f.Land.GeographicalLocation != null ? f.Name : null,
                            OldStreetAddress = f.Land.GeographicalLocation != null ? string.Format("{0} {1} {2} {3}", f.Land.GeographicalLocation.StreetNumber, f.Land.GeographicalLocation.StreetName, f.Land.GeographicalLocation.Suburb, f.Land.GeographicalLocation.Province) : null,
                            CurrentStreetAddress = f.Land.GeographicalLocation != null ? string.Format("{0} {1} {2} {3}", f.Land.GeographicalLocation.StreetNumber, f.Land.GeographicalLocation.StreetName, f.Land.GeographicalLocation.Suburb, f.Land.GeographicalLocation.Province) : null,
                            PropertyDescription = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.OldDescription : null,
                            AssetType = f.Type,
                            ExtentofLand = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.Extent : null,                          
                            MunicipalUtilityServices = new List<MunicipalUtilityService>(),
                        }).ToList(),
                    };

                    uamp.TempleteTwoPointTwo = new TempleteTwoPointTwo
                    {
                        Id = 0,
                        Properties = facilities.Select(f => new Property()
                        {
                            Id = 0,
                            UserImmovableAssetManagementPlanId = uamp.Id,
                            TempleteNumber = 2.2,
                            FileReferenceNo = f.FileReference,
                            SerialNo = f.FileReference,
                            AssetType = f.Type,
                            DistrictRegion = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Region : null,
                            Town = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Town : null,
                            LocalAuthority = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.LocalAuthority : null,
                            AssetDescription = f.Land.GeographicalLocation != null ? f.Name : null,
                            OldStreetAddress = f.Land.GeographicalLocation != null ? string.Format("{0} {1} {2} {3}", f.Land.GeographicalLocation.StreetNumber, f.Land.GeographicalLocation.StreetName, f.Land.GeographicalLocation.Suburb, f.Land.GeographicalLocation.Province) : null,
                            CurrentStreetAddress = f.Land.GeographicalLocation != null ? string.Format("{0} {1} {2} {3}", f.Land.GeographicalLocation.StreetNumber, f.Land.GeographicalLocation.StreetName, f.Land.GeographicalLocation.Suburb, f.Land.GeographicalLocation.Province) : null,
                            PropertyDescription = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.OldDescription : null,                        
                            ExtentofLand = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.Extent : null,                           
                            MunicipalUtilityServices = new List<MunicipalUtilityService>(),                          
                        }).ToList(),
                    };

                    uamp.TempleteThree = new TempleteThree()
                    {
                        Id = 0,
                        StrategicAssessments = new List<StrategicAssessment>()
                    };

                    uamp.TempleteFourPointOne = new TempleteFourPointOne()
                    {
                        Id = 0,
                        AcquisitionPlans = new List<AcquisitionPlan>()
                    };

                    uamp.TempleteFourPointTwo = new TempleteFourPointTwo()
                    {
                        Id = 0,
                        AcquisitionPlans = new List<AcquisitionPlan>()
                    };

                    uamp.TempleteFivePointOne = new TempleteFivePointOne()
                    {
                        Id = 0,
                        OperationPlans = new List<OperationPlan>()
                    };
                    uamp.TempleteFivePointTwo = new TempleteFivePointTwo()
                    {
                        Id = 0,
                        OperationPlans = facilities.Select(f => new OperationPlan()
                        {
                            Id = 0,
                            UserImmovableAssetManagementPlanId = uamp.Id,
                            TempleteNumber = 2.2,
                            DistrictRegion = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Region : null,
                            Town = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Town : null,
                            LocalMunicipality = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.LocalAuthority : null,
                            AssetDescription = f.Land.GeographicalLocation != null ? f.Name : null,
                            StreetDescription = f.Land.GeographicalLocation != null ? string.Format("{0} {1} {2} {3}", f.Land.GeographicalLocation.StreetNumber, f.Land.GeographicalLocation.StreetName, f.Land.GeographicalLocation.Suburb, f.Land.GeographicalLocation.Province) : null,
                            PropertyDescription = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.OldDescription : null,
                            ExtentofLand = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.Extent : null,                           
                        }).ToList(),
                    };
                    uamp.TempleteFivePointThree = new TempleteFivePointThree()
                    {
                        Id = 0,
                        OperationPlans = facilities.Select(f => new OperationPlan()
                        {
                            Id = 0,
                            UserImmovableAssetManagementPlanId = uamp.Id,
                            TempleteNumber = 2.2,
                            DistrictRegion = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Region : null,
                            Town = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Town : null,
                            LocalMunicipality = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.LocalAuthority : null,
                            AssetDescription = f.Land.GeographicalLocation != null ? f.Name : null,
                            StreetDescription = f.Land.GeographicalLocation != null ? string.Format("{0} {1} {2} {3}", f.Land.GeographicalLocation.StreetNumber, f.Land.GeographicalLocation.StreetName, f.Land.GeographicalLocation.Suburb, f.Land.GeographicalLocation.Province) : null,
                            PropertyDescription = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.OldDescription : null,
                            ExtentofLand = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.Extent : null,
                        }).ToList(),
                    };
                    uamp.TempleteSix = new TempleteSix()
                    {
                        Id = 0,
                        SurrenderPlans = facilities.Select(f => new SurrenderPlan()
                        {
                            Id = 0,
                            UserImmovableAssetManagementPlanId = uamp.Id,
                            TempleteNumber = 2.2,
                            DistrictRegion = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Region : null,
                            Town = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Town : null,
                            LocalMunicipality = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.LocalAuthority : null,
                            AssetType = f.Type,
                            CurrentStreetAddress = f.Land.GeographicalLocation != null ? string.Format("{0} {1} {2} {3}", f.Land.GeographicalLocation.StreetNumber, f.Land.GeographicalLocation.StreetName, f.Land.GeographicalLocation.Suburb, f.Land.GeographicalLocation.Province) : null,
                            PropertyDescription = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.OldDescription : null,
                            ExtentofLand = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.Extent : null,
                        }).ToList(),
                    };
                    uamp.TempleteSeven = new TempleteSeven()
                    {
                        Id = 0,
                        MtefBudgetPeriods = new List<MtefBudgetPeriod>()
                    };
                }
            }
            uamp = SaveTempleteTwo(uamp);
            uamp = SaveTempleteThree(uamp);
            uamp = SaveTempleteFour(uamp);
            uamp = SaveTempleteFive(uamp);
            uamp = SaveTempleteSix(uamp);
            uamp = SaveTempleteSeven(uamp);

            return uamp;
        }

        public List<Programme> SaveProgramme(List<Programme> programmes)
        {
            using (var dataAccess = new DataAccess.Repositories.ProgrammeRepository(appSettings.ConnectionString))
            {
                foreach (var programme in programmes)
                {
                    if (programme.Id == 0)
                        programme.Id = dataAccess.AddProgramme(programme.ConvertToProgrammeTable(programme));
                    else
                        dataAccess.UpdateProgramme(programme.ConvertToProgrammeTable(programme));
                }
                return programmes;
            }
        }

        public UserImmovableAssetManagementPlan SaveOptimalSupportingAccommodationRepository(UserImmovableAssetManagementPlan uamp)
        {
            using (var dataAccess = new DataAccess.Repositories.OptimalSupportingAccommodationRepository(appSettings.ConnectionString))
            {
                OptimalSupportingAccommodation optimalSupportingAccommodation = new OptimalSupportingAccommodation();
                if (uamp.TempleteOne.OptimalSupportingAccommodation.Id == 0)
                    uamp.TempleteOne.OptimalSupportingAccommodation.Id = dataAccess.AddOptimalSupportingAccommodation(optimalSupportingAccommodation.ConvertToOptimalSupportingAccommodationTable(uamp.TempleteOne.OptimalSupportingAccommodation));
                else
                    dataAccess.UpdateOptimalSupportingAccommodation(optimalSupportingAccommodation.ConvertToOptimalSupportingAccommodationTable(uamp.TempleteOne.OptimalSupportingAccommodation));
                return uamp;
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
