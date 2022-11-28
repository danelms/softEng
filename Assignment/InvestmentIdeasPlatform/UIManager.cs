using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace InvestmentIdeasPlatform
{

    /// <summary>
    /// Class to handle dynamic UI for each usertype
    /// </summary>
    public class UIManager
    {
        byte userType;
        User currentUser;

        /// <summary>
        /// Constructor used to isntantiate UIManager
        /// </summary>
        /// <param name="user"></param>
        public UIManager(User user)
        {
            currentUser = user;
            userType = user.getUserType();
        }

        DataSet dataSet = null;

        Button viewIdeas = new Button(), viewClient = new Button(), createUser = new Button(), logout = new Button(), viewSuggestedIdeas = new Button(), createIdea = new Button();

        Panel viewIdeasPanel = new Panel(), viewClientPanel = new Panel(), createUserPanel = new Panel();

        DBConnection con = DBFactory.instance();

        ComboBox memCmbAccType { get; set; }
        TextBox memtxtUsername { get; set; }
        //RM>Create user panel placeholders (used for EventHandler access)
        CheckBox checkShowPass = null;
        TextBox txtPass1 = null, txtPass2 = null, txtUsername = null;
        Button btnCreateAccount = null;
        ComboBox cmbAccType = null;
        //RM>View ideas panel placeholders
        ListBox listBoxIdeas = null, listBoxClients = null;
        Button btnSeePreferences = null, btnSuggestIdea = null;

        public void getUI(Panel panel, Form form)
        {
            switch (userType)
            {
                case 1:
                    addClientMenu(panel);
                    
                    break;
                case 2:
                    addRmMenu(panel);
                    addRmPanels(form);
                    break;

                case 3:
                    addFaMenu(panel);
                    break;
            }
        }

        private void styleMenuButton(Button button, String title)
        {
            button.Width = 220;
            button.Height = 34;
            button.Dock = DockStyle.Top;
            button.Text = title;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Arial", 14);
            button.FlatAppearance.BorderSize = 0;
            button.BringToFront();
        }

        /// <summary>
        /// Adds the RelationshipManager menu to a panel
        /// </summary>
        /// <param name="panel">The panel affected</param>
        public void addRmMenu(Panel panel)
        {
            panel.Controls.Add(viewIdeas);
            panel.Controls.Add(viewClient);
            panel.Controls.Add(createUser);
            panel.Controls.Add(logout);

            styleMenuButton(viewIdeas, "View Ideas");
            styleMenuButton(viewClient, "View Clients");
            styleMenuButton(createUser, "Create User");
            styleMenuButton(logout, "Log Out");
        }

        /// <summary>
        /// Adds the Client menu to a panel
        /// </summary>
        /// <param name="panel">The panel affected</param>
        public void addClientMenu(Panel panel)
        {
            panel.Controls.Add(viewSuggestedIdeas);
            panel.Controls.Add(logout);

            styleMenuButton(viewSuggestedIdeas, "View suggest ideas");
            styleMenuButton(logout, "Log Out");
            addButtonEventHandlers(currentUser); //MOVE TO PANELS
        }

        /// <summary>
        /// Adds the FundAdministrator menu to a panel
        /// </summary>
        /// <param name="panel">The panel affected</param>
        public void addFaMenu(Panel panel)
        {
            panel.Controls.Add(logout);
            panel.Controls.Add(createIdea);

            styleMenuButton(createIdea, "Create idea");
            styleMenuButton(logout, "Log Out");
            addButtonEventHandlers(currentUser); //MOVE TO PANELS
        }

        /// <summary>
        /// Loads RM specific panels to a form
        /// </summary>
        /// <param name="form">The form the panels will be displayed on</param>
        public void addRmPanels(Form form)
        {
            stylePanel(viewIdeasPanel);
            stylePanel(viewClientPanel);
            stylePanel(createUserPanel);

            //View ideas
            
            //Button test = new Button();
            //test.Click += Test_Click;
            //viewIdeasPanel.Controls.Add(test);
            
            //End view ideas

            //View clients
            Label lblClients = new Label();
            lblClients.Text = "Clients";
            lblClients.Font = new Font("Arial", 15);
            lblClients.Location = new Point(100, 40);
            lblClients.ForeColor = Color.White;
            lblClients.Width = 600;
            lblClients.Height = 60;
            viewClientPanel.Controls.Add(lblClients);

            ListBox listboxClients = new ListBox();
            listboxClients.Location = new Point(100, 70);
            listboxClients.Size = new Size(600, 100);
            DataSet clients = new DataSet();

            clients = con.getDataSet("Select Name from User WHERE UserType = '1'");
            List<String> clientNames = clients.Tables[0].AsEnumerable().Select(r => r.Field<String>("Name")).ToList();
            foreach (String clientName in clientNames)
            {
                listboxClients.Items.Add(clientName);
            }

            viewClientPanel.Controls.Add(listboxClients);
            listboxClients.BringToFront();

            btnSeePreferences = new Button();
            btnSeePreferences.Text = "See preferences";
            btnSeePreferences.BackColor = Color.FromArgb(52, 70, 82);
            btnSeePreferences.ForeColor = Color.White;
            btnSeePreferences.Size = new Size(100, 40);
            btnSeePreferences.Location = new Point(350, 180);
            viewClientPanel.Controls.Add(btnSeePreferences);

            Label lblIdeas = new Label();
            lblIdeas.Text = "Ideas";
            lblIdeas.Font = new Font("Arial", 15);
            lblIdeas.Location = new Point(100, 220);
            lblIdeas.ForeColor = Color.White;
            lblIdeas.Width = 600;
            lblIdeas.Height = 30;
            viewClientPanel.Controls.Add(lblIdeas);

            ListBox listboxIdeas = new ListBox();
            listboxIdeas.Location = new Point(100, 250);
            listboxIdeas.Size = new Size(600, 100);
            DataSet ideas = new DataSet();

            ideas = con.getDataSet("Select Overview from InvestmentIdea");
            List<String> ideaOverviews = ideas.Tables[0].AsEnumerable().Select(r => r.Field<String>("Overview")).ToList();
            foreach (String ideaOverview in ideaOverviews)
            {
                listboxClients.Items.Add(ideaOverview);
            }

            viewClientPanel.Controls.Add(listboxIdeas);

            btnSuggestIdea = new Button();
            btnSuggestIdea.Text = "Suggest Idea";
            btnSuggestIdea.BackColor = Color.FromArgb(52, 70, 82);
            btnSuggestIdea.ForeColor = Color.White;
            btnSuggestIdea.Size = new Size(100, 40);
            btnSuggestIdea.Location = new Point(350, 360);
            viewClientPanel.Controls.Add(btnSuggestIdea);
            //End view clients

            //Create user
            PictureBox pb = new PictureBox();
            Bitmap userImage = new Bitmap(Properties.Resources.userIcon, 50, 50);
            pb.Image = (Image)userImage;
            pb.Location = new Point(350, 100);
            pb.Size = new Size(100, 100);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            createUserPanel.Controls.Add(pb);

            cmbAccType = new ComboBox();
            cmbAccType.Text = "Account Type";
            cmbAccType.Location = new Point(200, 240);
            cmbAccType.Size = new Size(400, 40);
            cmbAccType.BackColor = Color.White;
            cmbAccType.ForeColor = Color.Black;
            cmbAccType.Items.Add("Client");
            cmbAccType.Items.Add("Relationship Manager");
            cmbAccType.Items.Add("Fund Administrator");
            memCmbAccType = cmbAccType;
            createUserPanel.Controls.Add(cmbAccType);

            txtUsername = new TextBox();
            txtUsername.Text = "Username";
            txtUsername.Location = new Point(200, 270);
            txtUsername.Size = new Size(400, 40);
            memtxtUsername = txtUsername;
            createUserPanel.Controls.Add(txtUsername);

            txtPass1 = new TextBox();
            txtPass1.Text = "Password";
            txtPass1.Location = new Point(200, 300);
            txtPass1.Size = new Size(400, 40);
            createUserPanel.Controls.Add(txtPass1);

            txtPass2 = new TextBox();
            txtPass2.Text = "Confirm password";
            txtPass2.Location = new Point(200, 330);
            txtPass2.Size = new Size(400, 40);
            createUserPanel.Controls.Add(txtPass2);

            btnCreateAccount = new Button();
            btnCreateAccount.Text = "Create account";
            btnCreateAccount.BackColor = Color.FromArgb(52, 70, 82);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Size = new Size(100, 40);
            btnCreateAccount.Location = new Point(350, 360);
            createUserPanel.Controls.Add(btnCreateAccount);

            checkShowPass = new CheckBox();
            checkShowPass.Checked = true;
            checkShowPass.Size = new Size(15, 15);
            checkShowPass.Location = new Point(200, 365);
            createUserPanel.Controls.Add(checkShowPass);

            Label lblShowPass = new Label();
            lblShowPass.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            lblShowPass.Text = "Show password";
            lblShowPass.Size = new Size(200, 40);
            lblShowPass.ForeColor = Color.White;
            lblShowPass.Location = new Point(215, 365);
            createUserPanel.Controls.Add(lblShowPass);
            //End create user

            addButtonEventHandlers(currentUser);

            form.Controls.Add(viewIdeasPanel);
            form.Controls.Add(viewClientPanel);
            form.Controls.Add(createUserPanel);
        }

        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "Username" && txtUsername != null && txtPass1.Text == txtPass2.Text)
            {
                BusinessMetaLayer bl = BusinessMetaLayer.instance();
                bl.insertUserData("NAMEPLACEHOLDER", (cmbAccType.SelectedIndex + 1), txtUsername.Text, txtPass1.Text);
            }
            
        }

        private void Test_Click(object sender, EventArgs e)
        {
            DataGrid dt = new DataGrid();

            con.OpenConnection();
            dataSet = con.getDataSet("Select * from InvestmentProduct");
            DataTable table = dataSet.Tables[0];

            dt.DataSource = table;
            dt.Width = 300;
            dt.Height = 300;
            viewIdeasPanel.Controls.Add(dt);
        }

        /// <summary>
        /// Applies default styling to a panel
        /// </summary>
        /// <param name="panel">The panel the changes will be applied to</param>
        public void stylePanel(Panel panel)
        {
            panel.AutoScroll = true;
            panel.Location = new Point(220, 30);
            panel.Size = new Size(800, 550);
            panel.BackColor = Color.FromArgb(181, 190, 198);
            panel.Visible = true;
        }

        /// <summary>
        /// Adds event handlers to objects, such as buttons
        /// </summary>
        private void addButtonEventHandlers(User user)
        {
            logout.Click += Logout_Click;

            switch (user.getUserType())
            {
                case 1:
                    break;
                case 2:
                    viewClient.Click += ViewClient_Click;
                    viewIdeas.Click += ViewIdeas_Click;
                    createUser.Click += CreateUser_Click;
                    checkShowPass.CheckedChanged += checkShowPass_CheckedChanged;
                    btnCreateAccount.Click += BtnCreateAccount_Click;
                    break;
                case 3:
                    break;
            }
            
        }



        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            createUserPanel.BringToFront();
        }

        private void ViewClient_Click(object sender, EventArgs e)
        {
            viewClientPanel.BringToFront();
        }

        private void ViewIdeas_Click(object sender, EventArgs e)
        {
            viewIdeasPanel.BringToFront();
        }

        private void checkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShowPass.Checked)
            {
                txtPass1.UseSystemPasswordChar = false;
                txtPass2.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass1.UseSystemPasswordChar = true;
                txtPass2.UseSystemPasswordChar = true;
            }
        }

    }
}
