using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using digikala;

namespace APLabDigikalaTests
{
    [TestClass]
    public class DigiTests
    {
        private ItemInventory TestInitialize()
        {
            var inventory = new ItemInventory();
            
            var itemsTmp = new List<Item>()
            {
                new Item("Kase", 12.3, new DateTime(2012, 2, 21), "Ehsandar", "EhsanShop"),
                new Item("Boshghab", 23, new DateTime(2000, 1, 25), "Ehsandar", "EhsanShop"),
                new Item("Ahan", 2, new DateTime(2019, 2, 1), "Gholami", "EhsanShop"),
                new Item("Alat", 4.5, new DateTime(2003, 7, 23), "Gholami", "EhsanShop"),
                new Item("Docharkhe", 123.4, new DateTime(2018, 4, 4), "Gholami", "EhsanShop"),
                new Item("Mouse", 21.3, new DateTime(2019, 1, 1), "Genius", "EhsanShop"),
                new Item("Cat", 1, new DateTime(2020, 2, 21), "Hamsayeh", "EhsanShop"),
                new Item("Car", 100000000, new DateTime(2030, 3, 29), "Iran Kh", "EhsanShop"),
                new Item("Marker", 3.45, new DateTime(2012, 5, 11), "Panter", "EhsanShop"),
                new Item("Smart Phone", 2300000, new DateTime(2017, 4, 13), "Sony", "EhsanShop"),
            };

            foreach (Item item in itemsTmp)
            {
                inventory.AddItem(item);
            }

            return inventory;
        }
        
        [TestMethod]
        public void FilterDateTest()
        {
            var inv = TestInitialize();
            var releaseFilter = new ReleaseDateFilter(new DateTime(2012, 2, 12));
            var filtered = inv.Filter(new List<IFilter> {releaseFilter});
            
            CollectionAssert.DoesNotContain(filtered, inv.Items[1]);
        }
        
        [TestMethod]
        public void FilterPriceTest()
        {
            var inv = TestInitialize();
            var priceRangeFilter = new PriceRangeFilter(100, 200);
            var filtered = inv.Filter(new List<IFilter> {priceRangeFilter});
            
            CollectionAssert.Contains(filtered, inv.Items[4]);
        }
        
        [TestMethod]
        public void FilterBrandTest()
        {
            var inv = TestInitialize();
            var brandFilter = new BrandFilter("Ehsandar");
            var filtered = inv.Filter(new List<IFilter> {brandFilter});
            
            CollectionAssert.Contains(filtered, inv.Items[1]);
        }
    }
}