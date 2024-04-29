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
        private DateTime date;
        private FlightClass flightClass;
        private string gate;
        #endregion

        #region Properties
        public DateTime Date { get => date; set => date = value; }
        public FlightClass FlightClass { get => flightClass; set => flightClass = value; }
        public string Gate { get => gate; set => gate = value; }
        #endregion

        #region Constructors
        public BoardingPass(DateTime date, Plane plane, string gate)
        {

        }
        #endregion

        #region Methods

        #endregion
    }
}
