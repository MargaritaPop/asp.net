using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KASPLab1.Models
{
    public class Stationery
    {
        public int id { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public string img { set; get; }
        public int wholesale_price { set; get; }
        public int retail_price { set; get; }
        public int available { set; get; }

    }
}