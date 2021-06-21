using MAM.BusinessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string FileReferenceNo { get; set; }
        public string SerialNo { get; set; }
        public string Districts { get; set; }
        public string Town { get; set; }
        public string LocalMunicipality { get; set; }
        public string AssetDescription { get; set; }
        public string OldStreetAddress { get; set; }
        public string CurrentStreetAddress { get; set; }
        public string PropertyDescription { get; set; }
        public string AssetType { get; set; }
        public int? NoofParkingBays { get; set; }
        public int? NoofParkingBaysAllocated { get; set; }
        public decimal? UsableAllocatedSpace { get; set; }
        public decimal? LettableSpace { get; set; }
        public decimal? ExtentofLand { get; set; }
        public double? RentalPM { get; set; }
        public double? RentalPA { get; set; }
        public List<MunicipalUtilityService> MunicipalUtilityServices { get; set; }
        public double MunicipalUtilityServiceTotal { get; set; }
        public double PropertyRatesTaxes { get; set; }
        public double OperationalCosts { get; set; }
        public string RequiredPerformanceStandard { get; set; }
        public string Accessibility { get; set; }
        public ConditionRating ConditionRating { get; set; }
        public string SuitabilityIndex { get; set; }
        public string OperatingPerformanceIndex { get; set; }
        public string FunctionalPerformanceIndex { get; set; }
        public DateTime? LeaseStartDate { get; set; }
        public DateTime? LeaseEndDate { get; set; }
        public string LeaseTerm { get; set; }
        public string Comments { get; set; }
    }
}
