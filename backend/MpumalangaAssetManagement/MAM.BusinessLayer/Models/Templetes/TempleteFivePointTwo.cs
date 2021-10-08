using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteFivePointTwo
    {
        public int Id { get; set; }
        public List<OperationPlan> OperationPlans { get; set; }

        public TempleteFivePointTwo ConvertToTempleteFivePointTwo(List<DataAccess.Tables.OperationPlan> operationPlans)
        {
            TempleteFivePointTwo templeteFivePointTwo = new TempleteFivePointTwo();
            OperationPlan operationPlan = new OperationPlan();
            templeteFivePointTwo.OperationPlans = operationPlan.ConvertToOperationPlans(operationPlans);
            return templeteFivePointTwo;
        }
    }
}
