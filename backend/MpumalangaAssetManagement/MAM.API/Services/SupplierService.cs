using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Services
{
    public interface ISupplierService
    {
        List<Supplier> AddSuppliers(List<Supplier> suppliers);
        List<Supplier> GetSuppliers();
    }
    public class SupplierService : ISupplierService
    {
        private readonly AppSettings _appSettings;

        public SupplierService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public List<Supplier> AddSuppliers(List<Supplier> suppliers){
            using (var _supplierRepository = new SupplierRepository(_appSettings))
            {
                return _supplierRepository.AddSuppliers(suppliers);
            }
        }

        public List<Supplier> GetSuppliers()
        {
            using (var _supplierRepository = new SupplierRepository(_appSettings))
            {
                return _supplierRepository.GetSuppliers();
            }
        }
    }
}
