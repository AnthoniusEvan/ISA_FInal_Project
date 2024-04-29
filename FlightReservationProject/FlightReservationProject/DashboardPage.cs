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
        public User activeUser;
        private void DashboardPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Dispose();
        }

        private void DashboardPage_Load(object sender, EventArgs e)
        {
            LoginPage parent = (LoginPage)this.Owner;

            cbCityOri.DataSource = City.GetOrigins(parent.user.FromCity.FromCountry);
            cbCityOri.DisplayMember = "Name";
            cbCityOri.ValueMember = "Id";
            RefreshActiveUser(parent.user);

            cbCityDes.DataSource = City.GetDestinations();
            cbCityDes.DisplayMember = "Name";
            cbCityDes.ValueMember = "Id";
            cbCityDes.SelectedIndex = 0;
            cbCityDes.SelectedValue = ((City)cbCityDes.SelectedItem).Id;

            cbClass.DataSource = FlightClass.GetClasses();
            cbClass.DisplayMember = "Name";
            cbClass.ValueMember = "Id";
            cbClass.SelectedIndex = 0;

        }
        public void RefreshActiveUser(User user)
        {
            activeUser = user;
            foreach (City c in cbCityOri.Items)
            {
                if (c.Id == activeUser.FromCity.Id)
                    cbCityOri.SelectedValue = c.Id;
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

        private void CheckInOnlinetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CheckInPage p = new CheckInPage();
            p.Owner = this;
            p.Show();
        }

        private void bookinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingPage p = new BookingPage();
            p.Owner = this;
            p.Show();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            int desVal = (int)cbCityDes.SelectedValue;
            cbCityDes.SelectedValue = cbCityOri.SelectedValue;
            cbCityOri.SelectedValue = desVal;
        }

        private void txtPassengers_Click(object sender, EventArgs e)
        {
            if (!pnlPassengerSelection.Visible)
            {
                pnlPassengerSelection.Left = txtPassengers.Left;
                pnlPassengerSelection.Top = txtPassengers.Top;
                pnlPassengerSelection.Visible = true;
            }
            else
            {
                pnlPassengerSelection.Visible = false;
                ConfirmPassengers();
            }
        }

        private void btnAdultMin_Click(object sender, EventArgs e)
        {
            int adult = int.Parse(txtAdult.Text);
            if (adult > 1)
            {
                txtAdult.Text = (adult - 1).ToString();
            }
        }

        private void btnAdultPlus_Click(object sender, EventArgs e)
        {
            int adult = int.Parse(txtAdult.Text);
            int child = int.Parse(txtChild.Text);
            if (adult < 7 && adult+child<7)
            {
                txtAdult.Text = (adult + 1).ToString();
            }
        }

        private void btnChildMin_Click(object sender, EventArgs e)
        {
            int child = int.Parse(txtChild.Text);
            if (child > 0)
            {
                txtChild.Text = (child - 1).ToString();
            }
        }

        private void btnChildPlus_Click(object sender, EventArgs e)
        {
            int child = int.Parse(txtChild.Text);
            int adult = int.Parse(txtAdult.Text);
            if (child+adult < 7)
            {
                txtChild.Text = (child + 1).ToString();
            }
        }

        private void btnBabyMin_Click(object sender, EventArgs e)
        {
            int baby = int.Parse(txtBaby.Text);
            if (baby > 0)
            {
                txtBaby.Text = (baby - 1).ToString();
            }
        }

        private void btnBabyPlus_Click(object sender, EventArgs e)
        {
            int baby = int.Parse(txtBaby.Text);
            int adult = int.Parse(txtAdult.Text);
            if (adult>baby)
            {
                txtBaby.Text = (baby + 1).ToString();
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            ConfirmPassengers();
            pnlPassengerSelection.Visible = false;
        }

        private void ConfirmPassengers()
        {
            int adult = int.Parse(txtAdult.Text);
            int child = int.Parse(txtChild.Text);
            int baby = int.Parse(txtBaby.Text);
            string passengers = adult + " Adult";
            if (adult > 1) passengers += "s";
            if (child > 1) passengers += ", " + child + " Children";
            else passengers += ", " + child + " Child";
            if (baby > 1) passengers += ", " + baby + " Babies";
            else passengers += ", " + baby + " Baby";
            txtPassengers.Text = passengers;
        }
        string previousDes="";
        private void cbCityDes_TextUpdate(object sender, EventArgs e)
        {
            tmrSearch.Enabled=false;
            previousDes = cbCityDes.Text;
            tmrSearch.Enabled=true;
        }

        private void tmrSearch_Tick(object sender, EventArgs e)
        {
            if (previousDes == cbCityDes.Text)
            {
                label3.Text = previousDes;
            }
            tmrSearch.Enabled = false;
        }
    }
}
