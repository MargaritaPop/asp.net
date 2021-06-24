using Lab2.Models;
using Lab2.Validation;
using Plugin.FilePicker;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab2.ViewModels
{
    class NewItemViewModel : BaseViewModel
    {
        public Command SaveItemCommand { get; set; }

        public Command LoadImageCommand { get; set; }

        public Cocktail Item { get; set; }

        protected INavigation navigation;

        public NewItemViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            SaveItemCommand = new Command<Page>(async (page) => await ExecuteSaveItemCommand(page));
            LoadImageCommand = new Command(async () => await ExecuteLoadImageCommand());
            Item = new Cocktail()
            {
                SellDate = DateTime.Now
            };
        }

        async Task ExecuteSaveItemCommand(Page page)
        {
            if (!ValidationHelper.IsFormValid(Item, page)) { return; }
            await DataStore.AddItemAsync(Item);
            await navigation.PopModalAsync();
        }

        async Task ExecuteLoadImageCommand()
        {
            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                Item.Image = file.FilePath;
                OnPropertyChanged("Item");
            }
        }
    }
}
