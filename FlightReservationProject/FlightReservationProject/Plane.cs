using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
namespace FlightReservationProject
{
    public class Plane
    {
        #region Data Members
        private int id;
        private string name;
        private string type;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        #endregion

        #region Constructors
        public Plane(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
        #endregion

        #region Methods

        #endregion
    }
}
