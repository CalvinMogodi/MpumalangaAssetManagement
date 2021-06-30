using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class UserImmovableAssetManagementPlan
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string FileReference { get; set; }
        public int? OptimalSupportingAccommodationId { get; set; }
        public string Department { get; set; }
        public virtual OptimalSupportingAccommodation OptimalSupportingAccommodation { get; set; }
        public virtual List<Property> Properties { get; set; }
        //public virtual List<OperationPlan> OperationPlans { get; set; }
        //public virtual List<AcquisitionPlan> AcquisitionPlans { get; set; }       
        public virtual List<Programme> Programmes { get; set; }
        //public virtual List<MtefBudgetPeriod> MtefBudgetPeriods { get; set; }
        //public virtual List<SurrenderPlan> SurrenderPlans { get; set; }
        //public virtual List<StrategicAssessment> StrategicAssessments { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
