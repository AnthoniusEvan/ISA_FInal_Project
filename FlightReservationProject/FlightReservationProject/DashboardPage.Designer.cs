namespace FlightReservationProject
{
    partial class DashboardPage
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
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.cbCityDes = new System.Windows.Forms.ComboBox();
            this.cbCityOri = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.flightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFindFlight = new FlightReservationProject.CustomBtn();
            this.customBtn1 = new FlightReservationProject.CustomBtn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pbProfile = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // cbClass
            // 
            this.cbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(450, 311);
            this.cbClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(223, 30);
            this.cbClass.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(446, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 22);
            this.label5.TabIndex = 55;
            this.label5.Text = "Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(166, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 22);
            this.label4.TabIndex = 53;
            this.label4.Text = "Passengers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(676, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 22);
            this.label3.TabIndex = 52;
            this.label3.Text = "Travel Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(446, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 22);
            this.label2.TabIndex = 51;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 22);
            this.label1.TabIndex = 50;
            this.label1.Text = "From";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 311);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 35);
            this.textBox1.TabIndex = 49;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd MMMM yyyy";
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(681, 234);
            this.dtDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(222, 30);
            this.dtDate.TabIndex = 48;
            // 
            // cbCityDes
            // 
            this.cbCityDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCityDes.FormattingEnabled = true;
            this.cbCityDes.Location = new System.Drawing.Point(450, 234);
            this.cbCityDes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCityDes.Name = "cbCityDes";
            this.cbCityDes.Size = new System.Drawing.Size(176, 30);
            this.cbCityDes.TabIndex = 47;
            this.cbCityDes.Text = "Select City";
            // 
            // cbCityOri
            // 
            this.cbCityOri.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCityOri.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCityOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCityOri.FormattingEnabled = true;
            this.cbCityOri.IntegralHeight = false;
            this.cbCityOri.Location = new System.Drawing.Point(171, 234);
            this.cbCityOri.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCityOri.Name = "cbCityOri";
            this.cbCityOri.Size = new System.Drawing.Size(176, 30);
            this.cbCityOri.TabIndex = 46;
            this.cbCityOri.Text = "Select City";
            this.cbCityOri.SelectedIndexChanged += new System.EventHandler(this.cbCityOri_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flightsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.bookinToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1060, 39);
            this.menuStrip1.TabIndex = 44;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // flightsToolStripMenuItem
            // 
            this.flightsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 60, 0);
            this.flightsToolStripMenuItem.Name = "flightsToolStripMenuItem";
            this.flightsToolStripMenuItem.Size = new System.Drawing.Size(87, 35);
            this.flightsToolStripMenuItem.Text = "Flights";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(85, 35);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // bookinToolStripMenuItem
            // 
            this.bookinToolStripMenuItem.Name = "bookinToolStripMenuItem";
            this.bookinToolStripMenuItem.Size = new System.Drawing.Size(102, 35);
            this.bookinToolStripMenuItem.Text = "Booking";
            // 
            // btnFindFlight
            // 
            this.btnFindFlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(135)))));
            this.btnFindFlight.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(135)))));
            this.btnFindFlight.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnFindFlight.BorderRadius = 18;
            this.btnFindFlight.BorderSize = 0;
            this.btnFindFlight.FlatAppearance.BorderSize = 0;
            this.btnFindFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnFindFlight.ForeColor = System.Drawing.Color.White;
            this.btnFindFlight.Location = new System.Drawing.Point(698, 298);
            this.btnFindFlight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindFlight.Name = "btnFindFlight";
            this.btnFindFlight.Size = new System.Drawing.Size(206, 50);
            this.btnFindFlight.TabIndex = 58;
            this.btnFindFlight.Text = "Find me a flight now";
            this.btnFindFlight.TextColor = System.Drawing.Color.White;
            this.btnFindFlight.UseVisualStyleBackColor = false;
            // 
            // customBtn1
            // 
            this.customBtn1.BackColor = System.Drawing.Color.White;
            this.customBtn1.BackgroundColor = System.Drawing.Color.White;
            this.customBtn1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.customBtn1.BorderRadius = 50;
            this.customBtn1.BorderSize = 0;
            this.customBtn1.Enabled = false;
            this.customBtn1.FlatAppearance.BorderSize = 0;
            this.customBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customBtn1.ForeColor = System.Drawing.Color.White;
            this.customBtn1.Location = new System.Drawing.Point(110, 158);
            this.customBtn1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customBtn1.Name = "customBtn1";
            this.customBtn1.Size = new System.Drawing.Size(855, 242);
            this.customBtn1.TabIndex = 59;
            this.customBtn1.Text = "customBtn1";
            this.customBtn1.TextColor = System.Drawing.Color.White;
            this.customBtn1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(135)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Location = new System.Drawing.Point(0, 516);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 108);
            this.panel1.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(135)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(28, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(284, 15);
            this.label6.TabIndex = 62;
            this.label6.Text = "Copyright © 2021 PT Domain z All Rights Reserved";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::FlightReservationProject.Properties.Resources.domain_z;
            this.pictureBox4.Location = new System.Drawing.Point(32, 28);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(156, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.Image = global::FlightReservationProject.Properties.Resources.logo_Z;
            this.pictureBox2.Location = new System.Drawing.Point(18, 8);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::FlightReservationProject.Properties.Resources.icon2;
            this.pictureBox3.Location = new System.Drawing.Point(377, 225);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 54;
            this.pictureBox3.TabStop = false;
            // 
            // pbProfile
            // 
            this.pbProfile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbProfile.Image = global::FlightReservationProject.Properties.Resources.user;
            this.pbProfile.Location = new System.Drawing.Point(1011, 8);
            this.pbProfile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbProfile.Name = "pbProfile";
            this.pbProfile.Size = new System.Drawing.Size(29, 28);
            this.pbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfile.TabIndex = 45;
            this.pbProfile.TabStop = false;
            this.pbProfile.Click += new System.EventHandler(this.pbProfile_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1060, 490);
            this.panel3.TabIndex = 62;
            // 
            // DashboardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 616);
            this.Controls.Add(this.btnFindFlight);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.cbCityDes);
            this.Controls.Add(this.cbCityOri);
            this.Controls.Add(this.pbProfile);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customBtn1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DashboardPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "v";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DashboardPage_FormClosed);
            this.Load += new System.EventHandler(this.DashboardPage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.ComboBox cbCityDes;
        private System.Windows.Forms.ComboBox cbCityOri;
        private System.Windows.Forms.PictureBox pbProfile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem flightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookinToolStripMenuItem;
        private CustomBtn btnFindFlight;
        private CustomBtn customBtn1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
    }
}