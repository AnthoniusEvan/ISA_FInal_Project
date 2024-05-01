
namespace FlightReservationProject
{
    partial class ConfirmarionPage
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEticket = new FlightReservationProject.CustomBtn();
            this.backHome = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::FlightReservationProject.Properties.Resources.Asset_34;
            this.pictureBox1.Location = new System.Drawing.Point(140, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Poppins Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(81, 57);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(219, 30);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Reservation Sucessful";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.backHome);
            this.panel1.Controls.Add(this.btnEticket);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Location = new System.Drawing.Point(4, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 256);
            this.panel1.TabIndex = 2;
            // 
            // btnEticket
            // 
            this.btnEticket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(135)))));
            this.btnEticket.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(135)))));
            this.btnEticket.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEticket.BorderRadius = 0;
            this.btnEticket.BorderSize = 0;
            this.btnEticket.FlatAppearance.BorderSize = 0;
            this.btnEticket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEticket.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEticket.ForeColor = System.Drawing.Color.White;
            this.btnEticket.Location = new System.Drawing.Point(112, 180);
            this.btnEticket.Name = "btnEticket";
            this.btnEticket.Size = new System.Drawing.Size(150, 40);
            this.btnEticket.TabIndex = 1;
            this.btnEticket.Text = "View E-ticket";
            this.btnEticket.TextColor = System.Drawing.Color.White;
            this.btnEticket.UseVisualStyleBackColor = false;
            this.btnEticket.Click += new System.EventHandler(this.btnEticket_Click);
            // 
            // backHome
            // 
            this.backHome.AutoSize = true;
            this.backHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backHome.Location = new System.Drawing.Point(168, 223);
            this.backHome.Name = "backHome";
            this.backHome.Size = new System.Drawing.Size(45, 17);
            this.backHome.TabIndex = 2;
            this.backHome.Text = "Home";
            this.backHome.Click += new System.EventHandler(this.backHome_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.Location = new System.Drawing.Point(31, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(313, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "We are pleased that you have chosen Domain Z";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(106, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "for your flight reservation";
            // 
            // ConfirmarionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 306);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfirmarionPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ConfirmarionPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private CustomBtn btnEticket;
        private System.Windows.Forms.Label backHome;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
    }
}