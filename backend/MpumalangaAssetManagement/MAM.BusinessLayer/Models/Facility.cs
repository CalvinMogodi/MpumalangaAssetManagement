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
        public string Survey { get; set; }
        public string Type { get; set; }
        public string ClientCode { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int? LandId { get; set; }
        public int? FinanceId { get; set; }
        public FacilityTypes FacilityTypes { get; set; }
        public FacilityStatus FacilityStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Land Land { get; set; }
        public Finance Finance { get; set; }
        public List<Improvement> Improvements { get; set; }

        public List<Facility> ConvertToFacilities(List<DataAccess.Tables.Facility> facilities)
        {
            GeographicalLocation gl = new GeographicalLocation();
            PropertyDescription pd = new PropertyDescription();
            LandUseManagementDetail lumd = new LandUseManagementDetail();
            LeaseStatus ls = new LeaseStatus();
            SecondaryInformationNote sin = new SecondaryInformationNote();
            Improvement i = new Improvement();
            Valuation v = new Valuation();
            return facilities.Select(f => new Facility()
            {
                Id = f.Id,
                FileReference = f.FileReference,
                Name = f.Name,
                Type = f.Type,
                ClientCode = f.ClientCode,
                UserId = f.UserId,
                Status = f.Status,
                CreatedBy = f.CreatedBy,
                CreatedDate = f.CreatedDate,
                ModifiedBy = f.ModifiedBy,
                ModifiedDate = f.ModifiedDate,
                Land = f.Land != null ? new Land()
                {
                    Id = f.Land.Id,
                    DeedsOffice = f.Land.DeedsOffice,
                    Class = f.Land.Class,
                    Type = f.Land.Type,
                    GeographicalLocationId = f.Land.GeographicalLocationId,
                    PropertyDescriptionId = f.Land.PropertyDescriptionId,
                    LandUseManagementDetailId = f.Land.LandUseManagementDetailId,
                    LeaseStatusId = f.Land.LeaseStatusId,
                    GeographicalLocation = f.Land.GeographicalLocation != null ? gl.ConvertGeographicalLocation(f.Land.GeographicalLocation) : gl,
                    PropertyDescription = f.Land.PropertyDescription != null ? pd.ConvertPropertyDescription(f.Land.PropertyDescription) : pd,
                    LandUseManagementDetail = f.Land.LandUseManagementDetail != null ? lumd.ConvertLandUseManagementDetail(f.Land.LandUseManagementDetail) : new LandUseManagementDetail(),
                    LeaseStatus = f.Land.LeaseStatus != null ? ls.ConvertLeaseStatus(f.Land.LeaseStatus) : new LeaseStatus(),
                } : new Land() {
                    GeographicalLocation = new GeographicalLocation(),
                    PropertyDescription = new PropertyDescription(),
                    LandUseManagementDetail = new LandUseManagementDetail(),
                    LeaseStatus = new LeaseStatus()
                },
                Finance = f.Finance != null ? new Finance()
                {
                    Id = f.Finance.Id,
                    LandUseClass = f.Finance.LandUseClass,
                    NatureofAsset = f.Finance.NatureofAsset,
                    SecondaryInformationNoteId = f.Finance.SecondaryInformationNoteId,
                    ValuationId = f.Finance.ValuationId,
                    SecondaryInformationNote = f.Finance.SecondaryInformationNote != null ? sin.ConvertToSecondaryInformationNote(f.Finance.SecondaryInformationNote) : new SecondaryInformationNote(),
                    Valuation = f.Finance.Valuation != null ? v.ConvertToValuation(f.Finance.Valuation) : new Valuation(),
                } : new Finance()
                {
                    SecondaryInformationNote = new SecondaryInformationNote(),
                    Valuation = new Valuation()
                },
                Improvements = f.Improvements != null ? i.ConvertToImprovements(f.Improvements) : new List<Improvement>()
            }).ToList();
        }

        public Facility ConvertToFacility(DataAccess.Tables.Facility facility)
        {
            GeographicalLocation gl = new GeographicalLocation();
            PropertyDescription pd = new PropertyDescription();
            LandUseManagementDetail lumd = new LandUseManagementDetail();
            LeaseStatus ls = new LeaseStatus();
            SecondaryInformationNote sin = new SecondaryInformationNote();
            Improvement i = new Improvement();
            Valuation v = new Valuation();

            return new Facility()
            {
                Id = facility.Id,
                FileReference = facility.FileReference,
                Survey = facility.Survey,
                Name = facility.Name,
                Type = facility.Type,
                ClientCode = facility.ClientCode,
                UserId = facility.UserId,
                Status = facility.Status,
                CreatedBy = facility.CreatedBy,
                CreatedDate = facility.CreatedDate,
                ModifiedBy = facility.ModifiedBy,
                ModifiedDate = facility.ModifiedDate,
                Land = facility.Land != null ? new Land()
                {
                    Id = facility.Land.Id,
                    DeedsOffice = facility.Land.DeedsOffice,
                    Class = facility.Land.Class,
                    Type = facility.Land.Type,
                    GeographicalLocationId = facility.Land.GeographicalLocationId,
                    PropertyDescriptionId = facility.Land.PropertyDescriptionId,
                    LandUseManagementDetailId = facility.Land.LandUseManagementDetailId,
                    LeaseStatusId = facility.Land.LeaseStatusId,
                    GeographicalLocation = facility.Land.GeographicalLocation != null ? gl.ConvertGeographicalLocation(facility.Land.GeographicalLocation) : gl,
                    PropertyDescription = facility.Land.PropertyDescription != null ? pd.ConvertPropertyDescription(facility.Land.PropertyDescription) : pd,
                    LandUseManagementDetail = facility.Land.LandUseManagementDetail != null ? lumd.ConvertLandUseManagementDetail(facility.Land.LandUseManagementDetail) : new LandUseManagementDetail(),
                    LeaseStatus = facility.Land.LeaseStatus != null ? ls.ConvertLeaseStatus(facility.Land.LeaseStatus) : new LeaseStatus(),
                } : new Land()
                {
                    GeographicalLocation = new GeographicalLocation(),
                    PropertyDescription = new PropertyDescription(),
                    LandUseManagementDetail = new LandUseManagementDetail(),
                    LeaseStatus = new LeaseStatus()
                },
                Finance = facility.Finance != null ? new Finance()
                {
                    Id = facility.Finance.Id,
                    LandUseClass = facility.Finance.LandUseClass,
                    NatureofAsset = facility.Finance.NatureofAsset,
                    SecondaryInformationNoteId = facility.Finance.SecondaryInformationNoteId,
                    ValuationId = facility.Finance.ValuationId,
                    SecondaryInformationNote = facility.Finance.SecondaryInformationNote != null ? sin.ConvertToSecondaryInformationNote(facility.Finance.SecondaryInformationNote) : new SecondaryInformationNote(),
                    Valuation = facility.Finance.Valuation != null ? v.ConvertToValuation(facility.Finance.Valuation) : new Valuation(),
                } : new Finance() { 
                SecondaryInformationNote = new SecondaryInformationNote(),
                Valuation = new Valuation()
                },
                Improvements = facility.Improvements != null ? i.ConvertToImprovements(facility.Improvements) : new List<Improvement>()
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
                Survey = facility.Survey,
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
