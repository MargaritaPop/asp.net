using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ASPLabs2_4.Cart
{
    public class Cart
    {
        
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Stationery Stationery, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Stationery.Id == Stationery.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Stationery = Stationery,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Stationery Stationery)
        {
            lineCollection.RemoveAll(l => l.Stationery.Id == Stationery.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Stationery.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public class CartLine
        {
            public Stationery Stationery { get; set; }
            public int Quantity { get; set; }
        }
    }
}