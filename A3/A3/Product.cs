namespace A3
{
    public class Product
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}