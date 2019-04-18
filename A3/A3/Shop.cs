using System.Collections.Generic;
using System.Linq;

namespace A3
{
    public class Shop
    {
        public string Name { get; set; }

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public Shop(string name, List<Customer> customers)
        {
            Name = name;
            Customers = new List<Customer>(customers);
        }


        public List<City> CitiesCustomersAreFrom()
        {
            var cities = new List<City>();
            foreach (var cos in Customers)
                cities.Add(cos.City);
            var distinctCities = cities.Distinct().ToList();


            return distinctCities;
        }

        public List<Customer> CustomersFromCity(City city)
        {
            var citycustomer = new List<Customer>();
            foreach (var cus in Customers)
                if (cus.City == city)
                    citycustomer.Add(cus);
            return citycustomer;
        }

        public List<Customer> CustomersWithMostOrders()
        {
            var mostOrders = new List<Customer>();
            var maxLength = Customers[0].Orders.Count;
            var length = 0;
            mostOrders.Add(Customers[0]);
            for (var i = 1; i < Customers.Count; i++)
            {
                length = Customers[i].Orders.Count;
                if (maxLength == length)
                    mostOrders.Add(Customers[i]);
                if (length > maxLength)
                {
                    maxLength = length;
                    mostOrders.Clear();
                    mostOrders.Add(Customers[i]);
                }
            }

            return mostOrders;
        }
    }
}