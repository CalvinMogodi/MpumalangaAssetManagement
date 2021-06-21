using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IStrategicAssessmentRepository
    {
        int AddStrategicAssessment(StrategicAssessment StrategicAssessments);
        bool UpdateStrategicAssessment(StrategicAssessment StrategicAssessments);
        bool DeleteStrategicAssessment(StrategicAssessment StrategicAssessments);
        List<StrategicAssessment> GetStrategicAssessments();
    }
}
