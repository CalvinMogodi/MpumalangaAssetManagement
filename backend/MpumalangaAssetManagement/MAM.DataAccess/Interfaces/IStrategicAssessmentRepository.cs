using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IStrategicAssessmentRepository
    {
        int AddStrategicAssessment(StrategicAssessment strategicAssessments);
        void UpdateStrategicAssessment(StrategicAssessment strategicAssessments);
        void DeleteStrategicAssessment(StrategicAssessment strategicAssessments);
        List<StrategicAssessment> GetStrategicAssessments(int uampId);
    }
}
