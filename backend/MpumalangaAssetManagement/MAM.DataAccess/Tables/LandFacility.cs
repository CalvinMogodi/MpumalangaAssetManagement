using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class LandFacility
    {
        public int Id { get; set; }
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
        public string GPSCoordinatesSouth { get; set; }
        public string GPSCoordinatesEast { get; set; }
        public string VestingInformation { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
