using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermissionMVC5.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}