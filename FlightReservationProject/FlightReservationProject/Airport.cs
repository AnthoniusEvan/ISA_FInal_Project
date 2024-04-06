using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
namespace FlightReservationProject
{
    public class Airport
    {
        #region Data Members
        private int id;
        private City city;
        private string name;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public City City { get => city; set => city = value; }
        public string Name { get => name; set => name = value; }
        #endregion

        #region Constructors
        public Airport(int id, City city, string name)
        {
            Id = id;
            City = city;
            Name = name;
        }
        #endregion

        #region Methods

        #endregion
    }
}
