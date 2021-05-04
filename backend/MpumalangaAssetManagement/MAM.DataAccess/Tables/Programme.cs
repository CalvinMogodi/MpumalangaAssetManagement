using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
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
    }
}
