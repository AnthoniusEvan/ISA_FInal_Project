using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
namespace FlightReservationProject
{
    public class City
    {
        #region Data Members
        private int id;
        private string name;
        private Country fromCountry;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Country FromCountry { get => fromCountry; set => fromCountry = value; }
        #endregion

        #region Constructors
        public City(int id, string name, Country fromCountry)
        {
            Id = id;
            Name = name;
            FromCountry = fromCountry;
        }

        #endregion
    }
}
