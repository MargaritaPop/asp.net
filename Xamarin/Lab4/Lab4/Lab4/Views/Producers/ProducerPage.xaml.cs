using Lab4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab4.Views.Producers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProducerPage : ContentPage
	{
		public ProducerPage ()
		{
			InitializeComponent ();

            BindingContext = new ProducerViewModel(Navigation);
		}
	}
}