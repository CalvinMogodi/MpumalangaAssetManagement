using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class Improvement
    {
        public int Id { get; set; }
        public int? FacilityId { get; set; }
        public string BuildingName { get; set; }
        public string Type { get; set; }
        public int? Size { get; set; }
        public string PotentialUse { get; set; }
        public string SiteCoverag { get; set; }
        public string LevelofUtilization { get; set; }
        public string ExtentOfBuilding { get; set; }
        public string ConditionRating { get; set; }
        public string UsableArea { get; set; }
        public string FunctionalPerformanceRating { get; set; }
        public string Comment { get; set; }
    }
}
