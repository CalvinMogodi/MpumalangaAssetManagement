using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class SurrenderPlan
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public string District { get; set; }
        public string Town { get; set; }
        public string LocalMunicipality { get; set; }
        public string CurrentStreetAddress { get; set; }
        public string AssetType { get; set; }        
        public string PropertyDescription { get; set; }
        public decimal? AllocatedLettableSpace { get; set; }
        public decimal? ExtentofLand { get; set; }
        public string SurrenderRationale { get; set; }
        public DateTime? ProposedHandOverDate{ get; set; }
        public string ContractualObligations { get; set; }
    }
}
