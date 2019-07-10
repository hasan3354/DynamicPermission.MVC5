using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermissionMVC5.Models
{
    
    public class PermessionTypeAttribute:Attribute
    {
        //public readonly string PermissionName;
        private List<string> _permissionList=new List<string>();
        public PermessionTypeAttribute(params PermissionType[] permissonNames)
        {
            //PermissionName = permissonName.ToString();
            foreach (var item in permissonNames)
                _permissionList.Add(item.ToString());

            
        }

        public List<string> Permissions { get { return _permissionList; } }
    }
}