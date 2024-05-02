using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightReservationProject;
namespace FlightReservationProject
{
    public partial class BookingPage : Form
    {
        public BookingPage()
        {
            InitializeComponent();
        }
        List<Reservation> reservations;
        private void btnEticket_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Reservation reservation=new Reservation();
            foreach(Reservation r in reservations)
            {
                if (b.Tag.ToString() == r.Id.ToString()) reservation = r;
            }
            PrintETicket p = new PrintETicket(reservation);
            p.Owner = this;
            p.Show();
        }
        User activeUser;
        public AES aes;
        private void BookingPage_Load(object sender, EventArgs e)
        {
            if (this.Owner.GetType() == typeof(DashboardPage))
            {
                DashboardPage p = (DashboardPage)this.Owner;
                this.aes = p.aes;
                activeUser = p.activeUser;
            }
            else if (this.Owner.GetType() == typeof(FlightPage))
            {
                FlightPage p = (FlightPage)this.Owner;
                this.aes = p.aes;
                activeUser = p.activeUser;
            }
            else
            {
                ReservationPage p = (ReservationPage)this.Owner;
                this.aes = p.aes;
                activeUser = p.activeUser;
            }

            reservations = activeUser.RetrieveReservation(aes);
            if (reservations == null) return;
            foreach (Reservation r in reservations)
            {
                CreateBooking(r);
            }          
        }

