using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class FacilitySummaryChart
    {
        public int Year { get; set; }
        public List<FacilitySummary> FacilitySummaries { get; set; }
    }
}
