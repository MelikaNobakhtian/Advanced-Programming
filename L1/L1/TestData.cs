using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Users
            var user1 = new User("Sepehr Hashemi", "9643", "+981111111111", 100000);
            var user2 = new User("Sepehr Hashemi", "3312", "+981111111112", 100000);
            var user3 = new User("Sepehr Hashemi", "9856", "+981111111113", 100000);
            var user4 = new User("Sepehr Hashemi", "4065", "+981111111114", 100000);
            var user5 = new User("Sepehr Hashemi", "1176", "+981111111115", 100000);
            var user6 = new User("Sepehr Hashemi", "1327", "+981111111116", 100000);
            var user7 = new User("Sepehr Hashemi", "9845", "+981111111117", 100000);
            var user8 = new User("Sepehr Hashemi", "1098", "+981111111118", 100000);
            var user9 = new User("Sepehr Hashemi", "8865", "+981111111119", 100000);
            var user10 = new User("Sepehr Hashemi", "9010", "+981111111110", 100000);
            //Airlines
            var airline1 = new Airline("Mahan");
            var airline2 = new Airline("IranAir");
            var airline3 = new Airline("KishAir");
            var airline4 = new Airline("Asemaan");
            //Flights
            var flight1 = new Flight("1144", airline1, 100, "Hamedan", "Mashhad", new DateTime(year: 2019, month: 3, day: 21));
            var flight2 = new Flight("1217", airline2, 50, "Tehran", "Esfahan", new DateTime(year: 2019, month: 3, day: 27));
            var flight3 = new Flight("4113", airline3, 100, "Rasht", "Yazd", new DateTime(year: 2019, month: 5, day: 11));
            var flight4 = new Flight("9525", airline1, 70, "Tehran", "Shiraz", new DateTime(year: 2019, month: 4, day: 9));
            var flight5 = new Flight("1618", airline4, 60, "Mashhad", "Tehran", new DateTime(year: 2019, month: 8, day: 15));
            //Tickets
            var ticket1 = new Ticket(flight1, 250000, null);
            var ticket2 = new Ticket(flight3, 353000, null);
            var ticket3 = new Ticket(flight2, 550000, null);
            var ticket4 = new Ticket(flight1, 650000, null);
            var ticket5 = new Ticket(flight1, 150000, null);
            var ticket6 = new Ticket(flight4, 257000, null);
            var ticket7 = new Ticket(flight3, 455000, null);
            var ticket8 = new Ticket(flight5, 150000, null);
            var ticket9 = new Ticket(flight5, 850000, null);
            var ticket10 = new Ticket(flight5, 340000, null);
            var ticket11 = new Ticket(flight2, 160000, null);
            var ticket12 = new Ticket(flight1, 190000, null);
            var ticket13 = new Ticket(flight2, 699000, null);
            var ticket14 = new Ticket(flight5, 175000, null);
            var ticket15 = new Ticket(flight1, 250000, null);
            var ticket16 = new Ticket(flight4, 503000, null);
            var ticket17 = new Ticket(flight2, 2450000, null);
            var ticket18 = new Ticket(flight1, 225000, null);
            var ticket19 = new Ticket(flight3, 655000, null);
            var ticket20 = new Ticket(flight3, 750000, null);

            user1.DateFilteredTickets(new DateTime(year: 2019, month: 3, day: 28), new DateTime(year: 2019, month: 3, day: 18));
        }
    }
}
