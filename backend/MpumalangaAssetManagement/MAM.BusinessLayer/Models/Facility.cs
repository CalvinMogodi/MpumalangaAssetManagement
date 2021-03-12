using EnumsNET;
using MAM.BusinessLayer.Models.Enums;
using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileReference { get; set; }        
        public string Type { get; set; }
        public string ClientCode { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int LandId { get; set; }
        public int FinanceId { get; set; }
        public FacilityTypes FacilityTypes { get; set; }
        public FacilityStatus FacilityStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Land Land { get; set; }
        public Finance Finance { get; set; }
        public List<Improvement> Improvements { get; set; }

        public List<Facility> ConvertToFacilities(List<DataAccess.Tables.Facility> dwellingFacilities)
        {
            return dwellingFacilities.Select(f => new Facility()
            {
                Id = f.Id,
                FileReference = "D/" + f.Id,
                Name = f.Name,
                Type = f.Type,
                ClientCode = f.ClientCode,
                UserId = f.UserId,
                Status = f.Status,
                CreatedBy = f.CreatedBy,
                CreatedDate = f.CreatedDate,
                ModifiedBy = f.ModifiedBy,
                ModifiedDate = f.ModifiedDate
            }).ToList();
        }

        public Facility ConvertToFacility(DataAccess.Tables.Facility facility)
        {
            return new Facility()
            {
                Id = facility.Id,
                FileReference = facility.FileReference,
                Name = facility.Name,
                Type = facility.Type,
                ClientCode = facility.ClientCode,
                LandId = facility.LandId,
                FinanceId = facility.FinanceId,
                UserId = facility.FinanceId,
                Status = facility.Status,
                CreatedBy = facility.CreatedBy,
                CreatedDate = facility.CreatedDate,
                ModifiedBy = facility.ModifiedBy,
                ModifiedDate = facility.ModifiedDate,
            };
        }

        public DataAccess.Tables.Facility ConvertToFacility(Facility facility)
        {
            return new DataAccess.Tables.Facility()
            {
                Id = facility.Id,
                FileReference = facility.FileReference,
                Name = facility.Name,
                Type = facility.Type,
                ClientCode = facility.ClientCode,
                LandId = facility.LandId,
                FinanceId = facility.FinanceId,
                UserId = facility.UserId,
                Status = facility.Status,
                CreatedBy = facility.CreatedBy,
                CreatedDate = facility.CreatedDate,
                ModifiedBy = facility.ModifiedBy,
                ModifiedDate = facility.ModifiedDate,
            };
        }
    }   
}
