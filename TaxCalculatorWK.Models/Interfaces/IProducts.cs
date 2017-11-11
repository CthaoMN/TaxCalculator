using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorWK.Models.Models;

namespace TaxCalculatorWK.Models.Interfaces
{
    /// <summary>
    /// This way we can allow different type of products in the future, Goods, Online
    /// </summary>
    public interface IProducts
    {
        ProductType ProductTypeEnum { get; set; }
        string Name { get; set; }
        decimal Quantity { get; set; }
        bool Imported { get; set; }
        decimal ShelfPrice { get; set; }
        decimal TotalWithTax { get; }
        decimal SalesTaxRounded { get; }
        decimal CalculateSalesTaxRoundedValue();
        decimal CalculateSalesTaxValue();
        decimal CalculateTotal();
    }
}
