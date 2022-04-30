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
        Timer timer;
        public LoginForm()
        {
            InitializeComponent();
            
        }
        public void SetupTimer()
        {
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            lblOutput.Text = "";
            timer.Stop();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //storing testbox values in variables
                string username = txtLoginUsername.Text.ToLower().Trim();
                string password = txtLoginPassword.Text;
                //Opening connection
                MyDatabaseConn conn = new MyDatabaseConn();
                conn.Open();
                //function Login looks whether textbox values match any database records
                User user = conn.Login(username, password);
                //if null is returned (data did not match any record)
                if (user != null)
                {
                    this.Hide();
                    new MainWindow(user).Show();
                }
                else
                {
                    SetupTimer();
                    timer.Start();
                    lblOutput.Text = "User does not exist";
                }
                    conn.Close();

            }
            catch (Exception ex)
            {
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
