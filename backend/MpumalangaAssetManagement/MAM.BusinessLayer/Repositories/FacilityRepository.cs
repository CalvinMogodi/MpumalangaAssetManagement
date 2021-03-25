using MAM.BusinessLayer.Interfaces;
using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Models.Enums;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MAM.BusinessLayer.Repositories
{
    public class FacilityRepository : FacilityInterface, IDisposable
    {
        private AppSettings appSettings { get; set; }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public FacilityRepository(AppSettings settings)
        {
            appSettings = settings;
        }

        public List<FacilityType> GetFacilityZonings()
        {
            List<FacilityType> facilityTypes = new List<FacilityType>();

            using (var dataAccess = new DataAccess.Repositories.DwellingFacilityRepository(appSettings.ConnectionString))
            {
                FacilityType facilityType = new FacilityType()
                {
                    Name = "Dwellings",
                    FacilityZonings = new List<FacilityZoning>()
                };

                var dwellingFacilities = dataAccess.GetDwellingFacilities();
                var zonings = dwellingFacilities.Select(d => d.Zoning.ToLower().Trim()).Distinct();
                foreach (var zoning in zonings)
                {
                    FacilityZoning facilityZoning = new FacilityZoning()
                    {
                        Name = zoning,
                        SignedOff = dwellingFacilities.Where(d => d.Zoning.ToLower().Trim() == zoning.ToLower().Trim() && d.Status == (int)FacilityStatus.Completed).Count(),
                        Total = dwellingFacilities.Where(d => d.Zoning.ToLower().Trim() == zoning.ToLower().Trim()).Count(),
                    };
                    facilityType.FacilityZonings.Add(facilityZoning);
                }
                facilityTypes.Add(facilityType);
            }

            using (var dataAccess = new DataAccess.Repositories.LandFacilityRepository(appSettings.ConnectionString))
            {
                FacilityType facilityType = new FacilityType()
                {
                    Name = "Land",
                    FacilityZonings = new List<FacilityZoning>()
                };

                var landFacilities = dataAccess.GetLandFacilities();
                var zonings = landFacilities.Select(d => d.Zoning.ToLower().Trim()).Distinct();
                foreach (var zoning in zonings)
                {
                    FacilityZoning facilityZoning = new FacilityZoning()
                    {
                        Name = zoning,
                        SignedOff = landFacilities.Where(d => d.Zoning.ToLower().Trim() == zoning.ToLower().Trim() && d.Status == (int)FacilityStatus.Completed).Count(),
                        Total = landFacilities.Where(d => d.Zoning.ToLower().Trim() == zoning.ToLower().Trim()).Count()
                    };

                    facilityType.FacilityZonings.Add(facilityZoning);
                }
                facilityTypes.Add(facilityType);
            }

            using (var dataAccess = new DataAccess.Repositories.NonResidentialFacilityRepository(appSettings.ConnectionString))
            {
                FacilityType facilityType = new FacilityType()
                {
                    Name = "Non Residential Buildings",
                    FacilityZonings = new List<FacilityZoning>()
                };

                var nonResidentialFacilities = dataAccess.GetNonResidentialFacilities();
                var zonings = nonResidentialFacilities.Select(d => d.Zoning).Distinct();
                foreach (var zoning in zonings)
                {
                    FacilityZoning facilityZoning = new FacilityZoning()
                    {
                        Name = zoning,
                        SignedOff = nonResidentialFacilities.Where(d => d.Zoning.ToLower().Trim() == zoning.ToLower().Trim() && d.Status == (int)FacilityStatus.Completed).Count(),
                        Total = nonResidentialFacilities.Where(d => d.Zoning.ToLower().Trim() == zoning.ToLower().Trim()).Count()
                    };

                    facilityType.FacilityZonings.Add(facilityZoning);
                }
                facilityTypes.Add(facilityType);
            }
            return facilityTypes;
        }

        public List<DashboardWedge> GetDashboardWedges()
        {
            List<DashboardWedge> list = new List<DashboardWedge>();
            List<Facility> facilities = new List<Facility>();
            List<string> dashboardWedges = new List<string>();
            dashboardWedges.Add("Number of properties");
            dashboardWedges.Add("Signed off properties");
            dashboardWedges.Add("Non Residential Buildings");
            dashboardWedges.Add("Dwellings");
            dashboardWedges.Add("Land");
            List<DataAccess.Tables.DwellingFacility> dwellingFacilities = new List<DataAccess.Tables.DwellingFacility>();
            List<DataAccess.Tables.LandFacility> landFacilities = new List<DataAccess.Tables.LandFacility>();
            List<DataAccess.Tables.NonResidentialFacility> nonResidentialFacilities = new List<DataAccess.Tables.NonResidentialFacility>();

            using (var dataAccess = new DataAccess.Repositories.DwellingFacilityRepository(appSettings.ConnectionString))
            {
                dwellingFacilities = dataAccess.GetDwellingFacilities();
            }

            using (var dataAccess = new DataAccess.Repositories.LandFacilityRepository(appSettings.ConnectionString))
            {
                landFacilities = dataAccess.GetLandFacilities();
            }

            using (var dataAccess = new DataAccess.Repositories.NonResidentialFacilityRepository(appSettings.ConnectionString))
            {
                nonResidentialFacilities = dataAccess.GetNonResidentialFacilities();
            }

            foreach (var wedge in dashboardWedges)
            {
                DashboardWedge dashboardWedge = new DashboardWedge();
                dashboardWedge.Name = wedge;
                if (dashboardWedge.Name == "Number of properties")
                {
                    dashboardWedge.Total = dwellingFacilities.Count();
                    dashboardWedge.Total = dashboardWedge.Total + landFacilities.Count();
                    dashboardWedge.Total = dashboardWedge.Total + nonResidentialFacilities.Count();
                }
                if (dashboardWedge.Name == "Signed off properties")
                {
                    dashboardWedge.Total = dwellingFacilities.Where(d => d.Status == (int)FacilityStatus.Completed).Count();
                    dashboardWedge.Total = dashboardWedge.Total + landFacilities.Where(d => d.Status == (int)FacilityStatus.Completed).Count();
                    dashboardWedge.Total = dashboardWedge.Total + nonResidentialFacilities.Where(d => d.Status == (int)FacilityStatus.Completed).Count();
                }
                if (dashboardWedge.Name == "Non Residential Buildings")
                    dashboardWedge.Total = dwellingFacilities.Count();

                if (dashboardWedge.Name == "Dwellings")
                    dashboardWedge.Total = landFacilities.Count();

                if (dashboardWedge.Name == "Land")
                    dashboardWedge.Total = nonResidentialFacilities.Count();

                list.Add(dashboardWedge);
            }
            return list;
        }

        public List<FacilitySummaryChart> GetFacilitySummaries()
        {

            List<FacilitySummaryChart> facilitySummaryChartData = new List<FacilitySummaryChart>();

            using (var dataAccess = new DataAccess.Repositories.FacilityStatementRepository(appSettings.ConnectionString))
            {
                var facilities = dataAccess.GetFacilityStatements();
                int year = DateTime.Now.Year;

                for (int i = 0; i < 3; i++)
                {
                    FacilitySummaryChart facilitySummaryChart = new FacilitySummaryChart()
                    {
                        Year = year,
                        FacilitySummaries = new List<FacilitySummary>()
                    };
                    var dbRecord = facilities.FirstOrDefault(f => f.Year == year);
                    if (dbRecord != null)
                    {
                        FacilitySummary _facilitySummaries = new FacilitySummary()
                        {
                            Type = facilities.FirstOrDefault(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Dwellings).FacilityType,
                            Year = facilities.FirstOrDefault(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Dwellings).Year,
                            OpeningBalance = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Dwellings).Sum(f => Convert.ToDecimal(f.OpeningBalance)),
                            Additions = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Dwellings).Sum(f => Convert.ToDecimal(f.Additions)),
                            PpeaIn = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Dwellings).Sum(f => Convert.ToDecimal(f.PpeaIN)),
                            PpeaOut = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Dwellings).Sum(f => Convert.ToDecimal(f.PpeaOut)),
                            Disposals = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Dwellings).Sum(f => Convert.ToDecimal(f.Disposal)),
                            ClosingBalance = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Dwellings).Sum(f => Convert.ToDecimal(f.ClosingBalance)),
                            FacilityType = "Dwellings"
                        };
                        facilitySummaryChart.FacilitySummaries.Add(_facilitySummaries);

                        FacilitySummary _facilitySummariesNonRes = new FacilitySummary()
                        {
                            Type = facilities.FirstOrDefault(f => f.Year == year && f.FacilityType == (int)FacilityTypes.NonResidentialBuildings).FacilityType,
                            Year = facilities.FirstOrDefault(f => f.Year == year && f.FacilityType == (int)FacilityTypes.NonResidentialBuildings).Year,
                            OpeningBalance = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.NonResidentialBuildings).Sum(f => Convert.ToDecimal(f.OpeningBalance)),
                            Additions = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.NonResidentialBuildings).Sum(f => Convert.ToDecimal(f.Additions)),
                            PpeaIn = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.NonResidentialBuildings).Sum(f => Convert.ToDecimal(f.PpeaIN)),
                            PpeaOut = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.NonResidentialBuildings).Sum(f => Convert.ToDecimal(f.PpeaOut)),
                            Disposals = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.NonResidentialBuildings).Sum(f => Convert.ToDecimal(f.Disposal)),
                            ClosingBalance = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.NonResidentialBuildings).Sum(f => Convert.ToDecimal(f.ClosingBalance)),
                            FacilityType = "Non Residential Buildings"
                        };
                        facilitySummaryChart.FacilitySummaries.Add(_facilitySummariesNonRes);

                        FacilitySummary _facilitySummariesLand = new FacilitySummary()
                        {
                            Type = facilities.FirstOrDefault(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Land).FacilityType,
                            Year = facilities.FirstOrDefault(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Land).Year,
                            OpeningBalance = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Land).Sum(f => Convert.ToDecimal(f.OpeningBalance)),
                            Additions = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Land).Sum(f => Convert.ToDecimal(f.Additions)),
                            PpeaIn = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Land).Sum(f => Convert.ToDecimal(f.PpeaIN)),
                            PpeaOut = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Land).Sum(f => Convert.ToDecimal(f.PpeaOut)),
                            Disposals = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Land).Sum(f => Convert.ToDecimal(f.Disposal)),
                            ClosingBalance = facilities.Where(f => f.Year == year && f.FacilityType == (int)FacilityTypes.Land).Sum(f => Convert.ToDecimal(f.ClosingBalance)),
                            FacilityType = "Land"
                        };
                        facilitySummaryChart.FacilitySummaries.Add(_facilitySummariesLand);
                    }

                    facilitySummaryChartData.Add(facilitySummaryChart);
                    year--;
                }
            }
            return facilitySummaryChartData;
        }

        public List<MapCoordinate> GetMapCoordinates()
        {
            List<MapCoordinate> mapCoordinates = new List<MapCoordinate>();
            using (var dataAccess = new DataAccess.Repositories.FacilityRepository(appSettings.ConnectionString))
            {
                var facilities = dataAccess.GetFacilities();
                foreach (var item in facilities)
                {
                    if (!string.IsNullOrEmpty(item.Land.GeographicalLocation.Longitude) && !string.IsNullOrEmpty(item.Land.GeographicalLocation.Latitude))
                    {
                        MapCoordinate mapCoordinate = new MapCoordinate()
                        {
                            Longitude = item.Land.GeographicalLocation.Longitude.Replace(",", "."),
                            Latitude = item.Land.GeographicalLocation.Latitude.Replace(",", "."),
                            Description = item.Name,
                            FacilityId = item.Id,
                            FacilityType = FacilityTypes.Dwellings
                        };
                        mapCoordinates.Add(mapCoordinate);
                    }

                }
            }
            return mapCoordinates;
        }

        public List<Facility> GetAllFacilities()
        {
            List<Facility> facilities = new List<Facility>();
            Facility facility = new Facility();
            using (var dataAccess = new DataAccess.Repositories.FacilityRepository(appSettings.ConnectionString))
            {
                var _facilities = facility.ConvertToFacilities(dataAccess.GetFacilities());
                facilities.AddRange(_facilities);
            }
            return facilities;
        }

        public Facility GetFacilityById(int id, FacilityTypes facilityType)
        {
            Facility facility = new Facility();

            using (var dataAccess = new DataAccess.Repositories.FacilityRepository(appSettings.ConnectionString))
            {
                facility = facility.ConvertToFacility(dataAccess.GetFacilityById(id));

            }

            return facility;
        }

        public Facility CreateFacility(Facility facility)
        {
            using (var dataAccess = new DataAccess.Repositories.FacilityRepository(appSettings.ConnectionString))
            {
                facility.Id = dataAccess.AddFacility(facility.ConvertToFacility(facility));
            }
            return facility;
        }

        public Facility SaveFacility(string step, Facility facility)
        {
            facility.Land = SaveLand(facility.Land);
            facility.LandId = facility.Land.Id;
            
            facility.Finance = SaveFinance(facility.Finance);
            facility.FinanceId = facility.Finance.Id;
                        
           using (var dataAccess = new DataAccess.Repositories.FacilityRepository(appSettings.ConnectionString))
           {
                if (facility.Id == 0)
                {
                    facility.Id = dataAccess.AddFacility(facility.ConvertToFacility(facility));
                }
                else {
                    dataAccess.UpdateFacility(facility.ConvertToFacility(facility));
                }
            }
            
            facility.Improvements = SaveImprovement(facility.Improvements, facility.Id);
           
            return facility;
        }

        public void UpdateFacility(string step, Facility facility)
        {
            if (step.Trim().ToLower().Equals("land") || step.Trim().ToLower().Equals("facility"))
            {
                UpdateLand(facility.Land);
            }

            if (step.Trim().ToLower().Equals("finance") || step.Trim().ToLower().Equals("facility"))
            {
                UpdateFinance(facility.Finance);
            }

            if (step.Trim().ToLower().Equals("facility"))
            {
                using (var dataAccess = new DataAccess.Repositories.FacilityRepository(appSettings.ConnectionString))
                {
                    dataAccess.UpdateFacility(facility.ConvertToFacility(facility));
                }
            }

            if (step.Trim().ToLower().Equals("improvement") || step.Trim().ToLower().Equals("facility"))
            {
                UpdateImprovement(facility.Improvements);
            }
        }

        public Land SaveLand(Land land)
        {

            using (var dataAccess = new DataAccess.Repositories.LandRepository(appSettings.ConnectionString))
            {
                if (land.PropertyDescription.Id == 0)
                {
                    land.PropertyDescription.Id = dataAccess.AddPropertyDescription(land.PropertyDescription.ConvertPropertyDescription(land.PropertyDescription));
                    land.PropertyDescriptionId = land.PropertyDescription.Id;
                }
                else {
                    dataAccess.UpdatePropertyDescription(land.PropertyDescription.ConvertPropertyDescription(land.PropertyDescription));
                    land.PropertyDescriptionId = land.PropertyDescription.Id;
                }

                if (land.GeographicalLocation.Id == 0)
                {
                    land.GeographicalLocation.Id = dataAccess.AddGeographicalLocation(land.GeographicalLocation.ConvertGeographicalLocation(land.GeographicalLocation));
                    land.GeographicalLocationId = land.GeographicalLocation.Id;
                }
                else {
                    dataAccess.UpdateGeographicalLocation(land.GeographicalLocation.ConvertGeographicalLocation(land.GeographicalLocation));
                    land.GeographicalLocationId = land.GeographicalLocation.Id;
                }

                if (land.LeaseStatus.Id == 0)
                {
                    land.LeaseStatus.Id = dataAccess.AddLeaseStatus(land.LeaseStatus.ConvertLeaseStatus(land.LeaseStatus));
                    land.LeaseStatusId = land.LeaseStatus.Id;
                }
                else {
                    dataAccess.UpdateLeaseStatus(land.LeaseStatus.ConvertLeaseStatus(land.LeaseStatus));
                    land.LeaseStatusId = land.LeaseStatus.Id;
                }

                if (land.LandUseManagementDetail.Id == 0)
                {
                    land.LandUseManagementDetail.Id = dataAccess.AddLandUseManagementDetail(land.LandUseManagementDetail.ConvertLandUseManagementDetail(land.LandUseManagementDetail));
                    land.LandUseManagementDetailId = land.LandUseManagementDetail.Id;
                }
                else {
                    dataAccess.UpdateLandUseManagementDetail(land.LandUseManagementDetail.ConvertLandUseManagementDetail(land.LandUseManagementDetail));
                    land.LandUseManagementDetailId = land.LandUseManagementDetail.Id;
                }

                if (land.Id == 0)
                {
                    land.Id = dataAccess.AddLand(land.ConvertLand(land));
                }
                else {
                    dataAccess.UpdateLand(land.ConvertLand(land));
                }
            }
            return land;
        }

        public Finance SaveFinance(Finance finance)
        {

            using (var dataAccess = new DataAccess.Repositories.FinanceRepository(appSettings.ConnectionString))
            {
                if (finance.SecondaryInformationNote.Id == 0)
                {
                    finance.SecondaryInformationNote.Id = dataAccess.AddSecondaryInformationNote(finance.SecondaryInformationNote.ConvertToSecondaryInformationNote(finance.SecondaryInformationNote));
                    finance.SecondaryInformationNoteId = finance.SecondaryInformationNote.Id;
                }
                else {
                    dataAccess.UpdateSecondaryInformationNote(finance.SecondaryInformationNote.ConvertToSecondaryInformationNote(finance.SecondaryInformationNote));
                }

                if (finance.Valuation.Id == 0)
                {
                    finance.Valuation.Id = dataAccess.AddValuation(finance.Valuation.ConvertToValuation(finance.Valuation));
                    finance.ValuationId = finance.Valuation.Id;
                }
                else {
                    dataAccess.UpdateValuation(finance.Valuation.ConvertToValuation(finance.Valuation));
                }

                if (finance.Id == 0)
                {
                    finance.Id = dataAccess.AddFinance(finance.ConvertToFinance(finance));
                }
                else {
                    dataAccess.UpdateFinance(finance.ConvertToFinance(finance));
                }
            }
            return finance;
        }

        public List<Improvement> SaveImprovement(List<Improvement> improvements, int facilityId)
        {
            Improvement improvement = new Improvement();
            using (var dataAccess = new DataAccess.Repositories.ImprovementRepository(appSettings.ConnectionString))
            {
                foreach (var item in improvements)
                {
                    item.FacilityId = facilityId;
                    item.Id = dataAccess.AddImprovement(improvement.ConvertToImprovement(item));
                }
            }
            return improvements;
        }

        public void UpdateLand(Land land)
        {

            using (var dataAccess = new DataAccess.Repositories.LandRepository(appSettings.ConnectionString))
            {
                dataAccess.UpdatePropertyDescription(land.PropertyDescription.ConvertPropertyDescription(land.PropertyDescription));

                dataAccess.UpdateGeographicalLocation(land.GeographicalLocation.ConvertGeographicalLocation(land.GeographicalLocation));

                dataAccess.UpdateLeaseStatus(land.LeaseStatus.ConvertLeaseStatus(land.LeaseStatus));

                dataAccess.UpdateLandUseManagementDetail(land.LandUseManagementDetail.ConvertLandUseManagementDetail(land.LandUseManagementDetail));

                dataAccess.UpdateLand(land.ConvertLand(land));
            }
        }

        public void UpdateFinance(Finance finance)
        {

            using (var dataAccess = new DataAccess.Repositories.FinanceRepository(appSettings.ConnectionString))
            {
                dataAccess.UpdateSecondaryInformationNote(finance.SecondaryInformationNote.ConvertToSecondaryInformationNote(finance.SecondaryInformationNote));

                dataAccess.UpdateValuation(finance.Valuation.ConvertToValuation(finance.Valuation));

                dataAccess.UpdateFinance(finance.ConvertToFinance(finance));
            }
        }

        public void UpdateImprovement(List<Improvement> improvements)
        {
            Improvement improvement = new Improvement();
            using (var dataAccess = new DataAccess.Repositories.ImprovementRepository(appSettings.ConnectionString))
            {
                foreach (var item in improvements)
                {
                    if (item.Id == 0)
                    {
                        dataAccess.AddImprovement(improvement.ConvertToImprovement(item));
                    }
                    else
                    {
                        dataAccess.UpdateImprovement(improvement.ConvertToImprovement(item));
                    }
                }
            }
        }

        public bool DeleteFacility(int id)
        {
            Facility facility = new Facility();
            bool isDeleted = false;
            using (var dataAccess = new DataAccess.Repositories.FacilityRepository(appSettings.ConnectionString))
            {
                var dbFacility = dataAccess.GetFacilityById(id);
                dbFacility.Status = "Deleted";
                dbFacility.ModifiedDate = DateTime.Now;
                dataAccess.UpdateFacility(dbFacility);
                isDeleted = true;
            }
            return isDeleted;
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
