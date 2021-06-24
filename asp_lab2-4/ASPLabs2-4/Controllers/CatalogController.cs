using ASPLabs2_4.Models;
using ASPLabs2_4.ViewModels;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ASPLabs2_4.Controllers
{
    public class CatalogController : Controller
    {
        StationeryContext db = new StationeryContext();

        public ActionResult Catalog(string searchString, string sort)
        {
            List<Stationery> Stationeries = db.Stationeries.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                Stationeries = Search(searchString);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort == "Имя")
                {
                    Stationeries = db.Stationeries.OrderBy(a=>a.Name).ToList();
                }
                else if (sort == "Производитель")
                {
                    Stationeries = db.Stationeries.OrderBy(a => a.Maker).ToList();
                }
                else if (sort == "Цена")
                {
                    Stationeries = db.Stationeries.OrderBy(a => a.Price).ToList();
                }
            }

            return View(Stationeries);
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        {
            ViewBag.StationeryId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Order order)
        {
            order.Date = DateTime.Now;
            Cart.Cart cart = (Cart.Cart)Session["Cart" + User.Identity.Name];
            if (cart!= null && cart.Lines.Count() > 0)
            {
                foreach (var item in cart.Lines)
                {
                    order.StationeryId = item.Stationery.Id;
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        db.Orders.Add(order);
                        db.SaveChanges();
                    }
                }
                OrderCartViewModel purchCartViewModel = new OrderCartViewModel { Order = order, Count = cart.Lines.Count() };
                cart.Clear();
                return View("BoughtAll", purchCartViewModel);
            }
            else
            {
                db.Orders.Add(order);
            }
            db.SaveChanges();
            return RedirectToAction("Bought", order);
        }

        [HttpGet]
        public ActionResult Bought(Order order)
        {
            return View(order);
        }

        private List<Stationery> Search(string searchString)
        {
            var predicate = PredicateBuilder.New<Stationery>(e => false);


            Category category = db.Categories.FirstOrDefault(a => a.Name == searchString);

            if (category != null)
            {
                predicate.Or(a => a.CategoryId == category.Id);
            }
            predicate.Or(a => a.Name == searchString);
            predicate.Or(a => a.Maker == searchString);
            if (Int32.TryParse(searchString, out int result1))
            {
                predicate.Or(a => a.Price == result1);
            }
            predicate.Or(a => a.Brand == searchString);

            return new List<Stationery>(db.Stationeries.Where(predicate));

        }
    }
}