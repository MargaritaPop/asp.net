using ASPLabs2_4.Models;
using ASPLabs2_4.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLabs2_4.Controllers
{
    public class EditController : Controller
    {
        StationeryContext db = new StationeryContext();
        public ActionResult Edit(int? categoryId, string? maker)
        {
            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();

            categoryModels.Insert(0, new CategoryModel { Id = 0, Name = "Все" });

            IndexViewModel indexViewModel = new IndexViewModel() { Categories = categoryModels, Stationeries = db.Stationeries.ToList() };

            if (categoryId != null && categoryId > 0)
                indexViewModel.Stationeries = indexViewModel.Stationeries.Where(p => p.Category.Id == categoryId);
            if (maker != null && maker.Length > 0 && maker != "Все")
                indexViewModel.Stationeries = indexViewModel.Stationeries.Where(p => p.Maker == maker);
            
            return View(indexViewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
            StationeryCategoryViewModel StationeryCategoryViewModel = new StationeryCategoryViewModel() { Categories = categoryModels };
            return View(StationeryCategoryViewModel);
        }

        [HttpPost]
        public ActionResult Add(Stationery Stationery, HttpPostedFileBase upload, int categoryId)
        {
            if (upload != null)
            {
                string path = "/Pictures/" + upload.FileName;
                upload.SaveAs(Server.MapPath(path));
                Stationery.ImagePath = path;
                Stationery.Category = db.Categories.First(a=>a.Id == categoryId);
                db.Stationeries.Add(Stationery);
                db.SaveChanges();

            }
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult Back()
        {
            return RedirectToAction("Edit");
        }
        
        [HttpGet]
        public ActionResult Info(int id)
        {
            Stationery Stationery = db.Stationeries.Include(a=>a.Category).First(a => a.Id == id);
            return View(Stationery);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            ViewBag.StationeryId = id;
            Stationery Stationery = db.Stationeries.FirstOrDefault(a => a.Id == id);

            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
            StationeryCategoryViewModel StationeryCategoryViewModel = new StationeryCategoryViewModel() { Stationery=Stationery, Categories = categoryModels };
            return View(StationeryCategoryViewModel);
        }

        [HttpPost]
        public ActionResult Editor(Stationery Stationery, HttpPostedFileBase upload, int categoryId)
        {
            Stationery carOld = db.Stationeries.FirstOrDefault(a => a.Id == Stationery.Id);
            carOld.Name = Stationery.Name;
            carOld.Maker= Stationery.Maker;
            if(upload != null)
            {
                string path = "/Pictures/" + upload.FileName;
                upload.SaveAs(Server.MapPath(path));
                carOld.ImagePath = path;
               
            }
            carOld.Price = Stationery.Price;
            carOld.Brand = Stationery.Brand;
            carOld.Category = db.Categories.First(a => a.Id == categoryId);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.StationeryId = id;
            Stationery Stationery = db.Stationeries.FirstOrDefault(a=>a.Id == id);
            return View(Stationery);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var Stationery = db.Stationeries.First(b => b.Id == id);
            db.Stationeries.Remove(Stationery);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }
    }
}