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
        public string VestedType { get; set; }
        public string ClientCode { get; set; }
        public string UserDepartment { get; set; }
        public string Status { get; set; }
        public int? LandId { get; set; }
        public int? FinanceId { get; set; }
        public int? ApproverId { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? VerifierId { get; set; }
        public DateTime? SingedOffDate { get; set; }
        public FacilityTypes FacilityTypes { get; set; }
        public FacilityStatus FacilityStatus { get; set; }
        public int CapturerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifierId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Land Land { get; set; }
        public Finance Finance { get; set; }
        public List<Improvement> Improvements { get; set; }
        public virtual User Verifier { get; set; }
        public virtual User Approver { get; set; }
        public virtual User Capturer { get; set; }

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
                VestedType = f.VestedType,
                ClientCode = f.ClientCode,
                CapturerId = f.CapturerId,
                Status = f.Status,
                UserDepartment = f.UserDepartment,
                ApproverId = f.ApproverId,
                VerifierId = f.VerifierId,
                CreatedDate = f.CreatedDate,
                ModifierId = f.ModifierId,
                ApprovedDate = f.ApprovedDate,
                SingedOffDate = f.SingedOffDate,
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
                } : new Land(),
                Finance = f.Finance != null ? new Finance()
                {
                    Id = f.Finance.Id,
                    LandUseClass = f.Finance.LandUseClass,
                    NatureofAsset = f.Finance.NatureofAsset,
                    SecondaryInformationNoteId = f.Finance.SecondaryInformationNoteId,
                    ValuationId = f.Finance.ValuationId,
                    SecondaryInformationNote = f.Finance.SecondaryInformationNote != null ? sin.ConvertToSecondaryInformationNote(f.Finance.SecondaryInformationNote) : new SecondaryInformationNote(),
                    Valuation = f.Finance.Valuation != null ? v.ConvertToValuation(f.Finance.Valuation) : new Valuation(),
                } : new Finance(),
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
                VestedType = facility.VestedType,
                ClientCode = facility.ClientCode,
                CapturerId = facility.CapturerId,
                Status = facility.Status,
                VerifierId = facility.VerifierId,
                ApproverId = facility.ApproverId,
                CreatedDate = facility.CreatedDate,
                ApprovedDate = facility.ApprovedDate,
                SingedOffDate = facility.SingedOffDate,
                ModifierId = facility.ModifierId,
                ModifiedDate = facility.ModifiedDate,
                Land = new Land()
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
                } : new Finance(),
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
                VestedType= facility.VestedType,
                ClientCode = facility.ClientCode,
                Survey = facility.Survey,
                LandId = facility.LandId,
                FinanceId = facility.FinanceId,
                CapturerId = facility.CapturerId,
                ApproverId = facility.ApproverId,
                Status = facility.Status,
                VerifierId = facility.VerifierId,
                ApprovedDate = facility.ApprovedDate,
                SingedOffDate = facility.SingedOffDate,
                CreatedDate = facility.CreatedDate,
                ModifierId = facility.ModifierId,
                ModifiedDate = facility.ModifiedDate,
            };
        }
    }   
}
