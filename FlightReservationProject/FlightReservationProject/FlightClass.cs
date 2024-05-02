using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
using MySql.Data.MySqlClient;

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
            List<FlightClass> classes = new List<FlightClass>();
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FlightClass c = new FlightClass(reader.GetInt32(0), reader.GetString(1));
                            classes.Add(c);
                        }
                        return classes;
                    }
                }
            }
        }
        #endregion
    }
}
