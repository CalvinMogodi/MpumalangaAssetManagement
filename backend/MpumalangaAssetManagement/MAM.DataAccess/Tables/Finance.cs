using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class Finance
    {
        public int Id { get; set; }
        public string LandUseClass { get; set; }
        public string NatureofAsset { get; set; }
        public int SecondaryInformationNoteId { get; set; }
        public int ValuationId { get; set; }
        public SecondaryInformationNote SecondaryInformationNote { get; set; }
        public Valuation Valuation { get; set; }
    }
}
