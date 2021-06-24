using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLabs2_4.Controllers
{
    public class CategoryController : Controller
    {
        StationeryContext db = new StationeryContext();

        [HttpGet]
        public ActionResult Category()
        {
            return View(db.Categories.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (category != null)
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Category");
        }

        [HttpGet]
        public ActionResult Back()
        {
            return RedirectToAction("Category");
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            Category category = db.Categories.First(a => a.Id == id);
            return View(category);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            ViewBag.Id = id;
            Category category = db.Categories.FirstOrDefault(a => a.Id == id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Editor(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Id = id;
            Category category = db.Categories.FirstOrDefault(a => a.Id == id);
            return View(category);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = db.Categories.First(b => b.Id == id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Category");
        }
    }
}