using Lab4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GroupingPage : ContentPage
	{
		public GroupingPage ()
		{
			InitializeComponent ();

            BindingContext = new GroupingViewModel();
		}
	}
}