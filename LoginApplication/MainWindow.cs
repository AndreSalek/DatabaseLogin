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
    public partial class MainWindow : Form
    {
        public MainWindow(User user)
        {
            InitializeComponent();
            lblusername.Text = user.Username;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
