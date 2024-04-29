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
        public ReservationPage(PlaneFlight flight, Reservation order)
        {
            this.order = order;
            this.flight = flight;
            InitializeComponent();
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
    }
}
