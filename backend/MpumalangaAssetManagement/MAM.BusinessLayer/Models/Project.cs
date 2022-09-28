using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int DistrictId { get; set; }
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string PlannedDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PracticalCompletionDate { get; set; }
        public string ScopeofWork { get; set; }
        public bool HasFinancials { get; set; }
        public bool HasParentProject { get; set; }
        public int? ParentProjectId { get; set; }
        public int? Amount { get; set; }
        public string Account { get; set; }
        public string ManagedBy { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNumber { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string BusinessName { get; set; }
        public string BusinessRegNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public bool? IsDeleted { get; set; }

        public List<Project> ConvertToProjects(List<DataAccess.Tables.Project> projects)
        {
            return projects.Select(f => new Project()
            {
                Id = f.Id,
                OrderNumber = f.OrderNumber,
                DistrictId = f.DistrictId,
                PropertyId = f.PropertyId,
                Name = f.Name,
                PlannedDuration = f.PlannedDuration,
                StartDate = f.StartDate,
                PracticalCompletionDate = f.PracticalCompletionDate,
                ScopeofWork = f.ScopeofWork,
                HasFinancials = f.HasFinancials,
                HasParentProject = f.HasParentProject,
                ParentProjectId = f.ParentProjectId,
                Amount = f.Amount,
                Account = f.Account,
                ManagedBy = f.ManagedBy,
                EmployeeName = f.EmployeeName,
                EmployeeNumber = f.EmployeeNumber,
                ContactName = f.ContactName,
                ContactNumber = f.ContactNumber,
                BusinessName = f.BusinessName,
                BusinessRegNumber = f.BusinessRegNumber,
                CreatedDate = f.CreatedDate,
                ModifiedDate = f.ModifiedDate,
               // Suppliers = f.Suppliers,
                IsDeleted = f.IsDeleted
            }).ToList();
        }

        public DataAccess.Tables.Project ConvertToProjectTable(Project project)
        {
            return new DataAccess.Tables.Project() {
                Id = project.Id,
                OrderNumber = project.OrderNumber,
                DistrictId = project.DistrictId,
                PropertyId = project.PropertyId,
                Name = project.Name,
                PlannedDuration = project.PlannedDuration,
                StartDate = project.StartDate,
                PracticalCompletionDate = project.PracticalCompletionDate,
                ScopeofWork = project.ScopeofWork,
                HasFinancials = project.HasFinancials,
                HasParentProject = project.HasParentProject,
                ParentProjectId = project.ParentProjectId,
                Amount = project.Amount,
                Account = project.Account,
                ManagedBy = project.ManagedBy,
                EmployeeName = project.EmployeeName,
                EmployeeNumber = project.EmployeeNumber,
                ContactName = project.ContactName,
                ContactNumber = project.ContactNumber,
                BusinessName = project.BusinessName,
                BusinessRegNumber = project.BusinessRegNumber,
                CreatedDate = project.CreatedDate,
                ModifiedDate = project.ModifiedDate,
                // Suppliers = project.Suppliers,
                IsDeleted = project.IsDeleted
            };
        }
    }
}
