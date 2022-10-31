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
        RelationshipManager rm = null;

        public HomePage()
        {
            InitializeComponent();
            addPanel();
            showLogin();
        }

        private void showLogin()
        {
            if (login.ShowDialog() == DialogResult.OK)
                rm = login.getRelationShipManager();
            else
                rm = null;

            updateHomePage();
        }

        private void updateHomePage()
        {
            if (null == rm)
                usernameLabel.Text = "Guest";
            else
                usernameLabel.Text = rm.getName();
        }

        private void addPanel()
        {
            Panel thePanel = new Panel();
            thePanel.AutoScroll = true;
            thePanel.Location = new Point(220, 30);
            thePanel.Size = new Size(800, 550);
            thePanel.BackColor = Color.FromArgb(181, 190, 198);
            thePanel.Visible = true;

            PictureBox picLogo = new PictureBox();
            Bitmap logo = new Bitmap(Properties.Resources.EALogoPnkBackLBFront);
            picLogo.Image = (Image)logo;
            picLogo.Location = new Point(20,20);
            picLogo.Size = new Size(100, 100);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            thePanel.Controls.Add(picLogo);

            Label title = new Label();
            title.Text = "Edwards && Avey Investments";
            title.Font = new Font("Arial", 32);
            title.Location = new Point(130, 50);
            title.ForeColor = Color.Black;
            title.Width = 600;
            title.Height = 60;
            thePanel.Controls.Add(title);

            Panel textContainer = new Panel();
            Label description = new Label();
            textContainer.Location = new Point(60, 140);
            textContainer.Size = new Size(680, 300);
            textContainer.BackColor = Color.FromArgb(54, 70, 82);
            description.Text = "Edwards and Avey Investments is your go-to solution for tailored investment bundles. We offer up-to-the-day investment opportunities in groups of assets provided by our highly-experienced partners. These partners collate groups of relevant assets into investment “ideas”. These ideas make it easy for you as an investor to find collections of individual assets that meet your desired investment interests, without the need to personally hand pick them, saving you time and allowing you to grow your investment portfolio much faster, and easier.";
            description.Location = new Point(20, 35);
            description.MaximumSize = new Size(640,0);
            description.AutoSize = true;
            description.Font = new Font("Arial", 16);
            textContainer.Controls.Add(description);
            thePanel.Controls.Add(textContainer);


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
            showLogin();
        }

        public void updateUsernameLabel(string newLabel)
        {
            usernameLabel.Text = newLabel;
        }
    }
}
