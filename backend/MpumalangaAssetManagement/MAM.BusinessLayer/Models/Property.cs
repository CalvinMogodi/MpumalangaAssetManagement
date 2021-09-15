using MAM.BusinessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Property
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public double TempleteNumber { get; set; }
        public string FileReferenceNo { get; set; }
        public string SerialNo { get; set; }
        public string DistrictRegion { get; set; }
        public string Town { get; set; }
        public string LocalAuthority { get; set; }
        public string LocalMunicipality { get; set; }
        public string DistrictMunicipality { get; set; }
        public string AssetDescription { get; set; }
        public string OldStreetAddress { get; set; }
        public string CurrentStreetAddress { get; set; }
        public string PropertyDescription { get; set; }
        public string AssetType { get; set; }
        public int? NoofParkingBays { get; set; }
        public int? NoofParkingBaysAllocated { get; set; }
        public double? UsableAllocatedSpace { get; set; }
        public double? LettableSpace { get; set; }
        public double? ExtentofLand { get; set; }
        public decimal? RentalPM { get; set; }
        public decimal? RentalPA { get; set; }
        public decimal? RentalRate { get; set; }
        public List<MunicipalUtilityService> MunicipalUtilityServices { get; set; }
        public decimal? MunicipalUtilityServiceTotal { get; set; }
        public decimal? PropertyRatesTaxes { get; set; }
        public decimal? OperationalCosts { get; set; }
        public string RequiredPerformanceStandard { get; set; }
        public string Accessibility { get; set; }
        public ConditionRating? ConditionRating { get; set; }
        public string SuitabilityIndex { get; set; }
        public string OperatingPerformanceIndex { get; set; }
        public string FunctionalPerformanceIndex { get; set; }
        public DateTime? LeaseStartDate { get; set; }
        public DateTime? LeaseEndDate { get; set; }
        public string LeaseTerm { get; set; }
        public string Comment { get; set; }

        public List<Property> ConvertToProperties(List<DataAccess.Tables.Property> Properties)
        {
            return Properties.Select(p => new Property()
            {
                Id = p.Id,
                UserImmovableAssetManagementPlanId = p.UserImmovableAssetManagementPlanId,
                TempleteNumber = p.TempleteNumber,
                FileReferenceNo = p.FileReferenceNo,
                SerialNo = p.SerialNo,
                DistrictRegion = p.DistrictRegion,
                Town = p.Town,
                LocalAuthority = p.LocalAuthority,
                LocalMunicipality = p.LocalMunicipality,
                AssetDescription = p.AssetDescription,
                OldStreetAddress = p.OldStreetAddress,
                CurrentStreetAddress = p.CurrentStreetAddress,
                PropertyDescription = p.PropertyDescription,
                AssetType = p.AssetType,
                NoofParkingBays = p.NoofParkingBays,
                NoofParkingBaysAllocated = p.NoofParkingBaysAllocated,
                UsableAllocatedSpace = p.UsableAllocatedSpace,
                LettableSpace = p.LettableSpace,
                ExtentofLand = p.ExtentofLand,
                RentalPM = p.RentalPM,
                RentalPA = p.RentalPA,
                MunicipalUtilityServices = new List<MunicipalUtilityService>(),
                MunicipalUtilityServiceTotal = p.MunicipalUtilityServiceTotal,
                PropertyRatesTaxes = p.PropertyRatesTaxes,
                OperationalCosts = p.OperationalCosts,
                RequiredPerformanceStandard = p.RequiredPerformanceStandard,
                Accessibility = p.Accessibility,
                //ConditionRating = p.ConditionRating,
                SuitabilityIndex = p.SuitabilityIndex,
                OperatingPerformanceIndex = p.OperatingPerformanceIndex,
                FunctionalPerformanceIndex = p.FunctionalPerformanceIndex,
                LeaseStartDate = p.LeaseStartDate,
                LeaseEndDate = p.LeaseEndDate,
                LeaseTerm = p.LeaseTerm,
                Comment = p.Comment,
            }).ToList();
        }

        public DataAccess.Tables.Property ConvertToPropertyTable(Property property)
        {
            return new DataAccess.Tables.Property()
            {
                Id = property.Id,
                UserImmovableAssetManagementPlanId = property.UserImmovableAssetManagementPlanId,
                TempleteNumber = property.TempleteNumber,
                FileReferenceNo = property.FileReferenceNo,
                SerialNo = property.SerialNo,
                DistrictRegion = property.DistrictRegion,
                Town = property.Town,
                LocalAuthority = property.LocalAuthority,
                LocalMunicipality = property.LocalMunicipality,
                AssetDescription = property.AssetDescription,
                OldStreetAddress = property.OldStreetAddress,
                CurrentStreetAddress = property.CurrentStreetAddress,
                PropertyDescription = property.PropertyDescription,
                AssetType = property.AssetType,
                NoofParkingBays = property.NoofParkingBays,
                NoofParkingBaysAllocated = property.NoofParkingBaysAllocated,
                UsableAllocatedSpace = property.UsableAllocatedSpace,
                LettableSpace = property.LettableSpace,
                ExtentofLand = property.ExtentofLand,
                RentalPM = property.RentalPM,
                RentalPA = property.RentalPA,
                //MunicipalUtilityServices = new List<MunicipalUtilityService>(),
                MunicipalUtilityServiceTotal = property.MunicipalUtilityServiceTotal,
                PropertyRatesTaxes = property.PropertyRatesTaxes,
                OperationalCosts = property.OperationalCosts,
                RequiredPerformanceStandard = property.RequiredPerformanceStandard,
                Accessibility = property.Accessibility,
                //ConditionRating = p.ConditionRating,
                SuitabilityIndex = property.SuitabilityIndex,
                OperatingPerformanceIndex = property.OperatingPerformanceIndex,
                FunctionalPerformanceIndex = property.FunctionalPerformanceIndex,
                LeaseStartDate = property.LeaseStartDate,
                LeaseEndDate = property.LeaseEndDate,
                LeaseTerm = property.LeaseTerm,
                Comment = property.Comment,
            };
        }
    }
}
