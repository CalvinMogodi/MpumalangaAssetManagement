using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class PropertyDescription
    {
        public int Id { get; set; }
        public string RegistrationDivision { get; set; }
        public string TownshipName { get; set; }
        public string LandParcel { get; set; }
        public string LandPortion { get; set; }
        public string OldDescription { get; set; }
        public bool LandRemainder { get; set; }
        public string FarmName { get; set; }
        public string SGDiagramNumber { get; set; }
        public int Extent { get; set; }
        public string LPICode { get; set; }
        public string Acquired { get; set; }
        public string AcquiredOther { get; set; }

        public PropertyDescription ConvertPropertyDescription(DataAccess.Tables.PropertyDescription propertyDescription) {
            return new PropertyDescription {
                Id = propertyDescription.Id,
                RegistrationDivision = propertyDescription.RegistrationDivision,
                TownshipName = propertyDescription.TownshipName,
                LandParcel = propertyDescription.LandParcel,
                LandPortion = propertyDescription.LandPortion,
                OldDescription = propertyDescription.OldDescription,
                LandRemainder = propertyDescription.LandRemainder,
                FarmName = propertyDescription.FarmName,
                SGDiagramNumber = propertyDescription.SGDiagramNumber,
                Extent = propertyDescription.Extent,
                LPICode = propertyDescription.LPICode,
                Acquired = propertyDescription.Acquired,
                AcquiredOther = propertyDescription.AcquiredOther,
            };
        }

        public DataAccess.Tables.PropertyDescription ConvertPropertyDescription(PropertyDescription propertyDescription)
        {
            return new DataAccess.Tables.PropertyDescription
            {
                Id = propertyDescription.Id,
                RegistrationDivision = propertyDescription.RegistrationDivision,
                TownshipName = propertyDescription.TownshipName,
                LandParcel = propertyDescription.LandParcel,
                LandPortion = propertyDescription.LandPortion,
                OldDescription = propertyDescription.OldDescription,
                LandRemainder = propertyDescription.LandRemainder,
                FarmName = propertyDescription.FarmName,
                SGDiagramNumber = propertyDescription.SGDiagramNumber,
                Extent = propertyDescription.Extent,
                LPICode = propertyDescription.LPICode,
                Acquired = propertyDescription.Acquired,
                AcquiredOther = propertyDescription.AcquiredOther,
            };
        }
    }
}
