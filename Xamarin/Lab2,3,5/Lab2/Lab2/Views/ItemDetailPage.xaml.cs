using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Lab2.Models;
using Lab2.ViewModels;

namespace Lab2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Cocktail();

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}