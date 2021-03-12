using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class SecondaryInformationNote
    {
        public int Id { get; set; }
        public decimal? AdditionCash { get; set; }
        public decimal? AdditionNonCash { get; set; }
        public decimal? Addition { get; set; }
        public decimal? Disposal { get; set; }
        public decimal? ClosingBalance { get; set; }
    }
}
