using Lab4.Models;
using Lab4.Services;
using Lab4.Views;
using Lab4.Views.Purchases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab4.ViewModels.Purchases
{
    public class PurchaseViewModel : AbstractItemsViewModel<Purchase, PurchaseDataStore>
    {
        public PurchaseViewModel(INavigation navigation) : base(navigation)
        {
        }

        protected async override Task ExecuteAddItemCommand()
        {
            await navigation.PushModalAsync(new NavigationPage(new AddPurchasePage(new PurchaseAddViewModel(navigation))));
        }

        protected async override Task ExecuteUpdateSelectedCommand()
        {
            await navigation.PushModalAsync(new NavigationPage(new AddPurchasePage(new PurchaseUpdateViewModel(navigation, SelectedItem))));
        }

    }
}
