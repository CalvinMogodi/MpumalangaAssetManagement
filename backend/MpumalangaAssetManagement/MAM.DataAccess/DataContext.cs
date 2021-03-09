using MAM.DataAccess.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess
{
    public class DataContext : DbContext
    {
        private string _connectionString { get; set; }

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<LandFacility> LandFacilities { get; set; }
        public DbSet<NonResidentialFacility> NonResidentialFacilities { get; set; }
        public DbSet<DwellingFacility> DwellingFacilities { get; set; }
        public DbSet<FacilityStatement> FacilityStatements { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<GeographicalLocation> GeographicalLocations { get; set; }
        public DbSet<PropertyDescription> PropertyDescriptions { get; set; }
        public DbSet<LandUseManagementDetail> LandUseManagementDetails { get; set; }
        public DbSet<LeaseStatus> LeaseStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
