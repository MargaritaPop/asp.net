using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.Models;
using Lab4.Services;
using Lab4.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab4.Views.Producers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProducerPage : ContentPage
	{

        public AddProducerPage (BaseViewModel<Producer, ProducerDataStore> addItemViewModel)
		{
			InitializeComponent ();
            BindingContext = addItemViewModel;
        }

    }
}