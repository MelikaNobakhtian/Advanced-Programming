using System;

namespace digikala
{
    public interface IFilter
    {
        bool Filter(Item item);
    }

    public class PriceFilter : IFilter
    {
        public double Price { get; set; }
        public bool Filter(Item item)
        {
            return (item.Price <= Price);
        }
    }

    public class BrandFilter : IFilter
    {
        

        public BrandFilter(string v)
        {
            this.Brand = v;
        }

        public string Brand { get; set; }
        public bool Filter(Item item)
        {
            return (item.Brand == Brand);
        }
    }

    public class PriceRangeFilter : IFilter
    {
        

        public PriceRangeFilter(int v1, int v2)
        {
            this.StartPrice = v1;
            this.EndPrice = v2;
        }

        public double StartPrice{ get; set; }
        public double EndPrice { get; set; }
        public bool Filter(Item item)
        {
            return (item.Price < EndPrice && item.Price > StartPrice);
        }
    }

    public class ReleaseDateFilter : IFilter
    {
        

        public ReleaseDateFilter(DateTime dateTime)
        {
            this.Release = dateTime;
        }

        public DateTime Release { get; set; }
        public bool Filter(Item item)
        {
            return (item.RealeaseDate >= Release);
        }
    }
}