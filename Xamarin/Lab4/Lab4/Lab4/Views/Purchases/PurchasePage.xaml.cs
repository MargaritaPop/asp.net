using Lab4.ViewModels.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab4.Views.Purchases
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PurchasePage : ContentPage
	{
		public PurchasePage ()
		{
			InitializeComponent ();

            BindingContext = new PurchaseViewModel(Navigation);
		}
	}
}