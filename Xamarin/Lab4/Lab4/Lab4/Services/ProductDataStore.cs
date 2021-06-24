using Lab4.Models;
using Lab4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Lab4.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProductDataStore))]
namespace Lab4.Services
{
    public class ProductDataStore : AbstractCrudDbDataStore<Product>, IProductDataStore
    {
        public ProductDataStore() : base(new ApplicationContext())
        {

        }


        public ProductDataStore(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public override async Task<bool> AddItemAsync(Product item)
        {
            applicationContext.Attach(item.Producer);
            return await base.AddItemAsync(item);
        }

        public override async Task<bool> UpdateItemAsync(Product item)
        {
            applicationContext.Attach(item.Producer);
            return await base.UpdateItemAsync(item);
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return applicationContext.Products.Where(p => p.Name.ToUpper().Contains(name.ToUpper()));
        }

        public IEnumerable<Product> GetProductsByProducer(string producerName)
        {
            return applicationContext.Products.Where(product => product.Producer.Name == producerName);
        }

        public IEnumerable<Product> GetProductsByMaterial(string material)
        {
            return applicationContext.Products.Where(product => product.Material == material);
        }

        public IEnumerable<Product> GetProductsWithPriceLess(decimal price)
        {
            var result = applicationContext.Products.Where(product => product.Price < price);
            return result;
        }

        public IEnumerable<Product> GetProductsWithPriceMore(decimal price)
        {
            var result = applicationContext.Products.Where(product => product.Price > price);
            return result;
        }

    }
}
