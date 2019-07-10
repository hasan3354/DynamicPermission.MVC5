using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermissionMVC5.Controllers
{
    [Authorize]
    [DisplayName("Access Management")]
    public class Test3Controller : Controller
    {
        // GET: Test3
        public ActionResult Index()
        {
            return View();
        }

        // GET: Test3/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test3/Create
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

        // GET: Test3/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test3/Edit/5
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

        // GET: Test3/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test3/Delete/5
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
