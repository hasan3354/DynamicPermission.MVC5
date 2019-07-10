using PermissionMVC5.Data;
using PermissionMVC5.Security;
using System.Web;
using System.Web.Mvc;

namespace PermissionMVC5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new DynamicAuthorizationFilter());
        }
    }
}
