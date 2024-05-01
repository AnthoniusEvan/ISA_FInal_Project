using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
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
        public BoardingPass(FlightClass flightClass, string flightNumber, Passenger passenger)
        {
            Random rnd = new Random();
            Gate = (Convert.ToChar(rnd.Next(65, 91)) + rnd.Next(1,11)).ToString();
            if (passenger.Seat == null || passenger.Seat=="") Seat = rnd.Next(1, 100).ToString() + (char)(rnd.Next(65, 91));
            else Seat = passenger.Seat;
            FlightClass = flightClass;
            FlightNumber = flightNumber;
            Passenger = passenger;
            CreateBoardingPass();
        }

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
        public static string GenerateRandomSeat()
        {
            Random rnd = new Random();
            return rnd.Next(1, 100).ToString() + (char)(rnd.Next(65, 91));
        }
        private int GenerateId()
        {
            string sql = "SELECT COUNT(id) FROM boarding_pass WHERE plane_flight_flight_number = '" + FlightNumber + "'";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            int count = 0;
            while (results.Read())
            {
                count = results.GetInt32(0);
            }

            return count + 1;
        }
        private void CreateBoardingPass()
        {
            string sql = string.Format("INSERT INTO boarding_pass(id, class_id, gate, plane_flight_flight_number, seat_number, passenger_id) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", GenerateId(), FlightClass.Id, Gate, FlightNumber, Seat, Passenger.Id);
            dbConnection.ExecuteNonQuery(sql);
        }
        public static List<BoardingPass> GetBoardingPass(Passenger p)
        {
            string sql = "SELECT b.id, b.class_id, c.name, b.gate, b.plane_flight_flight_number, b.seat_number, b.passenger_id FROM boarding_pass b INNER JOIN class c ON b.class_id = c.id WHERE b.passenger_id = '" + p.Id + "'";
            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<BoardingPass> passes = new List<BoardingPass>();
            while (results.Read())
            {
                FlightClass fc = new FlightClass(results.GetInt32(1),results.GetString(2));
                BoardingPass pass = new BoardingPass(results.GetInt32(0), fc, results.GetString(3), results.GetString(4), results.GetString(5), p);
                passes.Add(pass);
            }

            if (passes.Count > 0) return passes;
            else return null;
        }
        #endregion
    }
}
