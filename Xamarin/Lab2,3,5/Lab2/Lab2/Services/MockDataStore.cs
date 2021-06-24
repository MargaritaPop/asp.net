using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;


[assembly: Xamarin.Forms.Dependency(typeof(Lab2.Services.MockDataStore))]
namespace Lab2.Services
{
    public class MockDataStore : IDataStore<Cocktail>
    {
        List<Cocktail> items;

        public MockDataStore()
        {
            items = new List<Cocktail>();
            var mockItems = new List<Cocktail>
            {
                new Cocktail
                    {
                        Name = "Текила санрайз",
                        Ingredient = "Cеребрянная текила",
                        Price = 10.20m,
                        SaleDate = DateTime.Now

                    },
                    new Cocktail
                    {
                        Name = "Кровавая Мэри",
                        Ingredient = "Томатный сок",
                        Price = 12.20m,
                        SaleDate = DateTime.Now

                    },
                    new Cocktail
                    {
                        Name = "Белый русский",
                        Ingredient = "Кофейный ликер",
                        Price = 13.43m,
                        SaleDate = DateTime.Now,
                    }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Cocktail item)
        {
            item.Id = items.Max(it => it.Id) + 1;
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Cocktail item)
        {
            var oldItem = items.Where((Cocktail arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Cocktail arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Cocktail> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Cocktail>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}