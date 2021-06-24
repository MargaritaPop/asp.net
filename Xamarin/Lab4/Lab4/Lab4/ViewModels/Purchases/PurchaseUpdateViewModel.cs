using Lab4.Models;
using Lab4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Lab4.ViewModels.Purchases
{
    public class PurchaseUpdateViewModel : UpdateItemViewModel<Purchase, PurchaseDataStore>
    {
        public ObservableCollection<Product> Parents { get; set; }

        public PurchaseUpdateViewModel(INavigation navigation, Purchase item) : base(navigation, item)
        {
            Parents = new ObservableCollection<Product>(DependencyService.Get<IDataStore<Product>>().GetItemsAsync().Result);

        }
    }
}
