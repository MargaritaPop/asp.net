using Lab4.Models;
using Lab4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Lab4.ViewModels.Products
{
    public class ProductAddViewModel : AddItemViewModel<Product, ProductDataStore>
    {
        public ObservableCollection<Producer> Parents { get; set; }

        public ProductAddViewModel(INavigation navigation) : base(navigation)
        {
            Parents = new ObservableCollection<Producer>(DependencyService.Get<IDataStore<Producer>>().GetItemsAsync().Result);
        }
    }
}
