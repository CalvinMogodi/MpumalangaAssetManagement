using MAM.BusinessLayer.Model;
using MAM.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Interfaces
{
    public interface IUserRepository
    {
        bool AddUser(User user);
        bool UpdateUser(User user);
        List<User> GetUsers(AppSettings appSettings);
        User Login(string username, string password, AppSettings appSettings);
        bool ResetPassword(string username, string adminPassword);
        bool ChangePassword(string username, string oldPassword, string newPassword);
    }
}
