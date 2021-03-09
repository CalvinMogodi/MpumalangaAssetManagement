using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface UserInterface
    {
        void AddUser(User user);
        void UpdateUser(User user);
        List<User> GetUsers();
        User GetUser(string username);
    }
}
