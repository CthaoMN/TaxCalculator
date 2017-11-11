using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculatorWK.Models.Interfaces;
using TaxCalculatorWK.Models.Models;
using System.Collections.Generic;

namespace TaxCalculatorWK.Test
{
    /// <summary>
    /// Test for Shopping Basket
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private List<IBasket> _listOfBaskets = new List<IBasket>();
        private IBasket _basketOne = new ShoppingBasket();
        private IBasket _basketTwo = new ShoppingBasket();
        private List<IProducts> _listOfGoodOne = new List<IProducts>();
        private List<IProducts> _listOfGoodTwo = new List<IProducts>();
        private IProducts _testOthersImported = new Goods()
        {
            Quantity = 1,
            Imported = true,
            ShelfPrice = 9.55m, //Check Round up 
            ProductTypeEnum = ProductType.Others
            //SalesTax pre-round = 1.43 => 1.45 
        };
        private IProducts _testOthers = new Goods()
        {
            Quantity = 1,
            Imported = false,
            ShelfPrice = 9.56m, //Check Round up
            ProductTypeEnum = ProductType.Others
            //SalesTax pre-round = .956 => .96 => 1.0
        };
        private IProducts _testImportedExempt = new Goods()
        {
            Quantity = 1,
            Imported = true,
            ShelfPrice = 10.00m,
            ProductTypeEnum = ProductType.Book
        };
        private IProducts _testExempt = new Goods()
        {
            Quantity = 1,
            Imported = false,
            ShelfPrice = 10.00m,
            ProductTypeEnum = ProductType.Book
        };
        public void Initialize()
        {
            _listOfGoodOne.Add(_testOthersImported);
            _listOfGoodOne.Add(_testOthers);
            _listOfGoodTwo.Add(_testImportedExempt);
            _listOfGoodTwo.Add(_testExempt);
            _basketOne.ShoppingItems = _listOfGoodOne;
            _basketTwo.ShoppingItems = _listOfGoodTwo;
            _listOfBaskets.Add(_basketOne);
            _listOfBaskets.Add(_basketTwo);
        }
        [TestMethod]
        public void CalculateTotalSalesTax()
        {
            Initialize();
            Assert.AreEqual(21.56m, _basketOne.CalculateTotal());
            Assert.AreEqual(20.50m, _basketTwo.CalculateTotal());
        }

        [TestMethod]
        public void CalculateTotal()
        {
            Initialize();
            Assert.AreEqual(2.45m, _basketOne.CalculateTotalSalesTax());
            Assert.AreEqual(0.50m, _basketTwo.CalculateTotalSalesTax());
        }
    }
}
