using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        public DataAccess.Tables.Role ConvertToRoleTable(Role role)
        {
            return new DataAccess.Tables.Role()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                CreatedDate = role.CreatedDate,
                ModifiedDate = role.ModifiedDate,
                CreatedUserId = role.CreatedUserId,
                ModifiedUserId = role.ModifiedUserId,
            };
        }

        public Role ConvertToRole(DataAccess.Tables.Role role)
        {
            return new Role()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                CreatedDate = role.CreatedDate,
                ModifiedDate = role.ModifiedDate,
                CreatedUserId = role.CreatedUserId,
                ModifiedUserId = role.ModifiedUserId,
            };
        }

        public List<Role> ConvertToRoles(List<DataAccess.Tables.Role> roles)
        {
            return roles.Select(r => new Role()
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                CreatedDate = r.CreatedDate,
                ModifiedDate = r.ModifiedDate,
                CreatedUserId = r.CreatedUserId,
                ModifiedUserId = r.ModifiedUserId,
            }).ToList();
        }
    }
}
