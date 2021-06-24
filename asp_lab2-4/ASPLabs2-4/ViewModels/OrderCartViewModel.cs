using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPLabs2_4.ViewModels
{
    public class OrderCartViewModel
    {
        public Order Order { get; set; }
        public int Count { get; set; }
    }
}