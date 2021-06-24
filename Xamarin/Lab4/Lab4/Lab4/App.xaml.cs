using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lab4.Views;
using Lab4.Services;
using System.Linq;
using Lab4.Services.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Lab4
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                if(db.Producers.Count() == 0 && db.Products.Count() == 0 && db.Purchases.Count() == 0)
                {
                    var Spartak = new Models.Producer()
                    {
                        Name = "Спартак",
                        Address = "Гомель",
                        Telephone = "123-12-12",
                        Email = "Spartak@gmail.com",
                        
                    };
                    db.Producers.Add(Spartak);
                    db.SaveChanges();
                }
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
