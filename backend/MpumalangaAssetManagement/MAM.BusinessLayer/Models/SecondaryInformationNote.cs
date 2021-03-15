using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class SecondaryInformationNote
    {
        public int Id { get; set; }
        public double? AdditionCash { get; set; }
        public double? AdditionNonCash { get; set; }
        public double? Addition { get; set; }
        public double? Disposal { get; set; }
        public double? ClosingBalance { get; set; }

        public List<SecondaryInformationNote> ConvertToSecondaryInformationNotes(List<DataAccess.Tables.SecondaryInformationNote> secondaryInformationNotes)
        {
            return secondaryInformationNotes.Select(s => new SecondaryInformationNote()
            {
                Id = s.Id,
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
                AdditionCash = sin.AdditionCash,
                AdditionNonCash = sin.AdditionNonCash,
                Addition = sin.Addition,
                Disposal = sin.Disposal,
                ClosingBalance = sin.ClosingBalance,
            };
        }
    }
}
