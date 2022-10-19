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
            addPanel();
            showLogin();
        }

        private void showLogin() 
        {
            login.ShowDialog();
        }
        private void addPanel() 
        {
            Panel thePanel = new Panel();
            ListBox test = new ListBox();
            test.Width = 20;
            test.ForeColor = Color.Black;
            test.Height = 1000;

            thePanel.AutoScroll = true;
            thePanel.Location = new Point(220, 30);
            thePanel.Size = new Size(800, 550);
            thePanel.BackColor = Color.FromArgb(181, 190, 198);
            thePanel.Visible = true;

            for (int i = 0; i < 100; i++)
            {
                test.Items.Add(i);
                thePanel.Controls.Add(test);
            }
            this.Controls.Add(thePanel);
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
