using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class Programme
    {
        public int Id { get; set; }
        public int UserImmovableAssetManagementPlanId { get; set; }
        public string CorporateObjective { get; set; }
        public string Outcomes { get; set; }
        public string OptimalSupportingAccommodationSolution { get; set; }
        public string RationaleChosenSolution { get; set; }
    }
}
