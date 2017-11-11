using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculatorWK.Models.Interfaces;
using TaxCalculatorWK.Models.Models;
using System.Collections.Generic;
using TaxCalculatorWK.Data;
using System.Linq;

namespace TaxCalculatorWK.Test
{
    /// <summary>
    /// Test for FactoryManager
    /// </summary>
    [TestClass]
    public class TaxCalcManagerTest
    {
        private static List<IBasket> _listOfBaskets = new List<IBasket>();

        public void Initialize()
        {
            MemoryRepo memoryRepo = new MemoryRepo();
            _listOfBaskets = memoryRepo.LoadData();
        }

        [TestMethod]
        public void CheckCounts()
        {
            Initialize();
            Assert.AreEqual(3, _listOfBaskets.Count);
            Assert.AreEqual(3, _listOfBaskets[0].ShoppingItems.Count);
            Assert.AreEqual(2, _listOfBaskets[1].ShoppingItems.Count);
            Assert.AreEqual(4, _listOfBaskets[2].ShoppingItems.Count);
            Assert.AreEqual(9, _listOfBaskets.SelectMany(x => x.ShoppingItems).Count());
        }
    }
}
