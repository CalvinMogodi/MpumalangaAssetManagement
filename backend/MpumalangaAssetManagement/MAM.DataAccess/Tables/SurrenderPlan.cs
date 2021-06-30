using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class SurrenderPlan
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public double TempleteNumber { get; set; }
        public string DistrictRegion { get; set; }
        public string Town { get; set; }
        public string LocalMunicipality { get; set; }
        public string CurrentStreetAddress { get; set; }
        public string AssetType { get; set; }
        public string PropertyDescription { get; set; }
        public double? AllocatedLettableSpace { get; set; }
        public double? ExtentofLand { get; set; }
        public string SurrenderRationale { get; set; }
        public DateTime? ProposedHandOverDate { get; set; }
        public string ContractualObligations { get; set; }
    }
}
