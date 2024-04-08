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
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void lblBackToLogin_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPass.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConfirmPass.PasswordChar = '•';
            }

        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Country selectedCountry = (Country)cbCountry.SelectedItem;
            lblPhoneCode.Text = "+" + selectedCountry.DialingCode;
            txtMobileNumber.Left = lblPhoneCode.Right + 5;
            txtMobileNumber.Width = cbCity.Right - txtMobileNumber.Left;

            cbCity.Enabled = true;
            cbCity.DataSource = City.GetCities(selectedCountry);
            cbCity.DisplayMember = "Name";
            cbCity.ValueMember = "Id";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            try
            {
                if (txtPassword.Text != txtConfirmPass.Text)        throw new ArgumentException("Password and confirm password does not match!");
                if (txtPassword.Text == "" || txtConfirmPass.Text == "") throw new ArgumentException("Please fill in your password!");

                newUser.Email = txtEmail.Text;
                newUser.Password = txtPassword.Text;

                pnlPage2.BringToFront();
            }
            catch(Exception ex)
            {
                // temporarily using msgbox but pls change it to be more visually aesthetic
                // better if shown with label imo
                MessageBox.Show(ex.Message);
            }
            
        }

        private void lblBackTo1_Click(object sender, EventArgs e)
        {
            pnlPage1.BringToFront();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            pnlPage3.BringToFront();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            pnlPage2.BringToFront();
        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {
            cbCountry.DataSource = Country.GetCountries();
            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "Id";

            cbCountry.SelectedIndex = 103;
        }

        private void RegisterPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Dispose();
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void btnContinue2_Click(object sender, EventArgs e)
        {
            User newUser = new User(txtFullName.Text, txtEmail.Text, txtPassword.Text, txtAddress.Text, dtpDob.Value, txtMobileNumber.Text, (City)cbCity.SelectedItem);
            int rowsAffected = User.Add(newUser);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Succesfully created your new account!");
            }
            else
            {
                MessageBox.Show("Unknown error occured!");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtMobileNumber_KeyPress(sender, e);
        }
    }
}
