using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Services.Interfaces
{
    public interface IProductDataStore : IDataStore<Product>
    {
        IEnumerable<Product> GetProductsByProducer(string producerName);

        IEnumerable<Product> GetProductsByName(string name);

        IEnumerable<Product> GetProductsByMaterial(string material);

        IEnumerable<Product> GetProductsWithPriceLess(decimal price);

        IEnumerable<Product> GetProductsWithPriceMore(decimal price);

    }
}
