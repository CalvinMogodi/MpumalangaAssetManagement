using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class ConditionAssessment
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int RequiredPerformanceStandard { get; set; }
        public int AccessibilityRating { get; set; }
        public int ConditionRating { get; set; }
        public int SuitabilityIndex { get; set; }
        public int OperatingPerformanceIndex { get; set; }
        public int FunctionalPerformanceStandard { get; set; }
        public virtual User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
