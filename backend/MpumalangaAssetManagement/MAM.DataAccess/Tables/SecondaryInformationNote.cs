using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class SecondaryInformationNote
    {
        public int Id { get; set; }
        public double? AdditionCash { get; set; }
        public double? AdditionNonCash { get; set; }
        public double? Addition { get; set; }
        public double? Disposal { get; set; }
        public double? ClosingBalance { get; set; }
    }
}
