using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KASPLab1.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string client { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public DateTime date { get; set; }
    }
}
