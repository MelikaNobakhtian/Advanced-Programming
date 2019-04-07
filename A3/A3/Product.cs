using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Product
    {

        public string Name
        {
            get {return _Name;}
            set {_Name = value;}
        }
        
        private string _Name;
        private float _Price;

        public float Price
        {
            get { return _Price; }
            set{
                if (value > 0)
                    _Price = value;
                else
                    Console.WriteLine("Wrong Price");
            }
        }

        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}