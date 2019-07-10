using PermissionMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermissionMVC5.Controllers
{
    [Authorize]
    public class TestController2Controller : Controller
    {
        // GET: TestController2
        [PermessionType(PermissionType.Read)]
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestController2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestController2/Create
        [PermessionType(PermissionType.Write)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestController2/Create
        [HttpPost]
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

        // GET: TestController2/Edit/5
        [PermessionType(PermissionType.Delete)]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestController2/Edit/5
        [HttpPost]
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

        // GET: TestController2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestController2/Delete/5
        [HttpPost]
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
