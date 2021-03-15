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
                FileReference = "D/" + f.Id,
                Name = f.Name,
                Type = f.Type,
                ClientCode = f.ClientCode,
                UserId = f.UserId,
                Status = f.Status,
                CreatedBy = f.CreatedBy,
                CreatedDate = f.CreatedDate,
                ModifiedBy = f.ModifiedBy,
                ModifiedDate = f.ModifiedDate,
                Land = new Land() {
                    Id = f.Land.Id,
                    DeedsOffice = f.Land.DeedsOffice,
                    AssetClass = f.Land.AssetClass,
                    AssetType = f.Land.AssetType,
                    GeographicalLocationId = f.Land.GeographicalLocationId,
                    PropertyDescriptionId = f.Land.PropertyDescriptionId,
                    LandUseManagementDetailId = f.Land.LandUseManagementDetailId,
                    LeaseStatusId = f.Land.LeaseStatusId,
                    GeographicalLocation = gl.ConvertGeographicalLocation(f.Land.GeographicalLocation), 
                    PropertyDescription = pd.ConvertPropertyDescription(f.Land.PropertyDescription),
                    LandUseManagementDetail = lumd.ConvertLandUseManagementDetail(f.Land.LandUseManagementDetail),
                    LeaseStatus = ls.ConvertLeaseStatus(f.Land.LeaseStatus),
                },
                Finance = new Finance() {
                    Id = f.Finance.Id,
                    LandUseClass = f.Finance.LandUseClass,
                    NatureofAsset = f.Finance.NatureofAsset,
                    SecondaryInformationNoteId = f.Finance.SecondaryInformationNoteId,
                    ValuationId = f.Finance.ValuationId,
                    SecondaryInformationNote = sin.ConvertToSecondaryInformationNote(f.Finance.SecondaryInformationNote),
                    Valuation = v.ConvertToValuation(f.Finance.Valuation),
                },
                Improvements = i.ConvertToImprovements(f.Improvements)
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
                UserId = facility.UserId,
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
