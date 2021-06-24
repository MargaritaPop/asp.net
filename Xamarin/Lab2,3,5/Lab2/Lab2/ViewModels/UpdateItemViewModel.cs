using Lab2.Models;
using Lab2.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab2.ViewModels
{
    class UpdateItemViewModel : NewItemViewModel
    {
        public UpdateItemViewModel(INavigation navigation, Cocktail item) : base(navigation)
        {
            Item = item;
            OnPropertyChanged("Item");
            SaveItemCommand = new Command<Page>(async (page) => await ExecuteSaveItemCommand(page));
        }

        async Task ExecuteSaveItemCommand(Page page)
        {
            if (!ValidationHelper.IsFormValid(Item, page)) { return; }
            await DataStore.UpdateItemAsync(Item);
            await navigation.PopModalAsync();
        }

    }
}
