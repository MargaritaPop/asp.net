using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPLabs2_4.ViewModels
{
    public class StationeryCategoryViewModel
    {
        public Stationery Stationery { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}