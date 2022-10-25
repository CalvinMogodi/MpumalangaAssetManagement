using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class ProjectSupplier
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<ProjectSupplier> ConvertToProjectSuppliers(List<DataAccess.Tables.ProjectSupplier> projectSuppliers)
        {

            return projectSuppliers.Select(ps => new ProjectSupplier()
            {
                Id = ps.Id,
                ProjectId = ps.ProjectId,
                SupplierId = ps.SupplierId,
                Supplier = new Supplier().ConvertToSupplier(ps.Supplier)
            }).ToList();
        }

        public DataAccess.Tables.ProjectSupplier ConvertToProjectSupplierTable(ProjectSupplier projectSupplier)
        {
            return new DataAccess.Tables.ProjectSupplier()
            {
                Id = projectSupplier.Id,
                ProjectId = projectSupplier.ProjectId,
                SupplierId = projectSupplier.SupplierId,
            };
        }
    }
}
