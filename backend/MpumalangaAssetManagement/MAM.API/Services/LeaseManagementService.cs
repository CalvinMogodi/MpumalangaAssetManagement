using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Services
{
    public interface ILeaseManagementService
    {
        List<LeasedProperty> GetLeasedProperties();
    }

    public class LeaseManagementService : ILeaseManagementService
    {
        private readonly AppSettings _appSettings;

        public LeaseManagementService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public List<LeasedProperty> GetLeasedProperties()
        {
            using var _leaseManagementRepository = new LeaseManagementRepository(_appSettings);
            return _leaseManagementRepository.GetLeasedProperties();
        }

    }
}
