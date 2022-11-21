namespace InvestmentIdeasPlatform
{
    partial class Login
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
            this.loginLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.requestLoginLinkLabel = new System.Windows.Forms.LinkLabel();
            this.loginButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.minimiseButton = new System.Windows.Forms.Button();
            this.loginPictureBox = new System.Windows.Forms.PictureBox();
            this.continueGuestButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loginPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(198)))));
            this.loginLabel.Location = new System.Drawing.Point(115, 130);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(94, 33);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Log In";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.usernameTextBox.Location = new System.Drawing.Point(85, 203);
            this.usernameTextBox.MaxLength = 40;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(152, 26);
            this.usernameTextBox.TabIndex = 3;
            this.usernameTextBox.TabStop = false;
            this.usernameTextBox.Text = "Username";
            this.usernameTextBox.Click += new System.EventHandler(this.usernameTextBox_Click);
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.passwordTextBox.Location = new System.Drawing.Point(85, 248);
            this.passwordTextBox.MaxLength = 40;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(152, 26);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.TabStop = false;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.Click += new System.EventHandler(this.passwordTextBox_Click);
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // requestLoginLinkLabel
            // 
            this.requestLoginLinkLabel.AutoSize = true;
            this.requestLoginLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(219)))), ((int)(((byte)(230)))));
            this.requestLoginLinkLabel.Location = new System.Drawing.Point(82, 292);
            this.requestLoginLinkLabel.Name = "requestLoginLinkLabel";
            this.requestLoginLinkLabel.Size = new System.Drawing.Size(162, 13);
            this.requestLoginLinkLabel.TabIndex = 8;
            this.requestLoginLinkLabel.TabStop = true;
            this.requestLoginLinkLabel.Text = "New User? Request An Account";
            // 
            // loginButton
            // 
            this.loginButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(198)))));
            this.loginButton.Location = new System.Drawing.Point(233, 360);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 25);
            this.loginButton.TabIndex = 9;
            this.loginButton.Text = "Log In";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = global::InvestmentIdeasPlatform.Properties.Resources.exitIconWhite2;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exitButton.Location = new System.Drawing.Point(275, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(45, 30);
            this.exitButton.TabIndex = 11;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // minimiseButton
            // 
            this.minimiseButton.BackgroundImage = global::InvestmentIdeasPlatform.Properties.Resources.minimiseIconWhite;
            this.minimiseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.minimiseButton.FlatAppearance.BorderSize = 0;
            this.minimiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimiseButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimiseButton.Location = new System.Drawing.Point(230, 0);
            this.minimiseButton.Name = "minimiseButton";
            this.minimiseButton.Size = new System.Drawing.Size(45, 30);
            this.minimiseButton.TabIndex = 10;
            this.minimiseButton.UseVisualStyleBackColor = true;
            this.minimiseButton.Click += new System.EventHandler(this.minimiseButton_Click);
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
            this.loginPictureBox.TabIndex = 1;
            this.loginPictureBox.TabStop = false;
            // 
            // continueGuestButton
            // 
            this.continueGuestButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.continueGuestButton.FlatAppearance.BorderSize = 0;
            this.continueGuestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueGuestButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueGuestButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(198)))));
            this.continueGuestButton.Location = new System.Drawing.Point(12, 360);
            this.continueGuestButton.Name = "continueGuestButton";
            this.continueGuestButton.Size = new System.Drawing.Size(129, 25);
            this.continueGuestButton.TabIndex = 12;
            this.continueGuestButton.Text = "Continue as Guest";
            this.continueGuestButton.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(70)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(320, 397);
            this.Controls.Add(this.continueGuestButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.minimiseButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.requestLoginLinkLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.loginPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.loginPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox loginPictureBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.LinkLabel requestLoginLinkLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button minimiseButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button continueGuestButton;
    }
}