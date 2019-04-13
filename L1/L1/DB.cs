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
            double max = 0;
            List<Ticket> expensive = new List<Ticket>();
            foreach(Ticket t in Tickets)
            {
                if (t.Price > max)
                {
                    max = t.Price;
                    expensive.Clear();
                    expensive.Add(t);
                }
            }
            return expensive[0];
        }

        /// <summary>
        /// returns airline with most sold tickets
        /// </summary>
        /// <returns></returns>
        public static Airline FavouriteAirline()
        {
           
            List<Airline> A = new List<Airline>();
            foreach(Ticket t in Tickets)
            {
                if (!A.Contains(t.Flight.Airline))
                    A.Add(t.Flight.Airline);
            }
            List<int> n = new List<int>(A.Count);
            for(int i = 0; i < A.Count; i++)
                foreach(Ticket t in Tickets)
                    if (t.Flight.Airline == A[i])
                        n[i] += 1;
                    
        
            int max = n[0];
            for(int i = 1; i < A.Count; i++)
            {
                if (n[i] > max)
                {
                    A.RemoveRange(0, i);
                    max = n[i];
                }
            }
            return A[0];
        }

        /// <summary>
        /// returns amount of money users should pay from their credit accounts
        /// </summary>
        /// <returns></returns>
        public static double UsersDebts()
        {
            double debts = 0;
            foreach(User u in Users)
            {
                debts += u.Account;
            }
            return Math.Abs(debts);
        }

        /// <summary>
        /// returns passengers favourite destination
        /// </summary>
        /// <returns></returns>
        public static string FavouriteDestination()
        {
            List<string> Dest = new List<string>();
            foreach (Ticket t in Tickets)
            {
                if (!Dest.Contains(t.Flight.Destination))
                    Dest.Add(t.Flight.Destination);
            }
            List<int> n = new List<int>(Dest.Count);
            for (int i = 0; i < Dest.Count; i++)
                foreach (Ticket t in Tickets)
                    if (t.Flight.Destination == Dest[i])
                        n[i] += 1;


            int max = n[0];
            for (int i = 1; i < Dest.Count; i++)
            {
                if (n[i] > max)
                {
                    Dest.RemoveRange(0, i);
                    max = n[i];
                }
            }
            return Dest[0];
        }

    }
}
