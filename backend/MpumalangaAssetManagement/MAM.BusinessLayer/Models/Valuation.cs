using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Valuation
    {
        public int Id { get; set; }
        public DateTime? MunicipalValuationDate { get; set; }
        public DateTime? NonMunicipalValuationDate { get; set; }
        public string MunicipalValuation { get; set; }
        public string NonMunicipalValuation { get; set; }
        public string PropetyRatesAccount { get; set; }
        public string Value { get; set; }
        public string AccountNoForService { get; set; }
        public string PersonInstitutionResposible { get; set; }

        public List<Valuation> ConvertToValuations(List<DataAccess.Tables.Valuation> valuations)
        {
            return valuations.Select(v => new Valuation()
            {
                Id = v.Id,
                MunicipalValuationDate = v.MunicipalValuationDate,
                NonMunicipalValuationDate = v.NonMunicipalValuationDate,
                MunicipalValuation = v.MunicipalValuation,
                NonMunicipalValuation = v.NonMunicipalValuation,
                PropetyRatesAccount = v.PropetyRatesAccount,
                Value = v.Value,
                AccountNoForService = v.AccountNoForService,
                PersonInstitutionResposible = v.PersonInstitutionResposible,
            }).ToList();
        }

        public Valuation ConvertToValuation(DataAccess.Tables.Valuation valuation)
        {
            return new Valuation()
            {
                Id = valuation.Id,
                MunicipalValuationDate = valuation.MunicipalValuationDate,
                NonMunicipalValuationDate = valuation.NonMunicipalValuationDate,
                MunicipalValuation = valuation.MunicipalValuation,
                NonMunicipalValuation = valuation.NonMunicipalValuation,
                PropetyRatesAccount = valuation.PropetyRatesAccount,
                Value = valuation.Value,
                AccountNoForService = valuation.AccountNoForService,
                PersonInstitutionResposible = valuation.PersonInstitutionResposible,
            };
        }

        public DataAccess.Tables.Valuation ConvertToValuation(Valuation valuation)
        {
            return new DataAccess.Tables.Valuation()
            {
                Id = valuation.Id,
                MunicipalValuationDate = valuation.MunicipalValuationDate,
                NonMunicipalValuationDate = valuation.NonMunicipalValuationDate,
                MunicipalValuation = valuation.MunicipalValuation,
                NonMunicipalValuation = valuation.NonMunicipalValuation,
                PropetyRatesAccount = valuation.PropetyRatesAccount,
                Value = valuation.Value,
                AccountNoForService = valuation.AccountNoForService,
                PersonInstitutionResposible = valuation.PersonInstitutionResposible,
            };
        }
    }
}
