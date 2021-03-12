using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class Valuation
    {
        public int Id { get; set; }
        public DateTime MunicipalValuationDate { get; set; }
        public DateTime NonMunicipalValuationDate { get; set; }
        public string MunicipalValuation { get; set; }
        public string NonMunicipalValuation { get; set; }
        public string PropetyRatesAccount { get; set; }
        public string Value { get; set; }
        public string AccountNoForService { get; set; }
        public string PersonInstitutionResposible { get; set; }
    }
}
