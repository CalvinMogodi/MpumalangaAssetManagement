using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class FacilitySummary
    {
        public int Type { get; set; }
        public int Year { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal Additions { get; set; }
        public decimal PpeaIn { get; set; }
        public decimal PpeaOut { get; set; }
        public decimal Disposals { get; set; }
        public decimal ClosingBalance { get; set; }
        public string FacilityType { get; set; }
    }
}
