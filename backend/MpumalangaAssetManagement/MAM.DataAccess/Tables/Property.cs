using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
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
        public List<MunicipalUtilityService> MunicipalUtilityServices { get; set; }
        public decimal? MunicipalUtilityServiceTotal { get; set; }
        public decimal? PropertyRatesTaxes { get; set; }
        public decimal? OperationalCosts { get; set; }
        public string RequiredPerformanceStandard { get; set; }
        public string Accessibility { get; set; }
        public string ConditionRating { get; set; }
        public string SuitabilityIndex { get; set; }
        public string OperatingPerformanceIndex { get; set; }
        public string FunctionalPerformanceIndex { get; set; }
        public DateTime? LeaseStartDate { get; set; }
        public DateTime? LeaseEndDate { get; set; }
        public string LeaseTerm { get; set; }
        public string Comment { get; set; }
    }
}
