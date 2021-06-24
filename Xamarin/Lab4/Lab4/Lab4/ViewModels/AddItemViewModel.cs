using Lab4.Models;
using Lab4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab4.ViewModels
{
    public class AddItemViewModel<T, U> : BaseViewModel<T, U> where T : Entity, new() where U : class, IDataStore<T>
    {
        public Command SaveItemCommand { get; set; }

        public T Item { get; set; }

        protected INavigation navigation;

        public AddItemViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            SaveItemCommand = new Command<Page>(async (page) => await ExecuteSaveItemCommand(page));
            Item = new T();
        }

        async Task ExecuteSaveItemCommand(Page page)
        {
            await DataStore.AddItemAsync(Item);
            await navigation.PopModalAsync();
        }

    }


}

