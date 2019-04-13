using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Flight
    {
        private string _FlightID;
        private Airline _Airline;
        private int _Capacity;
        private string _Source;
        private string _Destination;
        private DateTime _FlyDate;

        //Properties:
        public string FlightID
        {
            get { return _FlightID; }
            set { _FlightID = value; }
        }
        public Airline Airline
        {
            get { return _Airline; }
            set { _Airline = value; }
        }
        public int Capacity
        {
            get { return _Capacity; }
            set { _Capacity = value; }
        }
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }
        public DateTime FlyDate
        {
            get { return _FlyDate; }
            set { _FlyDate = value; }
        }
        //FlightID: string
        //Airline: Airline
        //Capacity: int
        //Source: string
        //Destination: string
        //FlyDate: DateTime


        /// <summary>
        /// set properties and add the object to DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="airline"></param>
        /// <param name="capacity"></param>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="dateTime"></param>
        public Flight(string id, Airline airline, int capacity, string source, string dest,
            DateTime dateTime)
        {
            FlightID = id;
            Airline = airline;
            Capacity = capacity;
            Source = source;
            Destination = dest;
            FlyDate = dateTime;
            DB.AddFlight(this);
            //TODO
        }

        public bool IsFull()
        {
            //TODO
            if (Capacity == 0)
                return true;
            else
                return false;
        }
    }
}
