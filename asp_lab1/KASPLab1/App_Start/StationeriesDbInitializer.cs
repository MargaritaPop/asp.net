using KASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KASPLab1.App_Start
{
    public class StationeriesDbInitializer : DropCreateDatabaseAlways<StationeryContext>
    {

        protected override void Seed(StationeryContext db)
        {
            db.Stationeries.Add(new Stationery
            {
                id = 1,
                name = "Скобосшиватель 1",
                description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                img = "https://www.officeton.by/upload/resize_cache/slam.image/Sh/imageCache/069/86e/04af62576e294b65d49ea242f5dd978e.jpg",
                wholesale_price = 12,
                retail_price = 10,
                available = 10,
            });
            db.Stationeries.Add(new Stationery
            {
                id = 2,
                name = "Скобосшиватель 2",
                description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                img = "https://www.officeton.by/upload/resize_cache/slam.image/Sh/imageCache/069/86e/04af62576e294b65d49ea242f5dd978e.jpg",
                wholesale_price = 12,
                retail_price = 10,
                available = 10,
            });
            base.Seed(db);
        }
    }
}