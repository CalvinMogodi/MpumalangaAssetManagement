using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class Project
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string District { get; set; }
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string PlannedDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PracticalCompletionDate { get; set; }
        public string ScopeofWork { get; set; }
        public bool HasFinancials { get; set; }
        public bool HasParentProject { get; set; }
        public int? ParentProjectId { get; set; }
        public double? Amount { get; set; }
        public long? Account { get; set; }
        public string ManagedBy { get; set; }
        public string EmployeeName { get; set; }
        public long? EmployeeNumber { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string BusinessName { get; set; }
        public string BusinessRegNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
