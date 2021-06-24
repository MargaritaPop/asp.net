using KASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KASPLab1.Controllers
{
    public class HomeController : Controller
    {
        StationeryContext db = new StationeryContext();
        public ActionResult Index()
        {
            IEnumerable<Stationery> stationeries = db.Stationeries;
            IEnumerable<Order> orders = db.Orders;
            ViewBag.Stationeries = stationeries;
            ViewBag.Orders = orders;
            return View();
        }

        [HttpGet]
        public ActionResult Order(int id)
        {
            ViewBag.stationery = id;
            return View();
        }

        [HttpPost]
        public string Order(Order order)
        {
            order.date = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();
            return "Спасибо за покупку, " + order.client + "! <a href='/'>Назад</a>";
        }
    }
}