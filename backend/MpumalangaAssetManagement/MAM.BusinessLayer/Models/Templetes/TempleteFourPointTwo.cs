using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteFourPointTwo
    {
        public int Id { get; set; }
        public List<AcquisitionPlan> AcquisitionPlans { get; set; }

        public TempleteFourPointTwo ConvertToTempleteFourPointTwo(List<DataAccess.Tables.AcquisitionPlan> acquisitionPlans)
        {
            TempleteFourPointTwo templeteFourPointTwo = new TempleteFourPointTwo();
            AcquisitionPlan acquisitionPlan = new AcquisitionPlan();
            templeteFourPointTwo.AcquisitionPlans = acquisitionPlan.ConvertToAcquisitionPlans(acquisitionPlans);
            return templeteFourPointTwo;
        }
    }
}
