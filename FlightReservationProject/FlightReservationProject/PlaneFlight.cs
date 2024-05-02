using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
using MySql.Data.MySqlClient;

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
            string sql = "SELECT COUNT(flight_number) FROM plane_flight WHERE flight_number LIKE @codeTop";

            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@codeTop", code);
                    connection.Open();
                    using (MySqlDataReader results = com.ExecuteReader())
                    {
                        int result = 0;
                        while (results.Read())
                        {
                            result = results.GetInt32(0);
                        }
                        return result + 1;
                    }
                }
            }
        }

        public static List<PlaneFlight> GetFlights(Reservation order)
        {
            string sql = "SELECT flight_number, datetime_depart, datetime_arrival, airline_name, init_price, duration_in_minutes, available_seats, from_city, to_city FROM plane_flight WHERE from_city = @fromcity AND to_city = @toCity AND datetime_depart LIKE @dateDepart";
            List<PlaneFlight> flights = new List<PlaneFlight>();
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@fromCity", order.FromCity.Id);
                    com.Parameters.AddWithValue("@toCity", order.ToCity.Id);
                    com.Parameters.AddWithValue("@dateDepart", order.DateDepart.ToString("yyyy-MM-dd"));
                    connection.Open();

                    using (MySqlDataReader results = com.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            PlaneFlight p = new PlaneFlight(results.GetString(0), order.FromCity, order.ToCity, results.GetDateTime(1), results.GetDateTime(2), results.GetString(3), results.GetInt32(4));
                            flights.Add(p);
                        }
                        if (flights.Count > 0)
                            return flights;
                        else return null;
                    }
                }
            }
            
        }
        public static PlaneFlight GetChosenFlight(string flightNumber)
        {
            string sql = "SELECT flight_number, datetime_depart, datetime_arrival, airline_name, init_price, duration_in_minutes, available_seats, from_city, to_city FROM plane_flight WHERE flight_number = @flightNum";


            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@flightNum", flightNumber);
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PlaneFlight p = new PlaneFlight(reader.GetString(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4));
                            return p;
                        }
                        else return null;
                    }
                }
            }

        }
        public static void AddFlights(List<PlaneFlight> flights)
        {
            foreach (PlaneFlight p in flights)
            {
                string sql = "INSERT INTO plane_flight(flight_number, from_city, to_city, datetime_depart, datetime_arrival, duration_in_minutes, airline_name, init_price) VALUES (@flightNum, @fromCity, @toCity, @depart, @arrival, @duration, @airline, @price)";
                using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
                {
                    using (MySqlCommand com = new MySqlCommand(sql, connection))
                    {
                        com.Parameters.AddWithValue("@flightNum", p.FlightNumber);
                        com.Parameters.AddWithValue("@fromCity", p.FromCity.Id);
                        com.Parameters.AddWithValue("@toCity", p.ToCity.Id);
                        com.Parameters.AddWithValue("@depart", p.Depart.ToString("yyyy-MM-dd HH:mm:ss"));
                        com.Parameters.AddWithValue("@arrival", p.Arrival.ToString("yyyy-MM-dd HH:mm:ss"));
                        com.Parameters.AddWithValue("@duration", (p.Arrival - p.Depart).TotalMinutes);
                        com.Parameters.AddWithValue("@airline", p.Airline);
                        com.Parameters.AddWithValue("@price", p.Price);

                        connection.Open();
                        com.ExecuteNonQuery();
                    }
                }
            }
            #endregion
        }
    } 
}
