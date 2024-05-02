using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
using MySql.Data.MySqlClient;

namespace FlightReservationProject
{
    public class BoardingPass
    {
        #region Data Members
        private int id;
        private FlightClass flightClass;
        private string gate;
        private string seat;
        private string flightNumber;
        private Passenger passenger;
        #endregion

        #region Properties
        public FlightClass FlightClass { get => flightClass; set => flightClass = value; }
        public string Gate { get => gate; set => gate = value; }
        public string Seat { get => seat; set => seat = value; }
        public string FlightNumber { get => flightNumber; set => flightNumber = value; }
        public int Id { get => id; set => id = value; }
        public Passenger Passenger { get => passenger; set => passenger = value; }
        #endregion

        #region Constructors
        public BoardingPass()
        {

        }
        // Used to export data
        public BoardingPass(FlightClass flightClass, string flightNumber, Passenger passenger, AES aes)
        {
            Random rnd = new Random();
            Gate = passenger.Gate;
            Seat = passenger.Seat;
            FlightClass = flightClass;
            FlightNumber = flightNumber;
            Passenger = passenger;
            CreateBoardingPass(aes);
        }

        // Used to import date
        public BoardingPass(int id, FlightClass flightClass, string gate, string flight_number, string seat, Passenger passenger)
        {
            Id = id;
            FlightClass = flightClass;
            Gate = gate;
            FlightNumber = flight_number;
            Seat = seat;
        }
        #endregion

        #region Methods
        public static string GenerateRandomGate()
        {
            Random rnd = new Random();
            return Convert.ToChar(rnd.Next(65, 91)) + rnd.Next(1, 11).ToString();
        }
        public static string[] GenerateRandomSeat(int qty)
        {
            string[] seats = new string[qty];
            Random rnd = new Random();
            int num = rnd.Next(1, 102 - qty);
            int ascii = rnd.Next(65, 91);
            seats[0] = num.ToString() + (char)ascii;
            for (int i = 1; i < seats.Length; i++)
            {
                if (i % 9 == 0)
                {
                    ascii++;
                    num = 1;

                }
                else
                {
                    num++;
                }
                seats[i] = num.ToString() + (char)ascii;
            }
            return seats;
        }
        public static string[] GenerateSeatFromCheckedInPassenger(int qty, string seat, int order)
        {
            string[] seats = new string[qty];
            int n = int.Parse(seat.Replace(seat[seat.Length - 1],'\0'));
            if (order > 1)
            {
                if (n > order)
                {
                    seats[0] = (n - order).ToString() + seat[seat.Length - 1];
                }
                else
                {
                    seats[0] = (102-order).ToString() + ((int)(seat[seat.Length - 1]) - 1);
                }
            }
            else seats[0] = seat;

            
            Random rnd = new Random();
            int num = int.Parse(seats[0].Replace(seats[0][seats[0].Length - 1], '\0'));
            int ascii = (int)(seats[0][seats[0].Length - 1]);

            for (int i = 1; i < seats.Length; i++)
            {
                if (i % 9 == 0)
                {
                    ascii++;
                    num = 1;

                }
                else
                {
                    num++;
                }
                seats[i] = num.ToString() + (char)ascii;
            }
            return seats;
        }
        private int GenerateId(AES aes)
        {
            string sql = "SELECT COUNT(id) FROM boarding_pass WHERE flight_number = '" + aes.Encrypt(FlightNumber) + "'";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            int count = 0;
            while (results.Read())
            {
                count = results.GetInt32(0);
            }

            return count + 1;
        }
        private void CreateBoardingPass(AES aes)
        {
            string sql = string.Format("INSERT INTO boarding_pass(id, class_id, gate, flight_number, seat_number, passenger_id) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", GenerateId(aes), FlightClass.Id, aes.Encrypt(Gate), aes.Encrypt(FlightNumber), aes.Encrypt(Seat), Passenger.Id);
            dbConnection.ExecuteNonQuery(sql);
        }
        public static BoardingPass GetBoardingPass(Passenger p, string flightNumber, AES aes)
        {
            string sql = "SELECT b.id, b.class_id, c.name, b.gate, b.flight_number, b.seat_number, b.passenger_id FROM boarding_pass b INNER JOIN class c ON b.class_id = c.id WHERE b.passenger_id = '" + p.Id + "' AND b.flight_number = '" + aes.Encrypt(flightNumber) +"'";

            BoardingPass pass=null;
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    using (MySqlDataReader results = cmd.ExecuteReader())
                    {
                        if (results.Read())
                        {
                            FlightClass fc = new FlightClass(results.GetInt32(1), results.GetString(2));
                            pass = new BoardingPass(results.GetInt32(0), fc, aes.Decrypt(results.GetString(3)), aes.Decrypt(results.GetString(4)), aes.Decrypt(results.GetString(5)), p);
                        }
                        return pass;
                    }
                }
            }
        }
        #endregion
    }
}
