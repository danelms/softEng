namespace InvestmentIdeasPlatform
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.loginSidebarPicturebox = new System.Windows.Forms.PictureBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginPictureBox = new System.Windows.Forms.PictureBox();
            this.minimiseButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loginSidebarButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.requestLoginLinkLabel = new System.Windows.Forms.LinkLabel();
            this.sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginSidebarPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(70)))), ((int)(((byte)(82)))));
            this.sidebarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sidebarPanel.Controls.Add(this.loginSidebarButton);
            this.sidebarPanel.Controls.Add(this.usernameLabel);
            this.sidebarPanel.Controls.Add(this.loginSidebarPicturebox);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(225, 580);
            this.sidebarPanel.TabIndex = 0;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(198)))));
            this.usernameLabel.Location = new System.Drawing.Point(65, 115);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(93, 33);
            this.usernameLabel.TabIndex = 4;
            this.usernameLabel.Text = "Guest";
            // 
            // loginSidebarPicturebox
            // 
            this.loginSidebarPicturebox.BackgroundImage = global::InvestmentIdeasPlatform.Properties.Resources.userIcon;
            this.loginSidebarPicturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loginSidebarPicturebox.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginSidebarPicturebox.InitialImage = null;
            this.loginSidebarPicturebox.Location = new System.Drawing.Point(0, 0);
            this.loginSidebarPicturebox.Name = "loginSidebarPicturebox";
            this.loginSidebarPicturebox.Size = new System.Drawing.Size(225, 158);
            this.loginSidebarPicturebox.TabIndex = 4;
            this.loginSidebarPicturebox.TabStop = false;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.passwordTextBox.Location = new System.Drawing.Point(85, 256);
            this.passwordTextBox.MaxLength = 40;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(152, 26);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.TabStop = false;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.Click += new System.EventHandler(this.passwordTextBox_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.usernameTextBox.Location = new System.Drawing.Point(85, 206);
            this.usernameTextBox.MaxLength = 40;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(152, 26);
            this.usernameTextBox.TabIndex = 2;
            this.usernameTextBox.TabStop = false;
            this.usernameTextBox.Text = "Username";
            this.usernameTextBox.Click += new System.EventHandler(this.usernameTextBox_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(198)))));
            this.loginLabel.Location = new System.Drawing.Point(116, 126);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(94, 33);
            this.loginLabel.TabIndex = 1;
            this.loginLabel.Text = "Log In";
            // 
            // loginPictureBox
            // 
            this.loginPictureBox.BackgroundImage = global::InvestmentIdeasPlatform.Properties.Resources.userIcon;
            this.loginPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loginPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginPictureBox.InitialImage = null;
            this.loginPictureBox.Location = new System.Drawing.Point(0, 0);
            this.loginPictureBox.Name = "loginPictureBox";
            this.loginPictureBox.Size = new System.Drawing.Size(320, 174);
            this.loginPictureBox.TabIndex = 0;
            this.loginPictureBox.TabStop = false;
            // 
            // minimiseButton
            // 
            this.minimiseButton.BackgroundImage = global::InvestmentIdeasPlatform.Properties.Resources.minimiseIcon;
            this.minimiseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.minimiseButton.FlatAppearance.BorderSize = 0;
            this.minimiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimiseButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimiseButton.Location = new System.Drawing.Point(928, 0);
            this.minimiseButton.Name = "minimiseButton";
            this.minimiseButton.Size = new System.Drawing.Size(45, 30);
            this.minimiseButton.TabIndex = 2;
            this.minimiseButton.UseVisualStyleBackColor = true;
            this.minimiseButton.Click += new System.EventHandler(this.minimiseButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = global::InvestmentIdeasPlatform.Properties.Resources.exitIcon;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exitButton.Location = new System.Drawing.Point(973, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(45, 30);
            this.exitButton.TabIndex = 1;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(70)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.requestLoginLinkLabel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.loginLabel);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.loginPictureBox);
            this.panel1.Controls.Add(this.usernameTextBox);
            this.panel1.Location = new System.Drawing.Point(472, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 397);
            this.panel1.TabIndex = 4;
            // 
            // loginSidebarButton
            // 
            this.loginSidebarButton.FlatAppearance.BorderSize = 0;
            this.loginSidebarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginSidebarButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginSidebarButton.Location = new System.Drawing.Point(0, 178);
            this.loginSidebarButton.Name = "loginSidebarButton";
            this.loginSidebarButton.Size = new System.Drawing.Size(225, 34);
            this.loginSidebarButton.TabIndex = 5;
            this.loginSidebarButton.Text = "Log In";
            this.loginSidebarButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(230, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "Log In";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // requestLoginLinkLabel
            // 
            this.requestLoginLinkLabel.AutoSize = true;
            this.requestLoginLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(219)))), ((int)(((byte)(230)))));
            this.requestLoginLinkLabel.Location = new System.Drawing.Point(82, 296);
            this.requestLoginLinkLabel.Name = "requestLoginLinkLabel";
            this.requestLoginLinkLabel.Size = new System.Drawing.Size(162, 13);
            this.requestLoginLinkLabel.TabIndex = 7;
            this.requestLoginLinkLabel.TabStop = true;
            this.requestLoginLinkLabel.Text = "New User? Request An Account";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(198)))));
            this.ClientSize = new System.Drawing.Size(1018, 580);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.minimiseButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.sidebarPanel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(198)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.sidebarPanel.ResumeLayout(false);
            this.sidebarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginSidebarPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button minimiseButton;
        private System.Windows.Forms.PictureBox loginPictureBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.PictureBox loginSidebarPicturebox;
        private System.Windows.Forms.Button loginSidebarButton;
        private System.Windows.Forms.LinkLabel requestLoginLinkLabel;
        private System.Windows.Forms.Button button1;
    }
}

