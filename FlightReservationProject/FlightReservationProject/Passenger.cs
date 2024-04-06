using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
namespace FlightReservationProject
{
    public class Passenger
    {
        #region Data Members
        private string fullName;
        private PlaneFlight flight;
        private string seat;
        private User user;
        private string ageType;
        #endregion

        #region Properties
        public string FullName { get => fullName; set => fullName = value; }
        public PlaneFlight Flight { get => flight; set => flight = value; }
        public string Seat { get => seat; set => seat = value; }
        public User User { get => user; set => user = value; }
        public string AgeType { get => ageType; set => ageType = value; }
        #endregion

        #region Constructors
        public Passenger(string fullName, PlaneFlight flight, string seat, User user, string ageType)
        {
            FullName = fullName;
            Flight = flight;
            Seat = seat;
            User = user;
            AgeType = ageType;
        }
        #endregion
    }
}
