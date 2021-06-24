using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public Producer Producer { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public string Material { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
