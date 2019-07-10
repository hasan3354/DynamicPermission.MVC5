using PermissionMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermissionMVC5.Controllers
{
    [Authorize]
    public class Test1Controller : Controller
    {
        // GET: Test1
        [PermessionType(PermissionType.Read)]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Test1/Details/5
        [PermessionType(PermissionType.Read)]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test1/Create
        [PermessionType(PermissionType.Read)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test1/Create
        [HttpPost]
        [PermessionType(PermissionType.Write)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test1/Edit/5
        [PermessionType(PermissionType.Write)]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test1/Edit/5
        [HttpPost]
        [PermessionType(PermissionType.Write)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test1/Delete/5
        [PermessionType(PermissionType.Delete)]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test1/Delete/5
        [HttpPost]
        [PermessionType(PermissionType.Delete)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
