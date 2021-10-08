using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteThree
    {
        public int Id { get; set; }
        public List<StrategicAssessment> StrategicAssessments { get; set; }

        public TempleteThree ConvertToTempleteThree(List<DataAccess.Tables.StrategicAssessment> strategicAssessments)
        {
            TempleteThree templeteThree = new TempleteThree();
            StrategicAssessment strategicAssessment = new StrategicAssessment();
            templeteThree.StrategicAssessments = strategicAssessment.ConvertToStrategicAssessments(strategicAssessments);
            return templeteThree;
        }
    }
}
