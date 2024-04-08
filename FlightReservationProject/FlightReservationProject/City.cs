using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
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

        #region Methods
        public static List<City> GetCities(string name)
        {
            string sql = "SELECT ci.id, ci.name, ci.country_id, co.name FROM city ci INNER JOIN country co";
            if (name != "")
            {
                sql = " WHERE ci.name = " + name;
            }
            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<City> cities = new List<City>();
            if (results.Read())
            {
                Country co = new Country(results.GetInt32(2), results.GetString(3));
                City ci = new City(results.GetInt32(0), results.GetString(1), co);
                cities.Add(ci);

                return cities;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
