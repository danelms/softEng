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
using System.Data.Entity.Core.Metadata.Edm;
using System.Xml.Linq;
using System.Data.SQLite;
using System.Drawing.Printing;

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

        Panel viewIdeasPanel = new Panel(), viewClientPanel = new Panel(), createUserPanel = new Panel(), createIdeaPanel = new Panel();

        DBConnection con = DBFactory.instance();
        static BusinessMetaLayer bml = BusinessMetaLayer.instance();
        List<InvestmentProduct> products = bml.getInvestmentProducts();
        List<User> RMs = new List<User>();

        ComboBox memCmbAccType { get; set; }
        TextBox memtxtUsername { get; set; }
        //RM>Create user panel placeholders (used for EventHandler access)
        CheckBox checkShowPass = null;
        TextBox txtPass1 = null, txtPass2 = null, txtUsername = null, txtName = null;
        Button btnCreateAccount = null;
        ComboBox cmbAccType = null;
        //RM>View ideas panel placeholders
        ListBox listBoxIdeas = null, listBoxClients = null;
        Button btnSeePreferences = null, btnSuggestIdea = null;
        //FA>Create ideas panel placeholders
        Button btnAddMajorSector = null, btnRemoveMajorSector = null, btnAddMinorSector = null, btnRemoveMinorSector = null, btnAddCurrency = null, btnAddProducts = null, btnRemoveProducts = null, btnCreateIdea = null;
        TextBox txtProductTitle = null, txtIdeaContent = null;
        ComboBox cbMajorSector = null, cbMinorSector = null, cbCurrency = null, cbProducts = null;
        ListBox lbMajorSector = null, lbMinorSector = null, lbCurrency = null, lbProducts = null, lbIdeas = null, lbProductType = null, lbCurrencyRM = null, lbCountryRM = null, lbRegionRM = null, lbMajorSectorRM = null, lbMinorSectorRM = null, lbInstrumentsRM = null;
        RichTextBox txtProductOverview = null;
        TextBox txtIdeaTitle = null;
        ComboBox cbRMs = null;

        RichTextBox txtIdeaOverview = null;

        public void getUI(Panel panel, Form form)
        {
            switch (userType)
            {
                case 1:
                    addClientMenu(panel);
                    //addClientPanels(form);
                    break;
                case 2:
                    addRmMenu(panel);
                    addRmPanels(form);
                    break;

                case 3:
                    addFaMenu(panel);
                    addFAPanels(form);
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

            Padding marginTop = new Padding();
            marginTop.Top = 30;

            Label lblViewIdeas = new Label();
            lblViewIdeas.Text = "Ideas";
            lblViewIdeas.Font = new Font("Arial", 14);
            lblViewIdeas.Location = new Point(100, 40);
            lblViewIdeas.ForeColor = Color.White;
            viewIdeasPanel.Controls.Add(lblViewIdeas);

            lbIdeas = new ListBox();
            lbIdeas.Location = new Point(100, 70);
            lbIdeas.Size = new Size(600, 100);
            viewIdeasPanel.Controls.Add(lbIdeas);

            Panel singleIdeaPanel = new Panel();
            singleIdeaPanel.Location = new Point(100, 200);
            singleIdeaPanel.Size = new Size(600, 1100);
            singleIdeaPanel.BackColor = Color.FromArgb(54, 70, 82);
            singleIdeaPanel.ForeColor = Color.White;


            singleIdeaPanel.Padding= marginTop;
            Label ideaTitle = new Label();
            ideaTitle.Text = "My Idea Title";
            ideaTitle.AutoSize = false;
            ideaTitle.Dock = DockStyle.Top;
            ideaTitle.TextAlign = ContentAlignment.MiddleCenter;
            ideaTitle.Font = new Font("Arial", 18);

            singleIdeaPanel.Controls.Add(ideaTitle);

            Label lblIdeaContent = new Label();
            lblIdeaContent.Text = "Overview";
            lblIdeaContent.Font = new Font("Arial", 14);
            lblIdeaContent.Location = new Point(50, 70);
            singleIdeaPanel.Controls.Add(lblIdeaContent);

            txtIdeaContent = new TextBox();
            txtIdeaContent.Location = new Point(50, 100);
            txtIdeaContent.Multiline = true;
            txtIdeaContent.Size = new Size(500, 100);
            singleIdeaPanel.Controls.Add(txtIdeaContent);

            Label lblriskLevel = new Label();
            lblriskLevel.Text = "Risk Level:";
            lblriskLevel.Font = new Font("Arial", 12);
            lblriskLevel.Location = new Point(50, 230);
            singleIdeaPanel.Controls.Add(lblriskLevel);

            Label lblriskLevelValue = new Label();
            lblriskLevelValue.Text = "3";
            lblriskLevelValue.Font = new Font("Arial", 12);
            lblriskLevelValue.Location = new Point(147, 230);
            singleIdeaPanel.Controls.Add(lblriskLevelValue);

            Label lblProductType = new Label();
            lblProductType.Text = "Product Type: ";
            lblProductType.AutoSize = false;
            lblProductType.Size = new Size(300,20);
            lblProductType.Font = new Font("Arial", 12);
            lblProductType.Location = new Point(50, 280);
            singleIdeaPanel.Controls.Add(lblProductType);

            lbProductType = new ListBox();
            lbProductType.Items.Add("Product1");
            lbProductType.Location = new Point(50, 310);
            lbProductType.Size = new Size(500, 50);
            singleIdeaPanel.Controls.Add(lbProductType);

            Label lblCurrency = new Label();
            lblCurrency.Text = "Currency: ";
            lblCurrency.MaximumSize = new Size(100, 0);
            lblCurrency.AutoSize = true;
            lblCurrency.Font = new Font("Arial", 12);
            lblCurrency.Location = new Point(50, 400);
            singleIdeaPanel.Controls.Add(lblCurrency);

            lbCurrencyRM = new ListBox();
            lbCurrencyRM.Items.Add("USD");
            lbCurrencyRM.Location = new Point(130, 390);
            lbCurrencyRM.Size = new Size(420, 50);
            singleIdeaPanel.Controls.Add(lbCurrencyRM);

            Label lblCountry = new Label();
            lblCountry.Text = "Country: ";
            lblCountry.MaximumSize = new Size(100, 0);
            lblCountry.AutoSize = true;
            lblCountry.Font = new Font("Arial", 12);
            lblCountry.Location = new Point(50, 480);
            singleIdeaPanel.Controls.Add(lblCountry);

            lbCountryRM = new ListBox();
            lbCountryRM.Items.Add("United Kingdom");
            lbCountryRM.Location = new Point(130, 470);
            lbCountryRM.Size = new Size(420, 50);
            singleIdeaPanel.Controls.Add(lbCountryRM);

            Label lblRegion = new Label();
            lblRegion.Text = "Region: ";
            lblRegion.MaximumSize = new Size(100, 0);
            lblRegion.AutoSize = true;
            lblRegion.Font = new Font("Arial", 12);
            lblRegion.Location = new Point(50, 560);
            singleIdeaPanel.Controls.Add(lblRegion);

            lbRegionRM = new ListBox();
            lbRegionRM.Items.Add("Europe");
            lbRegionRM.Location = new Point(130, 550);
            lbRegionRM.Size = new Size(420, 50);
            singleIdeaPanel.Controls.Add(lbRegionRM);

            Label lblMajor = new Label();
            lblMajor.Text = "Major Sector: ";
            lblMajor.MaximumSize = new Size(100, 0);
            lblMajor.AutoSize = true;
            lblMajor.Font = new Font("Arial", 12);
            lblMajor.Location = new Point(50, 640);
            singleIdeaPanel.Controls.Add(lblMajor);

            lbMajorSectorRM = new ListBox();
            lbMajorSectorRM.Items.Add("IT Services");
            lbMajorSectorRM.Location = new Point(130, 630);
            lbMajorSectorRM.Size = new Size(420, 50);
            singleIdeaPanel.Controls.Add(lbMajorSectorRM);

            Label lblMinor = new Label();
            lblMinor.Text = "Minor Sector: ";
            lblMinor.MaximumSize = new Size(100, 0);
            lblMinor.AutoSize = true;
            lblMinor.Font = new Font("Arial", 12);
            lblMinor.Location = new Point(50, 720);
            singleIdeaPanel.Controls.Add(lblMinor);

            lbMinorSectorRM = new ListBox();
            lbMinorSectorRM.Items.Add("Gaming");
            lbMinorSectorRM.Location = new Point(130, 710);
            lbMinorSectorRM.Size = new Size(420, 50);
            singleIdeaPanel.Controls.Add(lbMinorSectorRM);

            Label lblInstruments = new Label();
            lblInstruments.Text = "Instruments: ";
            lblInstruments.MaximumSize = new Size(100, 0);
            lblInstruments.AutoSize = true;
            lblInstruments.Font = new Font("Arial", 12);
            lblInstruments.Location = new Point(50, 800);
            singleIdeaPanel.Controls.Add(lblInstruments);

            lbInstrumentsRM = new ListBox();
            lbInstrumentsRM.Items.Add("CON");
            lbInstrumentsRM.Location = new Point(145, 790);
            lbInstrumentsRM.Size = new Size(405, 50);
            singleIdeaPanel.Controls.Add(lbInstrumentsRM);

            Label lblPublished = new Label();
            lblPublished.Text = "Date Published: ";
            lblPublished.MaximumSize = new Size(100, 0);
            lblPublished.AutoSize = true;
            lblPublished.Font = new Font("Arial", 12);
            lblPublished.Location = new Point(50, 870);
            singleIdeaPanel.Controls.Add(lblPublished);

            Label lblPublishedValue = new Label();
            lblPublishedValue.Text = "00/00/0000";
            lblPublishedValue.MaximumSize = new Size(100, 0);
            lblPublishedValue.AutoSize = true;
            lblPublishedValue.Font = new Font("Arial", 12);
            lblPublishedValue.Location = new Point(160, 870);
            singleIdeaPanel.Controls.Add(lblPublishedValue);

            Label lblExpires = new Label();
            lblExpires.Text = "Expiry Date: ";
            lblExpires.MaximumSize = new Size(100, 0);
            lblExpires.AutoSize = true;
            lblExpires.Font = new Font("Arial", 12);
            lblExpires.Location = new Point(50, 950);
            singleIdeaPanel.Controls.Add(lblExpires);

            Label lblExpriesValue = new Label();
            lblExpriesValue.Text = "00/00/0000";
            lblExpriesValue.MaximumSize = new Size(100, 0);
            lblExpriesValue.AutoSize = true;
            lblExpriesValue.Font = new Font("Arial", 12);
            lblExpriesValue.Location = new Point(160, 950);
            singleIdeaPanel.Controls.Add(lblExpriesValue);

            Label lblAuthor = new Label();
            lblAuthor.Text = "Author: ";
            lblAuthor.MaximumSize = new Size(100, 0);
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Arial", 12);
            lblAuthor.Location = new Point(50, 1030);
            singleIdeaPanel.Controls.Add(lblAuthor);

            Label lblAuthorValue = new Label();
            lblAuthorValue.Text = "John Cena: Bing Chilling";
            lblAuthorValue.MaximumSize = new Size(300, 0);
            lblAuthorValue.AutoSize = true;
            lblAuthorValue.Font = new Font("Arial", 12);
            lblAuthorValue.Location = new Point(130, 1030);
            singleIdeaPanel.Controls.Add(lblAuthorValue);

            viewIdeasPanel.Controls.Add(singleIdeaPanel);


            Padding paddingBot = new Padding();
            paddingBot.Bottom = 30;

            Panel clientsListPanel = new Panel();
            clientsListPanel.Location = new Point(100, 1350);
            clientsListPanel.Size = new Size(600, 400);
            //clientsListPanel.BackColor = Color.FromArgb(54, 70, 82);
            clientsListPanel.ForeColor = Color.White;

            Label lblClientsRM = new Label();
            lblClientsRM.Text = "Clients";
            lblClientsRM.Font = new Font("Arial", 15);
            lblClientsRM.Location = new Point(0, 30);
            lblClientsRM.ForeColor = Color.White;
            lblClientsRM.Width = 600;
            lblClientsRM.Height = 60;
            clientsListPanel.Controls.Add(lblClientsRM);

            ListBox listboxClientsRM = new ListBox();
            listboxClientsRM.Location = new Point(0, 50);
            listboxClientsRM.Size = new Size(470, 200);

            clientsListPanel.Controls.Add(listboxClientsRM);
            viewIdeasPanel.Controls.Add(clientsListPanel);
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

            clients = con.getDataSet("Select Name from User WHERE UserType='1'");
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

            ideas = con.getDataSet("Select Title from InvestmentIdea");
            List<String> ideaOverviews = ideas.Tables[0].AsEnumerable().Select(r => r.Field<String>("Title")).ToList();
            foreach (String ideaOverview in ideaOverviews)
            {
                listboxIdeas.Items.Add(ideaOverview);
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

            txtName = new TextBox();
            txtName.Text = "Name";
            txtName.Location = new Point(200, 270);
            txtName.Size = new Size(400, 40);
            memtxtUsername = txtName;
            createUserPanel.Controls.Add(txtName);

            txtUsername = new TextBox();
            txtUsername.Text = "Username";
            txtUsername.Location = new Point(200, 300);
            txtUsername.Size = new Size(400, 40);
            memtxtUsername = txtUsername;
            createUserPanel.Controls.Add(txtUsername);

            txtPass1 = new TextBox();
            txtPass1.Text = "Password";
            txtPass1.Location = new Point(200, 330);
            txtPass1.Size = new Size(400, 40);
            createUserPanel.Controls.Add(txtPass1);

            txtPass2 = new TextBox();
            txtPass2.Text = "Confirm password";
            txtPass2.Location = new Point(200, 360);
            txtPass2.Size = new Size(400, 40);
            createUserPanel.Controls.Add(txtPass2);

            btnCreateAccount = new Button();
            btnCreateAccount.Text = "Create account";
            btnCreateAccount.BackColor = Color.FromArgb(52, 70, 82);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Size = new Size(100, 40);
            btnCreateAccount.Location = new Point(350, 390);
            createUserPanel.Controls.Add(btnCreateAccount);

            checkShowPass = new CheckBox();
            checkShowPass.Checked = true;
            checkShowPass.Size = new Size(15, 15);
            checkShowPass.Location = new Point(200, 395);
            createUserPanel.Controls.Add(checkShowPass);

            Label lblShowPass = new Label();
            lblShowPass.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            lblShowPass.Text = "Show password";
            lblShowPass.Size = new Size(200, 40);
            lblShowPass.ForeColor = Color.White;
            lblShowPass.Location = new Point(215, 395);
            createUserPanel.Controls.Add(lblShowPass);
            //End create user

            addButtonEventHandlers(currentUser);

            form.Controls.Add(viewIdeasPanel);
            form.Controls.Add(viewClientPanel);
            form.Controls.Add(createUserPanel);
        }

        public void addFAPanels(Form form)
        {
            stylePanel(createIdeaPanel);

            Label lblCreateIdea = new Label();
            lblCreateIdea.Text = "Filters";
            lblCreateIdea.Font = new Font("Arial", 15, FontStyle.Bold);
            lblCreateIdea.Location = new Point(100, 40);
            lblCreateIdea.ForeColor = Color.White;
            lblCreateIdea.Width = 600;
            lblCreateIdea.Height = 25;
            createIdeaPanel.Controls.Add(lblCreateIdea);

            Label lblIndSectorMaj = new Label();
            lblIndSectorMaj.Text = "Industry Sector - Major";
            lblIndSectorMaj.Font = new Font("Arial", 15);
            lblIndSectorMaj.Location = new Point(100, 65);
            lblIndSectorMaj.ForeColor = Color.White;
            lblIndSectorMaj.Width = 600;
            lblIndSectorMaj.Height = 25;
            createIdeaPanel.Controls.Add(lblIndSectorMaj);

            lbMajorSector = new ListBox();
            lbMajorSector.Location = new Point(100, 100);
            lbMajorSector.Size = new Size(350, 80);
            createIdeaPanel.Controls.Add(lbMajorSector);

            cbMajorSector = new ComboBox();
            cbMajorSector.Location = new Point(470, 100);
            cbMajorSector.Font = new Font("Arial", 14);
            cbMajorSector.Size = new Size(230, 30);
            createIdeaPanel.Controls.Add(cbMajorSector);

            btnAddMajorSector = new Button();
            btnAddMajorSector.Text = "Add";
            btnAddMajorSector.BackColor = Color.FromArgb(52, 70, 82);
            btnAddMajorSector.ForeColor = Color.White;
            btnAddMajorSector.Size = new Size(110, 40);
            btnAddMajorSector.Location = new Point(470, 135);
            createIdeaPanel.Controls.Add(btnAddMajorSector);

            btnRemoveMajorSector = new Button();
            btnRemoveMajorSector.Text = "Remove";
            btnRemoveMajorSector.BackColor = Color.FromArgb(52, 70, 82);
            btnRemoveMajorSector.ForeColor = Color.White;
            btnRemoveMajorSector.Size = new Size(110, 40);
            btnRemoveMajorSector.Location = new Point(590, 135);
            createIdeaPanel.Controls.Add(btnRemoveMajorSector);

            Label lblMinorSector = new Label();
            lblMinorSector.Location = new Point(100, 180);
            lblMinorSector.Text = "Industry Sector - Minor";
            lblMinorSector.ForeColor = Color.White;
            lblMinorSector.Font = new Font("Arial", 15);
            lblMinorSector.Width = 600;
            lblMinorSector.Height = 25;
            createIdeaPanel.Controls.Add(lblMinorSector);

            lbMinorSector = new ListBox();
            lbMinorSector.Location = new Point(100, 215);
            lbMinorSector.Size = new Size(350, 80);
            createIdeaPanel.Controls.Add(lbMinorSector);

            cbMinorSector = new ComboBox();
            cbMinorSector.Location = new Point(470, 215);
            cbMinorSector.Font = new Font("Arial", 14);
            cbMinorSector.Size = new Size(230, 30);
            createIdeaPanel.Controls.Add(cbMinorSector);

            btnAddMinorSector = new Button();
            btnAddMinorSector.Text = "Add";
            btnAddMinorSector.BackColor = Color.FromArgb(52, 70, 82);
            btnAddMinorSector.ForeColor = Color.White;
            btnAddMinorSector.Size = new Size(110, 40);
            btnAddMinorSector.Location = new Point(470, 250);
            createIdeaPanel.Controls.Add(btnAddMinorSector);

            btnRemoveMinorSector = new Button();
            btnRemoveMinorSector.Text = "Remove";
            btnRemoveMinorSector.BackColor = Color.FromArgb(52, 70, 82);
            btnRemoveMinorSector.ForeColor = Color.White;
            btnRemoveMinorSector.Size = new Size(110, 40);
            btnRemoveMinorSector.Location = new Point(590, 250);
            createIdeaPanel.Controls.Add(btnRemoveMinorSector);

            Label lblCurrency = new Label();
            lblCurrency.Location = new Point(100, 300);
            lblCurrency.Text = "Currency";
            lblCurrency.ForeColor = Color.White;
            lblCurrency.Font = new Font("Arial", 15);
            lblCurrency.Width = 600;
            lblCurrency.Height = 25;
            createIdeaPanel.Controls.Add(lblCurrency);

            lbCurrency = new ListBox();
            lbCurrency.Location = new Point(100, 330);
            lbCurrency.Size = new Size(350, 80);
            createIdeaPanel.Controls.Add(lbCurrency);

            cbCurrency = new ComboBox();
            cbCurrency.Location = new Point(470, 330);
            cbCurrency.Font = new Font("Arial", 14);
            cbCurrency.Size = new Size(230, 30);
            createIdeaPanel.Controls.Add(cbCurrency);

            btnAddCurrency = new Button();
            btnAddCurrency.Text = "Add";
            btnAddCurrency.BackColor = Color.FromArgb(52, 70, 82);
            btnAddCurrency.ForeColor = Color.White;
            btnAddCurrency.Size = new Size(110, 40);
            btnAddCurrency.Location = new Point(470, 365);
            createIdeaPanel.Controls.Add(btnAddCurrency);

            btnRemoveMinorSector = new Button();
            btnRemoveMinorSector.Text = "Remove";
            btnRemoveMinorSector.BackColor = Color.FromArgb(52, 70, 82);
            btnRemoveMinorSector.ForeColor = Color.White;
            btnRemoveMinorSector.Size = new Size(110, 40);
            btnRemoveMinorSector.Location = new Point(590, 365);
            createIdeaPanel.Controls.Add(btnRemoveMinorSector);
            
            Label lblProducts = new Label();
            lblProducts.Location = new Point(100, 415);
            lblProducts.Text = "Products";
            lblProducts.ForeColor = Color.White;
            lblProducts.Font = new Font("Arial", 15);
            lblProducts.Width = 600;
            lblProducts.Height = 25;
            createIdeaPanel.Controls.Add(lblProducts);

            lbProducts = new ListBox();
            lbProducts.Location = new Point(100, 445);
            lbProducts.Size = new Size(350, 80);
            createIdeaPanel.Controls.Add(lbProducts);

            cbProducts = new ComboBox();
            cbProducts.Location = new Point(470, 445);
            cbProducts.Font = new Font("Arial", 14);
            cbProducts.Size = new Size(230, 30);
            createIdeaPanel.Controls.Add(cbProducts);

            btnAddProducts = new Button();
            btnAddProducts.Text = "Add";
            btnAddProducts.BackColor = Color.FromArgb(52, 70, 82);
            btnAddProducts.ForeColor = Color.White;
            btnAddProducts.Size = new Size(110, 40);
            btnAddProducts.Location = new Point(470, 480);
            createIdeaPanel.Controls.Add(btnAddProducts);

            btnRemoveProducts = new Button();
            btnRemoveProducts.Text = "Remove";
            btnRemoveProducts.BackColor = Color.FromArgb(52, 70, 82);
            btnRemoveProducts.ForeColor = Color.White;
            btnRemoveProducts.Size = new Size(110, 40);
            btnRemoveProducts.Location = new Point(590, 480);
            createIdeaPanel.Controls.Add(btnRemoveProducts);

            Label lblIdeaTitle = new Label();
            lblIdeaTitle.Location = new Point(225, 530);
            lblIdeaTitle.Text = "Idea Title";
            lblIdeaTitle.ForeColor = Color.White;
            lblIdeaTitle.Font = new Font("Arial", 15, FontStyle.Bold);
            lblIdeaTitle.Width = 600;
            lblIdeaTitle.Height = 25;
            createIdeaPanel.Controls.Add(lblIdeaTitle);

            txtIdeaTitle = new TextBox();
            txtIdeaTitle.Location = new Point(225, 560);
            txtIdeaTitle.Font = new Font("Arial", 14);
            txtIdeaTitle.Size = new Size(350, 20);
            createIdeaPanel.Controls.Add(txtIdeaTitle);

            Label lblIdeaOverview = new Label();
            lblIdeaOverview.Location = new Point(225, 590);
            lblIdeaOverview.Text = "Idea Overview";
            lblIdeaOverview.ForeColor = Color.White;
            lblIdeaOverview.Font = new Font("Arial", 15, FontStyle.Bold);
            lblIdeaOverview.Width = 300;
            lblIdeaOverview.Height = 25;
            createIdeaPanel.Controls.Add(lblIdeaOverview);

            txtIdeaOverview = new RichTextBox();
            txtIdeaOverview.Size = new Size(350, 300);
            txtIdeaOverview.Location = new Point(225, 620);
            createIdeaPanel.Controls.Add(txtIdeaOverview);

            Label lblSendRM = new Label();
            lblSendRM.Location = new Point(225, 940);
            lblSendRM.Text = "Select RM to manage idea";
            lblSendRM.ForeColor = Color.White;
            lblSendRM.Font = new Font("Arial", 15, FontStyle.Bold);
            lblSendRM.Width = 300;
            lblSendRM.Height = 25;
            createIdeaPanel.Controls.Add(lblSendRM);

            cbRMs = new ComboBox();
            RMs = bml.getRelationshipManagers();
            foreach (User rm in RMs)
            {
                cbRMs.Items.Add(rm.getName());
            }
            cbRMs.Location = new Point(225, 970);
            cbRMs.Size = new Size(350, 30);
            cbRMs.Font = new Font("Arial", 14);
            createIdeaPanel.Controls.Add(cbRMs);

            btnCreateIdea = new Button();
            btnCreateIdea.Text = "Create Idea";
            btnCreateIdea.BackColor = Color.FromArgb(52, 70, 82);
            btnCreateIdea.ForeColor = Color.White;
            btnCreateIdea.Size = new Size(350, 40);
            btnCreateIdea.Location = new Point(225, 1010);
            createIdeaPanel.Controls.Add(btnCreateIdea);

            updateCBIndustryMajor();
            addButtonEventHandlers(currentUser);
            form.Controls.Add(createIdeaPanel);
        }

        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "Username" && txtUsername != null && txtPass1.Text == txtPass2.Text)
            {
                BusinessMetaLayer bl = BusinessMetaLayer.instance();
                bl.insertUserData(txtName.Text, (cmbAccType.SelectedIndex + 1), txtUsername.Text, txtPass1.Text);
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
                    createIdea.Click += CreateIdea_Click;
                    btnAddMajorSector.Click += btnAddMajorSector_Click;
                    btnAddMinorSector.Click += btnAddMinorSector_Click;
                    btnAddCurrency.Click += btnAddCurrency_Click;
                    btnAddProducts.Click += btnAddProducts_Click;
                    btnCreateIdea.Click += btnCreateIdea_Click;
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

        private void CreateIdea_Click(object sender, EventArgs e)
        {
            createIdeaPanel.BringToFront();
        }

        private void ViewClient_Click(object sender, EventArgs e)
        {
            viewClientPanel.BringToFront();
        }

        private void ViewIdeas_Click(object sender, EventArgs e)
        {
            viewIdeasPanel.BringToFront();
        }

        private void btnAddMajorSector_Click(object sender, EventArgs e)
        {
            if (cbMajorSector.SelectedItem != null)
            {
                if (!lbMajorSector.Items.Contains(cbMajorSector.SelectedItem))
                {
                    lbMajorSector.Items.Add(cbMajorSector.SelectedItem);
                }
                updateCBIndustryMinor();
            }
        }

        private void btnAddMinorSector_Click(object sender, EventArgs e)
        {
            if (cbMinorSector.SelectedItem != null)
            {
                if (!lbMinorSector.Items.Contains(cbMinorSector.SelectedItem))
                {
                    lbMinorSector.Items.Add(cbMinorSector.SelectedItem);
                }
                updateCBCurrency();
            }
        }

        private void btnAddCurrency_Click(object sender, EventArgs e)
        {
            if (cbCurrency.SelectedItem != null)
            {
                if (!lbCurrency.Items.Contains(cbCurrency.SelectedItem))
                {
                    lbCurrency.Items.Add(cbCurrency.SelectedItem);
                }
                updateCBProducts();
            }
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            if (cbProducts.SelectedItem != null)
            {
                if (!lbProducts.Items.Contains(cbProducts.SelectedItem))
                {
                    lbProducts.Items.Add(cbProducts.SelectedItem);
                }
            }
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

        private void btnCreateIdea_Click(object sender, EventArgs e)
        {
            String publishDate = DateTime.Today.ToString("dd/MM/yyyy");
            String expiryDate = DateTime.Today.AddDays(90).ToString("dd/MM/yyyy");
            BusinessMetaLayer bml = BusinessMetaLayer.instance();

            BusinessMetaLayer bl = BusinessMetaLayer.instance();
            bl.insertIdeaData(txtIdeaTitle.Text, txtIdeaOverview.Text, publishDate, expiryDate, currentUser.getName(), bml.getUserID(RMs[cbRMs.SelectedIndex]) ,bml.getUserID(currentUser));
            
            foreach (InvestmentProduct product in products)
            {
                if (lbProducts.Items.Contains(product.getInstrumentName()))
                {
                    bml.insertProductIdeaLink(bml.getIdeaID(txtIdeaTitle.Text), bml.getProductID(product));
                }
            }

            MessageBox.Show("Idea uploaded to the database.");
            cbCurrency.Items.Clear();
            cbCurrency.Text = "";
            cbMajorSector.Text = "";
            cbMinorSector.Items.Clear();
            cbMinorSector.Text = "";
            cbProducts.Items.Clear();
            cbProducts.Text = "";
            cbRMs.Text = "";
            txtIdeaOverview.Clear();
            txtIdeaTitle.Clear();
            lbCurrency.Items.Clear();
            lbMajorSector.Items.Clear();
            lbMinorSector.Items.Clear();
            lbProducts.Items.Clear();
        }

        public void updateCBIndustryMajor()
        {
            foreach (InvestmentProduct product in products)
            {
                if (!cbMajorSector.Items.Contains(product.getSectorL1()))
                {
                    cbMajorSector.Items.Add(product.getSectorL1());
                }
            }
        }

        public void updateCBIndustryMinor()
        {
            foreach(String sector in lbMajorSector.Items)
            {
                if (lbMajorSector.Items.Contains(sector))
                {
                    foreach(InvestmentProduct product in products)
                    {
                        if (product.getSectorL1().Equals(sector))
                        {
                            if (!cbMinorSector.Items.Contains(product.getSectorL2()))
                            {
                                cbMinorSector.Items.Add(product.getSectorL2());
                            }
                        }
                    }
                }
            }
        }

        public void updateCBCurrency()
        {
            foreach (String minorSector in lbMinorSector.Items)
            {
                if (lbMinorSector.Items.Contains(minorSector))
                {
                    foreach (InvestmentProduct product in products)
                    {
                        if (product.getSectorL2().Equals(minorSector))
                        {
                            if (!cbCurrency.Items.Contains(product.getCurrency()))
                            {
                                cbCurrency.Items.Add(product.getCurrency());
                            }
                        }
                    }
                }
            }
        }

        public void updateCBProducts()
        {
            foreach (InvestmentProduct product in products)
            {
                if (lbCurrency.Items.Contains(product.getCurrency()) && lbMinorSector.Items.Contains(product.getSectorL2()) && lbCurrency.Items.Contains(product.getCurrency()))
                {
                    if (!cbProducts.Items.Contains(product.getInstrumentName()))
                    {
                        cbProducts.Items.Add(product.getInstrumentName());
                    }
                }
            }
        }
    }
}
