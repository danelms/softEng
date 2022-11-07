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
            this.homeSidebarButton = new System.Windows.Forms.Button();
            this.loginSidebarButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.loginSidebarPicturebox = new System.Windows.Forms.PictureBox();
            this.minimiseButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginSidebarPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sidebarPanel.Controls.Add(this.homeSidebarButton);
            this.sidebarPanel.Controls.Add(this.loginSidebarButton);
            this.sidebarPanel.Controls.Add(this.usernameLabel);
            this.sidebarPanel.Controls.Add(this.loginSidebarPicturebox);
            this.sidebarPanel.Location = new System.Drawing.Point(0, 30);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(220, 550);
            this.sidebarPanel.TabIndex = 0;
            // 
            // homeSidebarButton
            // 
            this.homeSidebarButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.homeSidebarButton.FlatAppearance.BorderSize = 0;
            this.homeSidebarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeSidebarButton.Font = new System.Drawing.Font("Arial", 14F);
            this.homeSidebarButton.Location = new System.Drawing.Point(0, 158);
            this.homeSidebarButton.Name = "homeSidebarButton";
            this.homeSidebarButton.Size = new System.Drawing.Size(220, 34);
            this.homeSidebarButton.TabIndex = 6;
            this.homeSidebarButton.Text = "Home";
            this.homeSidebarButton.UseVisualStyleBackColor = true;
            this.homeSidebarButton.Click += new System.EventHandler(this.homeSidebarButton_Click);
            // 
            // loginSidebarButton
            // 
            this.loginSidebarButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loginSidebarButton.FlatAppearance.BorderSize = 0;
            this.loginSidebarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginSidebarButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginSidebarButton.Location = new System.Drawing.Point(0, 516);
            this.loginSidebarButton.Name = "loginSidebarButton";
            this.loginSidebarButton.Size = new System.Drawing.Size(220, 34);
            this.loginSidebarButton.TabIndex = 5;
            this.loginSidebarButton.Text = "Log In";
            this.loginSidebarButton.UseVisualStyleBackColor = true;
            this.loginSidebarButton.Click += new System.EventHandler(this.loginSidebarButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(198)))));
            this.usernameLabel.Location = new System.Drawing.Point(0, 113);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(220, 33);
            this.usernameLabel.TabIndex = 4;
            this.usernameLabel.Text = "Guest";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginSidebarPicturebox
            // 
            this.loginSidebarPicturebox.BackgroundImage = global::InvestmentIdeasPlatform.Properties.Resources.userIcon;
            this.loginSidebarPicturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loginSidebarPicturebox.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginSidebarPicturebox.InitialImage = null;
            this.loginSidebarPicturebox.Location = new System.Drawing.Point(0, 0);
            this.loginSidebarPicturebox.Name = "loginSidebarPicturebox";
            this.loginSidebarPicturebox.Size = new System.Drawing.Size(220, 158);
            this.loginSidebarPicturebox.TabIndex = 4;
            this.loginSidebarPicturebox.TabStop = false;
            // 
            // minimiseButton
            // 
            this.minimiseButton.BackgroundImage = global::InvestmentIdeasPlatform.Properties.Resources.minimiseIconWhite;
            this.minimiseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.minimiseButton.FlatAppearance.BorderSize = 0;
            this.minimiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimiseButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimiseButton.Location = new System.Drawing.Point(930, 0);
            this.minimiseButton.Name = "minimiseButton";
            this.minimiseButton.Size = new System.Drawing.Size(45, 30);
            this.minimiseButton.TabIndex = 2;
            this.minimiseButton.UseVisualStyleBackColor = true;
            this.minimiseButton.Click += new System.EventHandler(this.minimiseButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = global::InvestmentIdeasPlatform.Properties.Resources.exitIconWhite2;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exitButton.Location = new System.Drawing.Point(975, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(45, 30);
            this.exitButton.TabIndex = 1;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(70)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1020, 580);
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
            ((System.ComponentModel.ISupportInitialize)(this.loginSidebarPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button minimiseButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.PictureBox loginSidebarPicturebox;
        private System.Windows.Forms.Button loginSidebarButton;
        private System.Windows.Forms.Button homeSidebarButton;
        private System.Windows.Forms.Panel sidebarPanel;
    }
}

