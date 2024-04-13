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
    public partial class DashboardPage : Form
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private void DashboardPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Dispose();
        }

        private void DashboardPage_Load(object sender, EventArgs e)
        {

        }

        private void cbCityOri_SelectedIndexChanged(object sender, EventArgs e)
        {
            City selectedCity = (City)cbCityOri.SelectedItem;
        }
    }
}
