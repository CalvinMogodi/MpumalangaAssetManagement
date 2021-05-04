using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Programme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlannedOutputs { get; set; }
        public string RequiredServiceLevel { get; set; }
        public string PossibleNonAssetSolutions { get; set; }
        public string Motivation { get; set; }
        public string RationaleForChosenSolution { get; set; }
        public int UserId { get; set; }

        public DataAccess.Tables.Programme ConvertToProgrammeTable(Programme programme)
        {
            return new DataAccess.Tables.Programme()
            {
                Id = programme.Id,
                Name = programme.Name,
                PlannedOutputs = programme.PlannedOutputs,
                RequiredServiceLevel = programme.RequiredServiceLevel,
                PossibleNonAssetSolutions = programme.PossibleNonAssetSolutions,
                Motivation = programme.Motivation,
                RationaleForChosenSolution = programme.RationaleForChosenSolution,
                UserId = 1033
            };
        }

        public List<Programme> ConvertToProgrammes(List<DataAccess.Tables.Programme> programmes)
        {
            return programmes.Select(p => new Programme()
            {
                Id = p.Id,
                UserId = p.UserId,
                Name = p.Name,
                PlannedOutputs = p.PlannedOutputs,
                RequiredServiceLevel = p.RequiredServiceLevel,
                PossibleNonAssetSolutions = p.PossibleNonAssetSolutions,
                Motivation = p.Motivation,
                RationaleForChosenSolution = p.RationaleForChosenSolution
            }).ToList();
        }
    }
}
