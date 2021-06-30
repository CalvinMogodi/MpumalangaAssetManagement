using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
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
        public DateTime? ProposedHandOverDate{ get; set; }
        public string ContractualObligations { get; set; }

        public DataAccess.Tables.SurrenderPlan ConvertToSurrenderPlanTable(SurrenderPlan surrenderPlan)
        {
            return new DataAccess.Tables.SurrenderPlan()
            {
                Id = surrenderPlan.Id,
                UserImmovableAssetManagementPlanId = surrenderPlan.UserImmovableAssetManagementPlanId,
                TempleteNumber = surrenderPlan.TempleteNumber,
                DistrictRegion = surrenderPlan.DistrictRegion,
                Town = surrenderPlan.Town,
                LocalMunicipality = surrenderPlan.LocalMunicipality,
                CurrentStreetAddress = surrenderPlan.CurrentStreetAddress,
                AssetType = surrenderPlan.AssetType,
                PropertyDescription = surrenderPlan.PropertyDescription,
                AllocatedLettableSpace = surrenderPlan.AllocatedLettableSpace,
                ExtentofLand = surrenderPlan.ExtentofLand,
                SurrenderRationale = surrenderPlan.SurrenderRationale,
                ProposedHandOverDate = surrenderPlan.ProposedHandOverDate,
                ContractualObligations = surrenderPlan.ContractualObligations,
            };
        }

        public List<SurrenderPlan> ConvertToSurrenderPlans(List<DataAccess.Tables.SurrenderPlan> surrenderPlans)
        {
            return surrenderPlans.Select(s => new SurrenderPlan()
            {
                Id = s.Id,
                UserImmovableAssetManagementPlanId = s.UserImmovableAssetManagementPlanId,
                TempleteNumber = s.TempleteNumber,
                DistrictRegion = s.DistrictRegion,
                Town = s.Town,
                LocalMunicipality = s.LocalMunicipality,
                CurrentStreetAddress = s.CurrentStreetAddress,
                AssetType = s.AssetType,
                PropertyDescription = s.PropertyDescription,
                AllocatedLettableSpace = s.AllocatedLettableSpace,
                ExtentofLand = s.ExtentofLand,
                SurrenderRationale = s.SurrenderRationale,
                ProposedHandOverDate = s.ProposedHandOverDate,
                ContractualObligations = s.ContractualObligations,
            }).ToList();
        }
    }
}
