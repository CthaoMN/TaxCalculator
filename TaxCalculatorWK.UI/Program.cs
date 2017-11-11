using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorWK.Models.Interfaces;
using TaxCalculatorWK.BLL;

namespace TaxCalculatorWK
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxCalculatorWKManager TaxCalculatorWKManager = TaxCalculatorWKManagerFactory.Create();
            var shoppingBaskets = TaxCalculatorWKManager.Load();
            var sales = "Sales Tax:";
            var total = "Total:";
            try
            {
                foreach (var basket in shoppingBaskets)
                {
                    Console.WriteLine($"{basket.Name}:");
                    foreach (var item in basket.ShoppingItems)
                    {
                        Console.WriteLine("\t{0} {1}: ${2:N2}", item.Quantity, item.Name, item.TotalWithTax);
                    }
                    Console.WriteLine("\t{0} ${1:N2}", sales, basket.TotalSalesTaxes);
                    Console.WriteLine("\t{0} ${1:N2} \n", total, basket.Total);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to display mock data {0}", ex);
            }
            Console.ReadLine();
        }
    }
}

