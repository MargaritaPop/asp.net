using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Models
{
    public class Producer : Entity
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
