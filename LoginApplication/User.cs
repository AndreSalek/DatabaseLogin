using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApplication
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public User(int ID, string Username)
        {
            this.ID = ID;
            this.Username = Username;   
        }
    }
}
