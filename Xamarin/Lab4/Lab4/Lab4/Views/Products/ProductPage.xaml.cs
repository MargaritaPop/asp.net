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
	public partial class ProductPage : ContentPage
	{
		public ProductPage ()
		{
			InitializeComponent ();

            BindingContext = new ProductViewModel(Navigation);
        }
	}
}