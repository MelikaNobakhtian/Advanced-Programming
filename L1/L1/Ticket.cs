using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ticket
    {
        public Flight Flight;

        public double Price;

        public User Buyer;

        public Ticket(Flight flight, double price, User buyer)
        {
            Flight = flight;
            Price = price;
            Buyer = buyer;
            DB.AddTicket(this);
        }

        public bool IsSold()
        {
            if (this.Buyer != null)
                return true;
            return false;
        }

    }
}
