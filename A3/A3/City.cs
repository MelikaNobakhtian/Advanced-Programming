using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class City
    {
        private string _Name;
        public string Name
        {
            get {return _Name; }
            set{_Name = value;}
        }
       

        public City(string name)
        {
            Name = name;
        }
    }
}