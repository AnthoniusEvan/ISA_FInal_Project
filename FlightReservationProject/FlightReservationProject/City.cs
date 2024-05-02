using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
using MySql.Data.MySqlClient;

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
            string sql = "SELECT ci.id, ci.name, ci.country_id, co.name FROM city ci INNER JOIN country co ON ci.country_id = co.id WHERE co.id = @countryid ORDER BY ci.name ASC";
            

            List<City> cities = new List<City>();


            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@countryId", country.Id);
                    connection.Open();
                    using (MySqlDataReader results = cmd.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            City ci = new City(results.GetInt32(0), results.GetString(1), country);
                            cities.Add(ci);
                        }
                        return cities;
                    }
                }
            }
        
        }
        public static List<City> GetSearchCities(string keyword)
        {
            string sql = "";
            if (keyword.Contains(","))
            {
                string[] key = keyword.Split(',');
                sql = string.Format("SELECT ci.id, CONCAT(ci.name, ', ', co.name), ci.rank FROM city ci INNER JOIN country co ON ci.country_id = co.id WHERE ci.name = '{0}' OR co.name = '{1}'", key[0], key[1].TrimStart(' '));
            }
            else
                sql = string.Format("SELECT ci.id, CONCAT(ci.name, ', ', co.name), ci.rank FROM city ci INNER JOIN country co ON ci.country_id = co.id WHERE ci.name LIKE '%{0}%' OR co.name LIKE '%{1}%'", keyword, keyword);

            
            List<City> cities = new List<City>();

            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            City ci = new City(reader.GetInt32(0), reader.GetString(1));
                            cities.Add(ci);
                        }
                        return cities;
                    }
                }
            }
        }
        public static List<City> GetOrigins(Country country)
        {
            string sql = "SELECT ci.id, CONCAT(ci.name, ', ', co.name) FROM city ci INNER JOIN country co ON ci.country_id = co.id ORDER BY co.id != @coName, co.name ASC LIMIT 200";

            List<City> cities = new List<City>();

            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("coName", country);
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            City ci = new City(reader.GetInt32(0), reader.GetString(1));
                            cities.Add(ci);
                        }

                        return cities;
                    }
                }
            }
            
        }

        public static List<City> GetDestinations()
        {
            string sql = "SELECT ci.id, CONCAT(ci.name, ', ', co.name), ci.rank FROM city ci INNER JOIN country co ON ci.country_id = co.id ORDER BY ISNULL(ci.rank), ci.rank ASC, co.name ASC, ci.name ASC LIMIT 200";

            List<City> cities = new List<City>();

            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            City ci = new City(reader.GetInt32(0), reader.GetString(1));
                            cities.Add(ci);
                        }

                        return cities;
                    }
                }
            }
            
        }
        #endregion
    }
}
