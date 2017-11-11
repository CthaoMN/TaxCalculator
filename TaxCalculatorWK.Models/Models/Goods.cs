using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorWK.Models.Interfaces;

namespace TaxCalculatorWK.Models.Models
{
    public class Goods : IProducts, ITaxRate
    {
        private const decimal normalTax = .10M;
        private const decimal importTax = .15M;
        private const decimal importOnly = .05M;
        private string name;
        public ProductType ProductTypeEnum { get; set; }
        public string Name { get => CheckNull(); set { name = value; } } //Not sure if this is a good idea if we can have empty string names
        public decimal Quantity { get; set; }
        public bool Imported { get; set; }
        public decimal ShelfPrice { get; set; }
        public decimal Tax { get => CalculateSalesTaxValue(); }
        public decimal TotalWithTax { get => CalculateTotal(); }
        public decimal SalesTaxRounded { get => CalculateSalesTaxRoundedValue(); }

        private string CheckNull()
        {
            return String.IsNullOrWhiteSpace(name) ? string.Empty : name;
        }

        //*20/20 gets us 100ths decimal then rounds to .05 then goes back to 2 decimal places
        public decimal CalculateSalesTaxRoundedValue()
        {
            return Math.Ceiling((ShelfPrice * Quantity * Tax) * 20) / 20;
        }

        public decimal CalculateSalesTaxValue()
        {
            return ProductTypeEnum == ProductType.Others ? (Imported ? importTax : normalTax) : (Imported ? importOnly : 0);
        }

        public decimal CalculateTotal()
        {
            return Math.Round(SalesTaxRounded + ShelfPrice, 2);
        }
    }
}