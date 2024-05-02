using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public Reservation(User user, City from, City to, DateTime dateDepart, int adult, int child, int baby, FlightClass flightClass, AES aes)
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
            Id = GenerateId(aes);
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
                string sql = "SELECT COUNT(id), ticket_num FROM reservation WHERE ticket_num LIKE @ticketNum";
                int count = 0;
                using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@ticketNum", ticketNum);
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
        private int GenerateId(AES aes)
        {
            string sql = "SELECT COUNT(r.id), u.id, u.email FROM reservation r INNER JOIN user u ON r.user_email = u.email WHERE u.email = SHA2(@email,512)";

            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@email", User.GetUInt64Hash(SHA512.Create(), User.Email).ToString());

                    connection.Open();
                    using (MySqlDataReader results = com.ExecuteReader())
                    {
                        int count = 0;
                        while (results.Read())
                        {
                            count = results.GetInt32(0);
                        }
                        return count + 1;
                    }
                }
            }
            
        }
        public int AddReservation(List<Passenger> passengers, AES aes)
        {
            if (TicketNum == null) return 0;

            string sql = "INSERT INTO reservation(id, user_email, from_city, to_city, adult, child, baby, date_depart, date_arrival, flight_number, class_id, ticket_num) VALUES(@id,SHA2(@email,512),@fromCity,@toCity,@adult,@child,@baby,@dated,@datea,@flightNum,@class,@ticketNum)";

            int rowsAffected = 0;
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@id", Id);
                    com.Parameters.AddWithValue("@email", User.GetUInt64Hash(SHA512.Create(), User.Email).ToString());
                    com.Parameters.AddWithValue("@fromCity", FromCity.Id);
                    com.Parameters.AddWithValue("@toCity", ToCity.Id);
                    com.Parameters.AddWithValue("@adult", Adult);
                    com.Parameters.AddWithValue("@child", Child);
                    com.Parameters.AddWithValue("@baby", Baby);
                    com.Parameters.AddWithValue("@dated", DateDepart.ToString("yyyy-MM-dd HH:mm:00"));
                    com.Parameters.AddWithValue("@datea", DateArrival.ToString("yyyy-MM-dd HH:mm:00"));
                    com.Parameters.AddWithValue("@flightNum", FlightChosen.FlightNumber);
                    com.Parameters.AddWithValue("@class", FlightClass.Id);
                    com.Parameters.AddWithValue("@ticketNum", aes.Encrypt(TicketNum));
                    connection.Open();
                    rowsAffected = com.ExecuteNonQuery();
                }
            }

            rowsAffected += AddPassengers(passengers, aes);
            return rowsAffected;
        }

        private int AddPassengers(List<Passenger> passengers, AES aes)
        {
            ListOfPassengers = passengers;

            string sql = "SELECT COUNT(p.id), r.id, u.email FROM passenger p INNER JOIN reservation r ON p.reservation_id = r.id INNER JOIN user u ON r.user_email = u.email WHERE u.email = SHA2(@email,512) AND r.id = @id";
            int count = 0;
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@email", User.GetUInt64Hash(SHA512.Create(), User.Email).ToString());
                    com.Parameters.AddWithValue("@id", Id);
                    connection.Open();
                    using (MySqlDataReader results = com.ExecuteReader())
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

                sql = "INSERT INTO passenger(id, title, full_name, dob, age_type, born_in, reservation_id, reservation_user_email) VALUES (@id,@title,@fullname,@dob,@ageType,@bornIn,@reservationId,SHA2(@email,512))";

                using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
                {
                    using (MySqlCommand com = new MySqlCommand(sql, connection))
                    {
                        com.Parameters.AddWithValue("@email", User.GetUInt64Hash(SHA512.Create(), User.Email).ToString());
                        com.Parameters.AddWithValue("@id", count + 1 + i);
                        com.Parameters.AddWithValue("@title", p.Title);
                        com.Parameters.AddWithValue("@fullname", aes.Encrypt(p.FullName));
                        com.Parameters.AddWithValue("@dob", p.Dob.ToString("yyyy-MM-dd"));
                        com.Parameters.AddWithValue("@ageType", p.AgeType);
                        com.Parameters.AddWithValue("@bornIn", p.BornIn.Id);
                        com.Parameters.AddWithValue("@reservationId", Id);

                        connection.Open();
                        rowsAffected = com.ExecuteNonQuery();
                    }
                }
 
            }
            return rowsAffected;
        }

        public List<Passenger> GetPassengers(AES aes)
        {
            string sql = "SELECT p.id, p.title, p.full_name, p.dob, p.age_type, p.born_in, u.email, p.reservation_id FROM passenger p INNER JOIN user u ON p.reservation_user_email = u.email WHERE u.email = SHA2(@email,512) AND p.reservation_id = @id";
            
            List<Passenger> passengers = new List<Passenger>();
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@email", User.GetUInt64Hash(SHA512.Create(), User.Email).ToString());
                    com.Parameters.AddWithValue("@id", Id);
                    connection.Open();
                    using (MySqlDataReader results = com.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            Passenger p = new Passenger(results.GetString(0), results.GetString(1), aes.Decrypt(results.GetString(2)), results.GetDateTime(3), results.GetString(4));

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
