using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermissionMVC5.Models
{
       public class MvcControllerInfo
        {
            public string Id => $"{Name}";

            public string Name { get; set; }

            public string DisplayName { get; set; }

            public IEnumerable<SelectedPermission> SelectedPermissions { get; set; }
    }
    public class SelectedPermission
    {
        public string Name { get; set; }
    }

    public enum PermissionType
    {
        Read,
        Write,
        Delete
    }
}