using Lab4.Models;
using Lab4.Views.Producers;
using Lab4.Views.Products;
using Lab4.Views.Purchases;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Products, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Products:
                        MenuPages.Add(id, new NavigationPage(new ProductPage()));
                        break;
                    case (int)MenuItemType.Purchases:
                        MenuPages.Add(id, new NavigationPage(new PurchasePage()));
                        break;
                    case (int)MenuItemType.Producers:
                        MenuPages.Add(id, new NavigationPage(new ProducerPage()));
                        break;
                    case (int)MenuItemType.Queries:
                        MenuPages.Add(id, new NavigationPage(new QueriesPage()));
                        break;
                    case (int)MenuItemType.Grouping:
                        MenuPages.Add(id, new NavigationPage(new GroupingPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}