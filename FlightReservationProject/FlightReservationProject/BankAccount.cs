using DbLib;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationProject
{
    public class BankAccount
    {
        #region Data Members
        private string num;
        private string cvv;
        private DateTime dateExpire;
        private User user;
        #endregion

        #region Properties
        public string Num { get => num; set => num = value; }
        public string Cvv { get => cvv; set => cvv = value; }
        public DateTime DateExpire { get => dateExpire; set => dateExpire = value; }
        public User User { get => user; set => user = value; }
        #endregion

        #region Constructors
        public BankAccount(string num, string cvv, DateTime dateExpire, User user)
        {
            Num = num;
            Cvv = cvv;
            DateExpire = dateExpire;
            User = user;
        }
        #endregion

        #region Methods
        public static List<BankAccount> GetBankAccounts(User user, AES aes)
        {
            string sql = " SELECT t.token, b.cvv, b.date_expire FROM bank_account b INNER JOIN token t ON b.number = t.bank_account_number WHERE b.user_email = SHA2(@email,512)";
            List<BankAccount> bankAccounts = null;
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@email", User.GetUInt64Hash(SHA512.Create(), user.Email).ToString());
                    connection.Open();

                    using(MySqlDataReader results = com.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            string dateExpire = aes.Decrypt(results.GetString(2));
                            int year = int.Parse(dateExpire.Split('-')[1]);
                            int month = int.Parse(dateExpire.Split('-')[0]);
                            BankAccount b = new BankAccount(results.GetString(0), aes.Decrypt(results.GetString(1)), new DateTime(year, month, 1), user);
                            bankAccounts.Add(b);
                        }
                        return bankAccounts;
                    }
                }
            }
        }
        public int AddToDB(AES aes)
        {
            int rowsAffected = 0;
            string sql = "INSERT INTO bank_account(number,cvv,date_expire,user_email) VALUES(@num,@cvv,@date,SHA2(@email,512))";

            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@num", aes.Encrypt(Num));
                    com.Parameters.AddWithValue("@cvv", aes.Encrypt(Cvv));
                    com.Parameters.AddWithValue("@date", aes.Encrypt(DateExpire.ToString("MM-yy")));
                    com.Parameters.AddWithValue("@email", User.GetUInt64Hash(SHA512.Create(), User.Email).ToString());
                    connection.Open();

                    rowsAffected += com.ExecuteNonQuery();
                }
            }

            string token = GenerateToken();
            sql = "INSERT INTO token(token, bank_account_number) VALUES(@token,@num)";

            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@token", token);
                    com.Parameters.AddWithValue("@num", aes.Encrypt(Num));
                    
                    connection.Open();
                    rowsAffected += com.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
        public string GenerateToken()
        {
            Random random = new Random();
            string TokenCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            char[] token = new char[40];
            for (int i = 0; i < 40; i++)
            {
                token[i] = TokenCharacters[random.Next(TokenCharacters.Length)];
            }

            string res = new string(token);
            string sql = "SELECT token FROM bank_account WHERE token = @token";
            using (MySqlConnection connection = new MySqlConnection(dbConnection.GetConnectionString()))
            {
                using (MySqlCommand com = new MySqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@token", res);
                    connection.Open();

                    using (MySqlDataReader results = com.ExecuteReader())
                    {
                        if (results.Read())
                        {
                            GenerateToken();
                        }
                    }
                }
            }
            return res;
        }
        #endregion
    }
}
