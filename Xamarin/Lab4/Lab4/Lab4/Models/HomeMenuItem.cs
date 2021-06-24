using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Models
{
    public enum MenuItemType
    {
        Products,
        Purchases,
        Producers,
        Queries,
        Grouping
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
