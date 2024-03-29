﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
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
        public string Department { get; set; }
    }
}
