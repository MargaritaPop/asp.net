using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5WebApi.Models
{

    public class Cocktail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Producer { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public DateTime SellDate { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")] 
        public string Telephone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
   
}