using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IProjectSupplier
    {
        int AddProjectSupplier(ProjectSupplier projectSupplier);
        void UpdateProjectSupplier(ProjectSupplier projectSupplier);
        List<ProjectSupplier> GetProjectSuppliers();
        ProjectSupplier GetProjectSupplierById(int id);
    }
}
