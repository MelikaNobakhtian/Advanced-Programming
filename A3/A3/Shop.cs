using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Shop
    {
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public List<Customer> Customers
        {
            get { return _Customers; }
            set { _Customers = value; }
        }
        private string _Name;
        private List<Customer> _Customers=new List<Customer>();

        public Shop(string name, List<Customer> customers)
        {
            Name = name;
            Customers = new List<Customer>(customers);
        }


        public List<City> CitiesCustomersAreFrom()
        {
            List<City> cities = new List<City>();
            foreach (Customer cos in Customers)
                cities.Add(cos.City);
            for(int i = 0; i < cities.Count; i++)
            {
                City first = cities[i];
                for (int j = i + 1; j < cities.Count; j++)
                    if (first == cities[j])
                        cities.RemoveAt(j);
            }
            return cities;
        }

        public List<Customer> CustomersFromCity(City city)
        {
            List<Customer> citycustomer = new List<Customer>();
            foreach (Customer cus in Customers)
                if (cus.City == city)
                    citycustomer.Add(cus);
            return citycustomer;
        }

        public List<Customer> CustomersWithMostOrders()
        {
            List<Customer> mostorder = new List<Customer>();
            int MaxLength = Customers[0].Orders.Count;
            int Length = 0;
            mostorder.Add(Customers[0]);
            for(int i=1;i<Customers.Count;i++)
            {
                Length= Customers[i].Orders.Count;
                if (MaxLength == Length)
                    mostorder.Add(Customers[i]);
                if (Length > MaxLength)
                {
                    MaxLength = Length;
                    mostorder.Clear();
                    mostorder.Add(Customers[i]);
                }
            }
            return mostorder;
        }
    }
}