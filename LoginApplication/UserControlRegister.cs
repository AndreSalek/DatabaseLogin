using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApplication
{
    public partial class UserControlRegister : UserControl
    {
        public UserControlRegister()
        {
            InitializeComponent();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MyDatabaseConn conn = new MyDatabaseConn();
            conn.Open();
            bool exists = conn.UserExists(txtUsername.Text);
            if (!exists)
            {
                if (txtPassword.Text == txtPasswordRepeat.Text)
                {
                    //Create user in database
                    bool createdUser = conn.CreateUser(txtUsername.Text, txtPassword.Text);
                    if (createdUser)
                    {
                        MessageBox.Show("Registered succesfully. You can login now.");
                        this.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Passwords don't match.");
                }
            }
            else
            {
                MessageBox.Show("Username already exists");
            }
            conn.Close();
        }
    }
}
