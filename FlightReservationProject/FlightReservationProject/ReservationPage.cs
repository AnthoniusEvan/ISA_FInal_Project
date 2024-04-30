using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationProject
{
    public partial class ReservationPage : Form
    {
        PlaneFlight flight;
        Reservation order;
        private Timer messageTimer;
        public ReservationPage(PlaneFlight flight, Reservation order)
        {
            this.order = order;
            this.flight = flight;
            InitializeComponent();

            messageTimer = new Timer();
            messageTimer.Interval = 3000;
            messageTimer.Tick += MessageTimer_Tick;
        }

        private void ReservationPage_Load(object sender, EventArgs e)
        {
            lblAirline.Text = flight.Airline;
            lblFlightCode.Text = flight.FlightNumber;
            lblClass.Text = order.FlightClass.Name;
            lblFrom.Text = flight.FromCity.Name;
            lblTo.Text = flight.ToCity.Name;
            lblTimeDepart.Text = flight.Depart.ToString("HH:mm");
            lblTimeArrival.Text = flight.Arrival.ToString("HH:mm");
            lblDate.Text = flight.Depart.ToString("dddd, dd MMMM yyyy");
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            UnselectControl();
            btnTransfer.BackColor = Color.LightGray;
            btnTransfer.TextColor = Color.Black;
            label29.Text = "1. Choose Other transaction go to";
        }

        private void btnOnlineBank_Click(object sender, EventArgs e)
        {
            UnselectControl();
            btnOnlineBank.BackColor = Color.LightGray;
            btnOnlineBank.TextColor = Color.Black;
            label29.Text = "1. Choose m-Transfer go to";
            lblAccNum.Text = "122209876";
        }
        private void UnselectControl()
        {
            btnOnlineBank.BackColor = Color.White;
            btnTransfer.BackColor = Color.White;
            btnOnlineBank.TextColor = Color.DimGray;
            btnTransfer.TextColor = Color.DimGray;
        }

        private void CopyIcon_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblAccNum.Text);
            lblMessage.Text = "Text has been copied!";
            messageTimer.Start();
        }
        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            messageTimer.Stop();
            lblMessage.Text = "";
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            pnlInformation.Visible = false;
            pnlDetail.Visible = true;
        }

        private void lblBackToInfo_Click(object sender, EventArgs e)
        {
            pnlInformation.Visible = true;
            pnlDetail.Visible = false;
        }
    }
}
