using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab5WebApi.Models
{
public class CocktailInitializer : DropCreateDatabaseAlways<CocktailContext>
    {

        protected override void Seed(CocktailContext db)
        {
            db.CocktailSet.Add(new Cocktail
            {
                Name = "Текила санрайз",
                Ingredient = "Cеребрянная текила",
                Price = 10.20m,
                SaleDate = DateTime.Now

            });
            db.CocktailSet.Add(new Cocktail
                    {
                        Name = "Кровавая Мэри",
                        Ingredient = "Томатный сок",
                        Price = 12.20m,
                        SaleDate = DateTime.Now

                    });
            base.Seed(db);
        }
    }
}