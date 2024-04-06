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
        private User user;
        private Plane plane;
        private Airport fromAirport;
        private Airport toAirport;
        private Class flightClass;
        private string gate;;
        private
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        #endregion

        #region Constructors
        public Class(int id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion

        #region Methods

        #endregion
    }
}
