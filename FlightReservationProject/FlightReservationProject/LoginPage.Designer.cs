namespace FlightReservationProject
{
    partial class LoginPage
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
            this.lblCreateAcc = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbShowPass = new System.Windows.Forms.CheckBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWrong = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCreateAcc
            // 
            this.lblCreateAcc.AutoSize = true;
            this.lblCreateAcc.BackColor = System.Drawing.Color.White;
            this.lblCreateAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCreateAcc.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblCreateAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(187)))), ((int)(((byte)(184)))));
            this.lblCreateAcc.Location = new System.Drawing.Point(261, 529);
            this.lblCreateAcc.Name = "lblCreateAcc";
            this.lblCreateAcc.Size = new System.Drawing.Size(140, 28);
            this.lblCreateAcc.TabIndex = 5;
            this.lblCreateAcc.Text = "Create account";
            this.lblCreateAcc.Click += new System.EventHandler(this.lblCreateAcc_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(135)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(205, 456);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(243, 44);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.BackColor = System.Drawing.Color.White;
            this.lblGreeting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGreeting.Font = new System.Drawing.Font("Poppins", 19.8F, System.Drawing.FontStyle.Bold);
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(187)))), ((int)(((byte)(184)))));
            this.lblGreeting.Location = new System.Drawing.Point(203, 66);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(262, 70);
            this.lblGreeting.TabIndex = 7;
            this.lblGreeting.Text = "Get Started";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(232, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Don\'t have an account";
            // 
            // cbShowPass
            // 
            this.cbShowPass.AutoSize = true;
            this.cbShowPass.BackColor = System.Drawing.Color.White;
            this.cbShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShowPass.Font = new System.Drawing.Font("Poppins", 7F);
            this.cbShowPass.Location = new System.Drawing.Point(310, 385);
            this.cbShowPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbShowPass.Name = "cbShowPass";
            this.cbShowPass.Size = new System.Drawing.Size(139, 29);
            this.cbShowPass.TabIndex = 3;
            this.cbShowPass.Text = "Show Password";
            this.cbShowPass.UseVisualStyleBackColor = false;
            this.cbShowPass.CheckedChanged += new System.EventHandler(this.cbShowPass_CheckedChanged);
            this.cbShowPass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbShowPass_MouseDown);
            this.cbShowPass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cbShowPass_MouseUp);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.White;
            this.lblPassword.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(201, 310);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(93, 28);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtPassword.Font = new System.Drawing.Font("Poppins", 10F);
            this.txtPassword.Location = new System.Drawing.Point(205, 340);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(242, 37);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtUsername.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(205, 259);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(242, 37);
            this.txtUsername.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.White;
            this.lblEmail.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(201, 230);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(59, 28);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Image = global::FlightReservationProject.Properties.Resources.login_2;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1063, 624);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // lblWrong
            // 
            this.lblWrong.AutoSize = true;
            this.lblWrong.BackColor = System.Drawing.Color.Snow;
            this.lblWrong.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblWrong.ForeColor = System.Drawing.Color.Red;
            this.lblWrong.Location = new System.Drawing.Point(197, 417);
            this.lblWrong.Name = "lblWrong";
            this.lblWrong.Size = new System.Drawing.Size(268, 28);
            this.lblWrong.TabIndex = 11;
            this.lblWrong.Text = "Wrong username or password!";
            this.lblWrong.Visible = false;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtId.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(206, 180);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(242, 37);
            this.txtId.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(202, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID / NIK / SSN";
            // 
            // LoginPage
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 616);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblWrong);
            this.Controls.Add(this.lblCreateAcc);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblGreeting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbShowPass);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreateAcc;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbShowPass;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWrong;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
    }
}