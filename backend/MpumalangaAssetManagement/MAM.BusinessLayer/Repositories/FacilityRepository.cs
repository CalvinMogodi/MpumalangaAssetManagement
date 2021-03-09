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
                FacilityType facilityType = new FacilityType() {
                    Name = "Dwellings",
                    FacilityZonings = new List<FacilityZoning>()
                };
               
                var dwellingFacilities = dataAccess.GetDwellingFacilities();
                var zonings = dwellingFacilities.Select(d => d.Zoning.ToLower().Trim()).Distinct();
                foreach (var zoning in zonings)
                {
                    FacilityZoning facilityZoning = new FacilityZoning() {
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
                    FacilityZoning facilityZoning = new FacilityZoning() {
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
                FacilityType facilityType = new FacilityType() {
                    Name = "Non Residential Buildings",
                    FacilityZonings = new List<FacilityZoning>()
                };

                var nonResidentialFacilities = dataAccess.GetNonResidentialFacilities();
                var zonings = nonResidentialFacilities.Select(d => d.Zoning).Distinct();
                foreach (var zoning in zonings)
                {
                    FacilityZoning facilityZoning = new FacilityZoning() {
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
            List <DataAccess.Tables.DwellingFacility> dwellingFacilities = new List<DataAccess.Tables.DwellingFacility>();
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

        public List<FacilitySummaryChart> GetFacilitySummaries() {

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
            using (var dataAccess = new DataAccess.Repositories.DwellingFacilityRepository(appSettings.ConnectionString))
            {
               var dwellingFacilities = dataAccess.GetDwellingFacilities();
                foreach (var item in dwellingFacilities)
                {                    
                    if (!string.IsNullOrEmpty(item.GPSCoordinatesEast) && !string.IsNullOrEmpty(item.GPSCoordinatesSouth))
                    {
                        MapCoordinate mapCoordinate = new MapCoordinate() {
                            Longitude = item.GPSCoordinatesEast.Replace(",", "."),
                            Latitude = item.GPSCoordinatesSouth.Replace(",", "."),
                            Description = string.Format("Dwelling: {0} - {1}", item.ClientCode, item.Name),
                            FacilityId = item.Id,
                            FacilityType = FacilityTypes.Dwellings
                        };
                        mapCoordinates.Add(mapCoordinate);
                    }
                    
                }
            }

            using (var dataAccess = new DataAccess.Repositories.LandFacilityRepository(appSettings.ConnectionString))
            {
                var landFacilities = dataAccess.GetLandFacilities();
                foreach (var item in landFacilities)
                {
                    if (!string.IsNullOrEmpty(item.GPSCoordinatesEast) && !string.IsNullOrEmpty(item.GPSCoordinatesSouth))
                    {
                        MapCoordinate mapCoordinate = new MapCoordinate()
                        {
                            Longitude = item.GPSCoordinatesSouth,
                            Latitude = item.GPSCoordinatesEast,
                            Description = string.Format("Land: {0} - {1}", item.ClientCode, item.Name),
                            FacilityId = item.Id,
                            FacilityType = FacilityTypes.Land
                        };
                        mapCoordinates.Add(mapCoordinate);
                    }

                }
            }

            using (var dataAccess = new DataAccess.Repositories.NonResidentialFacilityRepository(appSettings.ConnectionString))
            {
                var nonResidentialFacilities = dataAccess.GetNonResidentialFacilities();
                foreach (var item in nonResidentialFacilities)
                {
                    if (!string.IsNullOrEmpty(item.GPSCoordinatesEast) && !string.IsNullOrEmpty(item.GPSCoordinatesSouth))
                    {
                        MapCoordinate mapCoordinate = new MapCoordinate()
                        {
                            Longitude = item.GPSCoordinatesSouth,
                            Latitude = item.GPSCoordinatesEast,
                            Description = string.Format("Non Residential: {0} - {1}", item.ClientCode, item.Name),
                            FacilityId = item.Id,
                            FacilityType = FacilityTypes.NonResidentialBuildings
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
            using (var dataAccess = new DataAccess.Repositories.DwellingFacilityRepository(appSettings.ConnectionString))
            {
                var _facilities = facility.ConvertDwellingToFacility(dataAccess.GetDwellingFacilities());
                facilities.AddRange(_facilities);
            }

            using (var dataAccess = new DataAccess.Repositories.LandFacilityRepository(appSettings.ConnectionString))
            {
                var _facilities = facility.ConvertLandToFacility(dataAccess.GetLandFacilities());
                facilities.AddRange(_facilities);
            }

            using (var dataAccess = new DataAccess.Repositories.NonResidentialFacilityRepository(appSettings.ConnectionString))
            {
                var _facilities = facility.ConvertNonResidentialToFacility(dataAccess.GetNonResidentialFacilities());
                facilities.AddRange(_facilities);
            }
            return facilities;
        }

        

        public Facility getFacilityById(int id, FacilityTypes facilityType)
        {
            Facility facility = new Facility();
            switch ((int)facilityType)
            {
                case 1:
                    using (var dataAccess = new DataAccess.Repositories.DwellingFacilityRepository(appSettings.ConnectionString))
                    {
                        facility = facility.ConvertDBFacilityToFacility(dataAccess.GetDwellingFacilityById(id), null, null);
                        break;
                    }
                case 2:
                    using (var dataAccess = new DataAccess.Repositories.LandFacilityRepository(appSettings.ConnectionString))
                    {
                        facility = facility.ConvertDBFacilityToFacility(null, dataAccess.GetLandFacilityById(id),  null);
                        break;
                    }
                case 3:
                    using (var dataAccess = new DataAccess.Repositories.NonResidentialFacilityRepository(appSettings.ConnectionString))
                    {
                        facility = facility.ConvertDBFacilityToFacility(null, null, dataAccess.GetNonResidentialFacilityById(id));
                        break;
                    }
            }            
            return facility;
        }

        public Facility CreateFacility(Facility facility)
        {
            switch ((int)facility.FacilityTypes)
            {
                case 1:
                    using (var dataAccess = new DataAccess.Repositories.DwellingFacilityRepository(appSettings.ConnectionString))
                    {
                        facility.Id = dataAccess.AddDwellingFacility(facility.ConvertToDwellingFacility(facility));                       
                        break;
                    }
                case 2:
                    using (var dataAccess = new DataAccess.Repositories.LandFacilityRepository(appSettings.ConnectionString))
                    {
                        facility.Id = dataAccess.AddLandFacility(facility.ConvertToLandFacility(facility));
                        break;
                    }
                case 3:
                    using (var dataAccess = new DataAccess.Repositories.NonResidentialFacilityRepository(appSettings.ConnectionString))
                    {
                        facility.Id = dataAccess.AddNonResidentialFacilities(facility.ConvertToNonResidentialFacility(facility));
                        break;
                    }
            }
            return facility;
        }

        public bool UpdateFacility(Facility facility)
        {
            bool isUpdated = false;
            switch ((int)facility.FacilityTypes)
            {
                case 1:
                    using (var dataAccess = new DataAccess.Repositories.DwellingFacilityRepository(appSettings.ConnectionString))
                    {
                        facility.Id = dataAccess.AddDwellingFacility(facility.ConvertToDwellingFacility(facility));
                        break;
                    }
                case 2:
                    using (var dataAccess = new DataAccess.Repositories.LandFacilityRepository(appSettings.ConnectionString))
                    {
                        facility.Id = dataAccess.AddLandFacility(facility.ConvertToLandFacility(facility));
                        break;
                    }
                case 3:
                    using (var dataAccess = new DataAccess.Repositories.NonResidentialFacilityRepository(appSettings.ConnectionString))
                    {
                        facility.Id = dataAccess.AddNonResidentialFacilities(facility.ConvertToNonResidentialFacility(facility));
                        break;
                    }
            }
            return isUpdated = true;
        }

        public bool DeleteFacility(Facility facility)
        {
            bool isDeleted = false;
            facility.Status = "Deleted";
            switch (facility.FacilityType)
            {
                case "Dwelling":
                    using (var dataAccess = new DataAccess.Repositories.DwellingFacilityRepository(appSettings.ConnectionString))
                    {                        
                        dataAccess.UpdateDwellingFacility(facility.ConvertToDwellingFacility(facility));
                        break;
                    }
                case "Land":
                    using (var dataAccess = new DataAccess.Repositories.LandFacilityRepository(appSettings.ConnectionString))
                    {
                        dataAccess.UpdateLandFacility(facility.ConvertToLandFacility(facility));
                        break;
                    }
                case "NonResidential":
                    using (var dataAccess = new DataAccess.Repositories.NonResidentialFacilityRepository(appSettings.ConnectionString))
                    {
                        dataAccess.UpdateNonResidentialFacilities(facility.ConvertToNonResidentialFacility(facility));
                        break;
                    }
            }
            return isDeleted = true;
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
