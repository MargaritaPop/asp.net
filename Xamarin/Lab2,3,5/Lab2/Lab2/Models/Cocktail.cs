using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab2.Models
{
    public class Cocktail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ingredient { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public DateTime SellDate { get; set; }

        [RegularExpression(@"^\d{3}-\d{2}-\d{2}$")] //Format: ###-##-##
        public string Telephone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
