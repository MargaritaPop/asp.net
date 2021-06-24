using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Lab4.Models;
using Lab4.Views;
using Lab4.Services;

namespace Lab4.ViewModels
{
    public abstract class AbstractItemsViewModel<T, U> : BaseViewModel<T, U> where T : Entity, new () where U : class, IDataStore<T>
    {

        private T _selectedItem;

        public T SelectedItem
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


        public ObservableCollection<T> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        public Command AddItemCommand { get; set; }

        public Command DeleteSelectedCommand { get; set; }

        public Command UpdateSelectedCommand { get; set; }

        protected INavigation navigation;

        public AbstractItemsViewModel(INavigation navigation)
        {
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            DeleteSelectedCommand = new Command(async () => await ExecuteDeleteSelectedCommand());
            UpdateSelectedCommand = new Command(async () => await ExecuteUpdateSelectedCommand());
            AddItemCommand = new Command(async () => await ExecuteAddItemCommand());
            this.navigation = navigation;
            Reload();
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

        protected virtual Task ExecuteAddItemCommand()
        {
            return Task.FromResult(true);
        }
        


        protected virtual Task ExecuteUpdateSelectedCommand()
        {
            return Task.FromResult(true);
        }

        async Task ExecuteDeleteSelectedCommand()
        {
            if (SelectedItem == null)
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

        protected virtual async Task Reload()
        {
            Items.Clear();
            var items = await DataStore.GetItemsAsync(true);
            Items = new ObservableCollection<T>(items);
            OnPropertyChanged("Items");
        }

    }
}