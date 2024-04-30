using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
namespace FlightReservationProject
{
    public class PlaneFlight
    {
        #region Data Members
        private string flightNumber;
        private Plane plane;
        private int totalPassenger;
        private string status;
        private Airport fromAirport;
        private Airport toAirport;
        private City fromCity;
        private City toCity;
        private DateTime depart;
        private DateTime arrival;
        private string airline;
        private List<Passenger> listOfPassengers;
        private int price;
        #endregion

        #region Properties
        public string FlightNumber { get => flightNumber; set => flightNumber = value; }
        public Plane Plane { get => plane; set => plane = value; }
        public int TotalPassenger { get => totalPassenger; set => totalPassenger = value; }
        public string Status { get => status; set => status = value; }
        public Airport FromAirport { get => fromAirport; set => fromAirport = value; }
        public Airport ToAirport { get => toAirport; set => toAirport = value; }
        public List<Passenger> ListOfPassengers { get => listOfPassengers; set => listOfPassengers = value; }
        public City FromCity { get => fromCity; set => fromCity = value; }
        public City ToCity { get => toCity; set => toCity = value; }
        public DateTime Depart { get => depart; set => depart = value; }
        public DateTime Arrival { get => arrival; set => arrival = value; }
        public string Airline { get => airline; set => airline = value; }
        public int Price { get => price; set => price = value; }
        #endregion

        #region Constructors
        public PlaneFlight(string flightNumber, City from, City to, DateTime depart, DateTime arrival, string airline, int price)
        {
            FlightNumber = flightNumber;
            FromCity = from;
            ToCity = to;
            Depart = depart;
            Arrival = arrival;
            Airline = airline;
            Price = price;
        }
        public PlaneFlight()
        {

        }
        #endregion

        #region Methods
        public static int GetFlightNumber(string code)
        {
            string sql = "SELECT COUNT(flight_number) FROM plane_flight WHERE flight_number LIKE '"+code.ToUpper()+"%'";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            int result = 0;
            while (results.Read())
            {
                result = results.GetInt32(0);
            }
            return result+1;
        }

       
        #endregion
    }
}
