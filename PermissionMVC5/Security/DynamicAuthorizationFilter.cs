using Newtonsoft.Json;
using PermissionMVC5.Data;
using PermissionMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermissionMVC5.Security
{
    public class DynamicAuthorizationFilter : IAuthorizationFilter
    {
        private readonly ApplicationDbContext _context;

        public DynamicAuthorizationFilter()
        {
            _context = new ApplicationDbContext();
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsProtectedAction(filterContext))
                return;

            if (!IsUserAuthenticated(filterContext))
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            var actionId = GetActionId(filterContext);
            var userName = filterContext.HttpContext.User.Identity.Name;

            var roles = (
                from user in _context.Users
                join userRole in _context.UserRoles on user.Id equals userRole.UserId
                join role in _context.Roles on userRole.RoleId equals role.Id
                where user.UserName == userName
                select role
            ).ToList();

            foreach (var role in roles)
            {
                if (role.Permission == null)
                    continue;

                var accessList = JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Permission);
                var permissions = filterContext.ActionDescriptor.GetCustomAttributes(typeof(PermessionTypeAttribute), true);
                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.Name;

                var controllerPermission = accessList.Where(x => x.Id == controllerName);
                var totalPermission = controllerPermission.Select(x => x.SelectedPermissions.Where(y => permissions.Any(z=>z.ToString()==y.Name)));
                if (totalPermission.Any())
                    return;
                //var test = accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId && a.PermissionType == Controllers.Helpers.PermissionTypes.Read);
//                if (accessList.SelectMany(c => c.SelectedPermissions).Any(a => a.Name == filterContext.ActionDescriptor.GetCustomAttributes(typeof(PermessionTypeAttribute), true))
//{
//                    return;
//                }
            }

            filterContext.Result = new HttpUnauthorizedResult();
        }


        private bool IsProtectedAction(AuthorizationContext context)
        {
            if (context.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                         || context.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return false;
            }

           
            if (context.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AuthorizeAttribute), true))
                return true;

            if (context.ActionDescriptor.IsDefined(typeof(AuthorizeAttribute), true))
                return true;

            return false;
        }

        private bool IsUserAuthenticated(AuthorizationContext context)
        {
            return context.HttpContext.User.Identity.IsAuthenticated;
        }

        private string GetActionId(AuthorizationContext context)
        {
            var controllerActionDescriptor = context.ActionDescriptor;
            var controller = controllerActionDescriptor.ControllerDescriptor.ControllerName;
            var action = controllerActionDescriptor.ActionName;

            return $"{controller}:{action}";
        }
    }
}