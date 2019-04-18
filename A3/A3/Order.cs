using System.Collections.Generic;

namespace A3
{
    public class Order
    {
        public List<Product> Products { get; set; } = new List<Product>();


        public bool IsDelivered { get; set; }

        public Order(List<Product> products, bool isDelivered)
        {
            IsDelivered = isDelivered;
            Products = new List<Product>(products);
        }

        public float CalculateTotalPrice()
        {
            float total = 0;
            foreach (var product in Products) total += product.Price;
            return total;
        }
    }
}