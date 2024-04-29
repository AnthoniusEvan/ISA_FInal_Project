using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;

namespace FlightReservationProject
{
    public class TransportRate
    {
        #region Data Members
        private Airport from;
        private Airport to;
        private FlightClass flightClass;
        private string ageType;
        private int fee;
        #endregion

        #region Properties
        public Airport From { get => from; set => from = value; }
        public Airport To { get => to; set => to = value; }
        public FlightClass FlightClass { get => flightClass; set => flightClass = value; }
        public string AgeType { get => ageType; set => ageType = value; }
        public int Fee { get => fee; set => fee = value; }
        #endregion

        #region Constructors
        public TransportRate(Airport from, Airport to, FlightClass flightClass, string ageType, int fee)
        {
            From = from;
            To = to;
            FlightClass = flightClass;
            AgeType = ageType;
            Fee = fee;
        }
        #endregion
    }
}
