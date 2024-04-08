using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DbLib
{
    public class dbConnection : IDisposable
    {
        #region Data Members
        private MySqlConnection dbCon;
        #endregion

        #region Properties
        public MySqlConnection DbCon { get => dbCon; private set => dbCon = value; }
        #endregion

        #region Constructors
        public dbConnection()
        {
            Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConfigurationSectionGroup userSettings = configFile.SectionGroups["userSettings"];

            var settingSection = userSettings.Sections["FlightReservationProject.db"] as ClientSettingsSection;

            string DbServer = settingSection.Settings.Get("DbServer").Value.ValueXml.InnerText;
            string DbName = settingSection.Settings.Get("DbName").Value.ValueXml.InnerText;
            string DbUsername = settingSection.Settings.Get("DbUsername").Value.ValueXml.InnerText;
            //string DbPassword = settingSection.Settings.Get("DbPassword").Value.ValueXml.InnerText;
            string DbPassword = configFile.AppSettings.Settings["DbPassword"].Value;

            DbCon = new MySqlConnection();
            DbCon.ConnectionString = "server=" + DbServer + ";database=" + DbName + ";uid=" + DbUsername + ";password=" + DbPassword;

            Connect();
        }
        public dbConnection(string serverAddress, string databaseName, string dbUsername, string dbPassword)
        {
            DbCon = new MySqlConnection();
            DbCon.ConnectionString = "server=" + serverAddress + ";database=" + databaseName + ";uid=" + dbUsername + ";password=" + dbPassword;
            Connect();
        }
        #endregion

        #region Destructors
        ~dbConnection()
        {
            DbCon.Close();
        }
        #endregion

        #region Methods
        public void Dispose()
        {
        }
        public void Connect()
        {
            if (DbCon.State == System.Data.ConnectionState.Closed)
                DbCon.Open();
        }

        public static MySqlDataReader ExecuteQuery(string sql)
        {
            dbConnection con = new dbConnection();
            MySqlCommand com = new MySqlCommand(sql, con.DbCon);
            return com.ExecuteReader();
        }

        public static int ExecuteNonQuery(string sql)
        {
            dbConnection con = new dbConnection();
            MySqlCommand com = new MySqlCommand(sql, con.DbCon);
            int rowsAffected = com.ExecuteNonQuery();
            return rowsAffected;
        }

        public static int ExecuteNonQuery(string sql, dbConnection con)
        {
            MySqlCommand com = new MySqlCommand(sql, con.dbCon);
            int rowsAffected = com.ExecuteNonQuery();
            return rowsAffected;
        }
        #endregion
    }
}
