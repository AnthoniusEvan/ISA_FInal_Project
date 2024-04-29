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
    public partial class ProfilePage : Form
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        User u;
        private void ProfilePage_Load(object sender, EventArgs e)
        {
            DashboardPage p = (DashboardPage)this.Owner;
            u = p.activeUser;
            txtFullname.Text = u.FullName;
            txtID.Text = u.Id;
            dtpDob.Value = u.BirthDate;
            lblCode.Text = "+" + u.FromCity.FromCountry.DialingCode;
            cbCountry.DataSource = Country.GetCountries();
            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "Id";
            foreach (Country c in cbCountry.Items)
            {
                if (c.Name == u.FromCity.FromCountry.Name)
                    cbCountry.SelectedItem = c;
            }

            cbCity.DataSource = City.GetCities(u.FromCity.FromCountry);
            cbCity.DisplayMember = "Name";
            cbCity.ValueMember = "Id";
            foreach (City c in cbCity.Items)
            {
                if (c.Name == u.FromCity.Name)
                    cbCity.SelectedItem = c;
            }

            txtAddress.Text = u.Address;
            txtMobileNumber.Text = u.MobileNumber.Split('-')[1];
            txtEmail.Text = u.Email;
            txtPassword.Text = u.Password;
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCode.Text = "+" + ((Country)cbCountry.SelectedItem).DialingCode;
            txtMobileNumber.Left = lblCode.Right + 5;
            txtMobileNumber.Width = cbCity.Right - txtMobileNumber.Left;

            cbCity.DataSource = City.GetCities((Country)cbCountry.SelectedItem);
            cbCity.DisplayMember = "Name";
            cbCity.ValueMember = "Id";
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                User updatedUser = new User(u.Id, txtFullname.Text, u.Email, txtPassword.Text, txtAddress.Text, dtpDob.Value, lblCode.Text + "-" + txtMobileNumber.Text, (City)cbCity.SelectedItem);
                int rowsAffected = User.Update(updatedUser);
                if (rowsAffected > 0)
                {
                    DashboardPage p = (DashboardPage)this.Owner;
                    p.RefreshActiveUser(updatedUser);
                    MessageBox.Show("Account details updated succesfully!");
                    lblBack_Click(sender, e);
                }
                else
                    MessageBox.Show("Unknown error occured! Couldn't update account details!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
