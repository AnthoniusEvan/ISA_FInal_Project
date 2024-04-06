using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
namespace FlightReservationProject
{
    public class BoardingPass
    {
        #region Data Members
        private DateTime date;
        private Class flightClass;
        private string gate;
        #endregion

        #region Properties
        public DateTime Date { get => date; set => date = value; }
        public Class FlightClass { get => flightClass; set => flightClass = value; }
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
