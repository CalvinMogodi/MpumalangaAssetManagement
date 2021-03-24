using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Finance
    {
        public int Id { get; set; }
        public string LandUseClass { get; set; }
        public string NatureofAsset { get; set; }
        public int? SecondaryInformationNoteId { get; set; }
        public int? ValuationId { get; set; }
        public SecondaryInformationNote SecondaryInformationNote { get; set; }
        public Valuation Valuation { get; set; }

        public List<Finance> ConvertToFinances(List<DataAccess.Tables.Finance> finances)
        {
            return finances.Select(f => new Finance()
            {
                Id = f.Id,
                LandUseClass = f.LandUseClass,
                NatureofAsset = f.NatureofAsset,
                SecondaryInformationNoteId = f.SecondaryInformationNoteId,
                ValuationId = f.ValuationId,
            }).ToList();
        }

        public Finance ConvertToFinance(DataAccess.Tables.Finance finance)
        {
            return new Finance() {
                Id = finance.Id,
                LandUseClass = finance.LandUseClass,
                NatureofAsset = finance.NatureofAsset,
                SecondaryInformationNoteId = finance.SecondaryInformationNoteId,
                ValuationId = finance.ValuationId,
            };
        }

        public DataAccess.Tables.Finance ConvertToFinance(Finance finance)
        {
            return new DataAccess.Tables.Finance()
            {
                Id = finance.Id,
                LandUseClass = finance.LandUseClass,
                NatureofAsset = finance.NatureofAsset,
                SecondaryInformationNoteId = finance.SecondaryInformationNoteId,
                ValuationId = finance.ValuationId,
            };
        }
    }
}
