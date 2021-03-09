using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Models.Enums;
using MAM.BusinessLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Services
{
    public interface IFacilityService
    {
        List<DashboardWedge> GetDashboardWedges();
        List<FacilityType> GetFacilityZonings();
        List<FacilitySummaryChart> GetFacilitySummaries();
        List<MapCoordinate> GetMapCoordinates();
        List<Facility> GetAllFacilities();
        Facility GetFacilityById(int id, FacilityTypes facilityType);
        Facility CreateFacility(Facility facility);
        bool UpdateFacility(Facility facility);
        bool DeleteFacility(Facility facility);
    }

    public class FacilityService : IFacilityService
    {
        private readonly AppSettings _appSettings;

        public FacilityService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public List<DashboardWedge> GetDashboardWedges() {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.GetDashboardWedges();
            }
        }

        public List<FacilityType> GetFacilityZonings() {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.GetFacilityZonings();
            }
        }

        public List<FacilitySummaryChart> GetFacilitySummaries()
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.GetFacilitySummaries();
            }
        }

        public List<MapCoordinate> GetMapCoordinates()
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.GetMapCoordinates();
            }
        }

        public List<Facility> GetAllFacilities()
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.GetAllFacilities();
            }
        }

        public Facility GetFacilityById(int id, FacilityTypes facilityType)
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.getFacilityById(id, facilityType);
            }
        }

        public Facility CreateFacility(Facility facility)
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.CreateFacility(facility);
            }
        }

        public bool UpdateFacility(Facility facility)
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.UpdateFacility(facility);
            }
        }

        public bool DeleteFacility(Facility facility)
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.DeleteFacility(facility);
            }
        }
    }
}
