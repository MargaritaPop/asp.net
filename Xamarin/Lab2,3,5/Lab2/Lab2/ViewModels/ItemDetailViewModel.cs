using System;

using Lab2.Models;

namespace Lab2.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Cocktail Item { get; set; }
        public ItemDetailViewModel(Cocktail item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
