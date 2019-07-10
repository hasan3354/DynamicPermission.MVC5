using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermissionMVC5.Data
{
    public class UserRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }

        public int UserId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}