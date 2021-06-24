using Lab4.Models;
using Lab4.Services;
using Lab4.Views.Producers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab4.ViewModels
{
    public class ProducerViewModel : AbstractItemsViewModel<Producer, ProducerDataStore>
    {
        public ProducerViewModel(INavigation navigation) : base(navigation)
        {
        }

        protected async override Task ExecuteAddItemCommand()
        {
            await navigation.PushModalAsync(new NavigationPage(new AddProducerPage(new AddItemViewModel<Producer, ProducerDataStore>(navigation))));
        }

        protected async override Task ExecuteUpdateSelectedCommand()
        {
            await navigation.PushModalAsync(new NavigationPage(new AddProducerPage(new UpdateItemViewModel<Producer, ProducerDataStore>(navigation, SelectedItem))));
        }
    }
}
