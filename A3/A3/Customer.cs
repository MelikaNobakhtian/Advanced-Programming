using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Customer
    {
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public City City
        {
            get { return _City; }
            set { _City = value; }
        }
        public List<Order> Orders
        {
            get { return _Orders; }
            set { _Orders = value; }
        }
        private string _Name;
        private City _City;
        private List<Order> _Orders=new List<Order>();

        public Customer(string name, City city, List<Order> orders)
        {
            Name = name;
            City = city;
            Orders = new List<Order>(orders);
        }

        public Product MostOrderedProduct()
        {
            List<Product> ourproducts = new List<Product>();
            for(int i = 0; i < Orders.Count; i++)
            {
                Order count = Orders[i];
                List<Product> pru = count.Products;
                for(int j = 0; j < pru.Count; j++)
                {
                    ourproducts.Add(pru[j]);
                }
            }
            
            List<Product> result = new List<Product>();
            int max = 0;
            for (int i = 0; i < ourproducts.Count; i++)
            {
                int count = 0;
                Product Most =ourproducts[i];
                for(int j = 0; j < ourproducts.Count; j++)
                {
                    if (ourproducts[j] == Most)
                        count++;
                }
                if (i == 0)
                {
                    max = count;
                    continue;
                }
                if (count > max)
                {
                    max = count;
                    result.Clear();
                    result.Add(ourproducts[i]);
                }
                if (count == max)
                    result.Add(ourproducts[i]);
                
            }
            Random rnd = new Random();
            int mostpro = rnd.Next(0, result.Count);
            return result[mostpro];
        }

        public List<Order> UndeliveredOrders()
        {
            List<Order> undelivered = new List<Order>();
            foreach(Order order in Orders)
                if (!order.IsDelivered)
                    undelivered.Add(order);

            return undelivered;
        }
    }
}