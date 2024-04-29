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
    public partial class FlightPage : Form
    {
        public Reservation order;
        List<PlaneFlight> planeFlights;
        public FlightPage(Reservation order)
        {
            this.order = order;
            InitializeComponent();
        }

        private void FlightPage_Load(object sender, EventArgs e)
        {
            order.FromCity.Name = order.FromCity.Name.Split(',')[0];
            order.ToCity.Name = order.ToCity.Name.Split(',')[0];
            lblOri.Text = order.FromCity.Name;
            lblDes.Text = order.ToCity.Name;
            lblDate.Text = order.DateDepart.ToString("dd MMMM yyyy");
            int total = order.getTotalPassengers();
            lblPassengers.Text =  total + " Passenger";
            if (total > 1) lblPassengers.Text += "s";
            lblClass.Text = order.FlightClass.Name;
            planeFlights = new List<PlaneFlight>();

            GenerateRandomFlights(order);
        }
        private void GenerateRandomFlights(Reservation order)
        {
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(3,15); i++)
            {
                List<string> airlines = new List<string>() { "Garuda", "Lion Air", "Wings Air", "Citilink", "Batik Air", "Scoot" };
                string airline = airlines[rnd.Next(6)];
                string flightNumber = airline.Substring(0, 2).ToUpper()+PlaneFlight.GetFlightNumber(airline.Substring(0, 2)).ToString("D4");
                DateTime depart = new DateTime(order.DateDepart.Year, order.DateDepart.Month, order.DateDepart.Day, rnd.Next(24), rnd.Next(0,12)*5, 0);
                int duration = rnd.Next(2, 10) * 30;
                DateTime arrival = depart.AddMinutes(duration);
                int multiplier = 1;
                string flightClass = order.FlightClass.Name;
                if (flightClass == "Premium Economy") multiplier = 2;
                else if (flightClass == "Business") multiplier = 3;
                else if (flightClass == "First Class") multiplier = 4;
                int price = rnd.Next(200000,600000) * multiplier;
                PlaneFlight p = new PlaneFlight(flightNumber, order.FromCity, order.ToCity, depart, arrival, airline, price);
                planeFlights.Add(p);
                CreateFlights(p, i);
            }
        }
        private void CreateFlights(PlaneFlight flight, int order)
        {
            Panel pnlFlight = new Panel();
            CustomBtn btnOrder = new CustomBtn();
            Label lblFlightNum = new Label();
            Label lblPrice = new Label();
            Label lblAirline = new Label();
            Label lblDateStart = new Label();
            Label lblDateEnd = new Label();
            Label lblArrival = new Label();
            Label lblTo = new Label();
            Label lblDepart = new Label();
            Label lblFrom = new Label();
            CustomBtn bigBorder = new CustomBtn();
            CustomBtn smallBorder = new CustomBtn();
            pnlFlight.SuspendLayout();
            // 
            // smallBorder
            // 
            smallBorder.BackColor = System.Drawing.Color.White;
            smallBorder.BackgroundColor = System.Drawing.Color.White;
            smallBorder.BorderColor = System.Drawing.Color.PaleVioletRed;
            smallBorder.BorderRadius = 20;
            smallBorder.BorderSize = 0;
            smallBorder.Enabled = false;
            smallBorder.FlatAppearance.BorderSize = 0;
            smallBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            smallBorder.ForeColor = System.Drawing.Color.WhiteSmoke;
            smallBorder.Location = new System.Drawing.Point(372, 10);
            smallBorder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            smallBorder.Name = "smallBorder";
            smallBorder.Size = new System.Drawing.Size(277, 82);
            smallBorder.TextColor = System.Drawing.Color.WhiteSmoke;
            smallBorder.UseVisualStyleBackColor = false;
            // 
            // btnOrder
            // 
            btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            btnOrder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            btnOrder.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnOrder.BorderRadius = 18;
            btnOrder.BorderSize = 0;
            btnOrder.FlatAppearance.BorderSize = 0;
            btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            btnOrder.ForeColor = System.Drawing.Color.White;
            btnOrder.Location = new System.Drawing.Point(520, 29);
            btnOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new System.Drawing.Size(132, 51);
            btnOrder.TabIndex = 70;
            btnOrder.Text = "Order";
            btnOrder.TextColor = System.Drawing.Color.White;
            btnOrder.UseVisualStyleBackColor = false;
            btnOrder.Click += new System.EventHandler(btnOrder_Click);
            btnOrder.Tag = order;
            //
            // pnlFlight
            // 
            pnlFlight.Controls.Add(btnOrder);
            pnlFlight.Controls.Add(lblFlightNum);
            pnlFlight.Controls.Add(lblPrice);
            pnlFlight.Controls.Add(lblAirline);
            pnlFlight.Controls.Add(lblDateStart);
            pnlFlight.Controls.Add(lblDateEnd);
            pnlFlight.Controls.Add(lblArrival);
            pnlFlight.Controls.Add(lblTo);
            pnlFlight.Controls.Add(lblDepart);
            pnlFlight.Controls.Add(lblFrom);
            pnlFlight.Controls.Add(smallBorder);
            pnlFlight.Controls.Add(bigBorder);
            pnlFlight.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFlight.Location = new System.Drawing.Point(0, 175);
            pnlFlight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pnlFlight.Name = "pnlFlight";
            pnlFlight.Size = new System.Drawing.Size(738, 105);
            // 
            // lblFlightNum
            // 
            lblFlightNum.BackColor = System.Drawing.Color.White;
            lblFlightNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblFlightNum.Location = new System.Drawing.Point(396, 46);
            lblFlightNum.Name = "lblFlightNum";
            lblFlightNum.Size = new System.Drawing.Size(99, 19);
            lblFlightNum.Text = flight.FlightNumber;
            // 
            // lblPrice
            // 
            lblPrice.BackColor = System.Drawing.Color.White;
            lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            lblPrice.Location = new System.Drawing.Point(396, 65);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(142, 29);
            lblPrice.Text = "IDR "+ flight.Price.ToString("C2"); 
            // 
            // lblAirline
            // 
            lblAirline.BackColor = System.Drawing.Color.White;
            lblAirline.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            lblAirline.Location = new System.Drawing.Point(392, 19);
            lblAirline.Name = "lblAirline";
            lblAirline.Size = new System.Drawing.Size(148, 44);
            lblAirline.Text = flight.Airline;
            // 
            // lblDateStart
            // 
            lblDateStart.BackColor = System.Drawing.Color.White;
            lblDateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblDateStart.Location = new System.Drawing.Point(59, 65);
            lblDateStart.Name = "lblDateStart";
            lblDateStart.Size = new System.Drawing.Size(137, 19);
            lblDateStart.Text = flight.Depart.ToString("ddd, dd MMMM yyyy");
            // 
            // lblDateEnd
            // 
            lblDateEnd.BackColor = System.Drawing.Color.White;
            lblDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblDateEnd.Location = new System.Drawing.Point(247, 65);
            lblDateEnd.Name = "lblDateEnd";
            lblDateEnd.Size = new System.Drawing.Size(205, 29);
            lblDateEnd.Text = flight.Arrival.ToString("ddd, dd MMMM yyyy");
            // 
            // lblArrival
            // 
            lblArrival.BackColor = System.Drawing.Color.White;
            lblArrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            lblArrival.Location = new System.Drawing.Point(247, 42);
            lblArrival.Name = "lblArrival";
            lblArrival.Size = new System.Drawing.Size(143, 36);
            lblArrival.Text = flight.Arrival.ToString("HH.mm")+" WIB";
            // 
            // lblTo
            // 
            lblTo.BackColor = System.Drawing.Color.White;
            lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblTo.Location = new System.Drawing.Point(247, 23);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size(84, 48);
            lblTo.Text = flight.ToCity.Name.Substring(0,3).ToUpper();
            // 
            // lblDepart
            // 
            lblDepart.BackColor = System.Drawing.Color.White;
            lblDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            lblDepart.Location = new System.Drawing.Point(58,42);
            lblDepart.Name = "lblDepart";
            lblDepart.Size = new System.Drawing.Size(142, 40);
            lblDepart.Text = flight.Depart.ToString("HH.mm") + " WIB";
            // 
            // lblFrom
            // 
            lblFrom.BackColor = System.Drawing.Color.White;
            lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            lblFrom.Location = new System.Drawing.Point(59, 23);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size(84, 51);
            lblFrom.Text = flight.FromCity.Name.Substring(0, 3).ToUpper();
            // 
            // bigBorder
            // 
            bigBorder.BackColor = System.Drawing.Color.White;
            bigBorder.BackgroundColor = System.Drawing.Color.White;
            bigBorder.BorderColor = System.Drawing.Color.PaleVioletRed;
            bigBorder.BorderRadius = 20;
            bigBorder.BorderSize = 0;
            bigBorder.Enabled = false;
            bigBorder.FlatAppearance.BorderSize = 0;
            bigBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bigBorder.ForeColor = System.Drawing.Color.White;
            bigBorder.Location = new System.Drawing.Point(35, 3);
            bigBorder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            bigBorder.Name = "bigBorder";
            bigBorder.Size = new System.Drawing.Size(630, 98);
            bigBorder.TextColor = System.Drawing.Color.White;
            bigBorder.UseVisualStyleBackColor = false;
            
            
            pnlFlight.ResumeLayout(false);
            pnlFlights.Controls.Add(pnlFlight);
            pnlFlights.Controls.SetChildIndex(pnlFlight, 0);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            ReservationPage p = new ReservationPage(planeFlights[int.Parse(b.Tag.ToString())], order);
            p.Owner = this;
            p.Show();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            BookingPage p = new BookingPage();
            p.Owner = this;
            p.Show();
        }

        private void pbSwap_Click(object sender, EventArgs e)
        {
            City from = order.FromCity;
            order.FromCity = order.ToCity;
            order.ToCity = from;

            string des = lblDes.Text;
            lblDes.Text = lblOri.Text;
            lblOri.Text = des;

            pnlFlights.Controls.Clear();
            GenerateRandomFlights(order);
        }
    }
}
