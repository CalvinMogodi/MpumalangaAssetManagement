using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Services
{
    public interface IFaultService
    {
        List<Fault> GetFaults();
        bool UpdateFault(Fault fault);
        bool DeleteFault(Fault fault);
        int AddFault(Fault fault);
        Fault GetFaultByReferenceNo(string referenceNo);
    }
    
    public class FaultService: IFaultService
    {
        private readonly AppSettings _appSettings;

        public FaultService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public List<Fault> GetFaults()
        {
            using var _FaultRepository = new FaultRepository(_appSettings);
            return _FaultRepository.GetFaults();
        }
        public bool UpdateFault(Fault fault)
        {
            using var _FaultRepository = new FaultRepository(_appSettings);
            return _FaultRepository.UpdateFault(fault);
        }
        public bool DeleteFault(Fault fault)
        {
            using var _FaultRepository = new FaultRepository(_appSettings);
            return _FaultRepository.DeleteFault(fault);
        }
        public int AddFault(Fault fault)
        {
            using var _FaultRepository = new FaultRepository(_appSettings);
            return _FaultRepository.AddFault(fault);
        }

        public Fault GetFaultByReferenceNo(string referenceNo)
        {
            using var _FaultRepository = new FaultRepository(_appSettings);
            return _FaultRepository.GetFaultByReferenceNo(referenceNo);
        }
    }
}
