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
        private string id;
        private Plane plane;
        private int totalPassenger;
        private string status;
        private Airport fromAirport;
        private Airport toAirport;
        private List<Passenger> listOfPassengers;
        #endregion

        #region Properties
        public string Id { get => id; set => id = value; }
        public Plane Plane { get => plane; set => plane = value; }
        public int TotalPassenger { get => totalPassenger; set => totalPassenger = value; }
        public string Status { get => status; set => status = value; }
        public Airport FromAirport { get => fromAirport; set => fromAirport = value; }
        public Airport ToAirport { get => toAirport; set => toAirport = value; }
        public List<Passenger> ListOfPassengers { get => listOfPassengers; set => listOfPassengers = value; }
        #endregion

        #region Constructors
        public PlaneFlight(string id, Plane plane, string status, Airport from, Airport to)
        {
            Id = id;
            Plane = plane;
            Status = status;
            FromAirport = from;
            ToAirport = to;
        }
        #endregion
    }
}
