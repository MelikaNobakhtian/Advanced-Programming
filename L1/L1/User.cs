using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class User
    {
        public string FullName;

        public string NationalID;

        public string PhoneNumber;

        public List<Ticket> Tickets;

        public double Account;

        public User(string fullName, string nationalID, string phoneNumber, double account)
        {
            FullName = fullName;
            NationalID = nationalID;
            PhoneNumber = phoneNumber;
            Tickets = new List<Ticket>();
            Account = 0;
            DB.AddUser(this);
        }

        /// <summary>
        /// reserve new ticket
        /// do necessary changes on Ticket, Flight, and User properties.
        /// </summary>
        /// <param name="ticket"></param>
        public void Reserve(Ticket ticket)
        {
            //TODO
            if (!ticket.IsSold())
            {
                Tickets.Add(ticket);
                Tickets[Tickets.Count - 1].Flight.Capacity--;
                Account -= Tickets[Tickets.Count - 1].Price;
                Tickets[Tickets.Count - 1].Buyer = this;
                DB.DeleteTicket(ticket);
            }
            
           
           
            throw new NotImplementedException();
        }

        /// <summary>
        /// cancel ticket reservation
        /// do necessary changes on Ticket, Flight, and User properties.
        /// 40% of the ticket price backs to the buyer account
        /// </summary>
        /// <param name="ticket"></param>
        public void Cancel(Ticket ticket)
        {
            Tickets.Remove(ticket);
            ticket.Flight.Capacity++;
            Account += (0.4 * ticket.Price);
            ticket.Buyer = null;
            DB.AddTicket(ticket);
            //TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns tickets with dates between two significant dates
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public List<Ticket> DateFilteredTickets(DateTime startDateTime, DateTime endDateTime)
        {
            List<Ticket> Dateticket = new List<Ticket>();
            foreach(Ticket t in Tickets)
            {
                if (t.Flight.FlyDate > startDateTime && t.Flight.FlyDate < endDateTime)
                    Dateticket.Add(t);
            }
            return Dateticket;
        }

        /// <summary>
        /// returns tickets with dates between 18 March, 28 March
        /// </summary>
        /// <returns></returns>
        public List<Ticket> NowruzTickets()
        {
            List<Ticket> Dateticket = new List<Ticket>();
            foreach (Ticket t in Tickets)
            {
                if (t.Flight.FlyDate.Month==3 && t.Flight.FlyDate.Day < 28 && t.Flight.FlyDate.Day > 18 )
                    Dateticket.Add(t);
            }
            return Dateticket;
            
        }

        /// <summary>
        /// returns tickets of a significant airline
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        public List<Ticket> AirlineTickets(Airline airline)
        {
            List<Ticket> A_tickets = new List<Ticket>();
            foreach(Ticket t in Tickets)
            {
                if (t.Flight.Airline == airline)
                    A_tickets.Add(t);
            }
            return A_tickets;
        }

        /// <summary>
        /// returns tickets with a significent route
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public List<Ticket> AirlineTickets(string source, string dest)
        {
            List<Ticket> A_tickets = new List<Ticket>();
            foreach (Ticket t in Tickets)
            {
                if (t.Flight.Source==source && t.Flight.Destination==dest)
                    A_tickets.Add(t);
            }
            return A_tickets;
        }

    }
}
