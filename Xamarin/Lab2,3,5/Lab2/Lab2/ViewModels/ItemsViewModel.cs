using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Lab2.Models;
using Lab2.Views;

namespace Lab2.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Cocktail _selectedItem;

        public Cocktail SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Cocktail> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        public Command AddItemCommand { get; set; }

        public Command DeleteSelectedCommand { get; set; }

        public Command UpdateSelectedCommand { get; set; }

        public Command OpenDetailsCommand { get; set; }

        protected INavigation navigation;

        public ItemsViewModel(INavigation navigation)
        {
            Title = "Список продуктов";
            Items = new ObservableCollection<Cocktail>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            DeleteSelectedCommand = new Command(async () => await ExecuteDeleteSelectedCommand());
            UpdateSelectedCommand = new Command(async () => await ExecuteUpdateSelectedCommand());
            AddItemCommand = new Command(async () => await ExecuteAddItemCommand());
            OpenDetailsCommand = new Command<int>(async (param) => await ExecuteOpenDetailsCommand(param));
            this.navigation = navigation;
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await Reload();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteAddItemCommand()
        {
            await navigation.PushModalAsync(new NavigationPage(new NewItemPage(new NewItemViewModel(navigation))));
        }

        async Task ExecuteUpdateSelectedCommand()
        {
            await navigation.PushModalAsync(new NavigationPage(new NewItemPage(new UpdateItemViewModel(navigation, SelectedItem))));
        }

        async Task ExecuteDeleteSelectedCommand()
        {
            if(SelectedItem == null)
            {
                return;
            }
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await DataStore.DeleteItemAsync(SelectedItem.Id);
                await Reload();
                SelectedItem = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteOpenDetailsCommand(int param)
        {
            await navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(await DataStore.GetItemAsync(param))));
        }

        protected virtual async Task Reload()
        {
            Items.Clear();
            var items = await DataStore.GetItemsAsync(true);
            Items = new ObservableCollection<Cocktail>(items);
            OnPropertyChanged("Items");
        }

    }
}