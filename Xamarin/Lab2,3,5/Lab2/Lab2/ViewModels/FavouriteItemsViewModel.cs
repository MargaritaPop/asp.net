using Lab2.Models;
using Lab2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab2.ViewModels
{
    class FavouriteItemsViewModel : ItemsViewModel
    {
        public ObservableCollection<Grouping<string, Cocktail>> ItemGroups { get; set; }

        public FavouriteItemsViewModel(INavigation navigation) : base(navigation)
        {
            Title = "Избранные продукты";
            var items = DataStore.GetItemsAsync().Result;
            CreateGroups(items);
        }

        protected override async Task Reload()
        {
            await base.Reload();
            CreateGroups(Items);

        }

        private void CreateGroups(IEnumerable<Cocktail> items)
        {
            var groups = items.GroupBy(s => s.Ingredient).Select(g => new Grouping<string, Cocktail>(g.Key, g));
            ItemGroups = new ObservableCollection<Grouping<string, Cocktail>>(groups);
            OnPropertyChanged("ItemGroups");
        }
    }
}
