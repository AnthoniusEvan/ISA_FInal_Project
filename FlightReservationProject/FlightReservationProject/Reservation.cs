using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
using MySql.Data.MySqlClient;

namespace FlightReservationProject
{
    public class Reservation
    {
        #region Data Members
        private int id;
        private User user;
        private City fromCity;
        private City toCity;
        private DateTime dateDepart;
        private DateTime dateArrival;
        private int adult;
        private int child;
        private int baby;
        private string ticketNum;
        private FlightClass flightClass;
        private PlaneFlight flightChosen;
        private List<Passenger> listOfPassengers;
        #endregion

        #region Properties
        public City FromCity { get => fromCity; set => fromCity = value; }
        public City ToCity { get => toCity; set => toCity = value; }
        public DateTime DateDepart { get => dateDepart; set => dateDepart = value; }
        public int Adult { get => adult; set => adult = value; }
        public int Child { get => child; set => child = value; }
        public int Baby { get => baby; set => baby = value; }
        public FlightClass FlightClass { get => flightClass; set => flightClass = value; }
        public List<Passenger> ListOfPassengers { get => listOfPassengers; set => listOfPassengers = value; }
        public User User { get => user; set => user = value; }
        public PlaneFlight FlightChosen { get => flightChosen; private set => flightChosen = value; }
        public DateTime DateArrival { get => dateArrival; set => dateArrival = value; }
        public int Id { get => id; set => id = value; }
        public string TicketNum { get => ticketNum; set => ticketNum = value; }
        #endregion

        #region Constructors
        // Used to import data
        public Reservation(int id, User user, City from, City to, DateTime dateDepart, int adult, int child, int baby, FlightClass flightClass, string ticketNum)
        {
            Id = id;
            User = user;
            FromCity = from;
            ToCity = to;
            DateDepart = dateDepart;
            Adult = adult;
            Child = child;
            Baby = baby;
            FlightClass = flightClass;
            TicketNum = ticketNum;
            ListOfPassengers = new List<Passenger>();
        }

        // Used to export data
        public Reservation(User user, City from, City to, DateTime dateDepart, int adult, int child, int baby, FlightClass flightClass)
        {
            User = user;
            FromCity = from;
            ToCity = to;
            DateDepart = dateDepart;
            Adult = adult;
            Child = child;
            Baby = baby;
            FlightClass = flightClass;
            ListOfPassengers = new List<Passenger>();
            Id = GenerateId();
        }
        public Reservation()
        {

        }

        public int getTotalPassengers()
        {
            return adult + child + baby;
        }
        #endregion

        #region Methods
        private void GenerateTicketNum()
        {
            if (FlightChosen != null)
            {
                int flightNum = int.Parse(FlightChosen.FlightNumber.Substring(2, FlightChosen.FlightNumber.Length - 2));
                TicketNum = FlightChosen.FlightNumber.Substring(0, 2) + FromCity.Name[0] + ToCity.Name[0] + flightNum;
                string sql = "SELECT COUNT(id), ticket_num FROM reservation WHERE ticket_num LIKE '" + TicketNum + "%'";
                int count = 0;
                using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (MySqlDataReader results = cmd.ExecuteReader())
                        {
                            if (results.Read())
                            {
                                count = results.GetInt32(0) + 1;
                            }
                        }
                    }
                }
                TicketNum += count;
            }
        }
        public void ChooseFlight(PlaneFlight flight)
        {
            FlightChosen = flight;
            dateArrival = flight.Arrival;
            if (TicketNum==null)GenerateTicketNum();
        }
        private int GenerateId()
        {
            string sql = "SELECT COUNT(r.id), u.id, u.email FROM reservation r INNER JOIN user u ON r.user_id = u.id WHERE u.id = '"+User.Id+"' AND u.email = '" + User.Email +"'";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            int count = 0;
            while (results.Read())
            {
                count = results.GetInt32(0);
            }
            return count + 1;
        }
        public int AddReservation(List<Passenger> passengers)
        {
            if (TicketNum == null) return 0;

            string sql = string.Format("INSERT INTO reservation(id, user_id, user_email, from_city, to_city, adult, child, baby, date_depart, date_arrival, flight_number, class_id, ticket_num) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}', '{11}', '{12}')", Id, User.Id, User.Email, FromCity.Id, ToCity.Id, Adult, Child, Baby, DateDepart.ToString("yyyy-MM-dd HH:mm:00"), DateArrival.ToString("yyyy-MM-dd HH:mm:00"), FlightChosen.FlightNumber, FlightClass.Id, TicketNum);

            int rowsAffected = dbConnection.ExecuteNonQuery(sql);

            rowsAffected+=AddPassengers(passengers);
            return rowsAffected;
        }

        private int AddPassengers(List<Passenger> passengers)
        {
            ListOfPassengers = passengers;

            string sql = "SELECT COUNT(p.id), r.id, u.id, u.email FROM passenger p INNER JOIN reservation r ON p.reservation_id = r.id INNER JOIN user u ON r.user_id = u.id WHERE u.id = '" + User.Id + "' AND u.email = '" + User.Email + "' AND r.id = '" + Id + "'";
            int count = 0;
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    using (MySqlDataReader results = cmd.ExecuteReader())
                    {
                        if (results.Read())
                        {
                            count = results.GetInt32(0);
                        }
                    }
                }
            }
            
            
            int rowsAffected = 0;
            for (int i = 0; i < passengers.Count; i++)
            {
                Passenger p = passengers[i];

                sql = string.Format("INSERT INTO passenger(id, title, full_name, dob, age_type, born_in, reservation_id, reservation_user_id, reservation_user_email) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",count + 1 + i, p.Title, p.FullName, p.Dob.ToString("yyyy-MM-dd"), p.AgeType, p.BornIn.Id, Id, User.Id, User.Email);

                rowsAffected += dbConnection.ExecuteNonQuery(sql);
            }
            return rowsAffected;
        }

        public List<Passenger> GetPassengers()
        {
            string sql = "SELECT p.id, p.title, p.full_name, p.dob, p.age_type, p.reservation_user_id, p.born_in, u.email, p.reservation_id FROM passenger p INNER JOIN user u ON p.reservation_user_id = u.id WHERE u.id = '" + User.Id + "' AND u.email = '" + User.Email + "' AND p.reservation_id = '" + Id + "'";
            
            List<Passenger> passengers = new List<Passenger>();
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    using (MySqlDataReader results = cmd.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            Passenger p = new Passenger(results.GetString(0), results.GetString(1), results.GetString(2), results.GetDateTime(3), results.GetString(4));

                            passengers.Add(p);
                        }
                        if (passengers.Count > 0) return passengers;
                        else return null;
                    }
                }
            }
            
        }

        #endregion
    }
}
