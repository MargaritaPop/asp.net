using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Lab2.Models;
using Plugin.FilePicker;
using Lab2.ViewModels;

namespace Lab2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {

        public NewItemPage(BaseViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

    }
}