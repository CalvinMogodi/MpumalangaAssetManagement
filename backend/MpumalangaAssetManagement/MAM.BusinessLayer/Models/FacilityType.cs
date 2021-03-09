using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class FacilityType
    {
        public string Name { get; set; }
        public List<FacilityZoning> FacilityZonings { get; set; }
    }
}
