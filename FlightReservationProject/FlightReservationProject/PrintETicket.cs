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
    public partial class PrintETicket : Form
    {
        Reservation ticket;
        public PrintETicket(Reservation ticket)
        {
            this.ticket = ticket;
            InitializeComponent();
        }

        private void PrintETicket_Load(object sender, EventArgs e)
        {
            lblAirline.Text = ticket.FlightChosen.Airline;
            lblFlightNum.Text = ticket.FlightChosen.FlightNumber;
            lblClass.Text = ticket.FlightClass.Name;
            lblDate.Text = ticket.DateDepart.ToString("dddd, dd MMMM yyyy");
            lblDepart.Text = ticket.DateDepart.ToString("HH:mm");
            lblArriv.Text = ticket.DateArrival.ToString("HH:mm");
            lblFrom.Text = ticket.FromCity.Name;
            lblTo.Text = ticket.ToCity.Name;
            lblEticketNum.Text = "#" + ticket.TicketNum;

            List<Passenger> passengers = ticket.GetPassengers();
            string num = "";
            string title = "";
            string name = "";
            for(int i = 0; i < passengers.Count; i++)
            {
                num += i + 1 + ".\n";
                title += passengers[i].Title + "\n";
                name += passengers[i].FullName + "\n";
            }
            lblNum.Text = num;
            lblTitle.Text = title;
            lblName.Text = name;
        }
    }
}
