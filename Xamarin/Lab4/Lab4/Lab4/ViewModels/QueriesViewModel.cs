using Lab4.Models;
using Lab4.Services;
using Lab4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab4.ViewModels
{
    public class QueriesViewModel : AbstractItemsViewModel<Product, ProductDataStore>
    {
        public enum QueryProducts
        {
            GetByProducer,
            GetByName,
            GetByPriceLess,
            GetByPriceMore,
            GetByMaterial
        }

        public class MenuItem
        {
            public QueryProducts Id { get; set; }

            public string Title { get; set; }
        }


        public Command PerformQueryCommand { get; set; }

        public ObservableCollection<MenuItem> Queries { get; set; }

        private string _queryParam;

        public string QueryParam
        {
            get
            {
                return _queryParam;
            }
            set
            {
                _queryParam = value;
                OnPropertyChanged();
            }
        }

        private MenuItem _selectedQuery;

        public MenuItem SelectedQuery
        {
            get
            {
                return _selectedQuery;
            }
            set
            {
                _selectedQuery = value;
                OnPropertyChanged();
            }
        }


        public QueriesViewModel(INavigation navigation) : base(navigation)
        {
            PerformQueryCommand = new Command(() => ExecutePerformQueryCommand());
            Queries = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Id = QueryProducts.GetByProducer,
                    Title = "Список товаров по производителю"
                },
                new MenuItem
                {
                    Id = QueryProducts.GetByMaterial,
                    Title = "Товар по начинке"
                },
                new MenuItem
                {
                    Id = QueryProducts.GetByName,
                    Title = "Товар по имени"
                },
                new MenuItem
                {
                    Id = QueryProducts.GetByPriceLess,
                    Title = "Продукты с ценой, которая меньше заданной"
                },
                new MenuItem
                {
                    Id = QueryProducts.GetByPriceMore,
                    Title = "Продукты с ценой, которая больше заданной"
                },
            };
        }

        void ExecutePerformQueryCommand()
        {
            if(SelectedQuery == null)
            {
                return;
            }
            var dataStore = DataStore as IProductDataStore;
            switch (SelectedQuery.Id)
            {
                case QueryProducts.GetByProducer:
                    Items = new ObservableCollection<Product>(
                        dataStore.GetProductsByProducer(QueryParam));
                    break;
                case QueryProducts.GetByName:
                    Items = new ObservableCollection<Product>(
                        dataStore.GetProductsByName(QueryParam));
                    break;
                case QueryProducts.GetByMaterial:
                    Items = new ObservableCollection<Product>(
                        dataStore.GetProductsByMaterial(QueryParam));
                    break;
                case QueryProducts.GetByPriceLess:
                    Items = new ObservableCollection<Product>(
                             dataStore.GetProductsWithPriceLess(Convert.ToDecimal(QueryParam)));
                    break;
                case QueryProducts.GetByPriceMore:
                    Items = new ObservableCollection<Product>(
                            dataStore.GetProductsWithPriceMore(Convert.ToDecimal(QueryParam)));
                    break;
            }
            OnPropertyChanged("Items");
        }

        protected override Task Reload()
        {
            ExecutePerformQueryCommand();
            return Task.FromResult(true);
        }


    }
}
