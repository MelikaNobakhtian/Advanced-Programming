using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DB
    {
        public static List<Airline> Airlines = new List<Airline>();

        public static List<User> Users = new List<User>();

        public static List<Ticket> Tickets = new List<Ticket>();

        public static List<Flight> Flights = new List<Flight>();

        public static void AddAirline(Airline airline)
        {
            Airlines.Add(airline);
        }

        public static void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }

        public static void DeleteAirline(Airline airline)
        {
            Airlines.Remove(airline);
        }

        public static void DeleteTicket(Ticket ticket)
        {
            Tickets.Remove(ticket);
        }

        public static void DeleteUser(User user)
        {
            Users.Remove(user);
        }

        public static void DeleteFlight(Flight flight)
        {
            Flights.Remove(flight);
        }

        /// <summary>
        /// returns most expensive ticket
        /// </summary>
        /// <returns></returns>
        public static Ticket MostExpensiveTicket()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns airline with most sold tickets
        /// </summary>
        /// <returns></returns>
        public static Airline FavouriteAirline()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns amount of money users should pay from their credit accounts
        /// </summary>
        /// <returns></returns>
        public static double UsersDebts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns passengers favourite destination
        /// </summary>
        /// <returns></returns>
        public static string FavouriteDestination()
        {
            throw new NotImplementedException();
        }

    }
}
