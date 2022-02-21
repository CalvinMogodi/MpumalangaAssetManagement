using MAM.BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class HiredProperty
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string District { get; set; }
        public string PropertyCode { get; set; }
        public string BuildingCondition { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public decimal MonthlyRental { get; set; }
        public string Town { get; set; }
        public string Status { get; set; }
        public string UserDepartment { get; set; }
        public string LandlandAgentName { get; set; }
        public int NumberofStuff { get; set; }
        public int EscalationRate { get; set; }
        public decimal Area { get; set; }
        public string Address { get; set; }
        public bool IsDeteted { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public User CreatedByUser { get; set; }
        public User ModifiedByUser { get; set; }

        public List<HiredProperty> ConvertToHiredProperties(List<DataAccess.Tables.HiredProperty> properties)
        {

            User creator, modifier = new User();

            creator = null;
            modifier = null;

            return properties.Select(f => new HiredProperty()
            {
                Id = f.Id,
                Type = f.Type,
                District = f.District,
                PropertyCode = f.PropertyCode,
                BuildingCondition = f.BuildingCondition,
                StartingDate = f.StartingDate,
                TerminationDate = f.TerminationDate,
                MonthlyRental = f.MonthlyRental,
                Town = f.Town,
                Status = f.Status,
                UserDepartment = f.UserDepartment,
                LandlandAgentName = f.LandlandAgentName,
                NumberofStuff = f.NumberofStuff,
                EscalationRate = f.EscalationRate,
                Area = f.Area,
                Address = f.Address,
                IsDeteted = f.IsDeteted,
                CreatedUserId = f.CreatedUserId,
                CreatedDate = f.CreatedDate,
                ModifiedUserId = f.ModifiedUserId,
                ModifiedDate = f.ModifiedDate,
                CreatedByUser = creator,
                ModifiedByUser = modifier,
            }).ToList();
        }

        public DataAccess.Tables.HiredProperty ConvertToHiredPropertyTable(HiredProperty property)
        {
            return new DataAccess.Tables.HiredProperty()
            {
                Id = property.Id,
                Type = property.Type,
                District = property.District,
                PropertyCode = property.PropertyCode,
                BuildingCondition = property.BuildingCondition,
                StartingDate = property.StartingDate,
                TerminationDate = property.TerminationDate,
                MonthlyRental = property.MonthlyRental,
                Town = property.Town,
                Status = property.Status,
                UserDepartment = property.UserDepartment,
                LandlandAgentName = property.LandlandAgentName,
                NumberofStuff = property.NumberofStuff,
                EscalationRate = property.EscalationRate,
                Area = property.Area,
                Address = property.Address,
                IsDeteted = property.IsDeteted,
                CreatedUserId = property.CreatedUserId,
                CreatedDate = property.CreatedDate,
                ModifiedUserId = property.ModifiedUserId,
                ModifiedDate = property.ModifiedDate,
            };
        }
    }
}
