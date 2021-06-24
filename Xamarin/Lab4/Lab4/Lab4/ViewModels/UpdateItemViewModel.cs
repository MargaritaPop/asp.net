using Lab4.Models;
using Lab4.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab4.ViewModels
{
    public class UpdateItemViewModel<T, U> : AddItemViewModel<T, U> where T : Entity, new() where U : class, IDataStore<T>
    {
        public UpdateItemViewModel(INavigation navigation, T item) : base(navigation)
        {
            Item = item;
            OnPropertyChanged("Item");
            SaveItemCommand = new Command<Page>(async (page) => await ExecuteSaveItemCommand(page));
        }

        async Task ExecuteSaveItemCommand(Page page)
        {
            await DataStore.UpdateItemAsync(Item);
            await navigation.PopModalAsync();
        }
    }
}
