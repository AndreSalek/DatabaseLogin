using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApplication
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtLoginUsername.Text.ToLower().Trim();
                string password = txtLoginPassword.Text;
                MyDatabaseConn conn = new MyDatabaseConn();
                conn.Open();
                User user = conn.Login(username, password);
                if (user != null)
                {
                    this.Close();
                    new MainWindow(user);
                }
                else lblOutput.Text = "User does not exist";
                conn.Close();

            }
            catch (Exception ex)
            {
                lblOutput.Text = "User does not exist";
                Debug.WriteLine(ex);
            }
        }

        
        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userControlRegister1.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}
