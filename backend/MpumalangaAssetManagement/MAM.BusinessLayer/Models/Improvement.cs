using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
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

        public List<Improvement> ConvertToImprovements(List<DataAccess.Tables.Improvement> improvements)
        {
            return improvements.Select(i => new Improvement()
            {
                Id = i.Id,
                FacilityId = i.FacilityId,
                BuildingName = i.BuildingName,
                Type = i.Type,
                Size = i.Size,
                PotentialUse = i.PotentialUse,
                SiteCoverag = i.SiteCoverag,
                LevelofUtilization = i.LevelofUtilization,
                ExtentOfBuilding = i.ExtentOfBuilding,
                ConditionRating = i.ConditionRating,
                UsableArea = i.UsableArea,
                FunctionalPerformanceRating = i.FunctionalPerformanceRating,
                Comment = i.Comment,
            }).ToList();
        }


        public Improvement ConvertToImprovement(DataAccess.Tables.Improvement i)
        {
            return new Improvement()
            {
                Id = i.Id,
                FacilityId = i.FacilityId,
                BuildingName = i.BuildingName,
                Type = i.Type,
                Size = i.Size,
                PotentialUse = i.PotentialUse,
                SiteCoverag = i.SiteCoverag,
                LevelofUtilization = i.LevelofUtilization,
                ExtentOfBuilding = i.ExtentOfBuilding,
                ConditionRating = i.ConditionRating,
                UsableArea = i.UsableArea,
                FunctionalPerformanceRating = i.FunctionalPerformanceRating,
                Comment = i.Comment,
            };
        }

        public DataAccess.Tables.Improvement ConvertToImprovement(Improvement i)
        {
            return new DataAccess.Tables.Improvement()
            {
                Id = i.Id,
                FacilityId = i.FacilityId,
                BuildingName = i.BuildingName,
                Type = i.Type,
                Size = i.Size,
                PotentialUse = i.PotentialUse,
                SiteCoverag = i.SiteCoverag,
                LevelofUtilization = i.LevelofUtilization,
                ExtentOfBuilding = i.ExtentOfBuilding,
                ConditionRating = i.ConditionRating,
                UsableArea = i.UsableArea,
                FunctionalPerformanceRating = i.FunctionalPerformanceRating,
                Comment = i.Comment,
            };
        }
    }
}
