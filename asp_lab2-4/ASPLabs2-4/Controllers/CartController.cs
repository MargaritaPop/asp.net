using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLabs2_4.Controllers
{
    public class CartController : Controller
    {
        StationeryContext db = new StationeryContext();
        
        public ActionResult Cart()
        {
           
            return View(GetCart());
        }

        public ActionResult Add(int id)
        {
            
            Stationery Stationery = db.Stationeries.Where(a => a.Id == id).FirstOrDefault();
            if(Stationery != null)
            {
                GetCart().AddItem(Stationery, 1);
            }
            return RedirectToAction("Catalog","Catalog");
        }

        public ActionResult Delete(int id)
        {
            Stationery Stationery = db.Stationeries.Where(a => a.Id == id).FirstOrDefault();
            if(Stationery != null)
            {
                GetCart().RemoveLine(Stationery);
            }
            return RedirectToAction("Cart", "Cart");
        }

        public ActionResult ClearAll()
        {
            GetCart().Clear();
            return RedirectToAction("Cart", "Cart");
        }

        public Cart.Cart GetCart()
        {
            Cart.Cart cart = (Cart.Cart)Session["Cart"+User.Identity.Name];
            if(cart == null)
            {
                cart = new Cart.Cart();
                Session["Cart"+User.Identity.Name] = cart;
            }
            return cart;
        }
    }
}