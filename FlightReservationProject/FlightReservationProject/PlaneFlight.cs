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

        public PlaneFlight(string flightNumber, DateTime depart, DateTime arrival, string airline, int price)
        {
            FlightNumber = flightNumber;
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
            string sql = "SELECT COUNT(flight_number) FROM plane_flight WHERE flight_number LIKE '" + code.ToUpper() + "%'";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            int result = 0;
            while (results.Read())
            {
                result = results.GetInt32(0);
            }
            return result + 1;
        }

        public static List<PlaneFlight> GetFlights(Reservation order)
        {
            string sql = "SELECT flight_number, datetime_depart, datetime_arrival, airline_name, init_price, duration_in_minutes, available_seats, from_city, to_city FROM plane_flight WHERE from_city = '" + order.FromCity.Id + "' AND to_city ='"+ order.ToCity.Id+"' AND datetime_depart LIKE '" + order.DateDepart.ToString("yyyy-MM-dd")+"%'";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<PlaneFlight> flights = new List<PlaneFlight>();
            while (results.Read())
            {
                PlaneFlight p = new PlaneFlight(results.GetString(0), order.FromCity, order.ToCity, results.GetDateTime(1), results.GetDateTime(2), results.GetString(3), results.GetInt32(4));
                flights.Add(p);
            }
            if (flights.Count > 0)
                return flights;
            else return null;
        }
        public static PlaneFlight GetChosenFlight(string flightNumber)
        {
            string sql = "SELECT flight_number, datetime_depart, datetime_arrival, airline_name, init_price, duration_in_minutes, available_seats, from_city, to_city FROM plane_flight WHERE flight_number = '" + flightNumber + "'";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
           
            if (results.Read())
            {
                PlaneFlight p = new PlaneFlight(results.GetString(0), results.GetDateTime(1), results.GetDateTime(2), results.GetString(3), results.GetInt32(4));
                return p;
            }
            else return null;
        }
        public static void AddFlights(List<PlaneFlight> flights)
        {
            foreach (PlaneFlight p in flights) 
            {
                string sql = string.Format("INSERT INTO plane_flight(flight_number, from_city, to_city, datetime_depart, datetime_arrival, duration_in_minutes, airline_name, init_price) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", p.FlightNumber, p.FromCity.Id, p.ToCity.Id, p.Depart.ToString("yyyy-MM-dd HH:mm:00"), p.Arrival.ToString("yyyy-MM-dd HH:mm:00"), (p.Arrival-p.Depart).TotalMinutes, p.Airline, p.Price);

                dbConnection.ExecuteNonQuery(sql);
            }
        }
        #endregion
    }
}
