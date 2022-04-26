using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LoginApplication
{
    public class MyDatabaseConn
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        private string connString = @"your connection string";      //change 


        public MyDatabaseConn()
        {
            conn = new SqlConnection(connString);
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
            string query = $"SELECT Username FROM User WHERE Username = { username }";
            cmd = new SqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows) return true;
            else return false;
        }

        public bool CreateUser(string username, string password)
        {
            if ((username.Length >= 1) && (password.Length >= 1))
            {
                string registerString = "INSERT INTO Userser(Username,Password) VALUES (@Username, @Password)";
                cmd = new SqlCommand(registerString, conn);
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
            string query = $"SELECT * FROM User WHERE Username = {name} AND Password = { password }";
            cmd = new SqlCommand(query, conn);
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
