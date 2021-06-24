using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Models
{
    public class Purchase : Entity
    {
        public Product Product { get; set; }

        public int Amount { get; set; }

        public decimal SellPrice { get; set; }

        public DateTime SellDate { get; set; }
    }
}
