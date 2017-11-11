using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorWK.Models.Interfaces
{
    /// <summary>
    /// this way in the future if we have different basket such as online cart, layway etc...
    /// </summary>
    public interface IBasket
    {
        string Name { get; set; }
        List<IProducts> ShoppingItems { get; set; }
        decimal TotalSalesTaxes { get; }
        decimal Total { get; }
        decimal CalculateTotalSalesTax();
        decimal CalculateTotal();
    }
}
