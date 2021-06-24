using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Data
{
    class Cocktail
    {
        public string Name { get; set; }

        public string Ingredient { get; set; }

        public decimal Price { get; set; }

        public DateTime SaleDate { get; set; }

        public bool Elected { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
