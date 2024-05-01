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
    public partial class ConfirmarionPage : Form
    {
        public ConfirmarionPage()
        {
            InitializeComponent();
        }
        private void btnEticket_Click(object sender, EventArgs e)
        {
            BookingPage bookingPage = new BookingPage();
            bookingPage.Owner = this.Owner;
            bookingPage.Show();

            bookingPage.Owner = null;
            this.Owner.Owner.Close();
        }

        private void backHome_Click(object sender, EventArgs e)
        {
            DashboardPage dashboardPage = this.Owner as DashboardPage;
            if (dashboardPage != null)
            {
                dashboardPage.Show();
            }
            this.Close();
        }
        private void ConfirmarionPage_Load(object sender, EventArgs e)
        {
            ReservationPage p = (ReservationPage)this.Owner;
        }
    }
}
