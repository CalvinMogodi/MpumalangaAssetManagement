using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class UserImmovableAssetManagementPlan
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int FileReference { get; set; }
        public int? OptimalSupportingAccommodationId { get; set; }
        public virtual List<Property> Properties { get; set; }
        public virtual List<OperationPlan> OperationPlans { get; set; }
        public virtual List<AcquisitionPlan> AcquisitionPlans { get; set; }       
        public virtual List<Programme> Programmes { get; set; }
        public virtual List<MtefBudgetPeriod> MtefBudgetPeriod { get; set; }
        public virtual List<SurrenderPlan> SurrenderPlans { get; set; }
        public virtual List<StrategicAssessment> StrategicAssessments { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
