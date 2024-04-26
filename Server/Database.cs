using CitizenFX.Core.Native;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LoginScreen.Server
{
    internal class Database
    {
        public static MySqlConnection GetConnection()
        {
            string host = API.GetConvar("MYSQL_HOST", null);
            string user = API.GetConvar("MYSQL_USER", null);
            string password = API.GetConvar("MYSQL_PASSWORD", null);
            string database = API.GetConvar("MYSQL_DATABASE", null);
            string port = API.GetConvar("MYSQL_PORT", null);
            if (host == null || user == null || password == null || database == null || port == null)
            {
                Debug.WriteLine("Missing MySQL configuration.");
                return null;
            }
            string connectionString = $"server={host};user={user};database={database};port={port};password={password}";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}
