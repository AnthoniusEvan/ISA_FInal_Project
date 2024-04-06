using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using System.Text.RegularExpressions;


namespace FlightReservationProject
{
    public class User
    {
        #region Data Members
        private int id;
        private string fullName;
        private string email;
        private string password;
        private string address;
        private DateTime birthDate;
        private string mobileNumber;
        private City fromCity;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Email { get => email; set => email = value; }
        public string Password
        {
            get => password;
            set
            {
                if (value.Length < 12)
                    throw new ArgumentException("Password length must be atleast 12 characters or longer!");
                Regex r = new Regex("^[a-zA-Z0-9]*$");

                if (!r.IsMatch(value))
                {
                    throw new ArgumentException("Password must contain atleast 1 letter or 1 number!");
                }

                if (value==Password)
                {
                    throw new ArgumentException("Password must not be the same as the old password!");
                }
                password = value;
            }
        }
        public string Address { get => address; set => address = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string MobileNumber { get => mobileNumber; set => mobileNumber = value; }
        public City FromCity { get => fromCity; set => fromCity = value; }
        #endregion

        #region Constructors
        public User(string fullName, string email, string password, string address, DateTime birthDate, string mobileNumber, City fromCity)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Address = address;
            BirthDate = birthDate;
            MobileNumber = mobileNumber;
            FromCity = fromCity;
        }
        #endregion

        #region Methods
        public static User ValidateLogin(string email, string password)
        {
            string sql = "SELECT u.full_name, u.email, u.password, u.address, u.date_of_birth, u.mobile_number, ci.id, ci.name, ci.country_id, co.name FROM user u INNER JOIN city ci ON u.from_city_id = ci.id INNER JOIN country co ON ci.country_id = co.id WHERE u.email ='" + email + "' AND u.password = SHA2('" + password + "',512)";
            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);

            if (results.Read())
            {
                Country co = new Country(results.GetInt32(8), results.GetString(9));
                City ci = new City(results.GetInt32(6), results.GetString(7), co);
                User user = new User(results.GetString(0), results.GetString(1), results.GetString(2), results.GetString(3), results.GetDateTime(4), results.GetString(5), ci);

                return user;
            }
            else
            {
                return null;
            }
        }

        #endregion

    }
}
