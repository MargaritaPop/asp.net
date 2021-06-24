using Lab4.Models;
using Lab4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Lab4.ViewModels.Products
{
    public class ProductUpdateViewModel : UpdateItemViewModel<Product, ProductDataStore>
    {
        public ObservableCollection<Producer> Parents { get; set; }

        public ProductUpdateViewModel(INavigation navigation, Product item) : base(navigation, item)
        {
            Parents = new ObservableCollection<Producer>(DependencyService.Get<IDataStore<Producer>>().GetItemsAsync().Result);
        }
    }
}
