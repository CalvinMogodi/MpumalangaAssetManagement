using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteFivePointOne
    {
        public int Id { get; set; }
        public List<OperationPlan> OperationPlans { get; set; }

        public TempleteFivePointOne ConvertToTempleteFivePointOne(List<DataAccess.Tables.OperationPlan> operationPlans)
        {
            TempleteFivePointOne templeteFivePointOne = new TempleteFivePointOne();
            OperationPlan operationPlan = new OperationPlan();
            templeteFivePointOne.OperationPlans = operationPlan.ConvertToOperationPlans(operationPlans);
            return templeteFivePointOne;
        }
    }
}
