using Lab4.Models;
using Lab4.Services;
using Lab4.ViewModels;
using Lab4.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab4.Views.Products
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProductPage : ContentPage
	{
		public AddProductPage (BaseViewModel<Product, ProductDataStore> productAddViewModel)
		{
			InitializeComponent ();
            BindingContext = productAddViewModel;
        }
	}
}