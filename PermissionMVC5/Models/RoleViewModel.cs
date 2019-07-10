using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermissionMVC5.Models
{
    
    public class RoleViewModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }

        public List<MvcControllerInfo> SelectedControllers { get; set; }
        public List<SelectedPermission> PermissionList { get; set; }
    }
}