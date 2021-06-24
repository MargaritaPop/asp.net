using Lab4.Models;
using Lab4.Services;
using Lab4.Views.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab4.ViewModels.Products
{
    public class ProductViewModel : AbstractItemsViewModel<Product, ProductDataStore>
    {
        public ProductViewModel(INavigation navigation) : base(navigation)
        {
        }

        protected async override Task ExecuteAddItemCommand()
        {
            await navigation.PushModalAsync(new NavigationPage(new AddProductPage(new ProductAddViewModel(navigation))));
        }

        protected async override Task ExecuteUpdateSelectedCommand()
        {
            await navigation.PushModalAsync(new NavigationPage(new AddProductPage(new ProductUpdateViewModel(navigation, SelectedItem))));
        }
    }
}
