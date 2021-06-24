using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLabs2_4.Controllers
{
    public class DeliveryController : Controller
    {
        StationeryContext db = new StationeryContext();

        [HttpGet]
        public ActionResult Delivery()
        {
            return View(db.Deliveries.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Delivery delivery)
        {
            if (delivery != null)
            {
                db.Deliveries.Add(delivery);
                db.SaveChanges();
            }
            return RedirectToAction("Delivery");
        }

        [HttpGet]
        public ActionResult Back()
        {
            return RedirectToAction("Delivery");
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            Delivery delivery = db.Deliveries.First(a => a.Id == id);
            return View(delivery);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            ViewBag.Id = id;
            Delivery delivery = db.Deliveries.FirstOrDefault(a => a.Id == id);
            return View(delivery);
        }

        [HttpPost]
        public ActionResult Editor(Delivery delivery)
        {
            db.Entry(delivery).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Delivery");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Id = id;
            Delivery delivery = db.Deliveries.FirstOrDefault(a => a.Id == id);
            return View(delivery);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var delivery = db.Deliveries.First(b => b.Id == id);
            db.Deliveries.Remove(delivery);
            db.SaveChanges();
            return RedirectToAction("Delivery");
        }
    }
}