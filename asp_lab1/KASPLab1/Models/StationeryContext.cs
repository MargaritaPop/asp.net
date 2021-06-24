using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KASPLab1.Models
{
    public class StationeryContext : DbContext
    {
        public DbSet<Stationery> Stationeries { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}