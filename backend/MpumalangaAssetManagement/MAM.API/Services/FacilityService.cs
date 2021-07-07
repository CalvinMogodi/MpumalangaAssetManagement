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
        List<Facility> GetAssetRegisterFacilities();
        List<Facility> GetProperties(string userDepartment);
        Facility GetFacilityById(int id, FacilityTypes facilityType);
        Facility SaveFacility(string step, Facility facility);
        bool UpdateFacility(string step, Facility facility);
        bool DeleteFacility(int id);
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

        public List<Facility> GetAssetRegisterFacilities() {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.GetAssetRegisterFacilities();
            }
        }

        public List<Facility> GetProperties(string userDepartment)
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.GetProperties(userDepartment);
            }
        }

        public Facility GetFacilityById(int id, FacilityTypes facilityType)
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.GetFacilityById(id, facilityType);
            }
        }

        public Facility SaveFacility(string step, Facility facility)
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.SaveFacility(step, facility);
            }
        }

        public bool UpdateFacility(string step, Facility facility)
        {
            bool isUpdated = false;
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                _facilityRepository.UpdateFacility(step, facility);
                isUpdated = true;
            }
            return isUpdated;
        }

        public bool DeleteFacility(int id)
        {
            using (var _facilityRepository = new FacilityRepository(_appSettings))
            {
                return _facilityRepository.DeleteFacility(id);
            }
        }
    }
}
