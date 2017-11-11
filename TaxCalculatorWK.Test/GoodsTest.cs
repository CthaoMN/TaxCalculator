using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculatorWK.Models.Interfaces;
using TaxCalculatorWK.Models.Models;

namespace TaxCalculatorWK.Test
{
    /// <summary>
    /// Test for Goods
    /// </summary>
    [TestClass]
    public class GoodsTest
    {
        IProducts testOthersImported = new Goods()
        {
            Quantity = 1,
            Imported = true,
            ShelfPrice = 9.55m, //Check Round up 
            ProductTypeEnum = ProductType.Others
            //SalesTax pre-round = 1.43 => 1.45 
        };
        IProducts testOthers = new Goods()
        {
            Quantity = 1,
            Imported = false,
            ShelfPrice = 9.56m, //Check Round up
            ProductTypeEnum = ProductType.Others
            //SalesTax pre-round = .956 => .96 => 1.0
        };
        IProducts testImportedExempt = new Goods()
        {
            Quantity = 1,
            Imported = true,
            ShelfPrice = 10.00m,
            ProductTypeEnum = ProductType.Book
        };
        IProducts testExempt = new Goods()
        {
            Quantity = 1,
            Imported = false,
            ShelfPrice = 10.00m,
            ProductTypeEnum = ProductType.Book
        };

        [TestMethod]
        public void CheckCalculateSalesTaxValue()
        {
            Assert.AreEqual(.15m, testOthersImported.CalculateSalesTaxValue());
            Assert.AreEqual(.10m, testOthers.CalculateSalesTaxValue());
            Assert.AreEqual(.05m, testImportedExempt.CalculateSalesTaxValue());
            Assert.AreEqual(0, testExempt.CalculateSalesTaxValue());
        }
        [TestMethod]
        public void CheckGoodCalculateSalesTaxRounded()
        {
            Assert.AreEqual(1.45m, testOthersImported.CalculateSalesTaxRoundedValue());
            Assert.AreEqual(1.0m, testOthers.CalculateSalesTaxRoundedValue());
            Assert.AreEqual(.5m, testImportedExempt.CalculateSalesTaxRoundedValue());
            Assert.AreEqual(0, testExempt.CalculateSalesTaxRoundedValue());
        }
        [TestMethod]
        public void CheckGoodCalculateTotal()
        {
            Assert.AreEqual(11m, testOthersImported.CalculateTotal());
            Assert.AreEqual(10.56m, testOthers.CalculateTotal());
            Assert.AreEqual(10.50m, testImportedExempt.CalculateTotal());
            Assert.AreEqual(10m, testExempt.CalculateTotal());
        }
    }
}
