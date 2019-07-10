using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PermissionMVC5.Models
{
    public class ControllerDescovery
    {
        private List<MvcControllerInfo> _mvcControllers;
        public  IEnumerable<MvcControllerInfo> GetAllControllers()
        {
            if (_mvcControllers != null)
                return _mvcControllers;
            _mvcControllers = new List<MvcControllerInfo>();
            var asm = Assembly.GetExecutingAssembly();
            var controllers = asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type))
                .Select(x=>x).ToList();

            var controlleractionlist = asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .GroupBy(x=>x.MemberType)
                .ToList();



            foreach (var controller in controllers)
            {
                var methods = controller.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
                if ( !methods.Any())
                {
                    continue;
                }
                var currentController = new MvcControllerInfo
                {
                    
                    DisplayName = controller.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName,
                    Name=controller.Name
                };
                var actions = new List<SelectedPermission>();
                foreach (var method in methods)
                {
                    
                    if (IsProtectedAction(controller, method))
                    {
                        //var permissionName = method.GetCustomAttribute<PermessionTypeAttribute>()?.PermissionName;
                        //if(!actions.Any(x=>x.Name==permissionName) && !string.IsNullOrEmpty(permissionName))
                        //actions.Add(new SelectedPermission
                        //{
                        //    Name=permissionName
                        //});
                        var permissionList = new List<string>();
                        if (method.GetCustomAttribute<PermessionTypeAttribute>()?.Permissions == null)
                        {
                            permissionList.Add(PermissionType.Read.ToString());
                        }
                        else
                        {
                            permissionList.AddRange(method.GetCustomAttribute<PermessionTypeAttribute>().Permissions);
                        }
                        
                        foreach (var permissionName in permissionList)
                        {
                            if (!actions.Any(x => x.Name == permissionName) && !string.IsNullOrEmpty(permissionName))
                                actions.Add(new SelectedPermission
                                {
                                    Name = permissionName
                                });
                        }
                    }

                }
                if (actions.Any())
                {
                    currentController.SelectedPermissions = actions;
                    _mvcControllers.Add(currentController);
                }
            }


            return _mvcControllers;

        }

        private static bool IsProtectedAction(MemberInfo controllerTypeInfo, MemberInfo actionMethodInfo)
        {
            if (actionMethodInfo.GetCustomAttribute<AllowAnonymousAttribute>(true) != null)
                return false;

            if (controllerTypeInfo.GetCustomAttribute<AuthorizeAttribute>(true) != null)
                return true;

            if (actionMethodInfo.GetCustomAttribute<AuthorizeAttribute>(true) != null)
                return true;

            return false;
        }

        //menu finder
        public static void GetMenuXml()
        {
            var projectName = Assembly.GetExecutingAssembly().FullName.Split(',')[0];

            Assembly asm = Assembly.GetAssembly(typeof(MvcApplication));

            var model = asm.GetTypes().
                SelectMany(t => t.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(d => d.ReturnType.Name == "ActionResult").Select(n => new 
                {
                    Controller = n.DeclaringType?.Name.Replace("Controller", ""),
                    Action = n.Name,
                    ReturnType = n.ReturnType.Name,
                    Attributes = string.Join(",", n.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))),
                    Area = n.DeclaringType.Namespace.ToString().Replace(projectName + ".", "").Replace("Areas.", "").Replace(".Controllers", "").Replace("Controllers", "")
                });

            //SaveData(model.ToList());
        }
    }

    
}