using Lab4.Models;
using Lab4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Lab4.Services;
using Xamarin.Forms;
using System.Threading.Tasks;

[assembly: Dependency(typeof(PurchaseDataStore))]
namespace Lab4.Services
{
    public class PurchaseDataStore : AbstractCrudDbDataStore<Purchase>, IPurchaseDataStore
    {

        public PurchaseDataStore() : base(new ApplicationContext())
        {

        }

        public PurchaseDataStore(ApplicationContext applicationContext) : base(applicationContext)
        {

        }


        public override async Task<bool> AddItemAsync(Purchase item)
        {
            applicationContext.Attach(item.Product);
            return await base.AddItemAsync(item);
        }

        public override async Task<bool> UpdateItemAsync(Purchase item)
        {
            applicationContext.Attach(item.Product);
            return await base.UpdateItemAsync(item);
        }


        public IQueryable<ResultLine> GetProductSalesByYear(int year)
        {
            var result = from p in applicationContext.Purchases
                         where p.SellDate.Year == year
                         group p by p.Product into g
                         select new ResultLine { Name = g.Key.Name, Count = g.Sum(p => p.Amount),
                             TotalPrice = g.Sum(p => p.SellPrice * p.Amount) };
            return result;
        }

    }
}
