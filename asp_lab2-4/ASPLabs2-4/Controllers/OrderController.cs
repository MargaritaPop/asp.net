using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLabs2_4.Controllers
{
    public class OrderController : Controller
    {
        StationeryContext db = new StationeryContext();

        public ActionResult Order(string? client, string? wageType)
        {
            IEnumerable<Order> orders = db.Orders.ToList(); 
            if (client != null && client.Length > 0 && client != "Все")
                orders = orders.Where(p => p.Client == client);
            if (wageType != null && wageType.Length > 0 && wageType != "Все")
                orders = orders.Where(p => p.WageType == wageType);
            return View(orders);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Order order)
        {
            if (order != null)
            {
                order.Date = DateTime.Now;
                db.Orders.Add(order);
                db.SaveChanges();
            }
            return RedirectToAction("Order");
        }

        [HttpGet]
        public ActionResult Back()
        {
            return RedirectToAction("Order");
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            Order order = db.Orders.First(a => a.OrderId == id);
            return View(order);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            ViewBag.Id = id;
            Order order = db.Orders.FirstOrDefault(a => a.OrderId == id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Editor(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Order");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Id = id;
            Order order = db.Orders.FirstOrDefault(a => a.OrderId == id);
            return View(order);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int purchaseId)
        {
            var order = db.Orders.First(b => b.OrderId == purchaseId);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Order");
        }
    }
}