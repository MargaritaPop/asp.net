using Lab4.Models;
using Lab4.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(ApplicationContext))]
namespace Lab4.Services
{
    public class ApplicationContext : DbContext
    {

        public const string dbFileName = "cocktail.db";

        private readonly string _databasePath = DependencyService.Get<IPath>().GetDatabasePath("cocktail.db");

        public DbSet<Product> Products { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public ApplicationContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public ApplicationContext(string databasePath) : this()
        {

            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

    }
}
