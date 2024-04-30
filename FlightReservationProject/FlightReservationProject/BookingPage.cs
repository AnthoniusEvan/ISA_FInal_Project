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
    public partial class BookingPage : Form
    {
        public BookingPage()
        {
            InitializeComponent();
        }

        private void btnEticket_Click(object sender, EventArgs e)
        {
            PrintETicket p = new PrintETicket();
            p.Owner = this;
            p.Show();
        }
    }
}
