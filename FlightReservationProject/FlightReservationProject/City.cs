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

        public City(int id, string cityCountry)
        {
            Id = id;
            Name = cityCountry;
        }
        #endregion

        #region Methods
        public static List<City> GetCities(Country country)
        {
            string sql = "SELECT ci.id, ci.name, ci.country_id, co.name FROM city ci INNER JOIN country co ON ci.country_id = co.id WHERE co.id = " + country.Id + " ORDER BY ci.name ASC";
            
            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<City> cities = new List<City>();

            while (results.Read())
            {
                City ci = new City(results.GetInt32(0), results.GetString(1), country);
                cities.Add(ci);  
            }
            return cities;
        }
        public static List<City> GetSearchCities(string keyword)
        {
            string sql = string.Format("SELECT ci.id, CONCAT(ci.name, ', ', co.name), ci.rank FROM city ci INNER JOIN country co ON ci.country_id = co.id WHERE ci.name LIKE '%{0}%' OR co.name LIKE '%{1}%'", keyword, keyword);

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<City> cities = new List<City>();
            while (results.Read() == true)
            {
                City ci = new City(results.GetInt32(0), results.GetString(1));
                cities.Add(ci);
            }
            return cities;
        }

        public static List<City> GetOrigins(Country country)
        {
            string sql = "SELECT ci.id, CONCAT(ci.name, ', ', co.name) FROM city ci INNER JOIN country co ON ci.country_id = co.id ORDER BY co.id != '"+ country.Id +"', co.name ASC LIMIT 200";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<City> cities = new List<City>();
            List<int> ids = new List<int>();
            while (results.Read()) // some countries cause input string not in the correct format
            {
                City ci = new City(results.GetInt32(0), results.GetString(1));
                cities.Add(ci);
                ids.Add(results.GetInt32(0));
            }

            sql = "SELECT ci.id, CONCAT(ci.name, ', ', co.name), ci.rank FROM city ci INNER JOIN country co ON ci.country_id = co.id ORDER BY ISNULL(ci.rank), ci.rank ASC, co.name ASC, ci.name ASC LIMIT 200";

            results = dbConnection.ExecuteQuery(sql);
            while (results.Read()) 
            {
                City ci = new City(results.GetInt32(0), results.GetString(1));
                if (!ids.Contains(results.GetInt32(0))) cities.Add(ci);
            }

            return cities;
        }

        public static List<City> GetDestinations(Country originCountry)
        {
            string sql = "SELECT ci.id, CONCAT(ci.name, ', ', co.name), ci.rank FROM city ci INNER JOIN country co ON ci.country_id = co.id ORDER BY ISNULL(ci.rank), ci.rank ASC, co.name ASC, ci.name ASC LIMIT 200";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<City> cities = new List<City>();
            List<int> ids = new List<int>();
            while (results.Read()==true)
            {
                City ci = new City(results.GetInt32(0), results.GetString(1));
                cities.Add(ci);
                ids.Add(results.GetInt32(0));
            }

            sql = "SELECT ci.id, CONCAT(ci.name, ', ', co.name) FROM city ci INNER JOIN country co ON ci.country_id = co.id ORDER BY co.id != '" + originCountry.Id + "', co.name ASC LIMIT 200";

            results = dbConnection.ExecuteQuery(sql);
            while (results.Read())
            {
                City ci = new City(results.GetInt32(0), results.GetString(1));
                if (!ids.Contains(results.GetInt32(0))) cities.Add(ci);
            }
            return cities;
        }
        #endregion
    }
}
