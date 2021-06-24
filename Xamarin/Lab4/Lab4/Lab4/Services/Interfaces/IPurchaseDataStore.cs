using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4.Services.Interfaces
{
    public interface IPurchaseDataStore : IDataStore<Purchase>
    {
        IQueryable<ResultLine> GetProductSalesByYear(int year);
    }
}
