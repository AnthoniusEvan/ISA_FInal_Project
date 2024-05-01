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
        private List<Reservation> reservations;
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
                if (value.Length < 8)
                    throw new ArgumentException("Password length must be atleast 8 characters or longer!");

          
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
        public List<Reservation> Reservations { get => reservations; private set => reservations = value; }
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

        public User(string id, string fullName, string email, string password, string address, DateTime birthDate, string mobileNumber, City fromCity)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
            Address = address;
            BirthDate = birthDate;
            MobileNumber = mobileNumber;
            FromCity = fromCity;
            Reservations = new List<Reservation>();
        }
        public User(string id, string fullName, string email, string address, DateTime birthDate, string mobileNumber, City fromCity)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Address = address;
            BirthDate = birthDate;
            MobileNumber = mobileNumber;
            FromCity = fromCity;
            Reservations = new List<Reservation>();
        }
        #endregion

        #region Methods

        public static User ValidateLogin(string id, string email, string password, out AES aes)
        {
            string sql = "SELECT key_value, iv, user_email FROM private_key WHERE user_email = SHA2(@email, 512)";
            aes = new AES();
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@email", GetUInt64Hash(SHA512.Create(), email).ToString());
                    connection.Open();
                    using (MySqlDataReader results = com.ExecuteReader())
                    {
                        if (results.Read())
                        {
                            aes = new AES(results.GetString(0), results.GetString(1));
                        }
                    }
                }
            }
            
            
            sql = "SELECT SHA2(u.id,512), u.full_name, SHA2(u.email,512), u.password, u.address, u.date_of_birth, u.mobile_number, ci.id, ci.name, ci.country_id, co.name FROM user u INNER JOIN city ci ON u.from_city_id = ci.id INNER JOIN country co ON ci.country_id = co.id WHERE u.id = SHA2(@id, 512) AND u.email = SHA2(@email,512) AND u.password = SHA2(@password,512)";
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@id", GetUInt64Hash(SHA512.Create(), id).ToString());
                    com.Parameters.AddWithValue("@email", GetUInt64Hash(SHA512.Create(), email).ToString());
                    com.Parameters.AddWithValue("@password", GetUInt64Hash(SHA512.Create(), password).ToString());
                    connection.Open();
                    using (MySqlDataReader results = com.ExecuteReader())
                    {
                        if (results.Read())
                        {
                            Country co = new Country(results.GetInt32(9), results.GetString(10));
                            City ci = new City(results.GetInt32(7), results.GetString(8), co);
                            User user = new User(id, aes.Decrypt(results.GetString(1)), email, aes.Decrypt(results.GetString(4)), results.GetDateTime(5), aes.Decrypt(results.GetString(6)), ci);

                            return user;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
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
            string sql = string.Format("INSERT INTO user(id, email, full_name, password, address, date_of_birth, mobile_number, from_city_id) VALUES (SHA2('{0}',512),SHA2('{1}',512),'{2}',SHA2('{3}',512),'{4}','{5}','{6}','{7}')", GetUInt64Hash(SHA512.Create(), user.Id).ToString(), GetUInt64Hash(SHA512.Create(), user.Email).ToString(), user.FullName, GetUInt64Hash(SHA512.Create(), user.Password).ToString(), user.Address, user.BirthDate.ToString("yyyy-MM-dd"), user.MobileNumber, user.FromCity.Id);

            dbConnection.ExecuteNonQuery(sql);

            byte[] iv;
            byte[] key = AES.GenerateKey(out iv);
            AES aes = new AES(Convert.ToBase64String(key), Convert.ToBase64String(iv));

            sql = string.Format("INSERT INTO private_key(key_value, iv, user_id, user_email) VALUES('{0}','{1}',SHA2('{2}',512),SHA2('{3}',512))", Convert.ToBase64String(key), Convert.ToBase64String(iv), GetUInt64Hash(SHA512.Create(), user.Id).ToString(), GetUInt64Hash(SHA512.Create(), user.Email));
            dbConnection.ExecuteNonQuery(sql);

            sql = string.Format("UPDATE user SET full_name = '{0}', address = '{1}', mobile_number = '{2}' WHERE id = SHA2('{3}',512) AND email = SHA2('{4}',512)", aes.Encrypt(user.FullName), aes.Encrypt(user.Address), aes.Encrypt(user.MobileNumber), GetUInt64Hash(SHA512.Create(), user.Id).ToString(), GetUInt64Hash(SHA512.Create(), user.Email).ToString());

            return dbConnection.ExecuteNonQuery(sql);
        }
        public static int Update(User user, string password, AES aes)
        {
            string sql = string.Format("UPDATE user SET full_name = '{0}', address = '{1}', date_of_birth = '{2}', mobile_number = '{3}', from_city_id = '{4}' WHERE id = SHA2('{5}',512) AND email = SHA2('{6}',512)", aes.Encrypt(user.FullName), aes.Encrypt(user.Address), user.BirthDate.ToString("yyyy-MM-dd"), aes.Encrypt(user.MobileNumber), user.FromCity.Id, GetUInt64Hash(SHA512.Create(), user.Id).ToString(), GetUInt64Hash(SHA512.Create(), user.Email).ToString());

            if (password != "")
            {
                sql += string.Format(";UPDATE user SET password = SHA2('{0}',512) WHERE id = SHA2('{1}',512) AND email = SHA2('{2}',512)",GetUInt64Hash(SHA512.Create(), password).ToString(), GetUInt64Hash(SHA512.Create(), user.Id).ToString(), GetUInt64Hash(SHA512.Create(), user.Email).ToString());
            }

            return dbConnection.ExecuteNonQuery(sql);
        }
        public static ulong GetUInt64Hash(HashAlgorithm hasher, string text)
        {
            using (hasher)
            {
                var bytes = hasher.ComputeHash(Encoding.Default.GetBytes(text));
                Array.Resize(ref bytes, bytes.Length + bytes.Length % 8); 
                return Enumerable.Range(0, bytes.Length / 8) 
                    .Select(i => BitConverter.ToUInt64(bytes, i * 8))
                    .Aggregate((x, y) => x ^ y);
            }
        }

        public List<Reservation> RetrieveReservation(AES aes)
        {
            string sql = "SELECT r.id, r.user_email, r.from_city, fc.name, r.to_city, tc.name, r.adult, r.child, r.baby, r.date_depart, r.date_arrival, r.class_id, c.name, r.flight_number, r.ticket_num FROM reservation r INNER JOIN city fc ON r.from_city = fc.id INNER JOIN city tc ON r.to_city = tc.id LEFT JOIN class c ON r.class_id = c.id WHERE r.user_email = SHA2('" + GetUInt64Hash(SHA512.Create(), Email).ToString() + "',512)";


            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    using (MySqlDataReader results = cmd.ExecuteReader())
                    {
                        List<Reservation> reservations = new List<Reservation>();
                        while (results.Read())
                        {
                            City fc = new City(results.GetInt32(2), results.GetString(3));
                            City tc = new City(results.GetInt32(4), results.GetString(5));
                            FlightClass c = new FlightClass(results.GetInt32(11), results.GetString(12));
                            Reservation r = new Reservation(results.GetInt32(0), this, fc, tc, results.GetDateTime(9), results.GetInt32(6), results.GetInt32(7), results.GetInt32(8), c, aes.Decrypt(results.GetString(14)));
                            r.ChooseFlight(PlaneFlight.GetChosenFlight(results.GetString(13)));
                            reservations.Add(r);
                        }
                        if (reservations.Count > 0) return reservations;
                        else return null;
                    }
                }
            }
            
        }

        public Reservation CheckIn(string ticketNum, string full_name, AES aes)
        {
            string sql = "SELECT r.id, r.user_email, r.from_city, fc.name, r.to_city, tc.name, r.adult, r.child, r.baby, r.date_depart, r.date_arrival, r.class_id, c.name, r.flight_number, r.ticket_num FROM reservation r INNER JOIN city fc ON r.from_city = fc.id INNER JOIN city tc ON r.to_city = tc.id LEFT JOIN class c ON r.class_id = c.id WHERE r.user_email = SHA2(@email,512) AND r.ticket_num = @ticketNum";

            Reservation reservation=new Reservation();

            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@email", GetUInt64Hash(SHA512.Create(), Email).ToString());
                    com.Parameters.AddWithValue("@ticketNum",aes.Encrypt(ticketNum));
                    connection.Open();
                    using (MySqlDataReader results = com.ExecuteReader())
                    {
                        if (results.Read())
                        {
                            City fc = new City(results.GetInt32(2), results.GetString(3));
                            City tc = new City(results.GetInt32(4), results.GetString(5));
                            FlightClass c = new FlightClass(results.GetInt32(11), results.GetString(12));
                            reservation = new Reservation(results.GetInt32(0), this, fc, tc, results.GetDateTime(9), results.GetInt32(6), results.GetInt32(7), results.GetInt32(8), c, aes.Decrypt(results.GetString(14)));
                            reservation.ChooseFlight(PlaneFlight.GetChosenFlight(results.GetString(13)));
                        }
                    }
                }
            }
            reservation.User = this;
            List<Passenger> passengers = reservation.GetPassengers(aes);
            if (passengers == null) return null;

            foreach(Passenger p in passengers)
            {
                if (p.FullName == full_name)
                {
                    reservation.ListOfPassengers = passengers;
                    return reservation;
                }
            }
            return null;
        }
        #endregion

    }
}
