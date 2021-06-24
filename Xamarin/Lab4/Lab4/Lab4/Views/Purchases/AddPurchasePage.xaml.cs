using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.Models;
using Lab4.Services;
using Lab4.ViewModels;
using Lab4.ViewModels.Purchases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab4.Views.Purchases
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPurchasePage : ContentPage
	{

        public AddPurchasePage (BaseViewModel<Purchase, PurchaseDataStore> purchaseAddViewModel)
		{
			InitializeComponent ();
            BindingContext = purchaseAddViewModel;
		}

    }
}