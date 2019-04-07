using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Order
    {
        private List<Product> _Products=new List<Product>();
        public List<Product> Products
        {
            get
            {
                return _Products;
            }
            set
            {
                _Products=value;
            }
        }
        private bool _IsDelivered;
       

        public bool IsDelivered
        {
            get
            {
                return _IsDelivered;
            }
            set
            {
                _IsDelivered = value;
            }
        }

        public Order(List<Product> products, bool isDelivered)
        {
            IsDelivered = isDelivered;
            Products=new List<Product>(products);
        }

        public float CalculateTotalPrice()
        {
            float Total = 0;
            foreach(Product product in this.Products)
            {
                Total += product.Price;
            }
            return Total;
        }
    }
}