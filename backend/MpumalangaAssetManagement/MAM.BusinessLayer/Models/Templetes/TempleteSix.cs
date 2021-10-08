using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteSix
    {
        public int Id { get; set; }
        public List<SurrenderPlan> SurrenderPlans { get; set; }

        public TempleteSix ConvertToTempleteSix(List<DataAccess.Tables.SurrenderPlan> surrenderPlans)
        {
            TempleteSix templeteSix = new TempleteSix();
            SurrenderPlan surrenderPlan = new SurrenderPlan();
            templeteSix.SurrenderPlans = surrenderPlan.ConvertToSurrenderPlans(surrenderPlans);
            return templeteSix;
        }
    }
}
