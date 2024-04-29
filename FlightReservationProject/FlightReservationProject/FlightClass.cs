using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
namespace FlightReservationProject
{
    public class FlightClass
    {
        #region Data Members
        private int id;
        private string name;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        #endregion

        #region Constructors
        public FlightClass(int id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion

        #region Methods
        public static List<FlightClass> GetClasses()
        {
            string sql = "SELECT id, name FROM class";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<FlightClass> classes = new List<FlightClass>();

            while (results.Read()) 
            {
                FlightClass c = new FlightClass(results.GetInt32(0), results.GetString(1));
                classes.Add(c);
            }
            return classes;
        }
        #endregion
    }
}