        public void CreateBooking(Reservation reservation)
        {
            Panel pnlBooking = new Panel();
            Label lblDes = new Label();
            Label lblOri = new Label();
            Label lblArrival = new Label();
            Label lblDepart = new Label();
            Label lblDepartDate = new Label();
            Label lblClass = new Label();
            Label lblFlightNum = new Label();
            Label lblAirline = new Label();
            CustomBtn btnEticket = new CustomBtn();
            Label lblBookingNum = new Label();
            Label label2 = new Label();
            Label label8 = new Label();
            pnlBooking.SuspendLayout();
            SuspendLayout();

            // 
            // pnlBooking
            // 
            pnlBooking.BackColor = System.Drawing.Color.WhiteSmoke;
            pnlBooking.Controls.Add(label2);
            pnlBooking.Controls.Add(lblBookingNum);
            pnlBooking.Controls.Add(btnEticket);
            pnlBooking.Controls.Add(label8);
            pnlBooking.Controls.Add(lblDes);
            pnlBooking.Controls.Add(lblOri);
            pnlBooking.Controls.Add(lblArrival);
            pnlBooking.Controls.Add(lblDepart);
            pnlBooking.Controls.Add(lblDepartDate);
            pnlBooking.Controls.Add(lblClass);
            pnlBooking.Controls.Add(lblFlightNum);
            pnlBooking.Controls.Add(lblAirline);
            pnlBooking.Dock = System.Windows.Forms.DockStyle.Top;
            pnlBooking.Location = new System.Drawing.Point(0, 55);
            pnlBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pnlBooking.Name = "pnlBooking";
            pnlBooking.Size = new System.Drawing.Size(707, 107);
            pnlBooking.TabIndex = 156;
            pnlBooking.BorderStyle = BorderStyle.FixedSingle;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(247, 45);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(16, 22);
            label2.TabIndex = 86;
            label2.Text = "-";
            // 
            // lblBookingNum
            // 
            lblBookingNum.AutoSize = false;
            lblBookingNum.TextAlign = ContentAlignment.TopRight;
            lblBookingNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblBookingNum.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            lblBookingNum.Location = new System.Drawing.Point(580, 16);
            lblBookingNum.Name = "lblBookingNum";
            lblBookingNum.Size = new System.Drawing.Size(100, 22);
            lblBookingNum.TabIndex = 85;
            lblBookingNum.Text = "#" + reservation.TicketNum;
            // 
            // btnEticket
            // 
            btnEticket.AutoSize = true;
            btnEticket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(135)))));
            btnEticket.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(135)))));
            btnEticket.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnEticket.BorderRadius = 18;
            btnEticket.BorderSize = 0;
            btnEticket.FlatAppearance.BorderSize = 0;
            btnEticket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEticket.ForeColor = System.Drawing.Color.White;
            btnEticket.Location = new System.Drawing.Point(574, 45);
            btnEticket.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnEticket.Name = "btnEticket";
            btnEticket.Size = new System.Drawing.Size(113, 32);
            btnEticket.TabIndex = 84;
            btnEticket.Text = "E-Ticket";
            btnEticket.TextColor = System.Drawing.Color.White;
            btnEticket.UseVisualStyleBackColor = false;
            btnEticket.Tag = reservation.Id;
            btnEticket.Click += new System.EventHandler(btnEticket_Click);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(19, 16);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(90, 22);
            label8.TabIndex = 83;
            label8.Text = "Departure";
            // 
            // lblDes
            // 
            lblDes.AutoSize = true;
            lblDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDes.Location = new System.Drawing.Point(280, 45);
            lblDes.Name = "lblDes";
            lblDes.Size = new System.Drawing.Size(69, 22);
            lblDes.TabIndex = 82;
            lblDes.Text = reservation.ToCity.Name;
            // 
            // lblOri
            // 
            lblOri.AutoSize = true;
            lblOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblOri.Location = new System.Drawing.Point(173, 45);
            lblOri.Name = "lblOri";
            lblOri.Size = new System.Drawing.Size(87, 22);
            lblOri.TabIndex = 81;
            lblOri.Text = reservation.FromCity.Name;
            // 
            // lblArrival
            // 
            lblArrival.AutoSize = true;
            lblArrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblArrival.Location = new System.Drawing.Point(279, 59);
            lblArrival.Name = "lblArrival";
            lblArrival.Size = new System.Drawing.Size(71, 25);
            lblArrival.TabIndex = 79;
            lblArrival.Text = reservation.DateArrival.ToString("HH:mm");
            // 
            // lblDepart
            // 
            lblDepart.AutoSize = true;
            lblDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDepart.Location = new System.Drawing.Point(173, 60);
            lblDepart.Name = "lblDepart";
            lblDepart.Size = new System.Drawing.Size(71, 25);
            lblDepart.TabIndex = 78;
            lblDepart.Text = reservation.DateDepart.ToString("HH:mm");
            // 
            // lblDepartDate
            // 
            lblDepartDate.AutoSize = true;
            lblDepartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDepartDate.Location = new System.Drawing.Point(79, 16);
            lblDepartDate.Name = "lblDepartDate";
            lblDepartDate.Size = new System.Drawing.Size(176, 22);
            lblDepartDate.TabIndex = 77;
            lblDepartDate.Text = reservation.DateDepart.ToString("dddd, dd MMMM yyyy");
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblClass.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            lblClass.Location = new System.Drawing.Point(19, 77);
            lblClass.Name = "lblClass";
            lblClass.Size = new System.Drawing.Size(84, 22);
            lblClass.TabIndex = 76;
            lblClass.Text = reservation.FlightClass.Name;
            // 
            // lblFlightNum
            // 
            lblFlightNum.AutoSize = true;
            //////lblFlightNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblFlightNum.Location = new System.Drawing.Point(19, 60);
            lblFlightNum.Name = "lblFlightNum";
            lblFlightNum.Size = new System.Drawing.Size(79, 25);
            lblFlightNum.TabIndex = 75;
            lblFlightNum.Text = reservation.FlightChosen.FlightNumber;
            // 
            // lblAirline
            // 
            lblAirline.AutoSize = true;
            lblAirline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAirline.Location = new System.Drawing.Point(18, 40);
            lblAirline.Name = "lblAirline";
            lblAirline.Size = new System.Drawing.Size(92, 29);
            lblAirline.TabIndex = 74;
            lblAirline.Text = reservation.FlightChosen.Airline;
            
            pnlBooking.ResumeLayout(false);
            pnlBooking.PerformLayout();
            ResumeLayout(false);

            pnlBookings.Controls.Add(pnlBooking);
            pnlBookings.Controls.SetChildIndex(pnlBooking, 0);
        }

    }
}
