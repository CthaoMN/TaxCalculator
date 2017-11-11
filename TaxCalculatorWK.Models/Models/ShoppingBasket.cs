using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorWK.Models.Interfaces;

namespace TaxCalculatorWK.Models.Models
{
    public class ShoppingBasket : IBasket
    {
        private string name;
        public string Name { get => CheckNull(); set { name = value; } } //Not sure if this is a good idea if we can have empty string names
        public List<IProducts> ShoppingItems { get; set; }
        public decimal TotalSalesTaxes { get => CalculateTotalSalesTax(); }
        public decimal Total { get => CalculateTotal(); }

        private string CheckNull()
        {
            return String.IsNullOrWhiteSpace(name) ? string.Empty : name;
        }

        public decimal CalculateTotalSalesTax()
        {
            return ShoppingItems.Select(x => x.SalesTaxRounded).Sum();
        }

        public decimal CalculateTotal()
        {
            return ShoppingItems.Select(x => x.TotalWithTax).Sum();
        }
    }
}
