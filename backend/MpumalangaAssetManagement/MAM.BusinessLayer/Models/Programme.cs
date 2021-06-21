using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Programme
    {
        public int Id { get; set; }
        public string CorporateObjective { get; set; }
        public string Outcomes { get; set; }
        public string OptimalSupportingAccommodationSolution { get; set; }
        public string RationaleChosenSolution { get; set; }

        public DataAccess.Tables.Programme ConvertToProgrammeTable(Programme programme)
        {
            return new DataAccess.Tables.Programme()
            {
                Id = programme.Id,
                CorporateObjective = programme.CorporateObjective,
                Outcomes = programme.Outcomes,
                OptimalSupportingAccommodationSolution = programme.OptimalSupportingAccommodationSolution,
                RationaleChosenSolution = programme.RationaleChosenSolution
            };
        }

        public List<Programme> ConvertToProgrammes(List<DataAccess.Tables.Programme> programmes)
        {
            return programmes.Select(p => new Programme()
            {
                Id = p.Id,
                CorporateObjective = p.CorporateObjective,
                Outcomes = p.Outcomes,
                OptimalSupportingAccommodationSolution = p.OptimalSupportingAccommodationSolution,
                RationaleChosenSolution = p.RationaleChosenSolution
            }).ToList();
        }
    }
}
