using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public bool PasswordIsChanged { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public string Token { get; set; }

        public Role Role { get; set; }

        public DataAccess.Tables.User ConvertToUserTable(User user) {
            return new DataAccess.Tables.User() {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                Password = user.Password,
                RoleId = user.RoleId,
                IsActive = user.IsActive,
                Email = user.Email,
                PasswordIsChanged = user.PasswordIsChanged,
                CreatedDate = user.CreatedDate,
                ModifiedDate = user.ModifiedDate,
                CreatedUserId = user.CreatedUserId,
                ModifiedUserId = user.ModifiedUserId,
            };
        }

        public User ConvertToUser(DataAccess.Tables.User user, string connectionString)
        {
            if (user != null)
            {
                Role _role = new Role();
                using (var roleDataAccess = new DataAccess.Repositories.RoleRepository(connectionString))
                {
                    DataAccess.Tables.Role role = roleDataAccess.GetRoleById(user.RoleId);
                    _role = _role.ConvertToRole(role);
                }

                return new User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.Username,
                    Password = user.Password,
                    RoleId = user.RoleId,
                    IsActive = user.IsActive,
                    Email = user.Email,
                    PasswordIsChanged = user.PasswordIsChanged,
                    CreatedDate = user.CreatedDate,
                    ModifiedDate = user.ModifiedDate,
                    CreatedUserId = user.CreatedUserId,
                    ModifiedUserId = user.ModifiedUserId,
                    Role = _role
                };
            }
            else
                return null;
            
        }

        public List<User> ConvertToUsers(List<DataAccess.Tables.User> users)
        {
            return users.Select(u => new User()
            {
                Id = u.Id,
                Name = u.Name,
                Surname = u.Surname,
                Username = u.Username,
                Password = u.Password,
                RoleId = u.RoleId,
                IsActive = u.IsActive,
                Email = u.Email,
                PasswordIsChanged = u.PasswordIsChanged,
                CreatedDate = u.CreatedDate,
                ModifiedDate = u.ModifiedDate,
                CreatedUserId = u.CreatedUserId,
                ModifiedUserId = u.ModifiedUserId,
            }).ToList();
        }
    }
}
