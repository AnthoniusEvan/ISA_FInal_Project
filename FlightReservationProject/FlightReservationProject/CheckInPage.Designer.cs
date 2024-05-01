
namespace FlightReservationProject
{
    partial class CheckInPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startingPanel = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnToCheckin = new System.Windows.Forms.Button();
            this.txtTicketNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.pnlCheckin = new System.Windows.Forms.Panel();
            this.lblClass = new System.Windows.Forms.Label();
            this.pnlPassengers = new System.Windows.Forms.Panel();
            this.line = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCheckInStatus = new System.Windows.Forms.Label();
            this.lblPassName = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.pnlTicket = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblAirline = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblFlightNum = new System.Windows.Forms.Label();
            this.lblArriv = new System.Windows.Forms.Label();
            this.lblDepart = new System.Windows.Forms.Label();
            this.pnlPrintBoardingPass = new System.Windows.Forms.Panel();
            this.pnlCheckedIns = new System.Windows.Forms.Panel();
            this.pnlCheckedIn = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.startingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnlCheckin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line)).BeginInit();
            this.pnlTicket.SuspendLayout();
            this.pnlPrintBoardingPass.SuspendLayout();
            this.pnlCheckedIns.SuspendLayout();
            this.pnlCheckedIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 44);
            this.panel1.TabIndex = 52;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FlightReservationProject.Properties.Resources.Asset_4;
            this.pictureBox1.Location = new System.Drawing.Point(20, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            this.label1.Location = new System.Drawing.Point(427, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Check In";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(150, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(300, 15);
            this.label8.TabIndex = 84;
            this.label8.Text = "Start Check-in with your full name and e-ticket number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 86;
            this.label2.Text = "Full Name";
            // 
            // startingPanel
            // 
            this.startingPanel.BackColor = System.Drawing.Color.White;
            this.startingPanel.Controls.Add(this.pictureBox4);
            this.startingPanel.Controls.Add(this.btnToCheckin);
            this.startingPanel.Controls.Add(this.label8);
            this.startingPanel.Controls.Add(this.txtTicketNum);
            this.startingPanel.Controls.Add(this.label3);
            this.startingPanel.Controls.Add(this.txtFullname);
            this.startingPanel.Controls.Add(this.label2);
            this.startingPanel.Location = new System.Drawing.Point(82, 90);
            this.startingPanel.Name = "startingPanel";
            this.startingPanel.Size = new System.Drawing.Size(781, 327);
            this.startingPanel.TabIndex = 87;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::FlightReservationProject.Properties.Resources.Asset_20;
            this.pictureBox4.Location = new System.Drawing.Point(153, 82);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(427, 2);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 153;
            this.pictureBox4.TabStop = false;
            // 
            // btnToCheckin
            // 
            this.btnToCheckin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            this.btnToCheckin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToCheckin.ForeColor = System.Drawing.Color.White;
            this.btnToCheckin.Location = new System.Drawing.Point(375, 228);
            this.btnToCheckin.Name = "btnToCheckin";
            this.btnToCheckin.Size = new System.Drawing.Size(262, 43);
            this.btnToCheckin.TabIndex = 152;
            this.btnToCheckin.Text = "Continue";
            this.btnToCheckin.UseVisualStyleBackColor = false;
            this.btnToCheckin.Click += new System.EventHandler(this.btnToCheckin_Click);
            // 
            // txtTicketNum
            // 
            this.txtTicketNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtTicketNum.Font = new System.Drawing.Font("Poppins", 10F);
            this.txtTicketNum.Location = new System.Drawing.Point(300, 173);
            this.txtTicketNum.Name = "txtTicketNum";
            this.txtTicketNum.Size = new System.Drawing.Size(337, 32);
            this.txtTicketNum.TabIndex = 151;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 150;
            this.label3.Text = "E-ticket number";
            // 
            // txtFullname
            // 
            this.txtFullname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtFullname.Font = new System.Drawing.Font("Poppins", 10F);
            this.txtFullname.Location = new System.Drawing.Point(300, 124);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(337, 32);
            this.txtFullname.TabIndex = 149;
            // 
            // pnlCheckin
            // 
            this.pnlCheckin.BackColor = System.Drawing.Color.White;
            this.pnlCheckin.Controls.Add(this.lblClass);
            this.pnlCheckin.Controls.Add(this.pnlPassengers);
            this.pnlCheckin.Controls.Add(this.line);
            this.pnlCheckin.Controls.Add(this.lblInfo);
            this.pnlCheckin.Controls.Add(this.label13);
            this.pnlCheckin.Controls.Add(this.lblCheckInStatus);
            this.pnlCheckin.Controls.Add(this.lblPassName);
            this.pnlCheckin.Controls.Add(this.btnConfirm);
            this.pnlCheckin.Controls.Add(this.pnlTicket);
            this.pnlCheckin.Location = new System.Drawing.Point(82, 90);
            this.pnlCheckin.Name = "pnlCheckin";
            this.pnlCheckin.Size = new System.Drawing.Size(781, 327);
            this.pnlCheckin.TabIndex = 153;
            // 
            // lblClass
            // 
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblClass.Location = new System.Drawing.Point(551, 114);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(209, 18);
            this.lblClass.TabIndex = 155;
            this.lblClass.Text = "Economy";
            this.lblClass.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlPassengers
            // 
            this.pnlPassengers.AutoScroll = true;
            this.pnlPassengers.Location = new System.Drawing.Point(31, 145);
            this.pnlPassengers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPassengers.Name = "pnlPassengers";
            this.pnlPassengers.Size = new System.Drawing.Size(729, 114);
            this.pnlPassengers.TabIndex = 172;
            // 
            // line
            // 
            this.line.Image = global::FlightReservationProject.Properties.Resources.Asset_20;
            this.line.Location = new System.Drawing.Point(31, 49);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(729, 3);
            this.line.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.line.TabIndex = 170;
            this.line.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(28, 30);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(390, 15);
            this.lblInfo.TabIndex = 169;
            this.lblInfo.Text = "Please check and confirm the information about passengers and flight ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(464, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 18);
            this.label13.TabIndex = 166;
            this.label13.Text = "Seat";
            // 
            // lblCheckInStatus
            // 
            this.lblCheckInStatus.AutoSize = true;
            this.lblCheckInStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInStatus.ForeColor = System.Drawing.Color.Black;
            this.lblCheckInStatus.Location = new System.Drawing.Point(239, 116);
            this.lblCheckInStatus.Name = "lblCheckInStatus";
            this.lblCheckInStatus.Size = new System.Drawing.Size(128, 18);
            this.lblCheckInStatus.TabIndex = 164;
            this.lblCheckInStatus.Text = "Check-in Status";
            // 
            // lblPassName
            // 
            this.lblPassName.AutoSize = true;
            this.lblPassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassName.ForeColor = System.Drawing.Color.Black;
            this.lblPassName.Location = new System.Drawing.Point(28, 116);
            this.lblPassName.Name = "lblPassName";
            this.lblPassName.Size = new System.Drawing.Size(137, 18);
            this.lblPassName.TabIndex = 163;
            this.lblPassName.Text = "Passenger Name";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(498, 271);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(262, 43);
            this.btnConfirm.TabIndex = 152;
            this.btnConfirm.Text = "Confirm check-in";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // pnlTicket
            // 
            this.pnlTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(234)))), ((int)(((byte)(251)))));
            this.pnlTicket.Controls.Add(this.label9);
            this.pnlTicket.Controls.Add(this.lblDate);
            this.pnlTicket.Controls.Add(this.lblTo);
            this.pnlTicket.Controls.Add(this.lblAirline);
            this.pnlTicket.Controls.Add(this.lblFrom);
            this.pnlTicket.Controls.Add(this.lblFlightNum);
            this.pnlTicket.Controls.Add(this.lblArriv);
            this.pnlTicket.Controls.Add(this.lblDepart);
            this.pnlTicket.Location = new System.Drawing.Point(31, 58);
            this.pnlTicket.Name = "pnlTicket";
            this.pnlTicket.Size = new System.Drawing.Size(729, 49);
            this.pnlTicket.TabIndex = 162;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(380, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 18);
            this.label9.TabIndex = 163;
            this.label9.Text = "-";
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(487, 17);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(227, 18);
            this.lblDate.TabIndex = 163;
            this.lblDate.Text = "Friday, 12 April 2024";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(408, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(55, 17);
            this.lblTo.TabIndex = 164;
            this.lblTo.Text = "Jakarta";
            // 
            // lblAirline
            // 
            this.lblAirline.AutoSize = true;
            this.lblAirline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirline.Location = new System.Drawing.Point(8, 13);
            this.lblAirline.Name = "lblAirline";
            this.lblAirline.Size = new System.Drawing.Size(77, 25);
            this.lblAirline.TabIndex = 153;
            this.lblAirline.Text = "Garuda";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(294, 6);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(69, 17);
            this.lblFrom.TabIndex = 163;
            this.lblFrom.Text = "Surabaya";
            // 
            // lblFlightNum
            // 
            this.lblFlightNum.AutoSize = true;
            this.lblFlightNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightNum.Location = new System.Drawing.Point(148, 16);
            this.lblFlightNum.Name = "lblFlightNum";
            this.lblFlightNum.Size = new System.Drawing.Size(61, 20);
            this.lblFlightNum.TabIndex = 154;
            this.lblFlightNum.Text = "JT-201";
            // 
            // lblArriv
            // 
            this.lblArriv.AutoSize = true;
            this.lblArriv.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArriv.Location = new System.Drawing.Point(409, 24);
            this.lblArriv.Name = "lblArriv";
            this.lblArriv.Size = new System.Drawing.Size(43, 15);
            this.lblArriv.TabIndex = 158;
            this.lblArriv.Text = "15:15";
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepart.Location = new System.Drawing.Point(295, 25);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(43, 15);
            this.lblDepart.TabIndex = 157;
            this.lblDepart.Text = "12:50";
            // 
            // pnlPrintBoardingPass
            // 
            this.pnlPrintBoardingPass.BackColor = System.Drawing.Color.White;
            this.pnlPrintBoardingPass.Controls.Add(this.pnlCheckedIns);
            this.pnlPrintBoardingPass.Controls.Add(this.label4);
            this.pnlPrintBoardingPass.Controls.Add(this.lblBack);
            this.pnlPrintBoardingPass.Location = new System.Drawing.Point(82, 90);
            this.pnlPrintBoardingPass.Name = "pnlPrintBoardingPass";
            this.pnlPrintBoardingPass.Size = new System.Drawing.Size(781, 327);
            this.pnlPrintBoardingPass.TabIndex = 171;
            // 
            // pnlCheckedIns
            // 
            this.pnlCheckedIns.AutoScroll = true;
            this.pnlCheckedIns.Controls.Add(this.pnlCheckedIn);
            this.pnlCheckedIns.Location = new System.Drawing.Point(32, 136);
            this.pnlCheckedIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCheckedIns.Name = "pnlCheckedIns";
            this.pnlCheckedIns.Size = new System.Drawing.Size(728, 135);
            this.pnlCheckedIns.TabIndex = 176;
            // 
            // pnlCheckedIn
            // 
            this.pnlCheckedIn.Controls.Add(this.btnPrint);
            this.pnlCheckedIn.Controls.Add(this.lblName);
            this.pnlCheckedIn.Controls.Add(this.lblStatus);
            this.pnlCheckedIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCheckedIn.Location = new System.Drawing.Point(0, 0);
            this.pnlCheckedIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCheckedIn.Name = "pnlCheckedIn";
            this.pnlCheckedIn.Size = new System.Drawing.Size(728, 32);
            this.pnlCheckedIn.TabIndex = 177;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(631, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 23);
            this.btnPrint.TabIndex = 152;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblName.Location = new System.Drawing.Point(0, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 18);
            this.lblName.TabIndex = 165;
            this.lblName.Text = "Anthonious";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblStatus.Location = new System.Drawing.Point(207, 7);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 18);
            this.lblStatus.TabIndex = 167;
            this.lblStatus.Text = "Checked In";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(28, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 18);
            this.label4.TabIndex = 175;
            this.label4.Text = "Passenger Name";
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            this.lblBack.Location = new System.Drawing.Point(28, 285);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(57, 17);
            this.lblBack.TabIndex = 174;
            this.lblBack.Text = "< Back";
            this.lblBack.Click += new System.EventHandler(this.lblBack_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::FlightReservationProject.Properties.Resources.Asset_29;
            this.pictureBox5.Location = new System.Drawing.Point(0, 43);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(949, 465);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 172;
            this.pictureBox5.TabStop = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // CheckInPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 493);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.startingPanel);
            this.Controls.Add(this.pnlCheckin);
            this.Controls.Add(this.pnlPrintBoardingPass);
            this.Controls.Add(this.pictureBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CheckInPage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CheckInPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.startingPanel.ResumeLayout(false);
            this.startingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnlCheckin.ResumeLayout(false);
            this.pnlCheckin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line)).EndInit();
            this.pnlTicket.ResumeLayout(false);
            this.pnlTicket.PerformLayout();
            this.pnlPrintBoardingPass.ResumeLayout(false);
            this.pnlPrintBoardingPass.PerformLayout();
            this.pnlCheckedIns.ResumeLayout(false);
            this.pnlCheckedIn.ResumeLayout(false);
            this.pnlCheckedIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel startingPanel;
        private System.Windows.Forms.Button btnToCheckin;
        private System.Windows.Forms.TextBox txtTicketNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Panel pnlCheckin;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblArriv;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblFlightNum;
        private System.Windows.Forms.Label lblAirline;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCheckInStatus;
        private System.Windows.Forms.Label lblPassName;
        private System.Windows.Forms.Panel pnlTicket;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.PictureBox line;
        private System.Windows.Forms.Panel pnlPrintBoardingPass;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel pnlPassengers;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.Panel pnlCheckedIns;
        private System.Windows.Forms.Panel pnlCheckedIn;
        private System.Windows.Forms.Label label4;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}