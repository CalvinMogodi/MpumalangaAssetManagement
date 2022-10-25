using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public DataAccess.Tables.Supplier ConvertToSupplierTable(Supplier supplier)
        {
            return new DataAccess.Tables.Supplier()
            {
                Id = supplier.Id,
                CompanyName = supplier.CompanyName,
                CompanyNumber = supplier.CompanyNumber,
                ContactName = supplier.ContactName,
                ContactNumber = supplier.ContactNumber,
                CreatedDate = supplier.CreatedDate,
                ModifiedDate = supplier.ModifiedDate
            };
        }

        public Supplier ConvertToSupplier(DataAccess.Tables.Supplier supplier)
        {
            return new Supplier()
            {
                Id = supplier.Id,
                CompanyName = supplier.CompanyName,
                CompanyNumber = supplier.CompanyNumber,
                ContactName = supplier.ContactName,
                ContactNumber = supplier.ContactNumber,
                CreatedDate = supplier.CreatedDate,
                ModifiedDate = supplier.ModifiedDate
            };
        }

        public List<Supplier> ConvertToSuppliers(List<DataAccess.Tables.Supplier> suppliers)
        {
            return suppliers.Select(f => new Supplier()
            {
                Id = f.Id,
                CompanyName = f.CompanyName,
                CompanyNumber = f.CompanyNumber,
                ContactName = f.ContactName,
                ContactNumber = f.ContactNumber,
                CreatedDate = f.CreatedDate,
                ModifiedDate = f.ModifiedDate
            }).ToList();
        }        
    }
}
