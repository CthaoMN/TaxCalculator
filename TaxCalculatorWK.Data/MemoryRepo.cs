using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorWK.Models.Interfaces;
using TaxCalculatorWK.Models.Models;

namespace TaxCalculatorWK.Data
{
    public class MemoryRepo : ITaxCalcRepo
    {
        public MemoryRepo()
        {
            try
            {
                GetBaskets();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed loading mock data in MemoryRepo", ex);
            }
        }
        private static List<IBasket> _shoppingBaskets = new List<IBasket>();
        private static IBasket _basket = new ShoppingBasket();
        #region Basket 1
        private static IProducts oneOne = new Goods()
        {
            Imported = false,
            Name = "book",
            ProductTypeEnum = ProductType.Book,
            Quantity = 1,
            ShelfPrice = 12.49m
        };
        private static IProducts oneTwo = new Goods()
        {
            Imported = false,
            Name = "music CD",
            ProductTypeEnum = ProductType.Others,
            Quantity = 1,
            ShelfPrice = 14.99m,

        };
        private static IProducts oneThree = new Goods()
        {
            Imported = false,
            Name = "chocolate bar",
            ProductTypeEnum = ProductType.Book,
            Quantity = 1,
            ShelfPrice = 0.85m
        };
        #endregion
        #region Basket 2
        private static IProducts twoOne = new Goods()
        {
            Imported = true,
            Name = "imported box of chocolates",
            ProductTypeEnum = ProductType.Food,
            Quantity = 1,
            ShelfPrice = 10.00m
        };
        private static IProducts twoTwo = new Goods()
        {
            Imported = true,
            Name = "imported bottle of perfume",
            ProductTypeEnum = ProductType.Others,
            Quantity = 1,
            ShelfPrice = 47.50m,

        };
        #endregion
        #region Basket 3
        private static IProducts threeOne = new Goods()
        {
            Imported = true,
            Name = "imported bottle of perfume",
            ProductTypeEnum = ProductType.Others,
            Quantity = 1,
            ShelfPrice = 27.99m
        };
        private static IProducts threeTwo = new Goods()
        {
            Imported = false,
            Name = "bottle of perfume",
            ProductTypeEnum = ProductType.Others,
            Quantity = 1,
            ShelfPrice = 18.99m
        };
        private static IProducts threeThree = new Goods()
        {
            Imported = false,
            Name = "packet of headache pills",
            ProductTypeEnum = ProductType.Medical,
            Quantity = 1,
            ShelfPrice = 9.75m
        };
        private static IProducts threeFour = new Goods()
        {
            Imported = true,
            Name = "imported box of chocolates",
            ProductTypeEnum = ProductType.Food,
            Quantity = 1,
            ShelfPrice = 11.25m
        };
        #endregion
        public List<IBasket> LoadData()
        {
            try
            {
                return _shoppingBaskets;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed returning mock data in MemoryRepo", ex);
            }
        }

        public static void GetBaskets()
        {
            List<IProducts> listOfGoodsOne = new List<IProducts>();
            listOfGoodsOne.Add(oneOne);
            listOfGoodsOne.Add(oneTwo);
            listOfGoodsOne.Add(oneThree);

            IBasket basketOne = new ShoppingBasket()
            {
                ShoppingItems = listOfGoodsOne,
                Name = "Output 1"
            };

            List<IProducts> listOfGoodsTwo = new List<IProducts>();
            listOfGoodsTwo.Add(twoOne);
            listOfGoodsTwo.Add(twoTwo);

            IBasket basketTwo = new ShoppingBasket()
            {
                ShoppingItems = listOfGoodsTwo,
                Name = "Output 2"
            };

            List<IProducts> listOfGoodsThree = new List<IProducts>();
            listOfGoodsThree.Add(threeOne);
            listOfGoodsThree.Add(threeTwo);
            listOfGoodsThree.Add(threeThree);
            listOfGoodsThree.Add(threeFour);
            IBasket basketThree = new ShoppingBasket()
            {
                ShoppingItems = listOfGoodsThree,
                Name = "Output 3"
            };
            _shoppingBaskets.Add(basketOne);
            _shoppingBaskets.Add(basketTwo);
            _shoppingBaskets.Add(basketThree);
        }
    }
}
