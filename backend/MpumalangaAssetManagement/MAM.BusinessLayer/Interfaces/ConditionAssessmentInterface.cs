using System;
using System.Collections.Generic;
using System.Text;
using MAM.BusinessLayer.Models;

namespace MAM.BusinessLayer.Interfaces
{
    public interface ConditionAssessmentInterface
    {
        int AddConditionAssessment(ConditionAssessment conditionAssessment);
        bool DeleteConditionAssessment(int id);
        List<ConditionAssessment> GetConditionAssessments(int facilityId);
        ConditionAssessment GetConditionAssessmentById(int id);
    }
}
