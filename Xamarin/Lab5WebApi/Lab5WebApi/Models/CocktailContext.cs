using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab5WebApi.Models
{
    public class CocktailContext : DbContext
    {
        public DbSet<Cocktail> CocktailSet { get; set; }
    }
}