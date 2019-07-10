using Newtonsoft.Json;
using PermissionMVC5.Data;
using PermissionMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PermissionMVC5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [PermessionType(PermissionType.Read)]
        public ActionResult Index()
        {
            //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket("mubassir", false);
            //string encTicket = FormsAuthentication.Encrypt(authTicket);
            //HttpCookie faCookie = new HttpCookie("mycokkie", encTicket);
            //Response.Cookies.Add(faCookie);
            FormsAuthentication.SetAuthCookie("mubassir", false);

            return View();
        }

        [PermessionType(PermissionType.Read)]
        public ActionResult About()
        {
            var model = new RoleViewModel();
            ControllerDescovery discovery = new ControllerDescovery();
            var list = discovery.GetAllControllers();
            ViewBag.Controllers = list;

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(RoleViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                var role = new Role
                {
                    Name = model.Name,
                };

                if (model.SelectedControllers != null && model.SelectedControllers.Any())
                {
                    

                    var accessJson = JsonConvert.SerializeObject(model.SelectedControllers);
                    role.Permission = accessJson;
                }
                _context.Roles.Add(role);
                _context.SaveChanges();

            }
            return View();
        }

        [Authorize]
        [PermessionType(PermissionType.Delete,PermissionType.Read)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}