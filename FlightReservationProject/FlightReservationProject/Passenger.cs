using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
using MySql.Data.MySqlClient;

namespace FlightReservationProject
{
    public class Passenger
    {
        #region Data Members
        private string id;
        private string fullName;
        private PlaneFlight flight;
        private string seat;
        private string gate;
        private User user;
        private string ageType;
        private string title;
        private string phoneNumber;
        private string email;
        private Country bornIn;
        private DateTime dob;
        private bool checkedIn;
        #endregion

        #region Properties
        public string FullName { get => fullName; set => fullName = value; }
        public PlaneFlight Flight { get => flight; set => flight = value; }
        public string Seat { get => seat; set => seat = value; }
        public User User { get => user; set => user = value; }
        public string AgeType { get => ageType; set => ageType = value; }
        public string Title { get => title; set => title = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public Country BornIn { get => bornIn; set => bornIn = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Id { get => id; set => id = value; }
        public bool CheckedIn { get => checkedIn; set => checkedIn = value; }
        public string Gate { get => gate; set => gate = value; }
        #endregion

        #region Constructors
        public Passenger(string fullName, PlaneFlight flight, User user, string ageType, string title, string phoneNumber, Country bornIn, DateTime dob)
        {
            FullName = fullName;
            Flight = flight;
            User = user;
            AgeType = ageType;
            Title = title;
            PhoneNumber = phoneNumber;
            BornIn = bornIn;
            Dob = dob;
        }
        public Passenger(string fullName, PlaneFlight flight, User user, string ageType, string title, Country bornIn, DateTime dob)
        {
            FullName = fullName;
            Flight = flight;
            User = user;
            AgeType = ageType;
            Title = title;
            BornIn = bornIn;
            Dob = dob;
        }
        public Passenger(string id, string title, string fullName, DateTime dob, string ageType)
        {
            Id = id;
            Title = title;
            FullName = fullName;
            Dob = dob;
            AgeType = ageType;
            //BornIn = bornIn;
        }
        #endregion

        #region Methods
        public static bool IsCheckedIn(string id, string flightNum, AES aes)
        {
            string sql = "SELECT flight_number, passenger_id FROM boarding_pass WHERE flight_number = @flightNum AND passenger_id = @p.id";
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@flightNum", aes.Encrypt(flightNum));
                    cmd.Parameters.AddWithValue("@p.id", id);
                    connection.Open();
                    using (MySqlDataReader results = cmd.ExecuteReader())
                    {
                        if (results.Read())
                        {
                            return true;
                        }
                        else return false;
                    }
                }
            }
        }
        #endregion
    }
}
