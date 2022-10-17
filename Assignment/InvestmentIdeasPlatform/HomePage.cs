using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestmentIdeasPlatform
{
    
    public partial class HomePage : Form
    {
        Login login = new Login();
        public HomePage()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimiseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void loginSidebarLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void loginSidebarButton_Click(object sender, EventArgs e)
        {
            login.Show();
        }
    }
}
