using System.Collections.Generic;
using System.Linq;

namespace A3
{
    public class Customer
    {
        public string Name { get; set; }

        public City City { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public Customer(string name, City city, List<Order> orders)
        {
            Name = name;
            City = city;
            Orders = new List<Order>(orders);
        }

        public Product MostOrderedProduct()
        {
            var ourProducts = new List<Product>();
            foreach (var count in Orders)
            {
                var pru = count.Products;
                ourProducts.AddRange(pru);
            }

            Dictionary<Product, int> prodic=new Dictionary<Product, int>();
            foreach(Product pro in ourProducts.Distinct())
                prodic.Add(pro, ourProducts.Count(p => p.Equals(pro)));
            return prodic.FirstOrDefault(p => p.Value == prodic.Values.Max()).Key;
            
        }

        public List<Order> UndeliveredOrders()
        {
            var undelivered = new List<Order>();
            foreach (var order in Orders)
                if (!order.IsDelivered)
                    undelivered.Add(order);

            return undelivered;
        }
    }
}