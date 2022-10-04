using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface ISupplier
    {
        int AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        List<Supplier> GetSuppliers();
        Supplier GetSupplierById(int id);
    }
}
