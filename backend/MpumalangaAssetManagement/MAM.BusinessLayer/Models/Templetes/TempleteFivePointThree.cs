using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteFivePointThree
    {
        public int Id { get; set; }
        public List<OperationPlan> OperationPlans { get; set; }

        public TempleteFivePointThree ConvertToTempleteFivePointThree(List<DataAccess.Tables.OperationPlan> operationPlans)
        {
            TempleteFivePointThree templeteFivePointThree = new TempleteFivePointThree();
            OperationPlan operationPlan = new OperationPlan();
            templeteFivePointThree.OperationPlans = operationPlan.ConvertToOperationPlans(operationPlans);
            return templeteFivePointThree;
        }
    }
}
