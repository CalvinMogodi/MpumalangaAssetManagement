using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Services
{
    public interface IHiringRegisterService
    {
        List<HiredProperty> GetHiredProperties();
        bool UpdateHiredProperty(HiredProperty hiredProperty);
        bool DeleteHiredProperty(HiredProperty hiredProperty);
        int AddHiredProperty(HiredProperty hiredProperty);
    }
    public class HiringRegisterService : IHiringRegisterService
    {
        private readonly AppSettings _appSettings;

        public HiringRegisterService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public List<HiredProperty> GetHiredProperties() {
            using var _hiringRegisterRepository = new HiringRegisterRepository(_appSettings);
            return _hiringRegisterRepository.GetHiredProperties();
        }
        public bool UpdateHiredProperty(HiredProperty hiredProperty) {
            using var _hiringRegisterRepository = new HiringRegisterRepository(_appSettings);
            return _hiringRegisterRepository.UpdateHiredProperty(hiredProperty);
        }
        public bool DeleteHiredProperty(HiredProperty hiredProperty) {
            using var _hiringRegisterRepository = new HiringRegisterRepository(_appSettings);
            return _hiringRegisterRepository.DeleteHiredProperty(hiredProperty);
        }
        public int AddHiredProperty(HiredProperty hiredProperty) {
            using var _hiringRegisterRepository = new HiringRegisterRepository(_appSettings);
            return _hiringRegisterRepository.AddHiredProperty(hiredProperty);
        }
    }
}
