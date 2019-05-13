using System;

namespace digikala
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price;
        public DateTime RealeaseDate { get; set; }
        public string Brand { get; set; }
        public string Seller { get; set; }

        public Item(string title,double price,DateTime realeasedate,string brand,string seller)
        {
            
            Title = title;
            Price = price;
            RealeaseDate = realeasedate;
            Brand = brand;
            Seller = seller;
            
        }

        public double UpdatePrice(double newprice)
        {
            if (newprice <= (1.2) * Price )
                return newprice;
                return (1.2) * Price;

        }
            

    }
}