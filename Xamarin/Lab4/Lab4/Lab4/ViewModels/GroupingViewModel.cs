using Lab4.Models;
using Lab4.Services;
using Lab4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Lab4.ViewModels
{
    class GroupingViewModel : BaseViewModel<Purchase, PurchaseDataStore>
    {

        public Command PerformQueryCommand { get; set; }

        public ObservableCollection<ResultLine> Groups { get; set; }

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

        public GroupingViewModel()
        {
            PerformQueryCommand = new Command(() => ExecutePerformQueryCommand());
        }

        void ExecutePerformQueryCommand()
        {
            if (string.IsNullOrEmpty(QueryParam))
            {
                return;
            }

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Groups = new ObservableCollection<ResultLine>((DataStore as IPurchaseDataStore).GetProductSalesByYear(Convert.ToInt32(QueryParam)));
                OnPropertyChanged("Groups");
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
    }
}
