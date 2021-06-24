using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPLabs2_4.Models
{
    public class StationeryContext : IdentityDbContext<ApplicationUser>
    {
        public StationeryContext()
            : base("StationeryContext")
        { }

        public static StationeryContext Create()
        {
            return new StationeryContext();
        }

        public DbSet<Stationery> Stationeries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}