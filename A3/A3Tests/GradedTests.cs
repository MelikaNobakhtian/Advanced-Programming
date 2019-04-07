using System.Linq;
using A3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A3Tests
{
    [TestClass]
    public class GradedTests
    {
        [TestMethod]
        public void CitiesCustomersAreFromTest()
        {
            var res = TestData.testShop.CitiesCustomersAreFrom();
            var ans = new City[] {
                TestData.Canberra,
                TestData.Vancouver,
                TestData.Budapest,
                TestData.Ankara,
                TestData.Tokyo };

            CollectionAssert.AreEquivalent(res, ans);
        }

        [TestMethod]
        public void CustomersFromCityTest()
        {
            var res = TestData.testShop.CustomersFromCity(TestData.Canberra);
            var ans = (new Customer[] { TestData.testCustomers[0], TestData.testCustomers[1] });


            CollectionAssert.AreEquivalent(res, ans);
        }

        [TestMethod]
        public void CustomersWithMostOrdersTest()
        {
            var res = TestData.testShop.CustomersWithMostOrders();
            var ans = new Customer[] { TestData.testCustomers[3] };

            CollectionAssert.AreEquivalent(res, ans);
        }

        [TestMethod]
        public void MostOrderedProductTest()
        {
            var res = TestData.testCustomers[0].MostOrderedProduct();
            var ans = TestData.reSharper;

            Assert.AreEqual(res, ans);
        }

        [TestMethod]
        public void UndeliveredOrdersTest()
        {
            var res = TestData.testCustomers[3].UndeliveredOrders();
            var ans = new Order[] { TestData.testOrders[3], TestData.testOrders[4] };

            CollectionAssert.AreEquivalent(res, ans);
        }

        [TestMethod]
        public void CalculateTotalPriceTest()
        {
            var res = TestData.testOrders[1].CalculateTotalPrice();
            float ans = (float)437.0;

            Assert.AreEqual(ans, res);
        }

        [TestMethod]
        public void CityConstructorTest()
        {
            City testCity = new City("Nishapur");
            Assert.AreEqual(testCity.Name, "Nishapur");
        }

        [TestMethod]
        public void ProductConstructorTest()
        {
            Product testProduct = new Product("Rug", (float)190.0);
            Assert.AreEqual(testProduct.Name, "Rug");
            Assert.AreEqual(testProduct.Price, (float)190.0);
        }

        [TestMethod]
        public void OrderConstructorTest()
        {
            CollectionAssert.AreEqual(TestData.testOrders[1].Products,
                (new Product[] { TestData.reSharper, TestData.dotMemory, TestData.dotTrace }));
        }

        [TestMethod]
        public void CustomerConstructorTest()
        {
            Customer testCustomer = TestData.testCustomers[3];

            Assert.AreEqual(testCustomer.Name, TestData.reka);
            CollectionAssert.AreEqual(testCustomer.Orders, 
                (new Order[] { TestData.testOrders[3], TestData.testOrders[4], TestData.testOrders[5] }));
            Assert.AreEqual(testCustomer.City, TestData.Budapest);
        }

        [TestMethod]
        public void ShopConstructorTest()
        {
            Shop testShop = TestData.testShop;
            Assert.AreEqual(testShop.Name, "test-shop");
            CollectionAssert.AreEqual(testShop.Customers, TestData.testCustomers);
        }
    }
}
