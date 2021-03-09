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
        public string FileReference { get; set; }
        public string Name { get; set; }
        public string ClientCode { get; set; }
        public string PropType { get; set; }
        public string Parcel { get; set; }
        public string Portion { get; set; }
        public string FarmName { get; set; }
        public string LandLoc { get; set; }
        public string Type { get; set; }
        public string ValuationDate { get; set; }
        public string SGDiagram { get; set; }
        public string AreaHA { get; set; }
        public string RegOwner { get; set; }
        public string OwnershipCategory { get; set; }
        public string Zoning { get; set; }
        public string RegDivision { get; set; }
        public string UserDept { get; set; }
        public string ConditionRating { get; set; }
        public string IntendUseOfTheProperty { get; set; }
        public string CurrentUse { get; set; }
        public MapCoordinate MapCoordinate { get; set; }
        public string VestingInformation { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public string FacilityType { get; set; }
        public FacilityTypes FacilityTypes { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public List<Facility> ConvertDwellingToFacility(List<DwellingFacility> dwellingFacilities)
        {
            return dwellingFacilities.Select(f => new Facility() { Id = f.Id,
                FileReference = "D/" + f.Id,
                Name = f.Name,
                ClientCode = f.ClientCode,
                PropType = f.PropType,
                Parcel = f.Parcel,
                Portion = f.Portion,
                FarmName = f.FarmName,
                LandLoc = f.LandLoc,
                Type = f.Type,
                ValuationDate = f.ValuationDate.ToString(),
                SGDiagram = f.SGDiagram,
                AreaHA = f.AreaHA,
                RegOwner = f.RegOwner,
                OwnershipCategory = f.OwnershipCategory,
                Zoning = f.Zoning,
                RegDivision = f.RegDivision,
                UserDept = f.UserDept,
                ConditionRating = f.ConditionRating,
                IntendUseOfTheProperty = f.IntendUseOfTheProperty,
                CurrentUse = f.CurrentUse,
                FacilityType = "Dwelling",
                MapCoordinate = new MapCoordinate() {
                    Longitude = f.GPSCoordinatesEast.Replace(",", "."),
                    Latitude = f.GPSCoordinatesSouth.Replace(",", "."),
                },
                VestingInformation = f.VestingInformation,
                Comments = f.Comments,
                UserId = f.UserId,
                Status = ((FacilityStatus)f.Status).AsString(EnumFormat.Description),
                CreatedBy = f.CreatedBy,
                CreatedDate = f.CreatedDate,
                ModifiedBy = f.ModifiedBy,
                ModifiedDate = f.ModifiedDate
            }).ToList();
        }

        public List<Facility> ConvertLandToFacility(List<LandFacility> landFacilities)
        {
            return landFacilities.Select(f => new Facility()
            {
                Id = f.Id,
                FileReference = "L/" + f.Id,
                Name = f.Name,
                ClientCode = f.ClientCode,
                PropType = f.PropType,
                Parcel = f.Parcel,
                Portion = f.Portion,
                FarmName = f.FarmName,
                LandLoc = f.LandLoc,
                Type = f.Type,
                ValuationDate = f.ValuationDate,
                SGDiagram = f.SGDiagram,
                AreaHA = f.AreaHA,
                RegOwner = f.RegOwner,
                OwnershipCategory = f.OwnershipCategory,
                Zoning = f.Zoning,
                RegDivision = f.RegDivision,
                UserDept = f.UserDept,
                ConditionRating = f.ConditionRating,
                IntendUseOfTheProperty = f.IntendUseOfTheProperty,
                CurrentUse = f.CurrentUse,
                FacilityType = "Land",
                MapCoordinate = new MapCoordinate()
                {
                    Longitude = f.GPSCoordinatesEast.Replace(",", "."),
                    Latitude = f.GPSCoordinatesSouth.Replace(",", "."),
                },
                VestingInformation = f.VestingInformation,
                Comments = f.Comments,
                UserId = f.UserId,
                Status = ((FacilityStatus)f.Status).AsString(EnumFormat.Description),
                CreatedBy = f.CreatedBy,
                CreatedDate = f.CreatedDate,
                ModifiedBy = f.ModifiedBy,
                ModifiedDate = f.ModifiedDate
            }).ToList();
        }

        public List<Facility> ConvertNonResidentialToFacility(List<NonResidentialFacility> nonResidentialFacilities)
        {
            return nonResidentialFacilities.Select(f => new Facility()
            {
                Id = f.Id,
                FileReference = "NR/" + f.Id,
                Name = f.Name,
                ClientCode = f.ClientCode,
                PropType = f.PropType,
                Parcel = f.Parcel,
                Portion = f.Portion,
                FarmName = f.FarmName,
                LandLoc = f.LandLoc,
                Type = f.Type,
                ValuationDate = f.ValuationDate,
                SGDiagram = f.SGDiagram,
                AreaHA = f.AreaHA,
                RegOwner = f.RegOwner,
                OwnershipCategory = f.OwnershipCategory,
                Zoning = f.Zoning,
                RegDivision = f.RegDivision,
                UserDept = f.UserDept,
                ConditionRating = f.ConditionRating,
                IntendUseOfTheProperty = f.IntendUseOfTheProperty,
                CurrentUse = f.CurrentUse,
                FacilityType = "NonResidential",
                MapCoordinate = new MapCoordinate()
                {
                    Longitude = f.GPSCoordinatesEast.Replace(",", "."),
                    Latitude = f.GPSCoordinatesSouth.Replace(",", "."),
                },
                VestingInformation = f.VestingInformation,
                Comments = f.Comments,
                UserId = f.UserId,
                Status = ((FacilityStatus)f.Status).AsString(EnumFormat.Description),
                CreatedBy = f.CreatedBy,
                CreatedDate = f.CreatedDate,
                ModifiedBy = f.ModifiedBy,
                ModifiedDate = f.ModifiedDate
            }).ToList();
        }

        public Facility ConvertDBFacilityToFacility(DwellingFacility dFacility, LandFacility lFacility, NonResidentialFacility nrFacility)
        {
            return new Facility()
            {
                Id = dFacility != null ? dFacility.Id : lFacility != null ? lFacility.Id : nrFacility.Id,
                FileReference = dFacility != null ? "D/" + dFacility.Id : lFacility != null ? "L/" + lFacility.Id : "NR/" + nrFacility.Id,            
                Name = dFacility != null ? dFacility.Name : lFacility != null ? lFacility.Name : nrFacility.Name,
                ClientCode = dFacility != null ? dFacility.ClientCode : lFacility != null ? lFacility.ClientCode : nrFacility.ClientCode,
                PropType = dFacility != null ? dFacility.PropType : lFacility != null ? lFacility.PropType : nrFacility.PropType,
                Parcel = dFacility != null ? dFacility.Parcel : lFacility != null ? lFacility.Parcel : nrFacility.Parcel,
                Portion = dFacility != null ? dFacility.Portion : lFacility != null ? lFacility.Portion : nrFacility.Portion,
                FarmName = dFacility != null ? dFacility.FarmName : lFacility != null ? lFacility.FarmName : nrFacility.FarmName,
                LandLoc = dFacility != null ? dFacility.LandLoc : lFacility != null ? lFacility.LandLoc : nrFacility.LandLoc,
                Type = dFacility != null ? dFacility.Type : lFacility != null ? lFacility.Type : nrFacility.Type,
                ValuationDate = dFacility != null ? dFacility.ValuationDate.ToString() : lFacility != null ? lFacility.ValuationDate.ToString() : nrFacility.ValuationDate.ToString(),
                SGDiagram = dFacility != null ? dFacility.SGDiagram : lFacility != null ? lFacility.SGDiagram : nrFacility.SGDiagram,
                AreaHA = dFacility != null ? dFacility.AreaHA : lFacility != null ? lFacility.AreaHA : nrFacility.AreaHA,
                RegOwner = dFacility != null ? dFacility.RegOwner : lFacility != null ? lFacility.RegOwner : nrFacility.RegOwner,
                OwnershipCategory = dFacility != null ? dFacility.OwnershipCategory : lFacility != null ? lFacility.OwnershipCategory : nrFacility.OwnershipCategory,
                Zoning = dFacility != null ? dFacility.Zoning : lFacility != null ? lFacility.Zoning : nrFacility.Zoning,
                RegDivision = dFacility != null ? dFacility.RegDivision : lFacility != null ? lFacility.RegDivision : nrFacility.RegDivision,
                UserDept = dFacility != null ? dFacility.UserDept : lFacility != null ? lFacility.UserDept : nrFacility.UserDept,
                ConditionRating = dFacility != null ? dFacility.ConditionRating : lFacility != null ? lFacility.ConditionRating : nrFacility.ConditionRating,
                IntendUseOfTheProperty = dFacility != null ? dFacility.IntendUseOfTheProperty : lFacility != null ? lFacility.IntendUseOfTheProperty : nrFacility.IntendUseOfTheProperty,
                CurrentUse = dFacility != null ? dFacility.CurrentUse : lFacility != null ? lFacility.CurrentUse : nrFacility.CurrentUse,
                FacilityType = dFacility != null ? "Dwelling" : lFacility != null ? "Land" : "NonResidential",
                MapCoordinate = new MapCoordinate()
                {
                    Longitude = dFacility != null ? dFacility.GPSCoordinatesEast.Replace(",", ".") : lFacility != null ? lFacility.GPSCoordinatesEast.Replace(",", ".") : nrFacility.GPSCoordinatesEast.Replace(",", "."),
                    Latitude = dFacility != null ? dFacility.GPSCoordinatesSouth.Replace(",", ".") : lFacility != null ? lFacility.GPSCoordinatesSouth.Replace(",", ".") : nrFacility.GPSCoordinatesSouth.Replace(",", "."),
                },
                VestingInformation = dFacility != null ? dFacility.VestingInformation : lFacility != null ? lFacility.VestingInformation : nrFacility.VestingInformation,
                Comments = dFacility != null ? dFacility.Comments : lFacility != null ? lFacility.Comments : nrFacility.Comments,
                UserId = dFacility != null ? dFacility.UserId : lFacility != null ? lFacility.UserId : nrFacility.UserId,
                Status = dFacility != null ? ((FacilityStatus)dFacility.Status).AsString(EnumFormat.Description) : lFacility != null ? ((FacilityStatus)lFacility.Status).AsString(EnumFormat.Description) : ((FacilityStatus)nrFacility.Status).AsString(EnumFormat.Description),
                CreatedBy = dFacility != null ? dFacility.CreatedBy : lFacility != null ? lFacility.CreatedBy : nrFacility.CreatedBy,
                CreatedDate = dFacility != null ? dFacility.CreatedDate : lFacility != null ? lFacility.CreatedDate : nrFacility.CreatedDate,
                ModifiedBy = dFacility != null ? dFacility.ModifiedBy : lFacility != null ? lFacility.ModifiedBy : nrFacility.ModifiedBy,
                ModifiedDate = dFacility != null ? dFacility.ModifiedDate : lFacility != null ? lFacility.ModifiedDate : nrFacility.ModifiedDate,
            };
        }

        public DwellingFacility ConvertToDwellingFacility(Facility facility)
        {
            int status;
            return new DwellingFacility() {
                Id = facility.Id,
                Name = facility.Name,
                ClientCode = facility.ClientCode,
                PropType = facility.PropType,
                Parcel = facility.Parcel,
                Portion = facility.Portion,
                FarmName = facility.FarmName,
                LandLoc = facility.LandLoc,
                Type = facility.Type,
                ValuationDate = Convert.ToDateTime(facility.ValuationDate),
                SGDiagram = facility.SGDiagram,
                AreaHA = facility.AreaHA,
                RegOwner = facility.RegOwner,
                OwnershipCategory = facility.OwnershipCategory,
                Zoning = facility.Zoning,
                RegDivision = facility.RegDivision,
                UserDept = facility.UserDept,
                ConditionRating = facility.ConditionRating,
                IntendUseOfTheProperty = facility.IntendUseOfTheProperty,
                CurrentUse = facility.CurrentUse,
                GPSCoordinatesEast = facility.MapCoordinate.Longitude,
                GPSCoordinatesSouth = facility.MapCoordinate.Latitude,
                VestingInformation = facility.VestingInformation,
                Comments = facility.Comments,
                UserId = facility.UserId,
                Status = Int32.TryParse(facility.Status, out status) ? Convert.ToInt32(facility.Status) : 0,
                CreatedBy = facility.CreatedBy,
                CreatedDate = facility.CreatedDate,
                ModifiedBy = facility.ModifiedBy,
                ModifiedDate = facility.ModifiedDate
            };
        }

        public LandFacility ConvertToLandFacility(Facility facility)
        {
            int status;
            return new LandFacility()
            {       
                Id = facility.Id,
                Name = facility.Name,
                ClientCode = facility.ClientCode,
                PropType = facility.PropType,
                Parcel = facility.Parcel,
                Portion = facility.Portion,
                FarmName = facility.FarmName,
                LandLoc = facility.LandLoc,
                Type = facility.Type,
                ValuationDate = facility.ValuationDate.ToString(),
                SGDiagram = facility.SGDiagram,
                AreaHA = facility.AreaHA,
                RegOwner = facility.RegOwner,
                OwnershipCategory = facility.OwnershipCategory,
                Zoning = facility.Zoning,
                RegDivision = facility.RegDivision,
                UserDept = facility.UserDept,
                ConditionRating = facility.ConditionRating,
                IntendUseOfTheProperty = facility.IntendUseOfTheProperty,
                CurrentUse = facility.CurrentUse,
                GPSCoordinatesEast = facility.MapCoordinate.Longitude,
                GPSCoordinatesSouth = facility.MapCoordinate.Latitude,
                VestingInformation = facility.VestingInformation,
                Comments = facility.Comments,
                UserId = facility.UserId,
                Status = Int32.TryParse(facility.Status, out status) ? Convert.ToInt32(facility.Status) : 0,
                CreatedBy = facility.CreatedBy,
                CreatedDate = facility.CreatedDate,
                ModifiedBy = facility.ModifiedBy,
                ModifiedDate = facility.ModifiedDate
            };     
        }

        public NonResidentialFacility ConvertToNonResidentialFacility(Facility facility)
        {
            int status;
            return new NonResidentialFacility()
            {
                Id = facility.Id,
                Name = facility.Name,
                ClientCode = facility.ClientCode,
                PropType = facility.PropType,
                Parcel = facility.Parcel,
                Portion = facility.Portion,
                FarmName = facility.FarmName,
                LandLoc = facility.LandLoc,
                Type = facility.Type,
                ValuationDate = facility.ValuationDate.ToString(),
                SGDiagram = facility.SGDiagram,
                AreaHA = facility.AreaHA,
                RegOwner = facility.RegOwner,
                OwnershipCategory = facility.OwnershipCategory,
                Zoning = facility.Zoning,
                RegDivision = facility.RegDivision,
                UserDept = facility.UserDept,
                ConditionRating = facility.ConditionRating,
                IntendUseOfTheProperty = facility.IntendUseOfTheProperty,
                CurrentUse = facility.CurrentUse,
                GPSCoordinatesEast = facility.MapCoordinate.Longitude,
                GPSCoordinatesSouth = facility.MapCoordinate.Latitude,
                VestingInformation = facility.VestingInformation,
                Comments = facility.Comments,
                UserId = facility.UserId,
                Status = Int32.TryParse(facility.Status, out status) ? Convert.ToInt32(facility.Status) : 0,
                CreatedBy = facility.CreatedBy,
                CreatedDate = facility.CreatedDate,
                ModifiedBy = facility.ModifiedBy,
                ModifiedDate = facility.ModifiedDate
            };
        }
    }   
}
