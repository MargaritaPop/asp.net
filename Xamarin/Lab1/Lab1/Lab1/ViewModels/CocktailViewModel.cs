using Lab1.Commands;
using Lab1.Data;
using Lab1.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Lab1.ViewModels
{
    class CocktailViewModel : ViewModelBase
    {
        private IDialogService dialogService;

        public CocktailViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            Cocktails = new ObservableCollection<Cocktail>(
                new List<Cocktail>
                {
                    new Cocktail
                    {
                        Name = "Текила санрайз",
                        Ingredient = "Cеребрянная текила",
                        Price = 10.20m,
                        SaleDate = DateTime.Now

                    },
                    new Cocktail
                    {
                        Name = "Кровавая Мэри",
                        Ingredient = "Томатный сок",
                        Price = 12.20m,
                        SaleDate = DateTime.Now

                    },
                    new Cocktail
                    {
                        Name = "Белый русский",
                        Ingredient = "Кофейный ликер",
                        Price = 13.43m,
                        SaleDate = DateTime.Now,
                    }
                }
            );

        }

        public ObservableCollection<Cocktail> Cocktails { get; set; }

        public ObservableCollection<Cocktail> ElectCocktails
        {
            get
            {
                return new ObservableCollection<Cocktail>(Cocktails.Where(item => item.Elected));
            }
        }

        private Cocktail _selected;

        public Cocktail Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if(_selected != null)
                {
                    FormValue = _selected;
                    DetailsShowed = true;
                    FormEnabled = false;
                }
                OnPropertyChanged();
            }
        }


        private Cocktail _formValue;

        public Cocktail FormValue
        {
            get { return _formValue; }
            set
            {
                _formValue = value;
                OnPropertyChanged();
            }
        }

        private bool _detailsShowed;

        public bool DetailsShowed
        {
            get { return _detailsShowed; }
            set
            {
                _detailsShowed = value;
                OnPropertyChanged();
            }
        }

        private bool _formEnabled;

        public bool FormEnabled
        {
            get { return _formEnabled; }
            set
            {
                _formEnabled = value;
                OnPropertyChanged();
            }
        }

        private ICommand _hideDetailsCommand;

        public ICommand HideDetailsCommand
        {
            get
            {
                return _hideDetailsCommand ?? (_hideDetailsCommand = new DelegateCommand(() =>
                {
                    Selected = null;
                    DetailsShowed = false;
                }));
            }
        }

        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new DelegateCommand(() =>
                {
                    Selected = null;
                    FormValue = new Cocktail()
                    {
                        SaleDate = DateTime.Now
                    };                
                    DetailsShowed = true;
                    FormEnabled = true;
                }));
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new DelegateCommand(async () =>
                {
                    await dialogService.ShowMessage("Подтверждение сохранения", "Вы действительно хотите сохранить", "Да", "Нет", result =>
                    {
                        if(result)
                        {
                            Cocktails.Add(FormValue);
                            OnPropertyChanged("ElectCocktails");
                            DetailsShowed = false;
                        }
                    });
                }));
            }
        }

    }
}
