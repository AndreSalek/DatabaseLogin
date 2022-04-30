using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LoginApplication
{
    public class MyDatabaseConn
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;
        string server = "localhost";
        string database = "UserDatabase";
        string uid = "root";
        string password = "";
        
        
        public MyDatabaseConn()
        {
            string connString = string.Format("server = {0};database = {1};uid = {2};pwd = {3};", server, database, uid, password);
            conn = new MySqlConnection(connString);
        }
        public void Open()
        {
            conn.Open();
        }
        public void Close()
        {
            conn.Close();
        }
        public bool UserExists(string username)
        {
            string query = $"SELECT Username FROM user WHERE Username = '{ username }'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Dispose();
                return true;
            }
            else
            {
                reader.Dispose();
                return false;
            }
        }

        public bool CreateUser(string username, string password)
        {
            if ((username.Length >= 1) && (password.Length >= 1))
            {
                string registerString = "INSERT INTO user(Username,Password) VALUES (@Username, @Password)";
                cmd = new MySqlCommand(registerString, conn);
                cmd.Parameters.AddWithValue("@Username", username.ToLower().Trim());
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Login(string name, string password)
        {
            string query = $"SELECT * FROM user WHERE Username = '{name}' AND Password = '{ password }'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new User(reader.GetInt32(0), reader.GetString(1));
            }
            reader.Dispose();
            return null;
        }
    }
}
