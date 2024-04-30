using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
using MySql.Data.MySqlClient;

namespace FlightReservationProject
{
    public class Country
    {
        #region Data Members
        private int id;
        private string name;
        private string dialingCode;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string DialingCode { get => dialingCode; set => dialingCode = value; }
        #endregion

        #region Constructors
        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Country(int id, string name, string dialingCode)
        {
            Id = id;
            Name = name;
            DialingCode = dialingCode;
        }
        #endregion

        #region Methods
        //public static List<Country> GetCountries()
        //{
        //    string sql = "SELECT id, name, dialing_code FROM country";
        //    MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
        //    List<Country> countries = new List<Country>();

        //    while (results.Read())
        //    {
        //        Country c = new Country(results.GetInt32(0), results.GetString(1), results.GetString(2));
        //        countries.Add(c);
        //    }
        //    return countries;
        //}

        public static List<Country> GetCountries()
        {
            string sql = "SELECT id, name, dialing_code FROM country";

            List<Country> countries = new List<Country>();
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Country c = new Country(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            countries.Add(c);
                        }
                        return countries;
                    }
                }
            }
            
        }
        #endregion
    }
}
