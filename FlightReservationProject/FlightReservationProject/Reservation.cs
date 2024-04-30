using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationProject
{
    public class Reservation
    {
        #region Data Members
        private User user;
        private City fromCity;
        private City toCity;
        private DateTime dateDepart;
        private int adult;
        private int child;
        private int baby;
        private FlightClass flightClass;
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
        #endregion

        #region Constructors
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
        }

        public int getTotalPassengers()
        {
            return adult + child + baby;
        }
        #endregion

    }
}
