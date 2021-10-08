using MAM.BusinessLayer.Model;
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

        public UserImmovableAssetManagementPlan GetUamp(int id) {
            UserImmovableAssetManagementPlan uamp = new UserImmovableAssetManagementPlan();
            using (var dataAccess = new DataAccess.Repositories.UampRepository(appSettings.ConnectionString))
            {
                return uamp.ConvertToUserImmovableAssetManagementPlan(dataAccess.GetUamp(id));
            }
        }

        public UserImmovableAssetManagementPlan GetUampWithTemplateOne(int id)
        {
            UserImmovableAssetManagementPlan uamp = new UserImmovableAssetManagementPlan();
            using (var dataAccess = new DataAccess.Repositories.UampRepository(appSettings.ConnectionString))
            {
                return uamp.ConvertToUserImmovableAssetManagementPlanWithTemplateOne(dataAccess.GetUampWithTemplateOne(id));
            }
        }        

        public UserImmovableAssetManagementPlan SaveUserImmovableAssetManagementPlan(UserImmovableAssetManagementPlan uamp)
        {
            if (uamp.TempleteOne != null)
            {
                if (uamp.TempleteOne.OptimalSupportingAccommodation != null)
                    uamp = SaveOptimalSupportingAccommodationRepository(uamp);
                if (uamp.TempleteOne.Programmes.Count > 0)
                    uamp.TempleteOne.Programmes = SaveProgramme(uamp.TempleteOne.Programmes);
                if (uamp.TempleteTwoPointOne?.Properties != null)
                    uamp = SaveTempleteTwo(uamp);
                if (uamp.TempleteThree?.StrategicAssessments.Count > 0)
                    uamp = SaveTempleteThree(uamp);
                if (uamp.TempleteFourPointOne?.AcquisitionPlans.Count > 0 || uamp.TempleteFourPointTwo?.AcquisitionPlans.Count > 0)
                    uamp = SaveTempleteFour(uamp);
                if (uamp.TempleteFivePointOne?.OperationPlans != null)
                    uamp = SaveTempleteFive(uamp);
                if (uamp.TempleteSix?.SurrenderPlans != null)
                    uamp = SaveTempleteSix(uamp);
                if (uamp.TempleteSeven?.MtefBudgetPeriods != null)
                    uamp = SaveTempleteSeven(uamp);

                uamp.OptimalSupportingAccommodationId = uamp.TempleteOne.OptimalSupportingAccommodation.Id;

                uamp = SaveUamp(uamp);
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
                if (uamp.TempleteFivePointOne.OperationPlans.Count > 0)
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
                List<MtefBudgetPeriod> _mtefBudgetPeriods = new List<MtefBudgetPeriod>();
                List<MtefBudgetPeriod> mtefBudgetPeriods = uamp.TempleteSeven.MtefBudgetPeriods.ToList();
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

                uamp.TempleteSeven.MtefBudgetPeriods = _mtefBudgetPeriods;
                return uamp;
            }
        }

        public bool DeleteOperationPlan(OperationPlan operationPlan)
        {
            using (var dataAccess = new DataAccess.Repositories.OperationPlanRepository(appSettings.ConnectionString))
            {
                dataAccess.DeleteOperationPlan(operationPlan.ConvertToOperationPlanTable(operationPlan));
                return true;
            }
        }

        public bool DeleteAcquisitionPlan(AcquisitionPlan acquisitionPlan)
        {
            using (var dataAccess = new DataAccess.Repositories.AcquisitionPlanRepository(appSettings.ConnectionString))
            {
                dataAccess.DeleteAcquisitionPlan(acquisitionPlan.ConvertToAcquisitionPlanTable(acquisitionPlan));
                return true;
            }
        }

        public bool DeleteProgramme(Programme programme)
        {
            using (var dataAccess = new DataAccess.Repositories.ProgrammeRepository(appSettings.ConnectionString))
            {
                dataAccess.DeleteProgramme(programme.ConvertToProgrammeTable(programme));
                return true;
            }
        }

        public bool DeleteProperty(Property property)
        {
            using (var dataAccess = new DataAccess.Repositories.PropertyRepository(appSettings.ConnectionString))
            {
                dataAccess.DeleteProperty(property.ConvertToPropertyTable(property));
                return true;
            }
        }

        public bool DeleteStrategicAssessment(StrategicAssessment strategicAssessment)
        {
            using (var dataAccess = new DataAccess.Repositories.StrategicAssessmentRepository(appSettings.ConnectionString))
            {
                dataAccess.DeleteStrategicAssessment(strategicAssessment.ConvertToStrategicAssessmentTable(strategicAssessment));
                return true;
            }
        }

        public bool DeleteSurrenderPlan(SurrenderPlan surrenderPlan)
        {
            using (var dataAccess = new DataAccess.Repositories.SurrenderPlanRepository(appSettings.ConnectionString))
            {
                dataAccess.DeleteSurrenderPlan(surrenderPlan.ConvertToSurrenderPlanTable(surrenderPlan));
                return true;
            }
        }

        public UserImmovableAssetManagementPlan SaveTempleteTwo(UserImmovableAssetManagementPlan uamp)
        {
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
                MtefBudgetPeriod mtefBudgetPeriod = new MtefBudgetPeriod();

                uamp.TempleteOne = new TempleteOne()
                {
                    Id = 0,
                    Programmes = new List<Programme>(),
                    OptimalSupportingAccommodation = new OptimalSupportingAccommodation()
                };
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
                        AssetType = f.Land.Type,
                        ExtentofLand = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.Extent : null,
                        PropertyRatesTaxes = null,
                        OperationalCosts = null,
                        NoofParkingBays = null,
                        RequiredPerformanceStandard = null,
                        Accessibility = null,
                        ConditionRating = null,
                        SuitabilityIndex = null,
                        OperatingPerformanceIndex = null,
                        FunctionalPerformanceIndex = null,
                        MunicipalUtilityServices = new List<MunicipalUtilityService>(),
                    }).ToList(),
                };

                uamp.TempleteTwoPointTwo = new TempleteTwoPointTwo
                {
                    Id = 0,
                    Properties = facilities.Where(f => f.Land.LandUseManagementDetail.IncomeLeaseStatus == "Yes").Select(f => new Property()
                    {
                        Id = 0,
                        UserImmovableAssetManagementPlanId = uamp.Id,
                        TempleteNumber = 2.2,
                        FileReferenceNo = f.FileReference,
                        SerialNo = f.FileReference,
                        AssetType = f.Land.Type,
                        DistrictRegion = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Region : null,
                        Town = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Town : null,
                        LocalAuthority = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.LocalAuthority : null,
                        AssetDescription = f.Land.GeographicalLocation != null ? f.Name : null,
                        OldStreetAddress = f.Land.GeographicalLocation != null ? string.Format("{0} {1} {2} {3}", f.Land.GeographicalLocation.StreetNumber, f.Land.GeographicalLocation.StreetName, f.Land.GeographicalLocation.Suburb, f.Land.GeographicalLocation.Province) : null,
                        CurrentStreetAddress = f.Land.GeographicalLocation != null ? string.Format("{0} {1} {2} {3}", f.Land.GeographicalLocation.StreetNumber, f.Land.GeographicalLocation.StreetName, f.Land.GeographicalLocation.Suburb, f.Land.GeographicalLocation.Province) : null,
                        PropertyDescription = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.OldDescription : null,
                        ExtentofLand = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.Extent : null,         
                        NoofParkingBays = null,
                        LettableSpace = null,
                        LeaseEndDate = null,
                        LeaseStartDate = null,
                        RentalRate = null,
                        RequiredPerformanceStandard = null,
                        Accessibility = null,
                        ConditionRating = null,
                        SuitabilityIndex = null,
                        OperatingPerformanceIndex = null,
                        FunctionalPerformanceIndex = null,
                        Comment = null
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
                    AcquisitionPlans = facilities.Where(f => f.Land.LeaseStatus.TerminationDate <= DateTime.Today).Select(f => new AcquisitionPlan()
                    {
                        Id = 0,
                        UserImmovableAssetManagementPlanId = uamp.Id,
                        TempleteNumber = 4.2,
                        DistrictRegion = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Region : null,
                        Town = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Town : null,
                        BudgetType = null,
                        Extent = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.Extent : null,
                        InitialNeedYear = null,
                        AcquisitionType = null,
                        Status = null,
                        TotalAmountRequired = null,
                        CashFlowYear1 = null,
                        CashFlowYear2 = null,
                        CashFlowYear3 = null,
                        CashFlowYear4 = null,
                        CashFlowYear5 = null,
                    }).ToList()
                };

                uamp.TempleteFivePointOne = new TempleteFivePointOne()
                {
                    Id = 0,
                    OperationPlans = facilities.Select(f => new OperationPlan()
                    {
                        Id = 0,
                        UserImmovableAssetManagementPlanId = uamp.Id,
                        TempleteNumber = 5.1,                        
                        DistrictRegion = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Region : null,
                        Town = f.Land.GeographicalLocation != null ? f.Land.GeographicalLocation.Town : null,
                        AssetDescription = f.Land.GeographicalLocation != null ? f.Name : null,
                        PropertyDescription = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.OldDescription : null,
                        ExtentofLand = f.Land.PropertyDescription != null ? f.Land.PropertyDescription.Extent : null,
                        NoofParkingBays = null,
                        ServiceDescription = null,
                        RepairDescription = null,
                        PrioityServiceReanking = null,
                        StreetDescription = null,
                        LeaseType = null,
                        UsableSpace = null,
                        ConstructionArea = null,
                        LeaseStartDate = f.Land.LeaseStatus != null ? f.Land.LeaseStatus.StartingDate : null,
                        LeaseEndDate = f.Land.LeaseStatus != null ? f.Land.LeaseStatus.TerminationDate : null,
                        RentalPmPa = null,
                        InitialNeedYear = null,
                        Status = null,
                        TotalAmountRequired = null,
                        CashFlowYear1 = null,
                        CashFlowYear2 = null,
                        CashFlowYear3 = null,
                        CashFlowYear4 = null,
                        CashFlowYear5 = null,
                        Comment = null
                    }).ToList(),
                };
                uamp.TempleteFivePointTwo = new TempleteFivePointTwo()
                {
                    Id = 0,
                    OperationPlans = facilities.Where(f => f.Land.LeaseStatus.TerminationDate <= DateTime.Today).Select(f => new OperationPlan()
                    {
                        Id = 0,
                        UserImmovableAssetManagementPlanId = uamp.Id,
                        TempleteNumber = 5.2,
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
                        TempleteNumber = 5.3,
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
                    SurrenderPlans = facilities.Where(f => f.Land.LeaseStatus.TerminationDate <= DateTime.Today).Select(f => new SurrenderPlan()
                    {
                        Id = 0,
                        UserImmovableAssetManagementPlanId = uamp.Id,
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
                    MtefBudgetPeriods = mtefBudgetPeriod.BuildMtefBudgetPeriod(uamp.Id)
                };

            }
            uamp = SaveTempleteTwo(uamp);
            uamp = SaveTempleteThree(uamp);
            uamp = SaveTempleteFour(uamp);
            uamp = SaveTempleteFive(uamp);
            uamp = SaveTempleteSix(uamp);
            uamp = SaveTempleteSeven(uamp);
            uamp.User = GetUserById(uamp.UserId);
            return uamp;
        }

        public User GetUserById(int userId)
        {
            using (var dataAccess = new DataAccess.Repositories.UserRepository(appSettings.ConnectionString))
            {
                var userdb = dataAccess.GetUser(userId);
                User user = new User()
                {
                    Id = userdb.Id,
                    Name = userdb.Name,
                    Surname = userdb.Surname,
                    Email = userdb.Email
                };
                return user;
            }
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

        public TempleteOne GetUAMPTempleteOne(int uampId)
        {
            TempleteOne templeteOne = new TempleteOne();
            DataAccess.Tables.OptimalSupportingAccommodation optimalSupportingAccommodation = new DataAccess.Tables.OptimalSupportingAccommodation();
            List<DataAccess.Tables.Programme> programmes = new List<DataAccess.Tables.Programme>();
            using (var dataAccess = new DataAccess.Repositories.ProgrammeRepository(appSettings.ConnectionString))
            {
                programmes = dataAccess.GetProgrammes(uampId);
            }

            using (var dataAccess = new DataAccess.Repositories.OptimalSupportingAccommodationRepository(appSettings.ConnectionString))
            {
                optimalSupportingAccommodation = dataAccess.GetOptimalSupportingAccommodation(uampId);
            }

            return templeteOne.ConvertToTempleteOne(programmes, optimalSupportingAccommodation);
        }

        public TempleteTwoPointOne GetUAMPTempleteTwoPointOne(int uampId)
        {
            TempleteTwoPointOne templeteTwoPointOne = new TempleteTwoPointOne();
            List<DataAccess.Tables.Property> properties = new List<DataAccess.Tables.Property>();
            using (var dataAccess = new DataAccess.Repositories.PropertyRepository(appSettings.ConnectionString))
            {
                double temNumber = 2.1;
                properties = dataAccess.GetProperties(uampId, temNumber);
            }
            templeteTwoPointOne = templeteTwoPointOne.ConvertToTempleteTwoPointOne(properties);

            return templeteTwoPointOne;
        }

        public TempleteTwoPointTwo GetUAMPTempleteTwoPointTwo(int uampId)
        {
            TempleteTwoPointTwo templeteTwoPointTwo = new TempleteTwoPointTwo();
            List<DataAccess.Tables.Property> properties = new List<DataAccess.Tables.Property>();
            using (var dataAccess = new DataAccess.Repositories.PropertyRepository(appSettings.ConnectionString))
            {
                double temNumber = 2.2;
                properties = dataAccess.GetProperties(uampId, temNumber);
            }
            templeteTwoPointTwo = templeteTwoPointTwo.ConvertToTempleteTwoPointTwo(properties);

            return templeteTwoPointTwo;
        }

        public TempleteThree GetUAMPTempleteThree(int uampId)
        {
            TempleteThree templeteThree = new TempleteThree();
            List<DataAccess.Tables.StrategicAssessment> strategicAssessments = new List<DataAccess.Tables.StrategicAssessment>();
            using (var dataAccess = new DataAccess.Repositories.StrategicAssessmentRepository(appSettings.ConnectionString))
            {
                strategicAssessments = dataAccess.GetStrategicAssessments(uampId);
            }
            templeteThree = templeteThree.ConvertToTempleteThree(strategicAssessments);

            return templeteThree;
        }

        public TempleteFourPointOne GetUAMPTempleteFourPointOne(int uampId)
        {
            TempleteFourPointOne templeteFourPointOne = new TempleteFourPointOne();
            List<DataAccess.Tables.AcquisitionPlan> acquisitionPlans = new List<DataAccess.Tables.AcquisitionPlan>();
            using (var dataAccess = new DataAccess.Repositories.AcquisitionPlanRepository(appSettings.ConnectionString))
            {
                double temNumber = 4.1;
                acquisitionPlans = dataAccess.GetAcquisitionPlans(uampId, temNumber);
            }
            templeteFourPointOne = templeteFourPointOne.ConvertToTempleteFourPointOne(acquisitionPlans);

            return templeteFourPointOne;            
        }

        public TempleteFourPointTwo GetUAMPTempleteFourPointTwo(int uampId)
        {
            TempleteFourPointTwo templeteFourPointTwo = new TempleteFourPointTwo();
            List<DataAccess.Tables.AcquisitionPlan> acquisitionPlans = new List<DataAccess.Tables.AcquisitionPlan>();
            using (var dataAccess = new DataAccess.Repositories.AcquisitionPlanRepository(appSettings.ConnectionString))
            {
                double temNumber = 4.2;
                acquisitionPlans = dataAccess.GetAcquisitionPlans(uampId, temNumber);
            }
            templeteFourPointTwo = templeteFourPointTwo.ConvertToTempleteFourPointTwo(acquisitionPlans);

            return templeteFourPointTwo;
        }

        public TempleteFivePointOne GetUAMPTempleteFivePointOne(int uampId)
        {
            TempleteFivePointOne templeteFivePointOne = new TempleteFivePointOne();
            List<DataAccess.Tables.OperationPlan> operationPlan = new List<DataAccess.Tables.OperationPlan>();
            using (var dataAccess = new DataAccess.Repositories.OperationPlanRepository(appSettings.ConnectionString))
            {
                double temNumber = 5.1;
                operationPlan = dataAccess.GetOperationPlans(uampId, temNumber);
            }
            templeteFivePointOne = templeteFivePointOne.ConvertToTempleteFivePointOne(operationPlan);

            return templeteFivePointOne;
        }

        public TempleteFivePointTwo GetUAMPTempleteFivePointTwo(int uampId)
        {
            TempleteFivePointTwo templeteFivePointTwo = new TempleteFivePointTwo();
            List<DataAccess.Tables.OperationPlan> operationPlan = new List<DataAccess.Tables.OperationPlan>();
            using (var dataAccess = new DataAccess.Repositories.OperationPlanRepository(appSettings.ConnectionString))
            {
                double temNumber = 5.2;
                operationPlan = dataAccess.GetOperationPlans(uampId, temNumber);
            }
            templeteFivePointTwo = templeteFivePointTwo.ConvertToTempleteFivePointTwo(operationPlan);

            return templeteFivePointTwo;
        }

        public TempleteFivePointThree GetUAMPTempleteFivePointThree(int uampId)
        {
            TempleteFivePointThree templeteFivePointThree = new TempleteFivePointThree();
            List<DataAccess.Tables.OperationPlan> operationPlan = new List<DataAccess.Tables.OperationPlan>();
            using (var dataAccess = new DataAccess.Repositories.OperationPlanRepository(appSettings.ConnectionString))
            {
                double temNumber = 5.3;
                operationPlan = dataAccess.GetOperationPlans(uampId, temNumber);
            }
            templeteFivePointThree = templeteFivePointThree.ConvertToTempleteFivePointThree(operationPlan);

            return templeteFivePointThree;
        }

        public TempleteSix GetUAMPTempleteSix(int uampId)
        {
            TempleteSix templeteSix = new TempleteSix();
            List<DataAccess.Tables.SurrenderPlan> surrenderPlans = new List<DataAccess.Tables.SurrenderPlan>();
            using (var dataAccess = new DataAccess.Repositories.SurrenderPlanRepository(appSettings.ConnectionString))
            {
                surrenderPlans = dataAccess.GetSurrenderPlans(uampId);
            }
            templeteSix = templeteSix.ConvertToTempleteSix(surrenderPlans);

            return templeteSix;
        }

        public TempleteSeven GetUAMPTempleteSeven(int uampId)
        {
            TempleteSeven templeteSeven = new TempleteSeven();
            List<DataAccess.Tables.MtefBudgetPeriod> mtefBudgetPeriods = new List<DataAccess.Tables.MtefBudgetPeriod>();
            using (var dataAccess = new DataAccess.Repositories.MtefBudgetPeriodRepository(appSettings.ConnectionString))
            {
                mtefBudgetPeriods = dataAccess.GetMtefBudgetPeriods(uampId);
            }
            templeteSeven = templeteSeven.ConvertToTempleteSeven(mtefBudgetPeriods);

            return templeteSeven;
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
