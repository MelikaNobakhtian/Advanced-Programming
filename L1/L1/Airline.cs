using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Airline
    {
        private string _Name;

        public string Name;
       

        public Airline(string name)
        {
            Name = name;
            DB.AddAirline(this);
        }
    }
}
