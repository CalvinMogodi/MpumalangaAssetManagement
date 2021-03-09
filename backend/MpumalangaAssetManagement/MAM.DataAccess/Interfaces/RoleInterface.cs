using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface RoleInterface
    {
        void AddRole(Role role);
        void UpdateRole(Role role);
        List<Role> GetRoles();
        Role GetRoleById(int id);        
    }
}
