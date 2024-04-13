using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace FlightReservationProject
{
    public class User
    {
        #region Data Members
        private string id;
        private string fullName;
        private string email;
        private string password;
        private string address;
        private DateTime birthDate;
        private string mobileNumber;
        private City fromCity;
        #endregion

        #region Properties
        public string Id
        {
            get => id;
            set
            {
                if (value=="")
                    throw new ArgumentException("Please provide your ID/NIK!");
                
                id = value;
            }
        }
        public string FullName
        {
            get => fullName;
            set
            {
                if (value != "")
                    fullName = value;
                else
                    throw new ArgumentException("Please provide your full name!");
            }
        }
        public string Email { get => email;
            set
            {
                if (value=="")
                    throw new ArgumentException("Please provide an email address!");
 
                if (value.Contains("@") && value.EndsWith(".com"))
                {
                    email = value;
                }
                else
                    throw new ArgumentException("Please provide a valid email address! e.g. cella@gmail.com");
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (value.Length < 12)
                    throw new ArgumentException("Password length must be atleast 12 characters or longer!");

          
                if (value.All(char.IsDigit) || value.All(char.IsLetter))
                {
                    throw new ArgumentException("Password must contain atleast 1 letter and 1 number!");
                }

                if (value==password)
                {
                    throw new ArgumentException("Password must not be the same as the old password!");
                }
                password = value;
            }
        }
        public string Address
        {
            get => address;
            set
            {
                if (value!="")
                    address = value;
                else
                    throw new ArgumentException("Please provide your home address!");
            }
        }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string MobileNumber
        {
            get => mobileNumber;
            set
            {
                string[] temp = value.Split('-');
                if (temp[1].Length > 3 && temp[1].Length < 16)
                    mobileNumber = value;
                else
                    throw new ArgumentException("Please provide a valid mobile number!");
            }
        }
        public City FromCity { get => fromCity; set => fromCity = value; }
        #endregion

        #region Constructors
        public User()
        {
        }

        private User(string fullName, string email)
        {
            this.fullName = fullName;
            this.email = email;
        }

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
            string sql = "SELECT u.full_name, u.email, u.password, u.address, u.date_of_birth, u.mobile_number, ci.id, ci.name, ci.country_id, co.name FROM user u INNER JOIN city ci ON u.from_city_id = ci.id INNER JOIN country co ON ci.country_id = co.id WHERE u.email = @email AND u.password = SHA2(@password,512)";
            
            dbConnection con = new dbConnection();
            MySqlCommand com = new MySqlCommand(sql, con.DbCon);
            com.Parameters.AddWithValue("@email", email);
            com.Parameters.AddWithValue("@password", GetUInt64Hash(SHA512.Create(),password).ToString());
            MySql.Data.MySqlClient.MySqlDataReader results = com.ExecuteReader();

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

        public static bool IsUserRegistered(string val)
        {
            string sql = "SELECT full_name, email FROM user";
            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<User> users = new List<User>();

            while (results.Read())
            {
                User user = new User(results.GetString(0), results.GetString(1));
                users.Add(user);
            }

            foreach (User u in users)
            {
                if (u.Email == val || u.Id == val)
                {
                    return true;
                }
            }
            return false;
        }

        public static int Add(User user)
        {
            string sql = string.Format("INSERT INTO user(id, email, full_name, password, address, date_of_birth, mobile_number, from_city_id) VALUES ('{0}','{1}','{2}',SHA2('{3}',512),'{4}','{5}','{6}','{7}')", user.Id, user.Email, user.FullName, GetUInt64Hash(SHA512.Create(),user.Password).ToString(), user.Address, user.BirthDate.ToString("yyyy-MM-dd"), user.MobileNumber, user.FromCity.Id);


            return dbConnection.ExecuteNonQuery(sql);
        }
        public static ulong GetUInt64Hash(HashAlgorithm hasher, string text)
        {
            using (hasher)
            {
                var bytes = hasher.ComputeHash(Encoding.Default.GetBytes(text));
                Array.Resize(ref bytes, bytes.Length + bytes.Length % 8); //make multiple of 8 if hash is not, for exampel SHA1 creates 20 bytes. 
                return Enumerable.Range(0, bytes.Length / 8) // create a counter for de number of 8 bytes in the bytearray
                    .Select(i => BitConverter.ToUInt64(bytes, i * 8)) // combine 8 bytes at a time into a integer
                    .Aggregate((x, y) => x ^ y); //xor the bytes together so you end up with a ulong (64-bit int)
            }
        }

        #endregion

    }
}
