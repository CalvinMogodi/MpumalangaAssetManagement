using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteFourPointOne
    {
        public int Id { get; set; }
        public List<AcquisitionPlan> AcquisitionPlans { get; set; }

        public TempleteFourPointOne ConvertToTempleteFourPointOne(List<DataAccess.Tables.AcquisitionPlan> acquisitionPlans)
        {
            TempleteFourPointOne templeteFourPointOne = new TempleteFourPointOne();
            AcquisitionPlan acquisitionPlan = new AcquisitionPlan();
            templeteFourPointOne.AcquisitionPlans = acquisitionPlan.ConvertToAcquisitionPlans(acquisitionPlans);
            return templeteFourPointOne;
        }
    }
}
