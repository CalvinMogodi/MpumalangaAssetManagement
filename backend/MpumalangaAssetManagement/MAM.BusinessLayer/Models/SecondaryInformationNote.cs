using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class SecondaryInformationNote
    {
        public int Id { get; set; }
        public decimal? OpeningBalance { get; set; }
        public decimal? AdditionCash { get; set; }
        public decimal? AdditionNonCash { get; set; }
        public decimal? Addition { get; set; }
        public decimal? Disposal { get; set; }
        public decimal? ClosingBalance { get; set; }

        public List<SecondaryInformationNote> ConvertToSecondaryInformationNotes(List<DataAccess.Tables.SecondaryInformationNote> secondaryInformationNotes)
        {
            return secondaryInformationNotes.Select(s => new SecondaryInformationNote()
            {
                Id = s.Id,
                OpeningBalance = s.OpeningBalance,
                AdditionCash = s.AdditionCash,
                AdditionNonCash = s.AdditionNonCash,
                Addition = s.Addition,
                Disposal = s.Disposal,
                ClosingBalance = s.ClosingBalance,
            }).ToList();
        }

        public SecondaryInformationNote ConvertToSecondaryInformationNote(DataAccess.Tables.SecondaryInformationNote sin)
        {
            return new SecondaryInformationNote()
            {
                Id = sin.Id,
                OpeningBalance = sin.OpeningBalance,
                AdditionCash = sin.AdditionCash,
                AdditionNonCash = sin.AdditionNonCash,
                Addition = sin.Addition,
                Disposal = sin.Disposal,
                ClosingBalance = sin.ClosingBalance,
            };
        }

        public DataAccess.Tables.SecondaryInformationNote ConvertToSecondaryInformationNote(SecondaryInformationNote sin)
        {
            return new DataAccess.Tables.SecondaryInformationNote()
            {
                Id = sin.Id,
                OpeningBalance = sin.OpeningBalance,
                AdditionCash = sin.AdditionCash,
                AdditionNonCash = sin.AdditionNonCash,
                Addition = sin.Addition,
                Disposal = sin.Disposal,
                ClosingBalance = sin.ClosingBalance,
            };
        }
    }
}
