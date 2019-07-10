using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermissionMVC5.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}