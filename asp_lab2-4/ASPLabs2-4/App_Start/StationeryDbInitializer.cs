using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPLabs2_4.App_Start
{
    public class StationeryDbInitializer : CreateDatabaseIfNotExists<StationeryContext>
    {
        protected override void Seed(StationeryContext db)
        {
            Category category1 = new Category { Name = "Степлер" };
            Category category2 = new Category { Name = "Блокнот" };
            Category category3 = new Category { Name = "Бумага" };
            Category category4 = new Category { Name = "Корректор" };
            Category category5 = new Category { Name = "Дырокол" };
            Category category6 = new Category { Name = "Циркуль" };
            Category category7 = new Category { Name = "Клей" };

            db.Categories.Add(category1);
            db.Categories.Add(category2);
            db.Categories.Add(category3);
            db.Categories.Add(category4);
            db.Categories.Add(category5);
            db.Categories.Add(category6);
            db.Categories.Add(category7);


            db.Stationeries.Add(new Stationery { Name = "Nowa-35/S", Maker = "Kangaro", ImagePath = "", Brand = "Nowa-35", Price = 24, Category = category1 });
            db.Stationeries.Add(new Stationery { Name = "Greenlogic standard mini", Maker = "Maped", ImagePath = "", Brand = "Greenlogic", Price = 24, Category = category1 });
            db.Stationeries.Add(new Stationery { Name = "Aion-10G", Maker = "Kangaro", ImagePath = "", Brand = "Greenlogic", Price = 64, Category = category5 });
            db.Stationeries.Add(new Stationery { Name = "Kores fluid", Maker = "Kores", ImagePath = "", Brand = "Kores", Price = 1, Category = category4 });
            db.Stationeries.Add(new Stationery { Name = "Q-Connect", Maker = "Q-Connect", ImagePath = "", Brand = "Q-Connect", Price = 1, Category = category7 });



            db.Suppliers.Add(new Supplier { Name = "Kangaro", Country = "Россия" });
            db.Suppliers.Add(new Supplier { Name = "Q-Connect", Country = "США" });
            db.Suppliers.Add(new Supplier { Name = "Kores", Country = "Австрия" });

            db.Deliveries.Add(new Delivery { NameOfProduct = "Nowa-35/S", Count = 30 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Greenlogic standard mini", Count = 70 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Aion-10G", Count = 20 });

            base.Seed(db);
        }
    }
}