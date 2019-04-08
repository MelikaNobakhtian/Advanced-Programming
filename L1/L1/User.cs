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
            Account = account;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns tickets with dates between 18 March, 28 March
        /// </summary>
        /// <returns></returns>
        public List<Ticket> NowruzTickets()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns tickets of a significant airline
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        public List<Ticket> AirlineTickets(Airline airline)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns tickets with a significent route
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public List<Ticket> AirlineTickets(string source, string dest)
        {
            throw new NotImplementedException();
        }

    }
}
