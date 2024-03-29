﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class PropertyDescription
    {
        public int Id { get; set; }
        public string RegistrationDivision { get; set; }
        public string TownshipName { get; set; }
        public string LandParcel { get; set; }
        public string LandPortion { get; set; }
        public string OldDescription { get; set; }
        public bool? LandRemainder { get; set; }
        public string FarmName { get; set; }
        public string SGDiagramNumber { get; set; }
        public double? Extent { get; set; }
        public string LPICode { get; set; }
        public string Acquired { get; set; }
        public string AcquiredOther { get; set; }
    }
}
