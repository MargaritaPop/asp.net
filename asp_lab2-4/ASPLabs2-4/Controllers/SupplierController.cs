using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLabs2_4.Controllers
{
    public class SupplierController : Controller
    {
        StationeryContext db = new StationeryContext();

        [HttpGet]
        public ActionResult Supplier()
        {
            return View(db.Suppliers.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {
            if (supplier != null)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
            }
            return RedirectToAction("Supplier");
        }

        [HttpGet]
        public ActionResult Back()
        {
            return RedirectToAction("Supplier");
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            Supplier supplier = db.Suppliers.First(a => a.Id == id);
            return View(supplier);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            ViewBag.Id = id;
            Supplier supplier = db.Suppliers.FirstOrDefault(a => a.Id == id);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult Editor(Supplier supplier)
        {
            db.Entry(supplier).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Supplier");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Id = id;
            Supplier supplier = db.Suppliers.FirstOrDefault(a => a.Id == id);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var supplier = db.Suppliers.First(b => b.Id == id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Supplier");
        }

    }
}