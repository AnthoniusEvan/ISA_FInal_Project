﻿using System;
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
        public User activeUser;
        private void DashboardPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Dispose();
        }

        private void DashboardPage_Load(object sender, EventArgs e)
        {
            LoginPage parent = (LoginPage)this.Owner;
            activeUser = parent.user;
            cbCityOri.DataSource = City.GetCities(activeUser.FromCity.FromCountry);
            cbCityOri.DisplayMember = "Name";
            cbCityOri.ValueMember = "Id";
            foreach (City c in cbCityOri.Items)
            {
                if (c.Name == activeUser.FromCity.Name)
                    cbCityOri.SelectedItem = c;
            }

        }

        private void cbCityOri_SelectedIndexChanged(object sender, EventArgs e)
        {
            City selectedCity = (City)cbCityOri.SelectedItem;
        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            ProfilePage p = new ProfilePage();
            p.Owner = this;
            p.Show();
        }
    }
}
